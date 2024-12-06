#nullable disable

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
        PropertyNameCaseInsensitive = true,
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

    public async Task<ErrorOr<IEnumerable<StatisticsItem>>> GetStatisticsAsync (RemoteServiceOptions options)
    {
        ConfigureRequest (options);
        var response = await httpClient.GetAsync($"{Consts.EnpointApiPrefix}/servers/{options.LocalId}/statistics");
        if (!response.IsSuccessStatusCode)
        {
            return Error.Failure ();
        }

        var content = await response.Content.ReadAsStringAsync ();

        return JsonSerializer.Deserialize<IEnumerable<StatisticsItem>> (content, jsonSerializerOptions)
                             .ToErrorOr ();
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
