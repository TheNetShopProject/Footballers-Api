using Application.ModelsDTO;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserDTO AddUser(CreateUserDTO user);
    }
}