using hiPower.Abstracts;
using MapsterMapper;

namespace hiPower.Core;

public class LocationService(IUnitOfWork unit,
                             IMapper mapper) : ILocationService
{
    public async Task<ErrorOr<Location>> CreateAsync (Location location)
    {
        var result = await unit.LocationRepository.CreateAsync(location.Adapt<ServerLocation>());
        await unit.SaveAsync ();
        return mapper.Map<Location> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        await unit.LocationRepository.DeleteAsync(id);
        return true;
    }

    public async Task<ErrorOr<Location>> GetAsync (string id)
    {
        var result = await unit.LocationRepository.GetAsync(x => x.Id.Equals(id.ToUpperInvariant()), null);
        return result.Adapt<Location> ();
    }

    public async Task<ErrorOr<IEnumerable<Location>>> GetAsync ()
    {
        var result = await unit.LocationRepository.GetAll(null, null,null);
        return result.Adapt<IEnumerable<Location>> ().ToErrorOr ();
    }

    public Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetServers (string id)
    {
        throw new NotImplementedException ();
    }

    public async Task<ErrorOr<Location>> UpdateAsync (string id, Location location)
    {
        if (!id.Equals(location.Id, StringComparison.OrdinalIgnoreCase))
        {
            return Error.NotFound (location.Id);
        }
        var result = unit.LocationRepository
                         .Update(location.Adapt<ServerLocation>())
                         .ToErrorOr();

        return await Task.FromResult(result.Adapt<Location> ());
    }
}
