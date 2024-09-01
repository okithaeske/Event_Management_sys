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
    public partial class Veiw_Events : Form
    {
        private Form _previousForm;
        public Veiw_Events(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Veiw_Events_Load(object sender, EventArgs e)
        {
            Database.VeiwData(dataGridView1);
        }
    }
}
