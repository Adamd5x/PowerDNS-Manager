namespace hiPower.Abstracts;

public interface ILicenseService
{
    Task<ErrorOr<string>> Get ();

    Task<ErrorOr<bool>> Store (string licenseToken);

    Task<ErrorOr<bool>> Validate(string licenseToken, string userToken);
}
