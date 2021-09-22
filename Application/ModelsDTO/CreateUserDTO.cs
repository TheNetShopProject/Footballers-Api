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
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(6)]
        public string Password { get; set; }
        public virtual int RoleId { get; set; } = 1;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDTO, User>();
        }
    }
}