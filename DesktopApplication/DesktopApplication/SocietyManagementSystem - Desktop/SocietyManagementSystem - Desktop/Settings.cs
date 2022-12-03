using SocietyManagementSystem___Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocietyManagementSystem___Desktop
{
    public partial class Settings : Form
    {
        private Student loggedin;
        public Settings()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog(); 
        }

        private void SocietiesButton_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            this.Hide();
            soc.ShowDialog();
        }

        private void EventsButton_Click(object sender, EventArgs e)
        {
            Events ev = new Events();
            this.Hide();
            ev.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
        }
        
        public void Get_Student(Student student)
        {
            loggedin = student;
            MessageBox.Show(loggedin.StudentId);
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            Username.Text = "Hello";
            Username.ReadOnly = true;
            Username.Enabled = false;
            Password.Text = this.loggedin.Password;
        }
    }
}
