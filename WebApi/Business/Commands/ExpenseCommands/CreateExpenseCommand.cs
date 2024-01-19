using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.Data.Entities;

namespace WebApi.Business.Commands.ExpenseCommands
{
    public class CreateExpenseCommand
    {   
        public CreateExpenseModelRquest Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateExpenseCommand(emsDbContext dbContext,IMapper mapper)
        {   _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var expense = _dbContext.Expenses.SingleOrDefault(e => e.ExpenseCode == Model.ExpenseCode); //değiştirilcek bu kontrol
            if (expense is not null)
            {
                throw new InvalidOperationException("Expence already exists");
            }
            expense = _mapper.Map<Expense>(Model);
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
        }





    }




        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string Email { get; set; }
        // public string ExpenceRole {get; set; }


}