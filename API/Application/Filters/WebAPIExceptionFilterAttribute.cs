using API.Application.ErrorHandling.Handlers.Interfaces;
using API.Application.ErrorHandling.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Application.Filters
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
