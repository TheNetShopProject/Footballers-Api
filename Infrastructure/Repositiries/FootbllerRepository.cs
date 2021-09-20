using System;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositiries
{
    public class FootbllerRepository : IFootballerRepository
    {
        private readonly FotballersDbContext _dbContext;

        public FootbllerRepository(FotballersDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Fotballer> GetAll()
        {
            return _dbContext.Fotballers
                .Include(x => x.Club);
        }
        public Fotballer GetByID(int ID)
        {
            return _dbContext.Fotballers.SingleOrDefault(x => x.ID == ID);
        }

        public Fotballer Add(Fotballer fotballer)
        {
            
            _dbContext.Fotballers.Add(fotballer);
            _dbContext.SaveChanges();
            return fotballer;
        }

        public void Update(Fotballer fotballer)
        {
            var footballerToUpdate = _dbContext.Fotballers.SingleOrDefault(x => x.ID == fotballer.ID);

        }

        public void Delete(Fotballer fotballer)
        {
            _dbContext.Fotballers.Remove(fotballer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Fotballer> GetByClubId(int id)
        {
       
            return _dbContext.Fotballers
                .Include(x => x.Club).
                Where(x => x.Club.ID == id);
        }
    }
}