namespace WebApi.Models
{
    public class CreateExpenseModelRquest
    {
        public string ExpenseCode { get; set; }
        public double Amount {get; set; }
        public string Currency {get; set; }
        public string Description {get; set; }


    }
    public class UpdateExpenseModelRquest
    {
         public string ExpenseStatus {get; set;}
    }
     public class GetExpenseModelResponse
    {
        public int EmployeeId {get; set; }
        public string ExpenseCode { get; set; }
        public double Amount {get; set; }
        public string Currency {get; set; }
        public string Description {get; set; }
        public string ExpenseStatus {get; set;}= "Pending Approval";// Pending Approval,Approved,Rejected


    }
}