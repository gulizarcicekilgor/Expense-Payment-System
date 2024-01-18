namespace WebApi.Models
{
    public class CreateExpenseModelRquest
    {
        public int EmployeeId {get; set; }
        public double Amount {get; set; }
        public string Currency {get; set; }
        public string Description {get; set; }

    }
     public class GetExpenseModelResponse
    {

        public double Amount {get; set; }
        public string Currency {get; set; }
        public string Description {get; set; }

    }
}