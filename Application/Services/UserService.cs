using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class UserService :IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _service;

        public UserService(IMapper mapper, ILogger<UserService> logger, IUserRepository service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }
        public UserDTO AddUser(CreateUserDTO user)
        {
            var UserToAdd = _mapper.Map<User>(user);
            UserToAdd.RoleId = 1; // Standard user role
            _service.CreateUser(UserToAdd);
            _logger.LogInformation(Utilities.LoggerUtils.DeserializeObjectToString(user));
            return _mapper.Map<UserDTO>(UserToAdd);
        }

        public string Login(LoginDTO user)
        {
            var Login = _mapper.Map<User>(user);
            string token = _service.Login(Login.Email, user.Password);
            return token; 
        }
    }
}