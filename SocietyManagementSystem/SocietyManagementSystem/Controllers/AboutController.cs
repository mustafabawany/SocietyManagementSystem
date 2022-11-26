using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocietyManagementSystem.Controllers
{
    public class AboutController : Controller
    {

        // GET: About
        public ActionResult Index(string id)
        {
          
            ViewBag.id = id;

            return View();
        }
    }
}