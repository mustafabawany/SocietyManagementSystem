using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocietyManagementSystem.Model;

namespace SocietyManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        SocietyMangementEntities1 _db = new SocietyMangementEntities1();
        // GET: Events
        public ActionResult Index()
        {
            ViewData.Model = _db.Event.ToList();
            return View();
        }
    }
}