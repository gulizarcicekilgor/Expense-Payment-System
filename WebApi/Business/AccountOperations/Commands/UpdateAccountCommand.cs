using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.AccountOperations.Commands
{
    public class UpdateAccountCommand
    {
        public int AccountId { get; set; }
        //update edilecek modele ihtiyaç var
        public AccountupdatedModelRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAccountCommand(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var account = _dbContext.Accounts.SingleOrDefault(x => x.AccountId == AccountId);
            if (account is null)
                throw new InvalidOperationException("This account does not exist");
            if(_dbContext.Accounts.Any(x => x.AccountName.ToLower() ==Model.AccountName.ToLower() && x.AccountId != AccountId))  //aynı isimli farklı idli kontrolü
                throw new InvalidOperationException("Aynı isimli hesap zaten mevcut");
            //isActive update edilirken: kendi name'i ile kendini update edecek, yani name i nulllamadan yapacak
            //isnullorEmty ile name i nulllamadan yapacak
            account.AccountName = string.IsNullOrEmpty( Model.AccountName.Trim()) ? account.AccountName : Model.AccountName;
            account.CurrencyType = Model.CurrencyType;
            _dbContext.SaveChanges();

            

        }
        
    }
}