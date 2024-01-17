using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class Expences
    {
        [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int ExpencesId { get; set; }
        public int EmployeeId {get; set; }
        public double Amount {get; set; }
        public string Description {get; set; }
        public string ExpenseStatus{get; set; } // PendingApproval,Approved,Rejected

    }
}