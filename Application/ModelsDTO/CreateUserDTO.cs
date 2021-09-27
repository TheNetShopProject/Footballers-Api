using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ModelsDTO
{
    public class CreateUserDTO : IMap
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDTO, User>();
        }
    }
}