using System.Text.Json.Serialization;

namespace hiPower.Dto.Remote;

public class ZoneItem
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Account { get; set; }

    public bool DnsSec {  get; set; }

    [JsonPropertyName("edited_serial")]
    public string EditedSerial { get; set; }

    public string Kind { get; set; }

    [JsonPropertyName("last_check")]
    public ulong LastCheck { get; set; }
    public IEnumerable<string> Masters { get; set; }

    [JsonPropertyName("notified_serial")]
    public ulong NotifiedSerial { get; set; }

    public ulong Serial { get; set; }

    public string Url { get; set; }
}
