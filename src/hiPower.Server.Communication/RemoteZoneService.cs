using System.Net;
using System.Net.Http.Json;
using ErrorOr;
using hiPower.Abstracts;
using hiPower.Common.Type.Options;

namespace hiPower.Server.Communication;

public class RemoteZoneService (IHttpClientFactory clientFactory) : RemoteServiceBase (clientFactory), IRemoteZoneService
{
    public async Task<ErrorOr<object?>> GetDetailsAsync (RemoteServiceOptions options, string zoneId)
    {
        ConfigureRequest (options);
        try
        {
            var response = await httpClient.GetFromJsonAsync<object>($"{Consts.EnpointApiPrefix}/servers/{options.LocalId}/zones/{zoneId}");
            return response;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return Error.NotFound (description: $"not found: {zoneId}");
        }
        catch (Exception ex) 
        {
            return Error.Failure (description: ex.Message);
        }
    }

    public async Task<ErrorOr<object?>> GetZonesListAsync (RemoteServiceOptions options)
    {
        ConfigureRequest (options);
        var response = await httpClient.GetFromJsonAsync<object>($"{Consts.EnpointApiPrefix}/servers/{options.LocalId}/zones");
        return response;
    }
}
