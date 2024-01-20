using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.Data.Entities;
using System.Security.Claims;

namespace WebApi.Business.EmployeeOperations.Commands
{
    public class CreateExpenseCommand
    {   
        public CreateExpenseModelRquest Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateExpenseCommand(emsDbContext dbContext,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {   _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Handle()
        {
            // Kullanıcının kimliğini çıkart
            string userIdstr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(userIdstr);
            

            var expense = _dbContext.Expenses.SingleOrDefault(e => e.ExpenseCode == Model.ExpenseCode 
                                                            && e.EmployeeId == userId); //değiştirilcek bu kontrol
            if (expense is not null)
            {
                throw new InvalidOperationException("Expence already exists");
            }
            expense = _mapper.Map<Expense>(Model);
            expense.EmployeeId = userId;
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
        }

    }


}