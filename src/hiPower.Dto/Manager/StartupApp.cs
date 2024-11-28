namespace hiPower.Dto.Manager;

public class StartupApp
{
    public string LicenseToken { get; }
    public string UserToken { get; }

    public int RefreshInterval { get; }

    public IEnumerable<EndpointItem> Endpoints { get; }

    public StartupApp(string licenseToken, string userToken, int refreshInterval, IEnumerable<EndpointItem> endpoints)
    {
        LicenseToken = licenseToken;
        UserToken = userToken;
        RefreshInterval = refreshInterval;
        Endpoints = endpoints;
    }
}
