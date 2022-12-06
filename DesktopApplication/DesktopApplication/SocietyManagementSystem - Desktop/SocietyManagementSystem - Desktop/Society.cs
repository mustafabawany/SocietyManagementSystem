using Newtonsoft.Json;
using SocietyManagementSystem___Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocietyManagementSystem___Desktop
{
    public partial class Society : Form
    {
        public string societyName { get; set; }
        public Society()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
        }

        private void EventsButton_Click(object sender, EventArgs e)
        {
            Events ev = new Events();
            this.Hide();
            ev.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void SocietiesButton_Click(object sender, EventArgs e)
        {

        }

        private async void Society_Load(object sender, EventArgs e)
        {
            string Baseurl = "https://society-management-api.azurewebsites.net/";

            List<SocietyHierarchy> _tempSocietyDetails = new List<SocietyHierarchy>();

            using (var httpClient = new HttpClient())
            {
                // Passing service base url
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();

                //Define request data format
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await httpClient.GetAsync("api/Society?SocietyName="+societyName);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var apiResponse = Res.Content.ReadAsStringAsync().Result;
                    _tempSocietyDetails = JsonConvert.DeserializeObject<List<SocietyHierarchy>>(apiResponse);
                }

                foreach (var item in _tempSocietyDetails)
                {
                    if (item.position == "Faculty Head")
                    {
                        FacultyName.Text = item.name;
                    }
                    else if (item.position == "Faculty Co Head")
                    {
                        CoFacultyName.Text = item.name;
                    }
                    else if (item.position == "President")
                    {
                        PresidentName.Text = item.name;
                    }
                    else if (item.position == "Vice President")
                    {
                        VicePresidentName.Text = item.name;
                    }
                    else if (item.position == "General Secretary")
                    {
                        GSName.Text = item.name;
                    }
                    else if (item.position == "Treasurer")
                    {
                        TreasurerName.Text = item.name;
                    }
                }
            }
         }
    }
}
