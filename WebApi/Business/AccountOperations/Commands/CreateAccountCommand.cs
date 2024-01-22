using System.Security.Claims;
using AutoMapper;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Models;
namespace WebApi.Business.AccountOperations.Commands
{
    public class CreateAccountCommand
    {
        public AccountModelRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAccountCommand(emsDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Handle()
        {
            // Kullanıcının kimliğini çıkart
            string userIdstr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(userIdstr);


            var account = _dbContext.Accounts.SingleOrDefault(e => e.AccountNumber == Model.AccountNumber
                                                            && e.EmployeeId == userId); //değiştirilcek bu kontrol
            if (account is not null)
            {
                throw new InvalidOperationException("Expence already exists");
            }
            account = _mapper.Map<Account>(Model);
            account.EmployeeId = userId;
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

    }


}