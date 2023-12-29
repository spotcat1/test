using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filter
{
    public class CustomActionResultFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (context == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                if (context.Result is ObjectResult obj)
                {
                    context.Result = new OkObjectResult(new CustomActionResult<object>
                    {
                        Success = true,
                        Result = obj.Value
                    });
                }
                else
                {
                    context.Result = new OkObjectResult(new CustomActionResult
                    {
                        Success = true
                    });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
