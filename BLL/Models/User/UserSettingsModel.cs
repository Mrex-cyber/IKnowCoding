namespace BLL.Models.User
{
    public class UserSettingsModel : BaseModel
    {
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpireTime { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
        public bool IsAdmin { get; set; }
        public UserModel User { get; set; }
    }
}
