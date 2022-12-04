
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using SocietyManagementSystem.Models;

namespace SocietyManagementSystem.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        string Baseurl = "https://localhost:7071/";
        // GET: SOCIETY HIERARCHY 
        public async Task<ActionResult> Index(string id)
        {
          
            ViewBag.id = id;
            List<SocietyHierarchy> _tempSocietyDetails = new List<SocietyHierarchy>();

            using (var httpClient = new HttpClient())
            {
                // Passing service base url
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();

                //Define request data format
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await httpClient.GetAsync("api/Society?SocietyName=" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _tempSocietyDetails = JsonConvert.DeserializeObject<List<SocietyHierarchy>>(apiResponse);
                    //return Content(apiResponse);
                    
                }
            }

            return View(_tempSocietyDetails);
        }
    }
}