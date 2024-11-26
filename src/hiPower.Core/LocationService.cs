using hiPower.Abstracts;

namespace hiPower.Core;

public class LocationService(IUnitOfWork unit) : ILocationService
{
    public Task<ErrorOr<Location>> CreateAsync (Location location)
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<Location>> GetAsync (string id)
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<IEnumerable<Location>>> GetAsync ()
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetServers (string id)
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<Location>> UpdateAsync (string id, Location location)
    {
        throw new NotImplementedException ();
    }
}
