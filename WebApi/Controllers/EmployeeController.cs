using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly emsDbContext _dbContext;

        public EmployeeController(emsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // [HttpPost]
        // [Authorize(EmployeeRole = "admin")]
        // public IActionResult Post([FromBody] Employee employee)
        // {
        // }

    }
}

