using hiPower.Common.Type;

namespace hiPower.Entity;

public class Server: EntityBase
{
    public string Name { get; set; }

    public string LocalId { get; set; }

    public string Proto { get; set; }

    public string HostAddress { get; set; }

    public string Port { get; set; }

    public string Description { get; set; }

    public string Version { get; set; }

    public string ApiKey { get; set; }

    public string Auth { get; set; }

    public string OS { get; set; }

    public string Configuration { get; set; }

    public ServerState State { get; set; }

    public int Timeout { get; set; }

    public int Retries { get; set; }

    public string LocationId { get; set; }

    public ServerLocation Location { get; set; }
}
