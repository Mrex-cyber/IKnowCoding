namespace API.Application.ErrorHandling.Interfaces
{
    public interface IObjectsProvider<T>
    {
        public IReadOnlyList<T> GetObjects();
    }
}
