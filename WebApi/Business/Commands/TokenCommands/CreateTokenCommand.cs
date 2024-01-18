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
            var user = _dbContext.Users.FirstOrDefault(e => e.UserName == Model.UserName && e.Password == Model.Password); 
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
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