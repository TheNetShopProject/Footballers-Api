using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IFootballerRepository
    {
        IEnumerable<Fotballer> GetAll();
        Fotballer GetByID(int ID);
        Fotballer Add(Fotballer fotballer);
        void Update(Fotballer fotballer);
        void Delete(Fotballer fotballer);
        IEnumerable<Fotballer> GetByClubId(int id);

    }
}