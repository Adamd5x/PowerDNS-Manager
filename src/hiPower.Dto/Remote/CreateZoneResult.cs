using System.Text.Json.Serialization;

namespace hiPower.Dto.Remote;

public sealed class CreateZoneResult
{
    public string Account { get; set; }

    [JsonPropertyName("api_rectify")]
    public bool ApiRectify { get; set; }

    public bool DnsSec { get; set; }

    [JsonPropertyName("edited_serial")]
    public int EditedSerial { get; set; }

    public string Id { get; set; }

    public string Kind { get; set; }
    public int LactCheck { get; set; }

    public IEnumerable<string> Masters { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("notified_serial")]
    public int NotifiedSerial { get; set; }
    public bool Nsec3Narrow { get; set; }
    public string Nsec3Param { get; set; }

    public int Serial { get; set; }

    [JsonPropertyName("soa_edit")]
    public string SoaEdit { get; set; }

    [JsonPropertyName("soa_edit_api")]
    public string SoaEditApi { get; set; }

    public string Url { get; set; }

}
