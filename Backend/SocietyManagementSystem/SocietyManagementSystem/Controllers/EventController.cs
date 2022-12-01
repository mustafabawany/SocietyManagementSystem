using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Data;
using SocietyManagementSystem.Models.Entities;
using System.Net;

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

        [HttpPost]
        [Route("Add/")]
        public async Task<IActionResult> AddEvent(EventsViewModel eventViewModel)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();

            try
            {
                eventViewModel.EventId = Guid.NewGuid();
                var _event = new Event
                {
                    EventId = eventViewModel.EventId,
                    Name = eventViewModel.Name,
                    Event_Type = eventViewModel.Event_Type,
                    Guest_name = eventViewModel.Guest_name,
                    Venue = eventViewModel.Venue,
                    Date_Time = eventViewModel.Date_Time,
                    SocietyName = eventViewModel.SocietyName
                };

                await SocietyDbContext.Events.AddAsync(_event);
                await SocietyDbContext.SaveChangesAsync();
                string message = ($"New Event Added - {_event.EventId}");

                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            catch (Exception ex)
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, ex.ToString());
            }

            return Ok(returnMessage);
        }

        [HttpPost]
        [Route("Delete/")]
        public async Task<IActionResult> DeleteEvent([FromRoute] Guid EventId)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();

            try
            {
                var existingEvent = await SocietyDbContext.Events.FindAsync(EventId);
                
                if (existingEvent == null)
                {
                    return NotFound();
                }
                
                SocietyDbContext.Events.Remove(existingEvent);
                await SocietyDbContext.SaveChangesAsync();
                string message = ($"Event Deleted");

                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            catch (Exception ex)
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, ex.ToString());
            }

            return Ok(returnMessage);
        }

        [HttpPut]
        [Route("Update/")]
        //No need of GUID EventID in Route Param
        
        public async Task<IActionResult> UpdateEvent( [FromBody] EventsViewModel eventViewModel)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            try
            {
                var existingEvent = await SocietyDbContext.Events.FindAsync(eventViewModel.EventId);

                if (existingEvent == null)
                {
                    return NotFound();
                }

                existingEvent.Name = eventViewModel.Name;
                existingEvent.Event_Type = eventViewModel.Event_Type;
                existingEvent.Venue = eventViewModel.Venue;
                existingEvent.Guest_name = eventViewModel.Guest_name;
                existingEvent.Date_Time = eventViewModel.Date_Time;

                await SocietyDbContext.SaveChangesAsync();
                
                string message = ($"Event Updated");

                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            catch (Exception ex)
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, ex.ToString());
            }

            return Ok(returnMessage);
        }
    }
}
