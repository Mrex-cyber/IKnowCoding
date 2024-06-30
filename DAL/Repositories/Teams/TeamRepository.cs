using DAL.Models.Entities.Teams;

namespace DAL.Repositories.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private PlatformContext _context;
        public TeamRepository(PlatformContext context)
        {
            _context = context;
        }

        public Task<bool> AddEntity(TeamEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamEntity>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TeamEntity? GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(TeamEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
