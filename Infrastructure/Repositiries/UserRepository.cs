using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositiries
{
    public class UserRepository :IUserRepository
    {
        private readonly FotballersDbContext _context;

        public UserRepository(FotballersDbContext context)
        {
            _context = context;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}