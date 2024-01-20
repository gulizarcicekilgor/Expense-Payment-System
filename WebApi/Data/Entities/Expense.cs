using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class Expense
    {
        [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int ExpenceId { get; set; }
        public string ExpenseCode { get; set; }
        public int? EmployeeId {get; set; }
        public double? Amount {get; set; }
        public string? Currency {get; set; }
        public string? Description {get; set; }

        [DefaultValue("Pending Approval")]
        public string? ExpenseStatus{get; set; } // Pending Approval,Approved,Rejected

        public virtual List<Employee>? Employees { get; set; }

    }
}