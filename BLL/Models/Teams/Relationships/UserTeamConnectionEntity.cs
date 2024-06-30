﻿using BLL.Models.User;

namespace BLL.Models.Teams.Relationships
{
    public class UserTeamConnectionEntity : BaseModel
    {
        public TeamModel Team { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}