using hiPower.Common.Type;

namespace hiPower.Dto.Remote;

public class SlaveZone
{
    public string Name { get; set; }
    public ZoneKind Kind { get; set; }
    public IEnumerable<string> Nameservers { get; set; }
}
