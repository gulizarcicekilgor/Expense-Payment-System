using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.EftOperations.Commands
{
    public class UpdateEftCommand
    {
        public int EftId { get; set; }
        //update edilecek modele ihtiyaç var
        public EftupdatedModelRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateEftCommand(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var eft = _dbContext.EftTransactions.SingleOrDefault(x => x.EftTransactionId == EftId);
            if (eft is null)
                throw new InvalidOperationException("This eft does not exist");
            eft.Description = string.IsNullOrEmpty( Model.Description.Trim()) ? eft.Description : Model.Description;
            _dbContext.SaveChanges();

            

        }
        
    }
}