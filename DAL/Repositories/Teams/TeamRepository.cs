using DAL.Models.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Teams
{
    public class TeamRepository : ITeamRepository
    {
        public bool AddEntity(TeamEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TeamEntity? GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatedEntity(TeamEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
