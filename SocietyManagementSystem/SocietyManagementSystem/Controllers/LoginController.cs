using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocietyManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Login(FormCollection collection)
        {
            //Method 2: Using Component Index Position
            //ViewData["StudentID"] = collection[1];
            //ViewData["Name"] = collection[2];
            //FormsAuthentication.SetAuthCookie("Ahsan",);
            return View();
        }

    }
}