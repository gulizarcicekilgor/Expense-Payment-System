using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Command;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeController(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeModel employee)
        {
            CreateEmployeeCommand command = new CreateEmployeeCommand(_dbContext, _mapper);
            command.Model = employee;
            command.Handle();
            return Ok();
        }

    }
}

