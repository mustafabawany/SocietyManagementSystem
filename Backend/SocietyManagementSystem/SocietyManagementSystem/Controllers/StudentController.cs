using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Data;
using SocietyManagementSystem.Models.Entities;

namespace SocietyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        //Local private readonly prop.
        private readonly SocietyManagementDbContext SocietyDbContext;
        //Constructor injection of DBContext
        public StudentController(SocietyManagementDbContext SocietyDbContext)
        {

            this.SocietyDbContext = SocietyDbContext;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentData()
        {

            //GET ALL STUDENT INFO FROM DB
            return Ok(await SocietyDbContext.Students.ToListAsync());

        }

        //Api/controller/GetDataById?Id=xxx
        [HttpGet("GetDataById")]
        public async Task<IActionResult> GetSpecificStudentData(int Id)
        {

            //GET ALL STUDENT INFO FROM DB
            //return Ok(await SocietyDbContext.Students.FirstOrDefaultAsync(x=>x.StudentId==Id));

            var studentData = await SocietyDbContext.Students.FindAsync(Id);
            if (studentData == null)
            {
                return NotFound();
            }
            return Ok(studentData);

        }


        //Login Screen - > Check if student credentials exist in Students TABLE
        [HttpGet("{Id}/{password}")]
        public async Task<IActionResult> Authentication(string Id, string password)
        {

            var _Id = await SocietyDbContext.Students.FindAsync(Id);
            if (_Id != null)
            {
                if (_Id.Password == password)
                {
                    return Ok("Account Found");
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();

        }





    }
}

