namespace WebApi.Models
{
    public class CreateEmployeeModelRequest
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public string UserName { get; set; }
        public string Password { get; set; }
        public int IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Roles {get; set; }
    }
      public class UpdateEmployeeModelRequest
    {   
        public string LastName { get; set; }
         public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class GetEmployeeModelResponse
    {   
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Roles {get; set; }

    }
    public class UserLogin
{
    public string Email { get; set; }
    public string Password { get; set; }
}

}