

using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.AccountOperations.Commands
{
    public class DeleteAccountCommand
    {
        private readonly emsDbContext _dbContext;
        public int AccountId { get; set; }

        public DeleteAccountCommand(emsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var account = _dbContext.Accounts.SingleOrDefault(x => x.AccountId == AccountId);
           
            if (account is null)
                throw new InvalidOperationException("this account does not exist");
            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }
    }
}