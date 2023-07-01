using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_Management_System
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty ||
textBox3.Text != string.Empty)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    cmd = new SqlCommand("select * from Login where UserName = '" + textBox1.Text + "'", conn);
                   
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("You are sucessfully authenticated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("Take Your Attendance");
                        Attendance a=new Attendance();
                        a.Show();
                     }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Login values(@UserName, @Password)", conn);
                        
                         cmd.Parameters.AddWithValue("UserName", textBox1.Text);
                        cmd.Parameters.AddWithValue("Password", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=LAPTOP-PVF3KUNS\\SQLEXPRESS;Initial Catalog=Payroll;Integrated Security=true";
            conn=new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text= string.Empty;
            textBox2.Text= string.Empty;
            textBox3.Text= string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin m=new Admin();
            m.Show();
        }
    }
}
