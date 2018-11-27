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
    public partial class deleteBooks : Form
    {
        public deleteBooks()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            BOOKS SS = new BOOKS();
            SS.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void deleteBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
