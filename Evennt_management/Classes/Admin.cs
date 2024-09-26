using Evennt_management.Classes.Controller_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Evennt_management
{
    internal class Admin:Person,Validations
    {
        public Admin(string name, int age, string role, string username, string password) :base(name,age,role,username,password)
        {
            
        }
        public Admin(string username, string password):base(username,password)
        {
            
        }
        public Admin(string username) : base(username)
        {

        }
        public Admin() {}

        public override void Register(Person person, Form f1)
        {
            PersonController.register(person,f1);
        }
        public override void login(string username, string password, Form f1)
        {
            PersonController.getUser(username, password, f1);
        }
        public void RemoveEvent(string username,Form deleteform ,string targetfrom) 
        {
            Event e1 = new Event();
            e1.DeleteEvent(username, deleteform, targetfrom);
        }

        public void RemoveParticipant(string username,string TableName, Form kick) 
        {
            AdminController.RemoveParticipant(username,TableName,kick);
        }

        public void KickUser(string username)
        {
            AdminController.KickUser(username);
        }

        public static void ViewUserDetail(DataGridView dataGridView)
        {
            AdminController.VeiwUserInfo(dataGridView);
        }

      

    }
}
