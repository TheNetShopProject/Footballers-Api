using System;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ModelsDTO
{
    public class CreateFotballerDTO : IMap
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ClubName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFotballerDTO, Fotballer>();
        }
    }
}