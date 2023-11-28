using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace BrillianceCodeAssessment.ExceptionErrorHandler
{

    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode;
            switch (context.Exception)
            {
                case InvalidInputException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default: statusCode = HttpStatusCode.InternalServerError; break;
            }

            context.Result = new JsonResult(new { errorMessage = context.Exception.Message }) { StatusCode = (int)statusCode };
        }
    }
}







