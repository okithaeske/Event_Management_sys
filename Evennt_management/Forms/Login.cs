using static Evennt_management.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Evennt_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register form = new Register();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string password = textBox2.Text;

            string role = Database.getRole(uname);

            if (role == "admin")
            {
                Person person = new Admin(uname, password);
                person.login(uname, password, this);
            }
            else if (role == "organizer")
            {
                Person person = new Organizer(uname, password);
                person.login(uname, password, this);

            }
            else if (role == "participant")
            {
                Person person = new Participant(uname,password);
                person.login(uname, password,this);
            
            }

            
            
            // After validating the login credentials
            UserSession.CurrentUser = uname; // Replace with actual username
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
