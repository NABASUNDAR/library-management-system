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
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SATYA\Documents\library.mdf;Integrated Security=True;Connect Timeout=30");
        string imalocation = "";
        SqlCommand cmd;

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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN_PAGE LL = new LOGIN_PAGE();
            LL.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            byte[] images = null;
            FileStream stream = new FileStream(imalocation,FileMode.Open,FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO addStudent VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "',@images,'" + textBox3.Text.Trim() + "','"+textBox2.Text.Trim()+"')", con);
            cmd.Parameters.Add(new SqlParameter("@images", images));
            int N= cmd.ExecuteNonQuery();
            MessageBox.Show(N.ToString()+"Data Insert Sussfully ....");
            con.Close();
        }

        private void STUDENTS_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                imalocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imalocation;


            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewStudents ss = new viewStudents();
            ss.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            issueBooks ss = new issueBooks();
            ss.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            returnBook ss = new returnBook();
            ss.Show();
        }

		private void button11_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
