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
    public partial class updateBooks : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

		public updateBooks()
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
            this.Hide();
            viewBooks SS = new viewBooks();
            SS.Show();
        }

        private void updateBooks_Load(object sender, EventArgs e)
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
            catch (Exception ex)
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
                    MessageBox.Show("no books found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
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
                    MessageBox.Show("no books found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from addBooks  WHERE Id="+i+" ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["Book_name"].ToString();
                    textBox3.Text = dr["Book_aut_name"].ToString();
					textBox4.Text = dr["Book_publication_name"].ToString();
					dateTimePicker1.Value = Convert.ToDateTime(dr["Book_p_date"].ToString());

					textBox6.Text = dr["Book_price "].ToString();
                    textBox7.Text = dr["Book_quantity"].ToString();
                   
                
                }
                
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update addBooks set Book_name='" + textBox2.Text + "',Book_aut_name='" + textBox3.Text + "',Book_publication_name='"+textBox4.Text+"',Book_p_date='"+dateTimePicker1.Value.ToString()+"',Book_price='" + textBox6.Text + "',Book_quantity='" + textBox7.Text + "' WHERE Id="+i+" ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("update sucessfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

		private void button15_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void button14_Click(object sender, EventArgs e)
		{
			int i = 0;
			i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
			try
			{
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "delete from addBooks  WHERE Id=" + i + " ";
				cmd.ExecuteNonQuery();
				con.Close();
				MessageBox.Show("Delete sucessfully");


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
		}
	}
}
