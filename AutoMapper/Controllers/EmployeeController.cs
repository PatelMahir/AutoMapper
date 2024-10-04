using AutoMapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper)
        {
            _mapper= mapper;
        }
        private List<Employee> listEmployees = new List<Employee>()
        {
            new Employee(){ Id = 1, Name = "Anurag", Age = 28, Salary=1000, Gender = "Male", Email = "Anurag@Example.com", SocialSecurityNumber="1234@Anurag" },
            new Employee(){ Id = 2, Name = "Pranay", Age = 30, Salary=2000, Gender = "Male", Email = "Pranaya@Example.com", SocialSecurityNumber="4567@Pranaya" }
        };
        [HttpGet]
        public ActionResult<List<EmployeeDTO>> GetEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            foreach(var employee in listEmployees)
            {
                EmployeeDTO emp = new EmployeeDTO()
                {
                    Id = employee.Id,
                    FullName = employee.Name,
                    Age = employee.Age,
                    Gender = employee.Gender,
                    EmailId = employee.Email,
                };
                employees.Add(emp);
            }
            return Ok(employees);
        }
        [HttpPost]
        public ActionResult<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            if(employee != null && employee.Id==0)
            {
                Employee emp = new Employee()
                {
                    Id=listEmployees.Count+1,
                    Name = employee.FullName,
                    Age = employee.Age,
                    Gender = employee.Gender,
                    Email = employee.EmailId,
                    Salary=3000,
                    SocialSecurityNumber=$"2356@{employee.FullName}"
                };
                listEmployees.Add(emp);
                employee.Id = emp.Id;
                return Ok(employee);
            }
            return BadRequest();
        }
    }
}