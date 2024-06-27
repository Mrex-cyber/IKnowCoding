using API.Application.ErrorHandling.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;

namespace API.Application.ErrorHandling.Handlers
{
    public class AutomapperMappingExceptionHandler : IExceptionControllerHandler
    {
        public bool CanHandle(ExceptionContext exceptionContext)
        {
            return exceptionContext.Exception is AutoMapperMappingException;
        }

        public void Handle(ExceptionContext exceptionContext)
        {
            exceptionContext.Result = new ContentResult
            {
                Content = "AutomapperMappingExceptionHandler: " + exceptionContext.Exception.Message,
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };

            exceptionContext.ExceptionHandled = true;
        }
    }
}
