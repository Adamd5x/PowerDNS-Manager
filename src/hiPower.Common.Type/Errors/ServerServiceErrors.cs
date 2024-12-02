using ErrorOr;

namespace hiPower.Common.Type.Errors;

public static class ServerServiceErrors
{
    public static Error UpdateError => Error.Failure (
            code: "UpdateError",
            description: "Unable to update"
        );
}
