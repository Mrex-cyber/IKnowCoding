using API.Application.ErrorHandling.Handlers;
using API.Application.ErrorHandling.Handlers.Interfaces;
using API.Application.ErrorHandling.Interfaces;

namespace API.Application.ErrorHandling
{
    public class ErrorHandlersProvider : IObjectsProvider<IExceptionControllerHandler>
    {
        public IReadOnlyList<IExceptionControllerHandler> GetObjects()
        {
            return new List<IExceptionControllerHandler>
            {
                new GeneralInternalExceptionHandler()
            };
        }
    }
}
