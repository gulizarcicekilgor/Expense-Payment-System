using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Commands.EmployeeCommands;
using WebApi.Business.Queries.EmployeeQueries;
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
        [HttpGet]
        public IActionResult GetEmployee()
        {
            GetEmployeeQuery query = new GetEmployeeQuery(_dbContext, _mapper);
            var employee = query.Handle();
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeModelRquest employee)
        {
            CreateEmployeeCommand command = new CreateEmployeeCommand(_dbContext, _mapper);
            command.Model = employee;
            command.Handle();
            return Ok();
        }



    }
}

