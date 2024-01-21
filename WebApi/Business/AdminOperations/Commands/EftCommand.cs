using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using static WebApi.Models.EftModel;


namespace WebApi.Business.EmployeeOperations.Commands
{
    public class EftCommand
    {
        public EftTransactionRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EftCommand(emsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //expens apply olan müşteri id si laz
        }
        public List<EftTransactionResponse> EmployeesTobePaid()
        {
            var expenses = _dbContext.Expenses
                .Where(e => e.ExpenseStatus == "approved")
                .ToList();

            List<EftTransactionResponse> eftResponses = new List<EftTransactionResponse>();


            foreach (var expenseResponse in expenses)
            {
                // Belirli bir EmployeeId'ye ait hesabı bul
                var account = _dbContext.Accounts.FirstOrDefault(a => a.EmployeeId == expenseResponse.EmployeeId);

                if (account != null)
                {
                    // Hesaptan ExpenseAmount kadar para transferi gerçekleştir
                    account.Balance += expenseResponse.Amount;

                    // İşlem gerçekleştirildikten sonra hesap bilgilerini güncelle
                    _dbContext.SaveChanges();
                    // EftTransactionResponse oluştur ve listeye ekle
                    var eftResponse = new EftTransactionResponse
                    {
                        AccountId = account.AccountId, // Burada AccountId'yi kullanabilirsiniz (Varsa)
                        ReferenceNumber = Guid.NewGuid().ToString(),
                        TransactionDate = DateTime.UtcNow,
                        Amount = (double)expenseResponse.Amount,
                        Description = expenseResponse.Description,
                        ReceiverAccount = account.AccountNumber.ToString(),
                        ReceiverIban = account.IBAN,
                        ReceiverName = account.AccountName
                    };

                    eftResponses.Add(eftResponse);
                }

                else
                {
                    // Hesap bulunamadı durumuyla başa çıkma
                    throw new InvalidOperationException($"EmployeeId {expenseResponse.EmployeeId} için hesap bulunamadı.");
                }
            }

            return eftResponses;



        }



    }


}