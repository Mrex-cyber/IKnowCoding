using Microsoft.AspNetCore.Mvc.Filters;

namespace IKnowCoding.ErrorHandling.Handlers.Interfaces
{
    public interface IExceptionControllerHandler
    {
        bool CanHandle(ExceptionContext exceptionContext);

        void Handle(ExceptionContext exceptionContext);
    }
}
