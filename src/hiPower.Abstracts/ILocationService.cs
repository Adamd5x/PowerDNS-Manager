namespace hiPower.Abstracts;

public interface ILocationService
{
    Task<ErrorOr<Location>> CreateAsync(Location location);
    Task<ErrorOr<Location>> UpdateAsync(string id, Location location);
    Task<ErrorOr<bool>> DeleteAsync (string id);
    Task<ErrorOr<Location>> GetAsync (string id);
    Task<ErrorOr<IEnumerable<Location>>> GetAsync ();
    Task<ErrorOr<IEnumerable<Server>>> GetServers(string id);
}
