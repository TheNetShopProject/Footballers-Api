using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ModelsDTO
{
    public class LoginDTO :IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDTO, User>();
        }
    }
}