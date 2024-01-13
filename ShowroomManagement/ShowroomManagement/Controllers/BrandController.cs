using Microsoft.AspNetCore.Mvc;

namespace ShowroomManagement.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
