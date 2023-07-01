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
    public partial class Admin : Form
    {
        SqlDataReader dr;
        SqlConnection conn;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text!=string.Empty||textBox2.Text!=string.Empty) {
                SqlCommand cmd = new SqlCommand("select * from admin where Name='" + textBox1.Text + "' and password='"+textBox2.Text+"'",conn);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    MessageBox.Show("you are authenticated");
                    Employee ee = new Employee();
                    ee.Show();
                }
                else
                {
                    MessageBox.Show("enter the correct details");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void Admin_Load(object sender, EventArgs e)
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
    }
    }

