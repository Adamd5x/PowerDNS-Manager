namespace hiPower.Abstracts;

public interface IZoneService
{
    Task<ErrorOr<object>> GetListAsync (string serviceId);
    Task<ErrorOr<object>> GetDetailsAsync(string zoneId);
    Task<ErrorOr<object>> UpdateDetailsAsync ();
    Task<ErrorOr<bool>> CreateMasterAsync();
    Task<ErrorOr<bool>> CreateSlaveAsync();
}
