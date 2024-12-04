using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hiPower.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VallidatModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting (ActionExecutingContext context)
        {
            bool cantProcced = !context.ModelState.IsValid;
            if (cantProcced) 
            { 
                context.Result = new BadRequestResult();
            }
        }
    }
}
