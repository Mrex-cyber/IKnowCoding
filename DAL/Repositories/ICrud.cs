namespace DAL.Repositories
{
    public interface ICrud<T>
    {
        public Task<IEnumerable<T>> GetEntities();
        public Task<T?> GetEntityById(int id);
        public Task<bool> AddEntity(T entity);
        public Task<bool> UpdateEntity(T entity);
        public Task<bool> RemoveEntity(int id);
        void Save();
    }
}
