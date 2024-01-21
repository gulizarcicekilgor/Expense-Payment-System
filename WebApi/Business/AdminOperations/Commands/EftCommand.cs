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
        public List<int> EmployeesTobePaid()
        {
            var expenses = _dbContext.Expenses
                .Where(e => e.ExpenseStatus == "approved")
                .ToList();
            List<int> employeeIds = _mapper.Map<List<GetExpenseModelResponse>>(expenses)
            .Select(expense => expense.EmployeeId)
            .ToList();
            foreach (var expenseResponse in expenses)
            {
                // Belirli bir EmployeeId'ye ait hesabı bul
                var account = _dbContext.Accounts.FirstOrDefault(a => a.EmployeeId == expenseResponse.EmployeeId);

                if (account != null)
                {
                    // Hesaptan ExpenseAmount kadar para transferi gerçekleştir
                    account.Balance -= expenseResponse.Amount;

                    // İşlem gerçekleştirildikten sonra hesap bilgilerini güncelle
                    _dbContext.SaveChanges();
                }
                else
                {
                    // Hesap bulunamadı durumuyla başa çıkma
                    throw new InvalidOperationException($"EmployeeId {expenseResponse.EmployeeId} için hesap bulunamadı.");
                }
            }

            return employeeIds;



        }



    }


}