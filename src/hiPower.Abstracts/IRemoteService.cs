namespace hiPower.Abstracts;

public interface IRemoteService
{
    Task<ErrorOr<IEnumerable<ConfigSetting>>> GetConfigurationAsync (RemoteServiceOptions options);
    Task<ErrorOr<IEnumerable<StatisticsItem>>> GetStatisticsAsync (RemoteServiceOptions options, IEnumerable<string> statItemsList);
    Task<ErrorOr<ServerInfo>> GetInfoAsync (RemoteServiceOptions options);
}
