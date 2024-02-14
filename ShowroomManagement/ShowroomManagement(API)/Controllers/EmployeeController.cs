using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagement_API_.DTOs;
using ShowroomManagement_API_.Repositories;
using System.Text.Json.Serialization;

namespace ShowroomManagement_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee Service;
        public EmployeeController(IEmployee _Service)
        {
            this.Service = _Service;
        }

        [HttpPost("AddEmployees")]
        public async Task<string> AddEmployee([FromForm]EmployeeDTO EmployeeDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddEmployee(EmployeeDTO));
        }

        [HttpGet("DeleteEmployees")]
        public async Task<string> DeleteEmployee(int ID)
        {
            return JsonConvert.SerializeObject(await Service.DeleteEmployee(ID));
        }

        [HttpGet("UpdateEmployees")]
        public async Task<string> UpdateEmployee([FromForm] EmployeeDTO EmployeeDTO)
        {
            return JsonConvert.SerializeObject(await Service.UpdateEmployee(EmployeeDTO));
        }
    }
}


