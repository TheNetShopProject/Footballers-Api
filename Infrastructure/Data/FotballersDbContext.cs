using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FotballersDbContext :DbContext
    {
        public FotballersDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Fotballer> Fotballers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}