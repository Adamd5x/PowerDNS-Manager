using hiPower.Common.Type;

namespace hiPower.Dto.Manager;

public class Server { 
   public string Id { get; set; }
   public string LocationId { get; set; }
    public string Name { get; set; }
    public CommunicationProto Proto { get; set; }
    public string HostAddress { get; set; }
    public int Port { get; set; }
    public string ApiKey { get; set; }
    public string Auth { get; set; }
    public string Version { get; set; }
    public string OS { get; set; }
    public string Configuration { get; set; }
    public string LocalId { get; set; }
    public int Timeout { get; set; }

    public int Retries { get; set; }
}
