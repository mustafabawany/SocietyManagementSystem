using System;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SocietyManagementSystem.Models;


namespace SocietyManagementSystem.Controllers
{
    [Authorize]


    public class RegistrationController : Controller
    {
        // GET: Registration

        //Set the base url
        string Baseurl = "https://localhost:7071/";
        EventAndRegistrationParent eventAndRegistrationParent = new EventAndRegistrationParent();

        //GET REQUEST.
        public async Task<ActionResult> Index(string Id)
        {
            ViewBag.id = Id;
            EventInfo _eventInfo = new EventInfo();

            using (var httpClient = new HttpClient())
            {
                // Passing service base url
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();

                //Define request data format
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await httpClient.GetAsync("api/Registration/FindById?Id=" + Id);

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _eventInfo = JsonConvert.DeserializeObject<EventInfo>(apiResponse);
                    eventAndRegistrationParent._EventInfo = _eventInfo;
                }
            }

            return View(eventAndRegistrationParent);
        }


        [HttpPost]
        public async Task<ActionResult> Index(EventAndRegistrationParent obj)
        {

            var json = new
            { 
                obj._EventRegistration.studentId,
                obj._EventRegistration.firstName,
                obj._EventRegistration.lastName,
                obj._EventRegistration.eventId
            };

            //POST DATA TO /api/Registration
            using (var httpClient = new HttpClient())
            {
 
                var jsonItem = JsonConvert.SerializeObject(json);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient

                HttpResponseMessage Res = await httpClient.PostAsync("https://localhost:7071/api/Registration", content);
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    //return Content(apiResponse);
                }

            }
            return View();
                




        }


    }
}