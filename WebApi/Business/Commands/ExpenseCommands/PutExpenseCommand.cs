using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.Data.Entities;
using System.Security.Claims;

namespace WebApi.Business.Commands.ExpenseCommands
{
    public class PutExpenseCommand
    {   
        public UpdateExpenseModelRquest Model {get; set;}
        private readonly emsDbContext _dbContext;
        public string ExpenseCode {get; set;}

        public PutExpenseCommand(emsDbContext dbContext)
        {   _dbContext = dbContext;
        }
        public void Handle()
        {//UpdateExpenseModelRquest
            var expense = _dbContext.Expenses.SingleOrDefault(e => e.ExpenseCode == ExpenseCode); //değiştirilcek bu kontrol
            if (expense is null)
            {
                throw new InvalidOperationException("There is no expense to update..");
            }
            expense.ExpenseStatus = Model.ExpenseStatus;
            _dbContext.SaveChanges();
        }

    }


}