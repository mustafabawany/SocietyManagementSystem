using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
