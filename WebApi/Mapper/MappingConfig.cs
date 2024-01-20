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
            CreateMap<Employee,CreateEmployeeModelRequest>();
            CreateMap<CreateEmployeeModelRequest,Employee>();
            
            CreateMap<Employee,GetEmployeeModelResponse>();
            CreateMap<GetEmployeeModelResponse,Employee>();

            CreateMap<Expense, CreateExpenseModelRquest>();
            CreateMap<CreateExpenseModelRquest, Expense>();

             CreateMap<Expense, GetExpenseModelResponse>();
            CreateMap<GetExpenseModelResponse, Expense>();

            CreateMap<UpdateExpenseModelRquest,Expense>();
            CreateMap<Expense,UpdateExpenseModelRquest>();

            CreateMap<Account, AccountModelRequest>();
            CreateMap<AccountModelRequest, Account>();

            CreateMap <Account,AccountModelResponse>();
            CreateMap <AccountModelResponse,Account>();

            
        }

    }
}