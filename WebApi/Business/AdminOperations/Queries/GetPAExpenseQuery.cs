using System.Security.Claims;
using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.AdminOperations.Queries
{
    public class GetPAExpenseQuery
    {   
        public GetExpenseModelResponse Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPAExpenseQuery(emsDbContext dbContext,IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetExpenseModelResponse> Handle()
        {   
            var expenses = _dbContext.Expenses
            .Where(e=>e.ExpenseStatus == "Pending Approval")
            .ToList();
            List<GetExpenseModelResponse> obj = _mapper.Map<List<GetExpenseModelResponse>>(expenses);
            return obj;
        }
        
    }
}