using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using IKnowCoding.ErrorHandling.Handlers.Interfaces;
using System.Net;
using System.Reflection.Metadata;

namespace IKnowCoding.ErrorHandling.Handlers
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
