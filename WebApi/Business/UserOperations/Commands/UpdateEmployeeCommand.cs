using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.EmployeeOperations.Commands
{
    public class UpdateEmployeeCommand
    {   
        public UpdateEmployeeModelRequest Model {get; set;}
        private readonly emsDbContext _dbContext;
        public int EmployeeId {get; set;}

        public UpdateEmployeeCommand(emsDbContext dbContext)
        {   _dbContext = dbContext;
        }
        public void Handle()
        {//UpdateEmployeeModelRquest
            var employee = _dbContext.Employees.SingleOrDefault(e => e.EmployeeId == EmployeeId); //değiştirilcek bu kontrol
            if (employee is null)
            {
                throw new InvalidOperationException("There is no employee to update..");
            }
            employee.Email = Model.Email;
            employee.LastName = Model.LastName;
            employee.UserName = Model.UserName;
            employee.Password = Model.Password;
            _dbContext.SaveChanges();
        }

    }


}