using API.ErrorHandling.Handlers.Interfaces;
using API.ErrorHandling.Interfaces;

namespace API.ErrorHandling
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
