using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ModelsDTO;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateUser(CreateUserDTO user)
        {
            _service.AddUser(user);
            return Created("Created", user);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO user)
        {
            string token = _service.Login(user);
            return Ok(token);
        }
    }
}
