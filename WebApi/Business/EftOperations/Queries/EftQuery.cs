using System.Security.Claims;
using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.EftOperations.Queries
{
    public class EftQuery
    {
        public EftTransactionResponseEmployee Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EftQuery(emsDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public List<EftTransactionResponseEmployee> GetMyEfts()
        {
            // Kullanıcının ID'sini al
            string userIdStr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(userIdStr, out int userId))
            {
                // Kullanıcının hesabını bul
                var userAccount = _dbContext.Accounts.FirstOrDefault(a => a.EmployeeId == userId);

                if (userAccount != null)
                {
                    // Kullanıcının hesabına ait EFT işlemlerini bul
                    var userEfts = _dbContext.EftTransactions
                        .Where(eft => eft.AccountId == userAccount.AccountId)
                        .ToList();

                    // EFT işlemlerini EftTransactionResponse sınıfına dönüştür
                    List<EftTransactionResponseEmployee> eftResponses = _mapper.Map<List<EftTransactionResponseEmployee>>(userEfts);

                    return eftResponses;
                }
                else
                {
                    // Kullanıcının hesabı bulunamadı durumuyla başa çıkma
                    throw new InvalidOperationException($"UserID {userId} için hesap bulunamadı.");
                }
            }
            else
            {
                // Geçersiz kullanıcı ID durumuyla başa çıkma
                throw new InvalidOperationException("Geçersiz kullanıcı ID.");
            }
        }

    }
}