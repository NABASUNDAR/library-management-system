using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class ADMIN_HOME : Form
    {
        public ADMIN_HOME()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN_PAGE LL = new LOGIN_PAGE();
            LL.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            REPORTS SS = new REPORTS();
            SS.Show();
        }

        private void ADMIN_HOME_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Enabled = true;
            timer2.Interval = 20;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }

            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }

            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }

            else if (pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox3.Visible = true;
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
