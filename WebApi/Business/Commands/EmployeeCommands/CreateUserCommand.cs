using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.Data.Entities;

namespace WebApi.Business.Commands.UserCommands
{
    public class CreateUserCommand
    {   
        public CreateUserModelRequest Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(emsDbContext dbContext,IMapper mapper)
        {   _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _dbContext.Employees.SingleOrDefault(e => e.UserName == Model.UserName); //değiştirilcek bu kontrol
            if (user is not null)
            {
                throw new InvalidOperationException("Employee already exists");
            }
            user = _mapper.Map<Employee>(Model);
            _dbContext.Employees.Add(user);
            _dbContext.SaveChanges();
        }





    }




        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string Email { get; set; }
        // public string ExpenceRole {get; set; }


}