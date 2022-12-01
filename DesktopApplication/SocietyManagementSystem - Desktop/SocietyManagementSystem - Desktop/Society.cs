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
    public partial class Society : Form
    {
        public Society()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Events ev = new Events();
            this.Hide();
            ev.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            this.Hide();
            setting.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
    }
}
