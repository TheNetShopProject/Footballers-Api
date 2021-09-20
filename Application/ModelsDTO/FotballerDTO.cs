using System;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ModelsDTO
{
    public class FotballerDTO : IMap
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ClubName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public string League { get; set; }
        public DateTime ClubCreatedYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fotballer, FotballerDTO>()
                .ForMember(x => x.ClubName, y => y.MapFrom(z => z.Club.FullName))
                .ForMember(x => x.League, y => y.MapFrom(z => z.Club.League))
                .ForMember(x => x.ClubCreatedYear, y => y.MapFrom(z => z.Club.CreatedYear));
        }
    }
}