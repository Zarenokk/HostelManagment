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
    public partial class Employee : Form
    {

        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cardi\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");
        void FillEmployeeDGV()
        {
            Con.Open();
            string myquery = "Select * from Employee_tbl";
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            FillEmployeeDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpIdTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Пусте поле!");
            }
            else
            {

                Con.Open();
                String query = "insert into Employee_tbl values('" + EmpIdTb.Text + "', '" + EmpNameTb.Text + "', '" + EmpPhoneTb.Text + "', '" + EmpAddTb.Text + "', '" + EmpPositionCb.SelectedItem.ToString() + "', '"+EmpStatusCb.SelectedItem.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Працівник успішно добавлений");
                Con.Close();
                FillEmployeeDGV();
               //FillRoomCombobox();
            }
        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdTb.Text = EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString();
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPositionCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpStatusCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Введіть ID працівника");
            }
            else
            {
                Con.Open();
                String query = "delete from Employee_tbl where EmpId = '" + EmpIdTb.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Працівник успішно видалений");
                Con.Close();
                FillEmployeeDGV();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPositionCb.SelectedItem.ToString() == "" || EmpStatusCb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Введіть інформацію про працівника");
            }
            else
            {
                Con.Open();
                string query = "update Employee_tbl set EmpName = '" + EmpNameTb.Text + "', EmpPhone = '" + EmpPhoneTb.Text + "', EmpAddress = '" + EmpAddTb.Text + "', EmpPos = '"+EmpPositionCb.SelectedItem.ToString()+"', EmpStatus = '"+EmpStatusCb.SelectedItem.ToString()+"' where EmpId = '"+EmpIdTb.Text+"'  ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Інформація про працівника успішно оновлена");
                Con.Close();
                FillEmployeeDGV();
                //FillRoomCombobox();
            }
        }
    }
}
