using Application.ModelsDTO;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserDTO AddUser(CreateUserDTO user);
        string Login(LoginDTO user);
    }
}