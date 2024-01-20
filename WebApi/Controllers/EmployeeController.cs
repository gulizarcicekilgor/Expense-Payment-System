using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.SystemOperations.Commands;
using WebApi.Business.SystemOperations.Queries;
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
        private readonly IConfiguration _configuration;

        public EmployeeController(emsDbContext dbContext, IMapper mapper , IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
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
        [HttpPost("userstoken")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbContext, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        










    }
}

