using BLL.Models.User;

namespace BLL.Services.Users.Settings
{
    public interface IUserService
    {
        Task<UserModel> SignUp(UserModel user);
        Task<UserSettingsModel> SignIn(UserModel user);
        Task<bool> ChangeSettings(UserSettingsModel settings);
    }
}
