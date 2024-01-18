using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Commands.TokenCommands;
using WebApi.Business.Commands.UserCommands;
using WebApi.Data;
using WebApi.Models;
using WebApi.TokenOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        public readonly IMapper _mapper;
        public readonly IConfiguration _configuration;

        public UserController(emsDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
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
