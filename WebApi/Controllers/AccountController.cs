
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.AccountOperations.Commands;
using WebApi.Business.AccountOperations.Queries;
using WebApi.Business.AccountOperations.Validations;
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
             CreateAccountValidator vl = new CreateAccountValidator();
          vl.ValidateAndThrow<AccountModelRequest>(command.Model);
            command.Handle();
            return Ok();
        }


        [HttpDelete("id")]
        public IActionResult DeleteAccount(int id)
        {
            DeleteAccountCommand cmd = new DeleteAccountCommand(_dbContext);
            cmd.AccountId = id;

            // DeleteAccountCommandValidator vl = new DeleteAccountCommandValidator();
            // vl.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdateAccount(int id, [FromBody] AccountupdatedModelRequest newModel)
        {
            UpdateAccountCommand cmd = new UpdateAccountCommand(_dbContext, _mapper);
            cmd.AccountId = id;
            cmd.Model = newModel;

            UpdateAccountValidator vl = new UpdateAccountValidator();
            vl.ValidateAndThrow<AccountupdatedModelRequest>(cmd.Model);

            cmd.Handle();
            return Ok();
        }





    }
}