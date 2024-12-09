using hiPower.Abstracts;
using hiPower.Common.Type.Errors;
using MapsterMapper;

namespace hiPower.Core;

public class DataCenterService(IUnitOfWork unit,
                               IMapper mapper) : IDataCenterService
{
    public async Task<ErrorOr<Dto.Manager.DataCenter>> CreateAsync (Dto.Manager.DataCenter dataCenter)
    {
        var result = await unit.DataCenterRepository.CreateAsync(dataCenter.Adapt<Entity.DataCenter>());
        await unit.SaveAsync ();
        return mapper.Map<Dto.Manager.DataCenter> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        var servers = await unit.ServerRepository.GetAll(x => x.DataCenterId.Equals(id.ToUpper()), null, null);
        if (servers.Any())
        {
            return DataCenterErrors.DeleteError;
        }
        await unit.DataCenterRepository.DeleteAsync(id);
        await unit.SaveAsync ();
        return true;
    }

    public async Task<ErrorOr<Dto.Manager.DataCenter>> GetAsync (string id)
    {
        var result = await unit.DataCenterRepository.GetAsync(x => x.Id.Equals(id.ToUpperInvariant()), null);
        if (result is null)
        {
            return Error.NotFound();
        }
        return result.Adapt<Dto.Manager.DataCenter> ();
    }

    public async Task<ErrorOr<IEnumerable<Dto.Manager.DataCenter>>> GetAsync ()
    {
        var result = await unit.DataCenterRepository.GetAll(null, null,null);
        return result.Adapt<IEnumerable<Dto.Manager.DataCenter>> ().ToErrorOr ();
    }

    public async Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetServers (string id)
    {
        var result = await unit.ServerRepository.GetAll(x => x.DataCenterId.Equals(id.ToUpper()), null, null);
        return result.Adapt<IEnumerable<Dto.Manager.Server>> ()
                     .ToErrorOr();
    }

    public async Task<ErrorOr<Dto.Manager.DataCenter>> UpdateAsync (string id, Dto.Manager.DataCenter dataCenter)
    {
        if (!id.Equals(dataCenter.Id, StringComparison.OrdinalIgnoreCase))
        {
            return Error.NotFound (dataCenter.Id);
        }
        var result = unit.DataCenterRepository
                         .Update(dataCenter.Adapt<Entity.DataCenter>())
                         .ToErrorOr();
        await unit.SaveAsync ();
        return await Task.FromResult(result.Adapt<Dto.Manager.DataCenter> ());
    }
}
