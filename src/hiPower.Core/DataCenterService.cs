using hiPower.Abstracts;
using hiPower.Common.Type.Errors;
using MapsterMapper;

namespace hiPower.Core;

public class DataCenterService(IUnitOfWork unit,
                               IMapper mapper) : IDataCenterService
{
    public async Task<ErrorOr<DataCenter>> CreateAsync (DataCenter location)
    {
        var result = await unit.DataCenterRepository.CreateAsync(location.Adapt<ServerLocation>());
        await unit.SaveAsync ();
        return mapper.Map<DataCenter> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        var servers = await unit.ServerRepository.GetAll(x => x.LocationId.Equals(id.ToUpper()), null, null);
        if (servers.Any())
        {
            return DataCenterErrors.DeleteError;
        }
        await unit.DataCenterRepository.DeleteAsync(id);
        await unit.SaveAsync ();
        return true;
    }

    public async Task<ErrorOr<DataCenter>> GetAsync (string id)
    {
        var result = await unit.DataCenterRepository.GetAsync(x => x.Id.Equals(id.ToUpperInvariant()), null);
        if (result is null)
        {
            return Error.NotFound();
        }
        return result.Adapt<DataCenter> ();
    }

    public async Task<ErrorOr<IEnumerable<DataCenter>>> GetAsync ()
    {
        var result = await unit.DataCenterRepository.GetAll(null, null,null);
        return result.Adapt<IEnumerable<DataCenter>> ().ToErrorOr ();
    }

    public async Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetServers (string id)
    {
        var result = await unit.ServerRepository.GetAll(x => x.LocationId.Equals(id.ToUpper()), null, null);
        return result.Adapt<IEnumerable<Dto.Manager.Server>> ()
                     .ToErrorOr();
    }

    public async Task<ErrorOr<DataCenter>> UpdateAsync (string id, DataCenter dataCenter)
    {
        if (!id.Equals(dataCenter.Id, StringComparison.OrdinalIgnoreCase))
        {
            return Error.NotFound (dataCenter.Id);
        }
        var result = unit.DataCenterRepository
                         .Update(dataCenter.Adapt<ServerLocation>())
                         .ToErrorOr();
        await unit.SaveAsync ();
        return await Task.FromResult(result.Adapt<DataCenter> ());
    }
}
