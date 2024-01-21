using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.EmployeeOperations.Commands;
using WebApi.Data;

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
            EftCommand query = new EftCommand(_dbContext, _mapper);
            var expense = query.EmployeesTobePaid();
            return Ok(expense);
        }
    }
}