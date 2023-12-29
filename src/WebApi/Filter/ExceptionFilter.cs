using Application.Exceptions;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filter
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ExceptionType = context.Exception.GetType();

            if (ExceptionType == typeof(CustomException))
            {
                var Exception = (CustomException)context.Exception;
                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                    Success = false,
                    Message = Exception.Message
                });
               
                context.ExceptionHandled = true;
            }

            else if (ExceptionType == typeof(CustomValidationException))
            {
                var Exception = (CustomValidationException)context.Exception;

                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                    Success = false,
                    Message = Exception.Message
                });

                context.ExceptionHandled = true;
            }

            else if (ExceptionType == typeof(NotFoundException))
            {
                var Ecception = (NotFoundException)context.Exception;

                context.Result = new NotFoundObjectResult(new CustomActionResult
                {
                    Success = false,
                    Message = Ecception.Message
                });

                context.ExceptionHandled = true;
            }

            else
            {
                context.Result = new BadRequestObjectResult(new CustomActionResult
                {
                    Success= false, 
                    Message = "خطای نامشخص"
                });
            }


            base.OnException(context);
        }
    }
}
