using System.Collections.Generic;

namespace IKnowCoding.ErrorHandling.Interfaces
{
    public interface IObjectsProvider<T>
    {
        public IReadOnlyList<T> GetObjects();
    }
}
