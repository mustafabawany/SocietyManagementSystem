using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocietyManagementSystem.Data;
using SocietyManagementSystem.Models.Entities;
using System.Net;

namespace SocietyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        public SocietyManagementDbContext SocietyDbContext; 

        public RegistrationController(SocietyManagementDbContext SocietyDbContext) 
        {
            this.SocietyDbContext = SocietyDbContext; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            return Ok(await SocietyDbContext.Registrations.ToListAsync());

        }

        [HttpGet("FindById")]
        public async Task<IActionResult> GetEventDetails(Guid Id)
        {

            var eventData = await SocietyDbContext.Events.FindAsync(Id);
            if (eventData == null)
            {
                return NotFound();
            }
            return Ok(eventData);

        }

        [HttpPost]
        public async Task<IActionResult> PostRegistraion(Guid eventId, [FromBody] RegistrationViewModel model)
        {
            Registration _registration = new Registration();
            _registration.StudentId = model.StudentId;
            _registration.EventId = eventId;


            HttpResponseMessage returnMessage = new HttpResponseMessage();


            try
            {
                // add details to database;
                await SocietyDbContext.Registrations.AddAsync(_registration);
                await SocietyDbContext.SaveChangesAsync();
                string message = ($"New Registration Created - {_registration.RegistrationId}");


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