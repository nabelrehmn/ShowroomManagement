using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagement_API_.Data;
using ShowroomManagement_API_.DTOs;
using ShowroomManagement_API_.Repositories;

namespace ShowroomManagement_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartment Service;
        public DepartmentController(IDepartment _Service)
        {
            this.Service = _Service;
        }

        [HttpGet("GetDepartments")]
        public async Task<string> GetDepartments()
        {
            return JsonConvert.SerializeObject(await Service.GetDepartments());
        }

        [HttpPost("AddDepartment")]
        public async Task<string> AddDepartment(DepartmentDTO DepartmentDTO)
        {
            return JsonConvert.SerializeObject(await Service.AddDepartment(DepartmentDTO));
        }
    }
}



