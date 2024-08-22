using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evennt_management
{
    public partial class Organizer_interface : Form
    {
        public Organizer_interface()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Veiw = new Veiw_Events(this);
            Veiw.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want to logout", "logout", MessageBoxButtons.YesNo);
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateEvent_interface createEvent_Interface = new CreateEvent_interface();
            createEvent_Interface.Show();
            this.Hide();
        }
    }
}
