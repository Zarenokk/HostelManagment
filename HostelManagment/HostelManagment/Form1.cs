using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rooms Myroom = new Rooms();
            Myroom.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clients Myclients = new Clients();
            Myclients.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Employee Myemployee = new Employee();
            Myemployee.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fees Myfees = new Fees();
            Myfees.Show();
            this.Hide();
        }

       
    }
}
