using Newtonsoft.Json;
using SocietyManagementSystem.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace SocietyManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        string Baseurl = "https://society-management-api.azurewebsites.net/";
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        
       


        [HttpPost]
        //Login login
        public async Task<ActionResult> Login(string studentId , string Password)
        {
            Login login = new Login();
            login.StudentId = studentId;
            login.Password = Password;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");


                HttpResponseMessage Res = await httpClient.PostAsync("api/Student/Login/", content);
                if (Res.StatusCode.ToString() =="NotFound")
                {
                    //var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    ModelState.AddModelError("CustomError", "Invalid Password or ID");
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(login.StudentId, false);

                    return RedirectToAction("Index","Home");


                }

            }
             
          
              
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }

}