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
    public partial class viewStudents : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

        public viewStudents()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            BOOKS ss = new BOOKS();
            ss.Show();
        }

        private void viewStudents_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.RowTemplate.Height = 100;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from addStudent";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
             int i = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from addStudent WHERE StudentEnroll like('%" + textBox1.Text+"%') ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("no Student found");
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
                cmd.CommandText = "Select * from addStudent WHERE StudentEnroll like('%" + textBox1.Text + "%') ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("no Student found");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

		private void textBox1_TextChanged(object sender, EventArgs e)
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
				cmd.CommandText = "Select * from addStudent  WHERE Id=" + i + " ";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				foreach (DataRow dr in dt.Rows)
				{
					textBox2.Text = dr["StudentName"].ToString();
					textBox3.Text = dr["StudentEnroll"].ToString();
					textBox4.Text = dr["Branch"].ToString();
					dateTimePicker1.Value = Convert.ToDateTime(dr["Dob"].ToString());

					textBox6.Text = dr["Semister"].ToString();
					textBox7.Text = dr["Email"].ToString();


				}

				con.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			int i = 0;
			i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
			try
			{
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "update addStudent set StudentName='" + textBox2.Text + "',StudentEnroll='" + textBox3.Text + "',Branch='" + textBox4.Text + "',Dob='" + dateTimePicker1.Value.ToString() + "',Semister='" + textBox6.Text + "',Email='" + textBox7.Text + "' WHERE Id=" + i + " ";
				cmd.ExecuteNonQuery();
				con.Close();
				MessageBox.Show("update sucessfully");


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
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
				cmd.CommandText = "delete from addStudent  WHERE Id=" + i + " ";
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
