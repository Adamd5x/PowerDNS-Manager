using hiPower.Common.Type;

namespace hiPower.Dto.Manager;

public record class Server(string Id, string LocationId, string Name, CommunicationProto Proto, string HostAddress, int Port, string ApiKey, string Auth) : BaseDto(Id);
