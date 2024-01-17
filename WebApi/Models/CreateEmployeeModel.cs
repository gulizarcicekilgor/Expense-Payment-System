namespace WebApi.Models
{
    public class CreateEmployeeModel
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeRole {get; set; }

    }

}