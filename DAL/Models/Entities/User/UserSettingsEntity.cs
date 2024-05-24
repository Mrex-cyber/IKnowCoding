using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Entities.User
{
    [Table("UserSettings")]
    public class UserSettingsEntity : BaseEntity
    {
        [Column("access_token")]
        public string? AccessToken { get; set; }

        [Column("access_token_expire_time")]
        public DateTime? AccessTokenExpireTime { get; set; }

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expire_time")]
        public DateTime? RefreshTokenExpireTime { get; set; }

        [Column("is_admin")]
        public bool IsAdmin { get; set; }

        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public UserSettingsEntity(int id, bool isAdmin, int userId)
        {
            Id = id;
            IsAdmin = isAdmin;
            UserId = userId;
        }

        public UserSettingsEntity(int id, string accessToken, string refreshToken, bool isAdmin, int userId) 
            : this(id, isAdmin, userId)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            AccessTokenExpireTime = RefreshTokenExpireTime = DateTime.UtcNow;
        }
    }
}
