using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var Data = await Service.GetDepartments();
            var ConvertData = JsonConvert.SerializeObject(Data);
            return ConvertData;
        }
    }
}