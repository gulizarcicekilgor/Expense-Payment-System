using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Commands.EmployeeCommands;
using WebApi.Business.Commands.TokenCommands;
using WebApi.Business.Commands.UserCommands;
using WebApi.Business.Queries.EmployeeQueries;
using WebApi.Data;
using WebApi.Models;
using WebApi.TokenOperations;

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

        
        [HttpGet]
        [Authorize]
        public IActionResult GetEmployee()
        {
            GetEmployeeQuery query = new GetEmployeeQuery(_dbContext, _mapper);
            var employee = query.Handle();
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeModelRequest employee)
        {
            CreateEmployeeCommand command = new CreateEmployeeCommand(_dbContext, _mapper);
            command.Model = employee;
            command.Handle();
            return Ok();
        }




    }
}

