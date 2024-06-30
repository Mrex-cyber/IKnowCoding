namespace DAL.Repositories
{
    public interface ICrud<T>
    {
        public Task<IEnumerable<T>> GetEntities();
        public T? GetEntityById(int id);
        public Task<bool> AddEntity(T entity);
        public bool UpdateEntity(T entity);
        public Task<bool> RemoveEntity(int id);
        void Save();
    }
}
