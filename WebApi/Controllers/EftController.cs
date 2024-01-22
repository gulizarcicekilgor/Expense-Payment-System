using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.EftOperations.Commands;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EftController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        public EftController(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetApproved")]
        //[Authorize]
        public IActionResult GetApprovedExpenses()
        {
            CreateEftCommand query = new CreateEftCommand(_dbContext, _mapper);
            var expense = query.EmployeesTobePaid();
            return Ok(expense);
        }
        [HttpDelete("id")]
        public IActionResult DeleteAccount(int id)
        {
            DeleteEftCommand cmd = new DeleteEftCommand(_dbContext);
            cmd.EftId = id;

            // DeleteEftCommandValidator vl = new DeleteEftCommandValidator();
            // vl.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok();
        }
         [HttpPut("id")]
        public IActionResult UpdateEft(int id, [FromBody] EftupdatedModelRequest newModel)
        {
            UpdateEftCommand cmd = new UpdateEftCommand(_dbContext, _mapper);
            cmd.EftId = id;
            cmd.Model = newModel;

            // UpdateEftCommandValidator vl = new UpdateEftCommandValidator();
            // vl.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
    }
}