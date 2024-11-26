using hiPower.Common.Type;

namespace hiPower.Dto.Manager;

public record class Zone(string Name, ZoneKind Kind, IEnumerable<string> Masters, bool DnsSec, ulong Serial);
