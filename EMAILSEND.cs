using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class EMAILSEND : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public EMAILSEND()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EMAILSEND_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(textBox5.Text,textBox6.Text);
            client = new SmtpClient(textBox8.Text);
            client.Port = Convert.ToInt32(textBox7.Text);
            client.EnableSsl = checkBox1.Checked;
            client.Credentials = login;
            msg = new MailMessage { From= new MailAddress(textBox5.Text + textBox8.Text.Replace("smtp.","@"),"Lucy",Encoding.UTF8)};
            msg.To.Add(new MailAddress(textBox1.Text));
            if (!string.IsNullOrEmpty(textBox2.Text))
                msg.To.Add(new MailAddress(textBox2.Text));

            msg.Subject = textBox3.Text;
            msg.Body = textBox4.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);


        }
        private static void SendCompletedCallback(object sender,AsyncCompletedEventArgs e)
        {

            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
