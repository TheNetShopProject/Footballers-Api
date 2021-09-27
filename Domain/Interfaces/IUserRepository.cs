using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        string Login(string email, string password);
        User CreateUser(User user);
    }
}