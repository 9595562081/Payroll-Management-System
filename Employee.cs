using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Management_System
{
    public partial class Employee : Form
    {
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand cmd;
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            
            this.table_1TableAdapter.Fill(this.payrollDataSet.Table_1);
            string connString = "Data Source=LAPTOP-PVF3KUNS\\SQLEXPRESS;Initial Catalog=Payroll;Integrated Security=true";
            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(present) from Table_1",conn);
            reader= cmd.ExecuteReader();
            if (reader.Read()) {
                int s=reader.GetInt32(0);
                textBox1.Text=s.ToString();
                MessageBox.Show(textBox1.Text);
                reader.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(Absent) from Table_1", conn);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                int s = reader.GetInt32(0);
                textBox2.Text = s.ToString();
                MessageBox.Show(textBox1.Text);
                reader.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select sum(Salary) from Table_1", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int s = reader.GetInt32(0);
                textBox3.Text = s.ToString();
                MessageBox.Show(textBox1.Text);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Attendance", conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string name=reader.GetString(0);
                string id=reader.GetString(1);
                MessageBox.Show(name);
                MessageBox.Show(id);
                

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home m=new Home();
            m.Show();
        }
    }
}
