using Evennt_management.Classes.Controller_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evennt_management.Forms
{
    public partial class PersonalDetails : Form
    {
        private Form _previousForm;
     
        public PersonalDetails()
        {
            InitializeComponent();
            
        }
        public PersonalDetails(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void PersonalDetails_Load(object sender, EventArgs e)
        {
            PersonController.VeiwPersonalData(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var updateUser = new UpdateUser(this);
            updateUser.Show();
            this.Hide();
        }
    }
}
