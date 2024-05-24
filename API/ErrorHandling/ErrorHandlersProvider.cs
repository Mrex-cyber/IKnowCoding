using IKnowCoding.ErrorHandling.Exceptions;
using IKnowCoding.ErrorHandling.Handlers;
using IKnowCoding.ErrorHandling.Handlers.Interfaces;
using IKnowCoding.ErrorHandling.Interfaces;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace IKnowCoding.ErrorHandling
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
