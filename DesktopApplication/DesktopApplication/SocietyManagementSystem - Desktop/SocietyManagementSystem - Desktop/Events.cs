using Newtonsoft.Json;
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
using System.Reflection;
using SocietyManagementSystem___Desktop.Model;

namespace SocietyManagementSystem___Desktop
{
    public partial class Events : Form
    {

        Guid EventID; 
        public Events()
        {
            InitializeComponent();
        }

    
        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
        }

        private void SocietiesButton_Click_1(object sender, EventArgs e)
        {
            Society soc = new Society();
            this.Hide();
            soc.ShowDialog();
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void EventsButton_Click(object sender, EventArgs e)
        {

        }

        private async void Events_Load(object sender, EventArgs e)
        {
            string Baseurl = "https://society-management-api.azurewebsites.net/";

            List<EventsInfo> _tempEventInfo = new List<EventsInfo>();
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
                    _tempEventInfo = JsonConvert.DeserializeObject<List<EventsInfo>>(apiResponse);
                }      
            }

            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;

            foreach (var item in _tempEventInfo)
            {
                if (item.Date_Time >= DateTime.Now)
                {
                    EventID = item.EventId;
                    Type1.Text = item.Event_Type;
                    Title1.Text = item.Name;
                    Guest1.Text = item.Guest_name;
                    Venue1.Text = item.Venue;
                    Date1.Text = item.Date_Time.ToString("dd MMMM yyyy h:mm tt");
                    flag3 = true;
                }
                else
                {
                    if (flag1 == false)
                    {
                        Type2.Text = item.Event_Type;
                        Title2.Text = item.Name;
                        Guest2.Text = item.Guest_name;
                        Venue2.Text = item.Venue;
                        Date2.Text = item.Date_Time.ToString("dd MMMM yyyy h:mm tt");
                        flag1 = true;
                    }
                    else if (flag1 == true && flag2 == false)
                    {
                        Type3.Text = item.Event_Type;
                        Title3.Text = item.Name;
                        Guest3.Text = item.Guest_name;
                        Venue3.Text = item.Venue;
                        Date3.Text = item.Date_Time.ToString("dd MMMM yyyy h:mm tt");
                        flag2 = true;
                    }

                    if (flag1 == true && flag2 == true && flag3 == true)
                    {
                        break;
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EventsInfo ev = new EventsInfo()
            {
                EventId = this.EventID,
                Event_Type = Type1.Text,
                Name = Title1.Text,
                Guest_name = Guest1.Text,
                Date_Time = Convert.ToDateTime(Date1.Text),
                Venue = Venue1.Text,
                SocietyName = Society1.Text
            };

            Registration reg = new Registration();
            this.Hide();
            reg.EventDetails(ev);
            reg.ShowDialog();
        }

  
    }
}
