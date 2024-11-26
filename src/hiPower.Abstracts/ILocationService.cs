namespace hiPower.Abstracts;

public interface ILocationService
{
    Task<ErrorOr<Location>> CreateAsync(Location location);

    Task<ErrorOr<Location>> UpdateAsync(Location location);

    Task<ErrorOr<Location>> DeleteAsync (string id);

    Task<ErrorOr<Location>> GetAsync (string id);
    Task<ErrorOr<IEnumerable<Location>>> GetAsync ();
}
