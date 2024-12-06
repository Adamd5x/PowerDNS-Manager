namespace hiPower.Common.Type.Extensions;

public static class ProtocolEnumExtension
{
    public static Protocol ToProtocol(this string value)
    {
        var isDone = Enum.TryParse<Protocol>(value, out var protocol);
        if (isDone)
        {
            return protocol;
        }
        return Protocol.HTTP;
    }
}
