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
    public partial class Attendance : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        public Attendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Attendance values(@Employee_Name,@Employee_id,@Date)",conn);
            cmd.Parameters.AddWithValue("Employee_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("Employee_id", textBox2.Text);
            cmd.Parameters.AddWithValue("Date",dateTimePicker1.Text);
            int no=cmd.ExecuteNonQuery();
            textBox1.Text =no.ToString();
            MessageBox.Show("Your details are updated" + textBox1.Text);
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            Home m= new Home();
            m.Show();
        }
    }
}
