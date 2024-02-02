using Microsoft.AspNetCore.Mvc;
using ShowroomManagement_API_.Repositories;

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

    }
}
