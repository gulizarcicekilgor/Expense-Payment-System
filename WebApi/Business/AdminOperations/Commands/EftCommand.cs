using AutoMapper;
using WebApi.Data;
using static WebApi.Models.EftModel;


namespace WebApi.Business.EmployeeOperations.Commands
{
    public class EftCommand
    {
        public EftTransactionRequest Model { get; set; }
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EftCommand(emsDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Handle()
        {
            //expens apply olan müşteri id si lazım
            





        }


    }


}