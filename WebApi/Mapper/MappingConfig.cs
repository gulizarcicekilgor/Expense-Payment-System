using AutoMapper;
using WebApi.Data.Entities;
using WebApi.Models;
namespace WebApi.Mapper
{
    public class MappingConfig : Profile //AutoMapperden gelen profile
    {
        public MappingConfig()
        {
                      //kaynak obje, değiştitiecek obje
            CreateMap<Employee, EmployeeLoginModel>();
            CreateMap<Employee,CreateEmployeeModelRquest>();
            CreateMap<CreateEmployeeModelRquest,Employee>();
            CreateMap<Employee,GetEmployeeModelResponse>();
            CreateMap<GetEmployeeModelResponse,Employee>();
            
            
        }

    }
}