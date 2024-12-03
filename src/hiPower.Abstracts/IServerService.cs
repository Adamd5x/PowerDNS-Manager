﻿namespace hiPower.Abstracts;

public interface IServerService
{
    Task<ErrorOr<IEnumerable<Server>>> GetAllAsync ();
    Task<ErrorOr<IEnumerable<Server>>> GetAllAsync (string dataCenterId);    
    Task<ErrorOr<Server>> GetAsync (string id);

    Task<ErrorOr<Server>> CreateAsync(Server server);

    Task<ErrorOr<Server>> UpdateAsync(string id, Server server);

    Task<ErrorOr<bool>> DeleteAsync (string id);

    Task<ErrorOr<IEnumerable<HintItem>>> GetAvailableDataCentersAsync ();
}