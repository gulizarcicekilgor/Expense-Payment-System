using System.Security.Claims;
using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.Queries.ExpenseQueries
{
    public class GetExpenseQuery
    {   
        public GetExpenseModelResponse Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetExpenseQuery(emsDbContext dbContext,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<GetExpenseModelResponse> Handle()
        {   string userIdstr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(userIdstr);

            var expenses = _dbContext.Expenses
            .Where(e => e.EmployeeId == userId)
            .ToList();
            List<GetExpenseModelResponse> obj = _mapper.Map<List<GetExpenseModelResponse>>(expenses);
            return obj;
        }

        
    }
}