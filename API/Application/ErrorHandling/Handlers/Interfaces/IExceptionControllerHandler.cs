using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Application.ErrorHandling.Handlers.Interfaces
{
    public interface IExceptionControllerHandler
    {
        bool CanHandle(ExceptionContext exceptionContext);

        void Handle(ExceptionContext exceptionContext);
    }
}
