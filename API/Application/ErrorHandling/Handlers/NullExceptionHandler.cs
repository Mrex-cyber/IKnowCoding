using API.Application.ErrorHandling.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data;
using System.Data.SqlTypes;

namespace API.Application.ErrorHandling.Handlers
{
    public class NullExceptionHandler : IExceptionControllerHandler
    {
        public bool CanHandle(ExceptionContext exceptionContext)
        {
            return exceptionContext.Exception is ArgumentNullException
                || exceptionContext.Exception is NullReferenceException
                || exceptionContext.Exception is NoNullAllowedException
                || exceptionContext.Exception is SqlNullValueException;
        }

        public void Handle(ExceptionContext exceptionContext)
        {
            exceptionContext.Result = new ContentResult
            {
                Content = "NullExceptionHandler: " + exceptionContext.Exception.Message,
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.NoContent,
            };

            exceptionContext.ExceptionHandled = true;
        }
    }
}
