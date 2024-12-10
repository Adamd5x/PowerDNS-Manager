namespace hiPower.Abstracts;

public interface IRemoteZoneService
{
    Task<ErrorOr<object?>> GetZonesListAsync (RemoteServiceOptions options);
    Task<ErrorOr<object?>> GetDetailsAsync(RemoteServiceOptions options,string zoneId);
}
