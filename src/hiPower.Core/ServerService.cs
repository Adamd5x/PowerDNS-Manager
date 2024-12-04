using hiPower.Abstracts;
using hiPower.Common.Type.Errors;
using MapsterMapper;

namespace hiPower.Core;

public class ServerService(IUnitOfWork unit,
                           IMapper mapper) : IServerService
{
    public async Task<ErrorOr<Dto.Manager.Server>> CreateAsync (Dto.Manager.Server server)
    {
        var result = await unit.ServerRepository.CreateAsync(server.Adapt<Entity.Server>());
        await unit.SaveAsync ();
        return mapper.Map<Dto.Manager.Server> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        await unit.ServerRepository.DeleteAsync (id);
        return true;
    }

    public async Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetAllAsync (string dataCenterId)
    {
        var result = await unit.ServerRepository.GetAll(x => x.LocationId.Equals(dataCenterId.ToUpper()), null, null);
        if (result.Any ())
        {
            return result.Adapt<IEnumerable<Dto.Manager.Server>> ()
                         .ToErrorOr ();
        }
        return Error.NotFound();
    }

    public async Task<ErrorOr<IEnumerable<Dto.Manager.Server>>> GetAllAsync ()
    {
        var result = await unit.ServerRepository.GetAll(null, null, null);
        return result.Adapt<IEnumerable<Dto.Manager.Server>>()
                     .ToErrorOr();
    }

    public async Task<ErrorOr<Dto.Manager.Server>> GetAsync (string id)
    {
        var result = await unit.ServerRepository
                               .GetAsync(x => x.Id.Equals(id.ToUpper()), null);
        if (result is not null)
        {
            return mapper.Map<Dto.Manager.Server> (result);
        }
        return Error.NotFound();
    }

    public async Task<ErrorOr<IEnumerable<HintItem>>> GetAvailableDataCentersAsync ()
    {
        var result = await unit.DataCenterRepository.GetAll(null, null, null);
        if (result.Any())
        {
            return result.Adapt<IEnumerable<HintItem>> ()
                         .ToErrorOr ();
        }
        return Error.NotFound ();
    }

    public async Task<ErrorOr<Dto.Manager.Server>> UpdateAsync (string id, Dto.Manager.Server server)
    {
        if (id.ToUpper ().Equals (server.Id.ToUpper ())) 
        { 
            var updateServer = server.Adapt<Entity.Server> ();
            var result = unit.ServerRepository.Update(updateServer);
            await unit.SaveAsync ();
            return await Task.FromResult(result.Adapt<Dto.Manager.Server>());
        }
        return ServerServiceErrors.UpdateError;
    }
}
