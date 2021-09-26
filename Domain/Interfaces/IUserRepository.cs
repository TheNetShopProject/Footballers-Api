using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        string Login(string email);
        User CreateUser(User user);
    }
}