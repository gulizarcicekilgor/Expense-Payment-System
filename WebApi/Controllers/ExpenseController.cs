using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.AdminOperations.Commands;
using WebApi.Business.AdminOperations.Queries;
using WebApi.Business.EmployeeOperations.Commands;
using WebApi.Business.EmployeeOperations.Queries;
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

        private readonly IHttpContextAccessor _httpContextAccessor;


        public ExpenseController(emsDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetMyExpenses()
        {
            GetExpenseQuery query = new GetExpenseQuery(_dbContext, _mapper, _httpContextAccessor);
            var expense = query.Handle();
            return Ok(expense);
        }
        [HttpGet("forAdmin")]
        //[Authorize]
        public IActionResult GetPAExpenses()
        {
            GetPAExpenseQuery query = new GetPAExpenseQuery(_dbContext, _mapper);
            var expense = query.Handle();
            return Ok(expense);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateMyExpense([FromBody] CreateExpenseModelRquest expense)
        {
            CreateExpenseCommand command = new CreateExpenseCommand(_dbContext, _mapper, _httpContextAccessor);
            command.Model = expense;
            command.Handle();
            return Ok();
        }


        [HttpPut("expenseCode")]
        //[Authorize]
        public IActionResult UpdateExpense(string expenseCode,[FromBody] UpdateExpenseModelRquest model)
        {
            PutExpenseCommand command = new PutExpenseCommand(_dbContext);
            command.ExpenseCode=expenseCode;
            command.Model = model;
            command.Handle();
            return Ok();
        }





    }
}