using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Commands.ExpenseCommands;
using WebApi.Business.Queries.ExpenseQueries;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExpenseController(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetExpense()
        {
            GetExpenseQuery query = new GetExpenseQuery(_dbContext, _mapper);
            var expense = query.Handle();
            return Ok(expense);
        }


        [HttpPost]
        public IActionResult CreateExpense([FromBody] CreateExpenseModelRquest expense)
        {
            CreateExpenseCommand command = new CreateExpenseCommand(_dbContext, _mapper);
            command.Model = expense;
            command.Handle();
            return Ok();
        }



    }
}