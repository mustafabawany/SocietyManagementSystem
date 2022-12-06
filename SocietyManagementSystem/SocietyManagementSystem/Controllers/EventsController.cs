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
        string Baseurl = "https://society-management-api.azurewebsites.net/";

        //Get all events data 
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

        //Get particular society Event to display on that Table .
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

                HttpResponseMessage Res = await httpClient.GetAsync("api/Event/GetDataById?Id="+User.Identity.Name);

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _specificSocietyEvent = JsonConvert.DeserializeObject<List<EventInfo>>(apiResponse);

                }

               
            }
            return View(_specificSocietyEvent);
        }

        public ActionResult UpdateEvent(Guid eventId)
        {
            TempData["ID"] = eventId;
            ViewBag.id = eventId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEvent(string Name, string Guest_name, string Venue, string Event_Type, string SocietyName, DateTime Date_Time)
        {
            EventInfo UpdatedEvent = new EventInfo();
            //Set the values to the Updated Object and send to backend.
            UpdatedEvent.Venue=Venue;
            UpdatedEvent.Guest_name=Guest_name;
            UpdatedEvent.Name =Name;
            UpdatedEvent.Date_Time=Date_Time;
            UpdatedEvent.Event_Type=Event_Type;
            UpdatedEvent.SocietyName=SocietyName;

            //Typecast string to GUID.
            UpdatedEvent.EventId = (Guid)TempData["ID"]; //or 
            //return Content(TempData["ID"].ToString());

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(UpdatedEvent);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await httpClient.PutAsync("api/Event/Update", content);
                return Content(Res.StatusCode.ToString()); 
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;

                }

            }
            //return View();
        }
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(string Name, string Guest_name, string Venue, string Event_Type, string SocietyName, DateTime Date_Time)
        {
            EventInfo UpdatedEvent = new EventInfo();

            UpdatedEvent.SocietyName = SocietyName;
            UpdatedEvent.Name = Name;
            UpdatedEvent.Venue = Venue;
            UpdatedEvent.Guest_name = Guest_name;
            UpdatedEvent.Event_Type = Event_Type;
            UpdatedEvent.Date_Time= Date_Time;
                
            var apiResponse = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);

                var jsonItem = JsonConvert.SerializeObject(UpdatedEvent);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient

                HttpResponseMessage Res = await httpClient.PostAsync("api/Event/Add", content);
                return Content(Res.StatusCode.ToString());

                if (Res.IsSuccessStatusCode)
                {
                     apiResponse = Res.Content.ReadAsStringAsync().Result;
                }

            }
            //return Content(apiResponse.ToString());

            //return View();

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