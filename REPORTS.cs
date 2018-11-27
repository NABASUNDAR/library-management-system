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
    public partial class REPORTS : Form
    {
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");

		public REPORTS()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            stokes SS = new stokes();
            SS.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN_PAGE LL = new LOGIN_PAGE();
            LL.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewBooks vv = new viewBooks();
            vv.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewStudents vv = new viewStudents();
            vv.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            sentMail ss = new sentMail();
            ss.Show();
        }

		private void REPORTS_Load(object sender, EventArgs e)
		{
			if(con.State==ConnectionState.Open)
			{
				con.Close();

			}
			con.Open();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			DataSet1 ds = new DataSet1();
			SqlCommand cmd = con.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from issue where return_date=''";
			cmd.ExecuteNonQuery();
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(ds.DataTable1);
			CrystalReport1 myreport = new CrystalReport1();
			myreport.SetDataSource(ds);
			crystalReportViewer1.ReportSource = myreport;


		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
