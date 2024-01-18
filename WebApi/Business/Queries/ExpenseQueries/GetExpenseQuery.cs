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

        public GetExpenseQuery(emsDbContext dbContext,IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetExpenseModelResponse> Handle()
        {
            var expenses = _dbContext.Expenses.ToList();
            List<GetExpenseModelResponse> obj = _mapper.Map<List<GetExpenseModelResponse>>(expenses);
            return obj;
        }
    }
}