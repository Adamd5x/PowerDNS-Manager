using hiPower.Common.Type;

namespace hiPower.Entity;

public class MonitorService
{
    public MonitorState MonitorState { get; set; }
    public DateTime Created {  get; set; }
    public string ServiceId { get; set; }
}
