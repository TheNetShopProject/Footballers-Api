using System.Collections.Generic;
using Application.ModelsDTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFootballerService
    {
        IEnumerable<FotballerDTO> getAllFotballers();
        FotballerDTO GetFotballerByID(int ID);
        FotballerDTO AddFotballer(CreateFotballerDTO  fotballer);
        void DeleteFotballer(int ID);
        IEnumerable<FotballerDTO> GetFotballersByClubId(int id);
    }
}