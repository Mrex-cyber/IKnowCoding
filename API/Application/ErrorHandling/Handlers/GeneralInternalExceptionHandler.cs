using API.Application.ErrorHandling.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Application.ErrorHandling.Handlers
{
    public class GeneralInternalExceptionHandler : IExceptionControllerHandler
    {
        public bool CanHandle(ExceptionContext exceptionContext)
        {
            return exceptionContext.Exception is not null;
        }

        public void Handle(ExceptionContext exceptionContext)
        {
            exceptionContext.Result = new ContentResult
            {
                Content = "generalInternalError",
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            exceptionContext.ExceptionHandled = true;
        }
    }
}
