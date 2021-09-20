using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ModelsDTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotballerController : ControllerBase
    {
        private readonly IFootballerService _service;

        public FotballerController(IFootballerService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var fotballers = _service.getAllFotballers();
            return Ok(fotballers);
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetByID(int ID)
        {
            var fotballer = _service.GetFotballerByID(ID);
            return Ok(fotballer);
        }

        [HttpPost]
        public IActionResult AddNewFotballer(CreateFotballerDTO fotballer)
        {
            var newFotballer = _service.AddFotballer(fotballer);
            return Ok(newFotballer);
        }

        [HttpDelete]
        [Route("{ID}")]
        public IActionResult DeleteFotballerByID(int ID)
        {
            _service.DeleteFotballer(ID);
            var fotballers = _service.getAllFotballers();
            return Ok(fotballers);
        }
    }
}
