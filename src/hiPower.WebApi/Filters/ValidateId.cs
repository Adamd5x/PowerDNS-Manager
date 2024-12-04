using hiPower.Dto.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hiPower.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting (ActionExecutingContext context)
        {
            object? id;
            bool idExists = context.RouteData.Values.TryGetValue ("id", out id) ||
                            context.RouteData.Values.TryGetValue ("dataCenterId", out id);
            
            bool cantProcced = !idExists || !Guid.TryParse(id?.ToString(), out Guid _);

            if (cantProcced) 
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
