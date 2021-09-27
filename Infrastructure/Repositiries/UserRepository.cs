using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositiries
{
    public class UserRepository :IUserRepository
    {
        private readonly FotballersDbContext _context;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserRepository(FotballersDbContext context, IPasswordHasher<User> hasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _hasher = hasher;
            _authenticationSettings = authenticationSettings;
        }
        public string Login(string email, string password)
        {
            var Login = _context.Users
                .Include(x=> x.Role)
                .FirstOrDefault(x => x.Email == email);
            if(Login is null)
                throw new NotFoundExceptions($"User with email {email} not fouund");
            var passwordVerificationResult = _hasher.VerifyHashedPassword(Login, Login.Password, password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Invalid Credentials");
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Login.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{Login.FirstName} {Login.LastName}"),
                new Claim(ClaimTypes.Role, Login.Role.Name),
                new Claim("DateOfBirth", Login.DateOfBirth.Value.ToString("yyyy MMMM dd"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }

        public User CreateUser(User user)
        {
            user.Password = _hasher.HashPassword(user, user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

    }
}