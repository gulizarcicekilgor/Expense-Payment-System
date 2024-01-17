using System.Linq;
using AutoMapper;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Business.Queries
{
    public class GetEmployeeQuery
    {   
        public GetEmployeeModelResponse Model {get; set;}
        private readonly emsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeQuery(emsDbContext dbContext,IMapper mapper)
        {   
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetEmployeeModelResponse> Handle()
        {
            var employeeList = _dbContext.Employees
            .OrderBy(x => x.EmployeeId).ToList();
            List<GetEmployeeModelResponse> Model = _mapper.Map<List<GetEmployeeModelResponse>>(employeeList);
            return Model;
        }
    }
}