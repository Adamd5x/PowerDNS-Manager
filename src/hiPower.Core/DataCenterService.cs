using hiPower.Abstracts;
using MapsterMapper;

namespace hiPower.Core;

public class DataCenterService(IUnitOfWork unit,
                             IMapper mapper) : IDataCenterService
{
    public async Task<ErrorOr<DataCenter>> CreateAsync (DataCenter location)
    {
        var result = await unit.LocationRepository.CreateAsync(location.Adapt<ServerLocation>());
        await unit.SaveAsync ();
        return mapper.Map<DataCenter> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        await unit.LocationRepository.DeleteAsync(id);
        return true;
    }

    public async Task<ErrorOr<DataCenter>> GetAsync (string id)
    {
        var result = await unit.LocationRepository.GetAsync(x => x.Id.Equals(id.ToUpperInvariant()), null);
        return result.Adapt<DataCenter> ();
    }

    public async Task<ErrorOr<IEnumerable<DataCenter>>> GetAsync ()
    {
        var result = await unit.LocationRepository.GetAll(null, null,null);
        return result.Adapt<IEnumerable<DataCenter>> ().ToErrorOr ();
    }

    public Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetServers (string id)
    {
        throw new NotImplementedException ();
    }

    public async Task<ErrorOr<DataCenter>> UpdateAsync (string id, DataCenter dataCenter)
    {
        if (!id.Equals(dataCenter.Id, StringComparison.OrdinalIgnoreCase))
        {
            return Error.NotFound (dataCenter.Id);
        }
        var result = unit.LocationRepository
                         .Update(dataCenter.Adapt<ServerLocation>())
                         .ToErrorOr();

        return await Task.FromResult(result.Adapt<DataCenter> ());
    }
}
