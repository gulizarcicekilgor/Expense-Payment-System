using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoginController : ControllerBase
    {
        public readonly emsDbContext _dbContext;
        public readonly IMapper _mapper;

        public EmployeeLoginController(emsDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       
        
    }
}
