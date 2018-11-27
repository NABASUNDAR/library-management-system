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
    public partial class stokes : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

		public stokes()
        {
            InitializeComponent();
        }

        private void SEARCH_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
            fill_books();
        }

        public void fill_books()
        {


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Book_name,Book_aut_name,Book_quantity,Book_available from addBooks";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            ADMIN_HOME SS = new ADMIN_HOME();
            SS.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BOOKS SS = new BOOKS();
            SS.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            students SS = new students();
            SS.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            REPORTS SS = new REPORTS();
            SS.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN_PAGE LL = new LOGIN_PAGE();
            LL.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Issue where Book_name='" + i.ToString() + "' and return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Book_name,Book_aut_name,Book_quantity,Book_available from addBooks where Book_name like('%" + textBox1.Text.Trim()+"%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

		private void button11_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
