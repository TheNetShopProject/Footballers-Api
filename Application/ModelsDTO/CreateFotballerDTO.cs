using System;
using System.ComponentModel.DataAnnotations;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ModelsDTO
{
    public class CreateFotballerDTO : IMap
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFotballerDTO, Fotballer>();
        }
    }
}