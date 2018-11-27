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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class LOGIN_PAGE : Form
    {
		
		public LOGIN_PAGE()
        {
            InitializeComponent();
        }

		

        private void Form1_Load(object sender, EventArgs e)
        {
			timer1.Enabled = true;
			timer1.Interval = 20;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\LIBRARY.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From addStudent Where StudentEnroll='" + textBox2.Text.Trim()+ "' and password='" + textBox3.Text.Trim()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query,sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                this.Hide();
                studentHome ss = new studentHome();
                ss.Show();

            }
            else
            {
                MessageBox.Show("Check UserName or Password !! ");
            }
			
            textBox2.Clear();
            textBox3.Clear();
			
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * From Login2 Where UserName='" + textBox5.Text.Trim() + "' and Password='" + textBox4.Text.Trim() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                this.Hide();
                ADMIN_HOME ss = new ADMIN_HOME();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Check UserName or Password !! ");
            }
            textBox4.Clear();
            textBox5.Clear();
        }

		private void panel5_Paint(object sender, PaintEventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (label9.Left < 0 && (Math.Abs(label9.Left) > label9.Width))
				label9.Left = this.Width;

			if (label4.Left < 0 && (Math.Abs(label4.Left) > label4.Width))
				label4.Left = this.Width;

			if (label3.Left < 0 && (Math.Abs(label3.Left) > label3.Width))
				label3.Left = this.Width;

			label9.Left -= 1;
			label4.Left -= 1;
			label3.Left -= 1;
		}

		private void label9_Click(object sender, EventArgs e)
		{

		}
	}
}
