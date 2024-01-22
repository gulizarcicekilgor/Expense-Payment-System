using WebApi.Data;
namespace WebApi.Business.UserOperations.Commands
{
    public class DeleteEmployeeCommand
    {
        private readonly emsDbContext _dbContext;
        public int EmployeId { get; set; }

        public DeleteEmployeeCommand(emsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var employee = _dbContext.Employees.SingleOrDefault(x => x.EmployeeId == EmployeId);
           
            if (employee is null)
                throw new InvalidOperationException("this Employee does not exist");
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}