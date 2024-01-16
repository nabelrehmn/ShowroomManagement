using Microsoft.AspNetCore.Mvc;

namespace ShowroomManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
