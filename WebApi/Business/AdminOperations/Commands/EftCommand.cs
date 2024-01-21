using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using static WebApi.Models.EftModel;


namespace WebApi.Business.EmployeeOperations.Commands
{
    public class EftCommand
    {
        public EftTransactionRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EftCommand(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //expens apply olan müşteri id si lazım
            





        }
        public List<GetExpenseModelResponse> Handle2()
        {   
            var expenses = _dbContext.Expenses
            .Where(e=>e.ExpenseStatus == "approved")
            .ToList();
            List<GetExpenseModelResponse> obj = _mapper.Map<List<GetExpenseModelResponse>>(expenses);
            return obj;
        }



    }


}