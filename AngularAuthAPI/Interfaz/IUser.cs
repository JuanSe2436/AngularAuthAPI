using AngularAuthAPI.Models;

namespace AngularAuthAPI.Interfaz
{
    public interface IUser
    {
        Task<User> Execute(User model);
    }
}
