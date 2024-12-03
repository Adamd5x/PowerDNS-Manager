using ErrorOr;

namespace hiPower.Common.Type.Errors;

public static class DataCenterErrors
{
    public static Error DeleteError => Error.Failure (
        code : "DeleteError",
        description: "Unable to delete the data center."
        );
}
