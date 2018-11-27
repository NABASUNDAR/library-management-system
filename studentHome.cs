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
    public partial class studentHome : Form
    {
        public studentHome()
        {
            InitializeComponent();
        }

        private void studentHome_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Enabled = true;
            timer2.Interval = 20;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }

           else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
           else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }

          else  if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }

          else  if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox1.Visible = true;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label1.Left < 0 && (Math.Abs(label1.Left) > label1.Width))
                label1.Left = this.Width;

            if (label2.Left < 0 && (Math.Abs(label2.Left) > label2.Width))
                label2.Left = this.Width;

            if (label3.Left < 0 && (Math.Abs(label3.Left) > label3.Width))
                label3.Left = this.Width;

            label1.Left -= 1;
            label2.Left -= 1;
            label3.Left -= 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN_PAGE ss = new LOGIN_PAGE();
            ss.Show();
        }

		private void pictureBox6_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{
		}
	}
}
