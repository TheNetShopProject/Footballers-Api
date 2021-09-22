using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmailAndPassword(string email, string password);
        User CreateUser(User user);
    }
}