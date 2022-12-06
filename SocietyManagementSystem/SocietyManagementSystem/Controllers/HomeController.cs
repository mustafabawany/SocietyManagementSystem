using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SocietyManagementSystem.Controllers
{
    [Authorize]


    public class HomeController : Controller
    {
        //[HttpGet("util/images/{:id}")]
        //public IActionResult getFile(string id) {
            
        //    using (FileStream fs = System.IO.File.Open(Path.Combine("/" , "utils" , "images" , id) , FileMode.Open, FileAccess.Read, FileShare.None))
        //    {
        //        MemoryStream stream = new MemoryStream();

        //        // Add some information to the file.
                

        //    }


        //    return File()
        //}

        public ActionResult Index()
        {
            

            return View();
        }

    }
}