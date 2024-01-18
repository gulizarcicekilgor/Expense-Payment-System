using WebApi.Data.Entities;

namespace WebApi.Models
{
    public class CreateEmployeeModelRequest
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeRole {get; set; }
    }
    public class GetEmployeeModelResponse
    {   
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeRole {get; set; }

    }

}