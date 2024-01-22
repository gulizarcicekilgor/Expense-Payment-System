using WebApi.Data;

namespace WebApi.Business.EftOperations.Commands
{
    public class DeleteEftCommand
    {
        private readonly emsDbContext _dbContext;
        public int EftId { get; set; }

        public DeleteEftCommand(emsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var eft = _dbContext.EftTransactions.SingleOrDefault(x => x.EftTransactionId == EftId);
           
            if (eft is null)
                throw new InvalidOperationException("this eft does not exist");
            _dbContext.EftTransactions.Remove(eft);
            _dbContext.SaveChanges();
        }
    }
}