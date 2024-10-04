using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Auto_Mapper_Program.Models;
namespace Auto_Mapper_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private List<Category>listCategories=new List<Category>()
        {
            new Category { Id = 1, Name="Electronics",
               Products = new List<Product>
               {
                   new Product { Id = 1001, Name="Laptop", Description="Gaming Laptop", Price = 1000, CategoryId = 1},
                   new Product { Id = 1002, Name="Desktop", Description="Programming Desktop", Price = 2000, CategoryId = 1}
               }
            },
           new Category { Id = 2, Name="Appearl",
               Products = new List<Product>
               {
                   new Product { Id = 1003, Name="T-Shrt", Description="T-Shrt with V Neck", Price = 700, CategoryId = 2},
                   new Product { Id = 1004, Name="Jacket", Description="Winter Jacket", Price = 800, CategoryId = 2}
               }
           }
        };
        [HttpGet("categories")]
        public ActionResult<List<Category>> GetAllCategory()
        {
            List<CategoryDTO> categories = _mapper.Map<List<CategoryDTO>>(listCategories);
            return Ok(categories);
        }
    }
}