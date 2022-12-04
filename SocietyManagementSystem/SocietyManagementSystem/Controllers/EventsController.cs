using Newtonsoft.Json;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocietyManagementSystem.Controllers
{
    [Authorize]

    public class EventsController : Controller
    {
        

        //Set the base url
        string Baseurl = "https://localhost:7071/";
        public async Task<ActionResult>  Index()
        {

            List<EventInfo> _tempEventInfo = new List<EventInfo>();
            using (var httpClient = new HttpClient())
            {
                // Passing service base url
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();

                //Define request data format
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await httpClient.GetAsync("api/Event");

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _tempEventInfo = JsonConvert.DeserializeObject<List<EventInfo>>(apiResponse);


                }

                //Hit the backend again to check if the ID is admin or not . 
                HttpResponseMessage Res2 = await httpClient.GetAsync("api/Student/GetAdmin?_Id=" + User.Identity.Name);
                var apiResponse2 = Res2.Content.ReadAsStringAsync().Result;

                if (Res2.StatusCode.ToString() == "OK")
                {

                    ViewBag.isAdmin = "True";

                }
                else
                {
                    ViewBag.isAdmin = "False";

                }

            }

            return View(_tempEventInfo);
        }

        [HttpGet]
        public async Task<ActionResult> GetSocietyEvent()
        {
            List<EventInfo> _specificSocietyEvent = new List<EventInfo>();

            using (var httpClient = new HttpClient())
            {
                // Passing service base url
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await httpClient.GetAsync("api/Event/GetDataById?Id="+ User.Identity.Name);

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _specificSocietyEvent = JsonConvert.DeserializeObject<List<EventInfo>>(apiResponse);

                }

               
            }
            return View(_specificSocietyEvent);
        }

        public ActionResult UpdateEvent(string eventId)
        {
            TempData["ID"] = eventId;
            ViewBag.id = eventId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEvent(EventInfo UpdatedEvent)
        {
            UpdatedEvent.EventId = TempData["ID"].ToString();
            //return Content(TempData["ID"].ToString());
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(UpdatedEvent);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await httpClient.PutAsync("api/Event/Update", content);
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;

                }

            }
            return View();
        }
        public ActionResult AddEvent()
        {


            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddEvent(EventInfo UpdatedEvent)
        {
            var json = new
            {
                UpdatedEvent.SocietyName,
                UpdatedEvent.Name,
                UpdatedEvent.Venue,
                UpdatedEvent.Guest_name,
                UpdatedEvent.Event_Type,
                UpdatedEvent.Date_Time
            };
    
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(json);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient

                HttpResponseMessage Res = await httpClient.PostAsync("api/Event/Add", content);

                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    //return Content(apiResponse.ToString());
                }

            }
            return View();

        }

        //[HttpDelete]
        public async Task<ActionResult> DeleteEvent(string eventId)
        {
            string msg = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
        
                HttpResponseMessage Res = await httpClient.DeleteAsync("api/Event/DeleteById?EventId=" + eventId);
                
                if (Res.IsSuccessStatusCode)
                {
                    msg = Res.Content.ReadAsStringAsync().Result;
                
                }
            }

           return RedirectToAction("Index", "Home");

    
        }

       

    }
}