using hiPower.Common.Type;

namespace hiPower.Entity;

public class ServiceDetails : EntityBase
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

    public ServiceState State { get; set; }

    public ServiceMode Mode { get; set; }

    public string DataCenterId { get; set; }

    public DataCenter DataCenter { get; set; }

    public virtual string MonitorId {get; set; }

    public virtual ICollection<MonitorVariables> MonitorStatistics { get; set; }
}
