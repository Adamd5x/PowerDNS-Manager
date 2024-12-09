namespace hiPower.Entity;

public class MonitorVariables
{
    public string ServiceId { get; set; }
    public string Variable { get; set; }
    public virtual ServiceDetails ServiceDetails { get; set; }
}
