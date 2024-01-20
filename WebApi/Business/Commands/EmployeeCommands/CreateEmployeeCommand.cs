using AutoMapper;
using WebApi.Data;
using WebApi.Models;
using WebApi.Data.Entities;

namespace WebApi.Business.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand
    {   
        public CreateEmployeeModelRequest Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateEmployeeCommand(emsDbContext dbContext,IMapper mapper)
        {   _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var employee = _dbContext.Employees.SingleOrDefault(e => e.IdentityNumber == Model.IdentityNumber);
            if (employee is not null)
            {
                throw new InvalidOperationException("Employee already exists");
            }
            employee = _mapper.Map<Employee>(Model);
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        





    }




        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string Email { get; set; }
        // public string EmployeeRole {get; set; }


}