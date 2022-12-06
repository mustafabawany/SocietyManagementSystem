using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SocietyManagementSystem___Desktop.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SocietyManagementSystem___Desktop
{
    public partial class Registration : Form
    {
        EventsInfo ev;
        public Registration()
        {
            InitializeComponent();
        }

        public void EventDetails(EventsInfo ev)
        {
            this.ev = ev;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            EventName.Text = ev.Name;
            Guest1.Text = ev.Guest_name;
            Society1.Text = ev.SocietyName;
            Venue1.Text = ev.Venue;
            Date1.Text = ev.Date_Time.ToString("dddd, dd MMMM yyyy h:mm tt");
        }

        private void SocietiesButton_Click_1(object sender, EventArgs e)
        {
            Society soc = new Society();
            this.Hide();
            soc.ShowDialog();

        }

        private void EventsButton_Click_1(object sender, EventArgs e)
        {
            Events ev = new Events();
            this.Hide();
            ev.ShowDialog();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home hom = new Home();
            this.Hide();
            hom.ShowDialog();
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var StudentId = StudentID.Text;
            var firstName = FirstName.Text;
            var lastName = LastName.Text;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://society-management-api.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                EventRegistration reg = new EventRegistration()
                {
                    studentId = StudentId,
                    eventId = ev.EventId,
                    firstName = firstName,
                    lastName = lastName
                };

                var data = JsonConvert.SerializeObject(reg);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/Registration/", content);


                if (response.IsSuccessStatusCode)
                {
                    Home homepage = new Home();
                    this.Hide();
                    MessageBox.Show("Registration Successful.");
                    homepage.ShowDialog();

                }
                else
                {
                    this.Hide();
                    MessageBox.Show("Registration Not Successful.");
                    Registration regi = new Registration();
                    regi.ShowDialog();
                }
            }
        }

    }
}
