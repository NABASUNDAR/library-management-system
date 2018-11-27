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
    public partial class issueBooks : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

		public issueBooks()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            students ss = new students();
            ss.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            this.Hide();
            viewStudents ss = new viewStudents();
            ss.Show();
        }

        private void issueBooks_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i = 0;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addStudent where StudentEnroll='" + textBox1.Text.Trim()+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("this Usn Number Not Found");
            }
            else
            {


                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["StudentName"].ToString();
                    textBox3.Text = dr["Branch"].ToString();
                    textBox4.Text = dr["Semister"].ToString();
                    textBox5.Text = dr["Email"].ToString();
                    //textBox6.Text=dr["Book_name"].ToString();
                }
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            
            }


        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;

            }

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
			int Book_available=0;

			SqlCommand cmd2 = con.CreateCommand();
			cmd2.CommandType = CommandType.Text;
			cmd2.CommandText = " select * from addBooks where Book_name='" + textBox6.Text.Trim() + "' ";
			cmd2.ExecuteNonQuery();

			DataTable dt2 = new DataTable();
			SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
			da2.Fill(dt2);
			foreach (DataRow dr2 in dt2.Rows)
			{

				Book_available = Convert.ToInt32(dr2["Book_available"].ToString());
			}

			if (Book_available > 0)
			{







				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "insert into issue values('" + textBox2.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + dateTimePicker1.Value.ToString() + "','') ";
				cmd.ExecuteNonQuery();


				SqlCommand cmd1 = con.CreateCommand();
				cmd1.CommandType = CommandType.Text;
				cmd1.CommandText = "update addBooks set Book_available=Book_available-1 where Book_name='" + textBox6.Text.Trim() + "' ";
				cmd1.ExecuteNonQuery();


				MessageBox.Show("Books Issue Successfully");
			}
			else
			{
				MessageBox.Show("Books is not availabale");
			}


		}

		private void textBox6_KeyUp_1(object sender, KeyEventArgs e)
		{
			int count = 0;
			if (e.KeyCode != Keys.Enter)
			{
				listBox1.Items.Clear();

				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from addBooks WHERE Book_name like('%" + textBox6.Text + "%') ";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				count = Convert.ToInt32(dt.Rows.Count.ToString());

				if (count > 0)
				{
					listBox1.Visible = true;
					foreach (DataRow dr in dt.Rows)
					{
						listBox1.Items.Add(dr["Book_name"].ToString());
					}
				}
			}
		}

		private void textBox6_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox6.Text = listBox1.SelectedItem.ToString();
				listBox1.Visible = false;

			}
		}
	}
}
