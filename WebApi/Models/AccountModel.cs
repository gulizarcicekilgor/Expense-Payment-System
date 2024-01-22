
namespace WebApi.Models
{
    public class AccountModelRequest
    {
        public int AccountNumber { get; set; }
        public string IBAN { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
        public string CurrencyType { get; set; }

        public static implicit operator AccountModelRequest(AccountupdatedModelRequest v)
        {
            throw new NotImplementedException();
        }
    }
    public class AccountupdatedModelRequest
    {
        public string AccountName { get; set; }
        public string CurrencyType { get; set; }
    }

    public class AccountModelResponse
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public string CurrencyType { get; set; }
        public string AccountName { get; set; }
      
    }

}