using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class Account
    {   [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int AccountId { get; set; }
        public string IBAN { get; set; }
        public double Balance { get; set; }
        public string AccountName { get; set; }
        public string CurrencyType { get; set; }
        public int EmployeeId { get; set;}
    }
}