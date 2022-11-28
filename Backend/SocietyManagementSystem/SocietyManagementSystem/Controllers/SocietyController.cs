using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocietyManagementSystem.Data;
using System.Linq;

namespace SocietyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocietyController : Controller
    {
        //TASK TODO  AJAR SCREEN :
        //GET ALL SOCIETIES (SPECIFICALLY THEIR NAME AND IMAGE URL TO PRINT IT ON HOME PAGE , BAQI DATA IS FUZOOL. ) 


        //TASK TODO AHSAN HIERARCHY SCREEN : 
        //I WILL GET THE NAME OF SOCIETY FROM FRONTEND URL.
        //I WILL FETCH THE DATA OF THAT PARTICULAR SOCIETY AND GET ALL THE STUDENT IDS(P_ID,GS_ID)
        // AND HIT THE FOREIGN KEYS TO STUDENT TABLE AND GET STUDENT DETAILS AND PRINT IT OUT.

        private readonly SocietyManagementDbContext SocietyDbContext;

        public SocietyController(SocietyManagementDbContext SocietyDbContext)
        {

            this.SocietyDbContext = SocietyDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index(string SocietyName)
        {
            var query = from S in SocietyDbContext.Societies
                        join
                        Std in SocietyDbContext.Students on
                        S.President_id equals Std.StudentId
                        where S.Name == SocietyName
                        select new
                        {
                            id = S.SocietyId,
                            societyName = S.Name,
                            Name = Std.Name,
                            Position = "President"
                        };

            var query2 = from S in SocietyDbContext.Societies
                        join
                        Std in SocietyDbContext.Students on
                        S.Vice_president_id equals Std.StudentId
                         where S.Name == SocietyName
                         select new
                        {
                            id = S.SocietyId,
                            societyName = S.Name,
                            Name = Std.Name,
                            Position = "Vice President"
                        };

            var query3 = from S in SocietyDbContext.Societies
                         join
                         Std in SocietyDbContext.Students on
                         S.Treasurer_id equals Std.StudentId
                         where S.Name == SocietyName
                         select new
                         {
                             id = S.SocietyId,
                             societyName = S.Name,
                             Name = Std.Name,
                             Position = "Treasurer"
                         };

            var query4 = from S in SocietyDbContext.Societies
                         join
                         Std in SocietyDbContext.Students on
                         S.Gs_id equals Std.StudentId
                         where S.Name == SocietyName
                         select new
                         {
                             id = S.SocietyId,
                             societyName = S.Name,
                             Name = Std.Name,
                             Position = "General Secretary"
                         };

            var query5 = from S in SocietyDbContext.Societies
                         join
                         Std in SocietyDbContext.Teachers on
                         S.Faculty_head_id equals Std.TeacherId
                         where S.Name == SocietyName
                         select new
                         {
                             id = S.SocietyId,
                             societyName = S.Name,
                             Name = Std.Name,
                             Position = "Faculty Head"
                         };

            var query6 = from S in SocietyDbContext.Societies
                         join
                         Std in SocietyDbContext.Teachers on
                         S.Faculty_cohead_id equals Std.TeacherId
                         where S.Name == SocietyName
                         select new
                         {
                             id = S.SocietyId,
                             societyName = S.Name,
                             Name = Std.Name,
                             Position = "Faculty Co Head"
                         };
            var result = query.Union(query2).Union(query3).Union(query4).Union(query5).Union(query6);
            
            return Ok(result);

        }

    }
}
