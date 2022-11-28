using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementSystem.Controllers
{
    public class FinanceDepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
