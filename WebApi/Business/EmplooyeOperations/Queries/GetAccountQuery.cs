using System.Security.Claims;
using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.EmployeeOperations.Queries
{
    public class GetAccountQuery
    {   
        public AccountModelResponse Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAccountQuery(emsDbContext dbContext,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<AccountModelResponse> Handle()
        {   string userIdstr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(userIdstr);

            var accounts = _dbContext.Accounts
            .Where(e => e.EmployeeId == userId)
            .ToList();
            List<AccountModelResponse> obj = _mapper.Map<List<AccountModelResponse>>(accounts);
            return obj;
        }
        
    }
}