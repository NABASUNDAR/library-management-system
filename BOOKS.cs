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
using System.IO;



namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class BOOKS : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
		string imalocation = "";
		SqlCommand cmd;

		public BOOKS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_HOME SS = new ADMIN_HOME();
            SS.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            students SS = new students();
            SS.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            stokes SS = new stokes();
            SS.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            REPORTS SS = new REPORTS();
            SS.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BOOKS_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
			

			con.Open();
			SqlCommand cmd = con.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "insert into addBooks values('"+textBox1.Text.Trim()+"','"+textBox2.Text.Trim()+"','"+textBox3.Text.Trim()+"','"+dateTimePicker1.Value.ToString()+"',"+textBox4.Text.Trim()+","+textBox5.Text.Trim()+","+textBox5.Text.Trim()+")";
			cmd.ExecuteNonQuery();
			con.Close();

			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";



			MessageBox.Show("Books Insert Successfully");


			


			con.Close();
		}

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateBooks SS = new updateBooks();
            SS.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            deleteBooks SS = new deleteBooks();
            SS.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
             this.Hide();
            viewBooks SS = new viewBooks();
            SS.Show();
        }

		private void button13_Click(object sender, EventArgs e)
		{
			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Hide();
			LOGIN_PAGE ll = new LOGIN_PAGE();
			ll.Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
