using ErrorOr;
using hiPower.Abstracts;
using hiPower.Dto.Manager;

namespace hiPower.Core;

public class LocationService(IUnitOfWork unit) : ILocationService
{
    public Task<ErrorOr<Location>> CreateAsync (Location location)
    {
        throw new NotImplementedException ();
    }

    public Task<ErrorOr<Location>> DeleteAsync (string id)
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

    public Task<ErrorOr<Location>> UpdateAsync (Location location)
    {
        throw new NotImplementedException ();
    }
}
