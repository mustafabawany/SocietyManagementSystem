using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Data;
using SocietyManagementSystem.Models.Entities;

namespace SocietyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {

        //TASK TODO: BAWANY SCREEN.
        //Get all Societies information . 
        //and print it on EVENTS page.
        private readonly SocietyManagementDbContext SocietyDbContext;
        public EventController(SocietyManagementDbContext SocietyDbContext) 
        {
            this.SocietyDbContext = SocietyDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //GET ALL STUDENT INFO FROM DB
            return Ok(await SocietyDbContext.Events.ToListAsync());

        }

        //[HttpPost]

        //public async Task<IActionResult> AddEvent(AddEventsViewModel itemviewmodel)
        //{
        //    //itemviewmodel.EventId = Guid.NewGuid();
        //    //var query = SocietyDbContext.Societies.Where(s => s.Name == itemviewmodel.SocietyName).Select(s => new { s.SocietyId });
        //    //var item = new Event
        //    //{
        //    //    EventId = itemviewmodel.EventId,
        //    //    Name = itemviewmodel.Name,
        //    //    Event_Type = itemviewmodel.Event_Type,
        //    //    Guest_name = itemviewmodel.Guest_name,
        //    //    Venue = itemviewmodel.Venue,
        //    //    Date_Time = itemviewmodel.Date_Time,
        //    //    //SocietyId = query
        //    //};
            
            

        //    //var query = SocietyDbContext.Societies.Where(s => s.Name == SocietyName).Select(s => new {s.SocietyId});
        //    //SocietyDbContext.Events.FromSql($"insert into Events (EventId , Name, Guest_name, Venue, Date_Time, Society_id) VALUES ({EventId},{Name} , {Guest_Name} , {Venue} , {Date} , {query})");
        //    //SocietyDbContext.SaveChangesAsync();

        //    return Ok(query); 
        //}
    }
}
