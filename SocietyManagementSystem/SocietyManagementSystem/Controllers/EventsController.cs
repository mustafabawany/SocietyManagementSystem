using Newtonsoft.Json;
using SocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocietyManagementSystem.Controllers
{
    //[Authorize]

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
            }

            return View(_tempEventInfo);
        }


    }
}