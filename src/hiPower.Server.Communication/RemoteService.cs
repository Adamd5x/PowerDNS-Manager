#nullable disable

using System.Net.Http.Json;
using System.Text.Json;
using ErrorOr;
using hiPower.Abstracts;
using hiPower.Common.Type.Options;
using hiPower.Dto.Remote;

namespace hiPower.Server.Communication;

public class RemoteService (IHttpClientFactory clientFactory) : IRemoteService
{
    private readonly HttpClient httpClient = clientFactory.CreateClient(Consts.HttpClientName);
    private readonly ApiAddressConfiguration addressBuilder = new();
    private readonly JsonSerializerOptions jsonSerializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<ErrorOr<IEnumerable<ConfigSetting>>> GetConfigurationAsync (RemoteServiceOptions options)
    {
        ConfigureRequest (options);
        var response = await httpClient.GetAsync ($"{Consts.EnpointApiPrefix}/servers/{options.LocalId}/config");

        if (!response.IsSuccessStatusCode)
        {
            return Error.Failure ();
        }

        var content = await response.Content.ReadAsStringAsync ();

        return JsonSerializer.Deserialize<IEnumerable<ConfigSetting>> (content, jsonSerializerOptions)
                             .ToErrorOr();
    }

    public async Task<ErrorOr<ServerInfo>> GetInfoAsync (RemoteServiceOptions options)
    {
        ConfigureRequest (options);
        var response = await httpClient.GetAsync ($"{Consts.EnpointApiPrefix}/servers/{options.LocalId}");

        if (!response.IsSuccessStatusCode)
        {
            return Error.Failure ();
        }

        var content = await response.Content.ReadAsStringAsync ();

        return JsonSerializer.Deserialize<ServerInfo> (content, jsonSerializerOptions)
                             .ToErrorOr ();
    }

    public async Task<ErrorOr<IEnumerable<StatisticsItem>>> GetStatisticsAsync (RemoteServiceOptions options, IEnumerable<string> statItemsList)
    {
        ConfigureRequest (options);
        string endpointUrl = $"{Consts.EnpointApiPrefix}/servers/{options.LocalId}/statistics";
        var statistics = new List<StatisticsItem> ();
        try
        {
            await foreach(var item in httpClient.GetFromJsonAsAsyncEnumerable<StatisticsItem> (endpointUrl, jsonSerializerOptions, default))
            {
                if (statItemsList.Any() && statItemsList.Contains (item.Name, StringComparer.OrdinalIgnoreCase) && item?.Type == "StatisticItem")
                {
                    statistics.Add (item);
                    bool isListFilledout = statistics.Count == statItemsList.Count();
                    if (isListFilledout)
                    {
                        break;
                    }
                    continue;
                }

                if (!statItemsList.Any ())
                {
                    statistics.Add (item);
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }

        return statistics;
    }

    private void ConfigureRequest(RemoteServiceOptions options)
    {
        var baseAddress = addressBuilder.SetProtocol(options.Proto)
                                        .SetHost(options.HostAddress)
                                        .SetPort(options.Port)
                                        .Build();
        httpClient.BaseAddress = new Uri(baseAddress);
        httpClient.DefaultRequestHeaders.Add(Consts.ApiKeyHeaderName, options.ApiKey);
    }
}
