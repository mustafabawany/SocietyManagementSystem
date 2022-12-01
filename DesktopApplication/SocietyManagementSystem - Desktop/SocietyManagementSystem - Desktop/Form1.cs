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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Add login functionality here, have to take user and password and then switch to next screen else give error
            var username = Username.Text;
            var password = Password.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Invalid Credentials", "Error");
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                this.Hide();
                Home form = new Home();
                form.ShowDialog();
            }
             
        }
    }
}
