using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> GetSpecificStudentData(string Id)
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
        [HttpPost]
        [Route("Login")]
        //https://localhost:7071/api/Student/Login
        public async Task<IActionResult> Authentication(LoginViewModel viewmodel)
        {
            string _Id = viewmodel.StudentId;
            var _info = await SocietyDbContext.Students.FindAsync(_Id);
            if (_info != null)
            {
                if (_info.Password == viewmodel.Password)
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

        [HttpGet("GetAdmin")]
        public async Task<IActionResult> IsAdmin(string _Id)
        {
            var isAdmin = SocietyDbContext.Societies.Where(x => x.Vice_president_id == _Id || x.President_id == _Id || x.Gs_id == _Id || x.Treasurer_id == _Id);

            if (isAdmin.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                return Ok("IsAdmin");
            }
        }





    }
}

