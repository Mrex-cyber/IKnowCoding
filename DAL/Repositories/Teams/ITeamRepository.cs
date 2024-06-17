using DAL.Models.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Teams
{
    internal interface ITeamRepository : ICrud<TeamEntity>
    {
    }
}
