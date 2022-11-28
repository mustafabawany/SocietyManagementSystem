using Microsoft.AspNetCore.Mvc;
using SocietyManagementSystem.Data;
using SocietyManagementSystem.Models.Entities;

namespace SocietyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        public SocietyManagementDbContext _db; 

        public RegistrationController(SocietyManagementDbContext _db) 
        {
            this._db = _db; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            return Ok();
        }

        
    }
}
