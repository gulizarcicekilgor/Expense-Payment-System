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
    public class ApplicationEmployeeController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        public readonly IConfiguration _configuration;

        public ApplicationEmployeeController(emsDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("userpost")]
        public IActionResult Create([FromBody] CreateUserModelRequest newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_dbContext, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
        }

        [HttpPost("users/create")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbContext, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }






    }
}

