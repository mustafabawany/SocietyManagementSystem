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
        string Baseurl = "https://localhost:7071/";
        // GET: Login
        public ActionResult Login()
        {
            Login login = new Login();

            return View(login);
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(login);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient

                HttpResponseMessage Res = await httpClient.PostAsync("api/Student/Login/?", content);

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