using AutoMapper;
using WebApi.Data.Entities;
using WebApi.Models;
using WebApi.TokenOperations;
namespace WebApi.Mapper
{
    public class MappingConfig : Profile //AutoMapperden gelen profile
    {
        public MappingConfig()
        {
                      //kaynak obje, değiştitiecek obje
            CreateMap<Employee,CreateEmployeeModelRequest>();
            CreateMap<CreateEmployeeModelRequest,Employee>();
            
            CreateMap<Employee,GetEmployeeModelResponse>();
            CreateMap<GetEmployeeModelResponse,Employee>();

            CreateMap<Expense, CreateExpenseModelRquest>();
            CreateMap<CreateExpenseModelRquest, Expense>();

             CreateMap<Expense, GetExpenseModelResponse>();
            CreateMap<GetExpenseModelResponse, Expense>();
            
        }

    }
}