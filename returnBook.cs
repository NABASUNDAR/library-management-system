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
    public partial class returnBook : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

		public returnBook()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;

            Fill_grid(textBox1.Text);
        }
        private void returnBook_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                        
            }
            con.Open();
        }
        public void Fill_grid(string usn)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue where StudentEnroll='" + usn.ToString() + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_HOME ss = new ADMIN_HOME();
            ss.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel6.Visible = true;

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue where Id="+i+" ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lbl_BookName.Text = dr["Book_name"].ToString();
                lbl_issueDate.Text =Convert.ToString( dr["book_issue_date"].ToString());
            
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Issue set return_date='" + dateTimePicker1.Value.ToString() + "' where Id="+i+" ";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update addBooks set Book_available=Book_available+1 where Book_name='" + lbl_BookName.Text+"' ";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Books retuen sucessfully");

            panel6.Visible = true;
            Fill_grid(textBox1.Text);
        
        
        }

    }
}
