using hiPower.Abstracts;
using hiPower.Common.Type.Errors;
using hiPower.Common.Type.Options;
using MapsterMapper;

namespace hiPower.Core;

public class ServerService(IUnitOfWork unit,
                           IMapper mapper,
                           IRemoteService remoteService) : IServerService
{
    public async Task<ErrorOr<Server>> CreateAsync (Server server)
    {
        var result = await unit.ServerRepository.CreateAsync(server.Adapt<ServerDetails>());
        await unit.SaveAsync ();
        return mapper.Map<Server> (result);
    }

    public async Task<ErrorOr<bool>> DeleteAsync (string id)
    {
        await unit.ServerRepository.DeleteAsync (id);
        return true;
    }

    public async Task<ErrorOr<IEnumerable<Server>>> GetAllAsync (string dataCenterId)
    {
        var result = await unit.ServerRepository.GetAll(x => x.LocationId.Equals(dataCenterId.ToUpper()), null, null);
        if (result.Any ())
        {
            return result.Adapt<IEnumerable<Server>> ()
                         .ToErrorOr ();
        }
        return Error.NotFound();
    }

    public async Task<ErrorOr<IEnumerable<Server>>> GetAllAsync ()
    {
        var result = await unit.ServerRepository.GetAll(null, null, null);
        return result.Adapt<IEnumerable<Server>>()
                     .ToErrorOr();
    }

    public async Task<ErrorOr<Server>> GetAsync (string id)
    {
        var result = await unit.ServerRepository
                               .GetAsync(x => x.Id.Equals(id.ToUpper()), null);
        if (result is not null)
        {
            return mapper.Map<Server> (result);
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

    public async Task<ErrorOr<Server>> UpdateAsync (string id, Server server)
    {
        if (id.ToUpper ().Equals (server.Id.ToUpper ())) 
        { 
            var updateServer = server.Adapt<Entity.ServerDetails> ();
            var result = unit.ServerRepository.Update(updateServer);
            await unit.SaveAsync ();
            return await Task.FromResult(result.Adapt<Server>());
        }
        return ServerServiceErrors.UpdateError;
    }

    public async Task<ErrorOr<IEnumerable<ConfigSetting>>> GetRemoteConfigurationAsync(string id)
    {
        var service = await GetAsync(id);

        if (service.IsError && service.FirstError.Type == ErrorType.NotFound)
        {
            return Error.NotFound();
        }

        var options = service.Value.Adapt<RemoteServiceOptions> ();
        var response = await remoteService.GetConfigurationAsync (options);

        if (response.IsError) 
        { 
            return response.FirstError;
        }

        return response;
    }

    public async Task<ErrorOr<IEnumerable<StatisticsItem>>> GetRemoteStatisticsAsync (string id)
    {
        var service = await GetAsync(id);

        if (service.IsError && service.FirstError.Type == ErrorType.NotFound)
        {
            return Error.NotFound ();
        }

        var options = service.Value.Adapt<RemoteServiceOptions> ();
        var response = await remoteService.GetStatisticsAsync (options);

        if (response.IsError)
        {
            return response.FirstError;
        }

        return response;
    }

    public async Task<ErrorOr<ServerInfo>> GetRemoteServerInfoAsync (string id)
    {
        var service = await GetAsync(id);

        if (service.IsError && service.FirstError.Type == ErrorType.NotFound)
        {
            return Error.NotFound ();
        }

        var options = service.Value.Adapt<RemoteServiceOptions> ();
        var response = await remoteService.GetInfoAsync (options);

        if (response.IsError)
        {
            return response.FirstError;
        }

        return response;
    }
}
