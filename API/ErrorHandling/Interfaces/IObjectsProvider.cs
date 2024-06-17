namespace API.ErrorHandling.Interfaces
{
    public interface IObjectsProvider<T>
    {
        public IReadOnlyList<T> GetObjects();
    }
}
