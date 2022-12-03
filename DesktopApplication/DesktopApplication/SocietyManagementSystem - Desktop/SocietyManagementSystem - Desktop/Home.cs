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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void EventsButton_Click_1(object sender, EventArgs e)
        {
            Events ev = new Events();
            this.Hide();
            ev.ShowDialog();
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

        private void HomeButton_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "ACM";
            this.Hide();
            soc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "ACM-W";
            this.Hide();
            soc.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "DECS";
            this.Hide();
            soc.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "SPORTICS";
            this.Hide();
            soc.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "GDSC";
            this.Hide();
            soc.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "TLC";
            this.Hide();
            soc.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "TNC";
            this.Hide();
            soc.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Society soc = new Society();
            soc.societyName = "WEB MASTER";
            this.Hide();
            soc.ShowDialog();
        }
    }
}
