using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.TokenOperations;

namespace WebApi.Business.Commands.TokenCommands
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(emsDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.UserName == Model.UserName && e.Password == Model.Password); 
            if (employee is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(employee);

                employee.RefreshToken = token.RefreshToken;
                employee.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;

            }
            else
                throw new InvalidOperationException("Kullanıcı adı, şifre hatalı");

        }





    }




    // public string FirstName { get; set; }
    // public string LastName { get; set; }
    // public string Email { get; set; }
    // public string ExpenceRole {get; set; }


}