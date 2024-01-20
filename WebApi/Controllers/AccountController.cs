
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.EmployeeOperations.Queries;
using WebApi.Business.SystemOperations.Commands;
using WebApi.Data;
using WebApi.Models;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountController(emsDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetMyAccounts()
        {
            GetAccountQuery query = new GetAccountQuery(_dbContext, _mapper, _httpContextAccessor);
            var account = query.Handle();
            return Ok(account);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateMyAccount([FromBody] AccountModelRequest account)
        {
            CreateAccountCommand command = new CreateAccountCommand(_dbContext, _mapper, _httpContextAccessor);
            command.Model = account;
            command.Handle();
            return Ok();
        }


        // [HttpPut("accountCode")]
        // //[Authorize]
        // public IActionResult UpdateAccount(string accountCode,[FromBody] UpdateAccountModelRquest model)
        // {
        //     PutAccountCommand command = new PutAccountCommand(_dbContext);
        //     command.AccountCode=accountCode;
        //     command.Model = model;
        //     command.Handle();
        //     return Ok();
        // }





    }
}