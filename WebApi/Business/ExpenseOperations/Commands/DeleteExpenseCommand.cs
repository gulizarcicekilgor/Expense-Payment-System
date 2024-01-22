

using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.ExpenseOperations.Commands
{
    public class DeleteExpenseCommand
    {
        private readonly emsDbContext _dbContext;
        public int ExpenseId { get; set; }

        public DeleteExpenseCommand(emsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var expense = _dbContext.Expenses.SingleOrDefault(x => x.ExpenceId == ExpenseId);
           
            if (expense is null)
                throw new InvalidOperationException("this expense does not exist");
            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();
        }
    }
}