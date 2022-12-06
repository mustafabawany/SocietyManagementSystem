using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using SocietyManagementSystem___Desktop.Model;

namespace SocietyManagementSystem___Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            // Add login functionality here, have to take user and password and then switch to next screen else give error
            var username = Username.Text;
            var password = Password.Text;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://society-management-api.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                Student student = new Student()
                {
                    StudentId = username,
                    Password = password
                };

                var data = JsonConvert.SerializeObject(student);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/Student/Login",content);

                
                if (response.IsSuccessStatusCode)
                {
                    Home homepage = new Home();
                    this.Hide();
                    homepage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password Incorrect.");
                    this.Hide();
                    Login loginpage = new Login();
                    loginpage.ShowDialog();
                }
            }
        }
    }
}
