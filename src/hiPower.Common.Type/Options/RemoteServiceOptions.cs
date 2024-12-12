namespace hiPower.Common.Type.Options;

public record struct RemoteServiceOptions(Protocol Proto, string HostAddress, uint Port, string LocalId, string ApiKey, string AuthToken, ServiceMode mode);

