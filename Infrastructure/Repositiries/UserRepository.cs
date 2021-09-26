using System.Linq;
using Application.Exceptions;
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
        public string Login(string email )
        {
            var LoginUser = _context.Users.FirstOrDefault(x => x.Email == email);
            if (LoginUser != null)
                return LoginUser.Password;
            else
                throw new NotFoundExceptions($"User with email {email} not fouund");
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

    }
}