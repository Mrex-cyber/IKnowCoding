using Microsoft.AspNetCore.Mvc.Filters;

namespace API.ErrorHandling.Handlers.Interfaces
{
    public interface IExceptionControllerHandler
    {
        bool CanHandle(ExceptionContext exceptionContext);

        void Handle(ExceptionContext exceptionContext);
    }
}
