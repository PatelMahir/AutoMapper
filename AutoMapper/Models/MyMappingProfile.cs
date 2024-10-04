using Auto_Mapper_Program.Models;
using AutoMapper;
namespace AutoMapper.Models
{
    public class MyMappingProfile:Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ForMember(dest=>dest.FullName,
                act=>act.MapFrom(src=>src.Name)).ForMember(dest=>dest.EmailId,
                act=>act.MapFrom(src=>src.Email));
            CreateMap<EmployeeDTO, Employee>().ForMember(dest => dest.Name, 
                act => act.MapFrom(src => src.FullName)).ForMember(dest => dest.Email, 
                act => act.MapFrom(src => src.EmailId));
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}