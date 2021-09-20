using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClubRepository
    {
        List<Club> GetAll();
        Club GetById(int id);
        Club Add(Club club);
    }
}