using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class EftTransaction
    {
        [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int EftTransactionId { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public string? ReceiverAccount { get; set; }
        public string? SenderAccount { get; set; }
        public string? ReceiverIban { get; set; }
        public string? ReceiverName { get; set; }
        public int? AccountId { get; set; }
        public virtual List<Account>? Accounts { get; set; }
    }
}
