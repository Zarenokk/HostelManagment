using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HostelManagment
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cardi\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");
        void FillStudentDGV()
        {
            Con.Open();
            string myquery = "Select * from Student_tbl";
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            StudentDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        void FillRoomCombobox()
        {
            Con.Open();
            string query = "Select * from Room_tbl where RoomStatus = '"+"Active"+"' and Booked = '"+"Not booked"+"' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RoomNum", typeof(int));
            dt.Load(rdr);
            StudRoomCb.ValueMember = "RoomNum";
            StudRoomCb.DataSource = dt;

            Con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void updateBookedStatusOndelete()
        {
            Con.Open();
            string query = "update Room_tbl set Booked = '" + "Not booked" + "' where RoomNum = '" + StudRoomCb.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        void updateBookedStatus()
        {
            Con.Open();
            string query = "update Room_tbl set Booked = '" + "Booked" + "' where RoomNum = '" + StudRoomCb.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StudUsn.Text == "" || StudName.Text == "" || FatherName.Text == "" || MotherName.Text == "" || AddressTb.Text == "" || CollegeTb.Text == "")
            {
                MessageBox.Show("Пусте поле!");
            }
            else
            {

                Con.Open();
                String query = "insert into Student_tbl values('"+StudUsn.Text +"', '" + StudName.Text + "', '" + FatherName.Text + "', '"+MotherName.Text+"', '"+AddressTb.Text+"', '"+CollegeTb.Text+"', '"+StudRoomCb.SelectedValue.ToString()+"', '"+StudStatusCb.SelectedItem.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Студент успішно добавлений");
                Con.Close();
                FillStudentDGV();
                FillRoomCombobox();
                updateBookedStatus();
            }
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            FillStudentDGV();
            FillRoomCombobox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StudUsn.Text == "")
            {
                MessageBox.Show("Введіть ID студента");
            }
            else
            {
                Con.Open();
                String query = "delete from Student_tbl where StdUsn = '"+StudUsn.Text+"' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Студент успішно видалений");
                Con.Close();
                updateBookedStatusOndelete();
                FillStudentDGV();
                FillRoomCombobox();
            }
        }

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudUsn.Text = StudentDGV.SelectedRows[0].Cells[0].Value.ToString();
            StudName.Text = StudentDGV.SelectedRows[0].Cells[1].Value.ToString();
            FatherName.Text = StudentDGV.SelectedRows[0].Cells[2].Value.ToString();
            MotherName.Text = StudentDGV.SelectedRows[0].Cells[3].Value.ToString();
            AddressTb.Text = StudentDGV.SelectedRows[0].Cells[4].Value.ToString();
            CollegeTb.Text = StudentDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudUsn.Text == "")
            {
                MessageBox.Show("Введіть іноформацію про студента студента");
            }
            else
            {
                Con.Open();
                string query = "update Student_tbl set StdName = '"+StudName.Text+"', FatherName = '"+FatherName.Text+"', MotherName = '"+MotherName.Text+"', StdAddress = '"+AddressTb.Text+"', College = '"+CollegeTb.Text+"', StdRoom = '"+StudRoomCb.SelectedItem.ToString()+"', StdStatus = '"+StudStatusCb.SelectedItem.ToString()+"' where StdUsn = '"+StudUsn.Text+"' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Інформація про студента успішно оновлена");
                Con.Close();
                FillStudentDGV();
                FillRoomCombobox();
            }
        }

        private void CollegeTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

