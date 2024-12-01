namespace hiPower.Abstracts;

public interface IDataCenterService
{
    Task<ErrorOr<DataCenter>> CreateAsync(DataCenter location);
    Task<ErrorOr<DataCenter>> UpdateAsync(string id, DataCenter location);
    Task<ErrorOr<bool>> DeleteAsync (string id);
    Task<ErrorOr<DataCenter>> GetAsync (string id);
    Task<ErrorOr<IEnumerable<DataCenter>>> GetAsync ();
    Task<ErrorOr<IEnumerable<Server>>> GetServers(string id);
}
