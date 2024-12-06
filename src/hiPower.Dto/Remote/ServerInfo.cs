

using System.Text.Json.Serialization;

namespace hiPower.Dto.Remote;

public sealed class ServerInfo
{

    [JsonPropertyName ("id")]
    public string Id { get; set; }

    [JsonPropertyName ("daemon_type")]
    public string DaemonType { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("zones_url")]
    public string ZonesUrl { get; set; }

    [JsonPropertyName("config_url")]
    public string ConfigUrl { get; set; }

}
