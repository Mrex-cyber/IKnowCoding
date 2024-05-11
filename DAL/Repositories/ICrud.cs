using Microsoft.Identity.Client;

namespace IKnowCoding.DAL.Repositories
{
    public interface ICrud<T>
    {
        public IEnumerable<T> GetEntities();
        public T GetEntityById(int id);
        public bool AddEntity(T entity);
        public bool UpdatedEntity(T entity);
        public bool RemoveEntity(int id);
        void Save();
    }
}
