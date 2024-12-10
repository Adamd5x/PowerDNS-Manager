#nullable disable

using hiPower.Common.Type;

namespace hiPower.Server.Communication;

public class ApiAddressConfiguration
{
    private const uint IANAMinTcpPortRange = 1024;
    private const uint IANAMaxTcpPortRange = 49151;
    private const uint DefaultWebTcpPort = 80;

    public string Proto{ get; private set; }

    private uint port = DefaultWebTcpPort;
    public uint Port { get => port; private set { port = value; } }
    public string HostAddress { get; private set; }

    public ApiAddressConfiguration SetProtocol (Protocol protocol)
    {
        Proto = protocol.ToString();
        return this;
    }

    public ApiAddressConfiguration SetPort (uint port) 
    {
        bool isPortInRange = port >= IANAMinTcpPortRange && port <= IANAMaxTcpPortRange;

        if (!isPortInRange)
        {
            throw new ArgumentOutOfRangeException (nameof(port));
        }

        Port = port;
        return this;
    }

    public ApiAddressConfiguration SetHost (string host) 
    {
        HostAddress = host;
        return this;
    }

    public string Build ()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace (Proto);
        ArgumentNullException.ThrowIfNullOrWhiteSpace (HostAddress);
        
        string result = $"{Proto}://{HostAddress}";

        if(Port != DefaultWebTcpPort)
        {
            result += $":{Port}";
        }

        return result;
    }
}
