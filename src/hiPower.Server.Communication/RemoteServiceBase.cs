using System.Text.Json;
using hiPower.Common.Type.Options;

namespace hiPower.Server.Communication;

public abstract class RemoteServiceBase(IHttpClientFactory clientFactory)
{
    protected readonly HttpClient httpClient = clientFactory.CreateClient(Consts.HttpClientName);
    protected readonly ApiAddressConfiguration addressBuilder = new();
    protected readonly JsonSerializerOptions jsonSerializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true
    };

    protected virtual void ConfigureRequest (RemoteServiceOptions options)
    {
        var baseAddress = addressBuilder.SetProtocol(options.Proto)
                                        .SetHost(options.HostAddress)
                                        .SetPort(options.Port)
                                        .Build();
        httpClient.BaseAddress = new Uri (baseAddress);
        httpClient.DefaultRequestHeaders.Add (Consts.ApiKeyHeaderName, options.ApiKey);
    }
}
