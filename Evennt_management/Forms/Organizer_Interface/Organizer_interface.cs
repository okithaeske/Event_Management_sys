using Evennt_management.Forms;
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
            var Veiw = new View_Events(this);
            Veiw.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout", "logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();

            }
            else
            {
                this.Show();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateEvent_interface createEvent_Interface = new CreateEvent_interface();
            createEvent_Interface.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
            createdEvent_Interface.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewBookings_interface veiwBookings_Interface = new ViewBookings_interface();
            veiwBookings_Interface.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var viewPersonal = new PersonalDetails(this);
            viewPersonal.Show();
            this.Hide();
        }
    }
}
