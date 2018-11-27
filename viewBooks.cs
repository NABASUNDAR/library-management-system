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
    public partial class viewBooks : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

        public viewBooks()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            BOOKS SS = new BOOKS();
            SS.Show();
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

        }

        private void viewBooks_Load(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from addBooks";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
			int i = 0;
			try
			{

				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from addBooks WHERE Book_name like('%" + textBox1.Text + "%') ";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				i = Convert.ToInt32(dt.Rows.Count.ToString());
				dataGridView1.DataSource = dt;
				con.Close();
				if (i == 0)
				{
					MessageBox.Show("no Books found");
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
			textBox1.Clear();
		}
	

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
			int i = 0;
			try
			{

				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from addBooks WHERE Book_name like('%" + textBox1.Text + "%') ";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				i = Convert.ToInt32(dt.Rows.Count.ToString());
				dataGridView1.DataSource = dt;
				con.Close();
				if (i == 0)
				{
					MessageBox.Show("no Books found");
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}

		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
