using hiPower.Abstracts;
using hiPower.Common.Type.Options;

namespace hiPower.Core;

public class ZoneService(IRemoteZoneService remoteZoneService,
                         IServerService serverService) : IZoneService
{
    public Task<ErrorOr<bool>> CreateMasterAsync ()
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<bool>> CreateSlaveAsync ()
    {
        throw new NotImplementedException ();
    }

    public async Task<ErrorOr<object?>> GetDetailsAsync (string serviceId, string zoneId)
    {
        var service = await serverService.GetAsync (serviceId);
        var options = service.Value.Adapt<RemoteServiceOptions> ();
        var result = await remoteZoneService.GetDetailsAsync(options, zoneId);

        if (result.IsError)
        {
            return result.Errors;
        }
        return result;
    }

    public async Task<ErrorOr<object>> GetListAsync (string serviceId)
    {
        var service = await serverService.GetAsync (serviceId);
        var options = service.Value.Adapt<RemoteServiceOptions> ();
        var result = await remoteZoneService.GetZonesListAsync (options);


        if (result.IsError)
        {
            return result.Errors;
        }
        return result;
    }

    public Task<ErrorOr<object>> UpdateDetailsAsync ()
    {
        throw new NotImplementedException ();
    }
}
