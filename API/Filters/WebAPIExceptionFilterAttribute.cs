using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using IKnowCoding.ErrorHandling.Handlers.Interfaces;
using IKnowCoding.ErrorHandling.Interfaces;

namespace IKnowCoding.Filters
{
    public class WebAPIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IReadOnlyList<IExceptionControllerHandler> _handlers;
        private readonly ILogger<WebAPIExceptionFilterAttribute> _logger;

        public WebAPIExceptionFilterAttribute(IObjectsProvider<IExceptionControllerHandler> _provider, ILogger<WebAPIExceptionFilterAttribute> logger)
        {
            _handlers = _provider.GetObjects();
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            _handlers.FirstOrDefault(e => e.CanHandle(context)).Handle(context);
        }
    }
}
