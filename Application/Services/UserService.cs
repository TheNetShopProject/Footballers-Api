using System;
using Application.Exceptions;
using Application.Interfaces;
using Application.ModelsDTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NLog.Fluent;
using Application.Exceptions;

namespace Application.Services
{
    public class UserService :IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _service;
        private readonly IPasswordHasher<User> _hasher;

        public UserService(IMapper mapper, ILogger<UserService> logger, IUserRepository service, IPasswordHasher<User> hasher)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
            _hasher = hasher;
        }
        public UserDTO AddUser(CreateUserDTO user)
        {
            var UserToAdd = _mapper.Map<User>(user);
            UserToAdd.Password = _hasher.HashPassword(UserToAdd, UserToAdd.Password);
            _service.CreateUser(UserToAdd);
            _logger.LogInformation(Utilities.LoggerUtils.DeserializeObjectToString(user));
            return _mapper.Map<UserDTO>(UserToAdd);
        }

        public string Login(LoginDTO user)
        {
            var Login = _mapper.Map<User>(user);
            Login.Password =_service.Login(Login.Email);
            var token = _hasher.VerifyHashedPassword(Login, Login.Password, user.Password);
            if (token == PasswordVerificationResult.Success)
                return "Logged in";
            else
                throw new NotFoundExceptions("Loggin failed");

        }
    }
}