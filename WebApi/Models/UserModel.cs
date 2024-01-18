namespace WebApi.Models
{
    public class CreateUserModelRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

    }
    public class CreateUserModelResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

    }

  


}
