using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Data;
using Evennt_management.Classes.Controller_Classes;
namespace Evennt_management
{
    internal class Organizer : Person, Validations
    {
     
        public static string TableName { get; set; }
        public Organizer() {}
        public Organizer(string name, int age, string role, string username, string password) : base(name, age, role, username, password){ }
        public Organizer(string username, string password):base(username,password) {}

        public override void Register(Person person, Form f1)
        {
            PersonController.register(person,f1);
        }

        public override void login(string username, string password, Form f1) 
        {
            PersonController.getUser(username, password, f1);
        
        }

        public void CreateEvent(Event e1,Form f1)
        {
            e1.CreateEvent(e1,f1);
        }

        public void UpdateEvent(Event e1,Form updateEvent)
        {
            e1.UpdateEvent(e1,updateEvent);
        }

        public void RemoveEvent(string username, Form deleteform, string targetfrom)
        {
            Event e1 = new Event();
            e1.DeleteEvent(username, deleteform, targetfrom);
        }







        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }
    }
}
