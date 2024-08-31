using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Data;
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
            Database.register(person,f1);
        }

        public override void login(string username, string password, Form f1) 
        {
            Database.getUser(username, password, f1);
        
        }

        public void CreateEvent(Event e1)
        {
            e1.CreateEvent(e1);
        }

        public void UpdateEvent(Event e1,Form updateEvent)
        {
            e1.UpdateEvent(e1,updateEvent);
        }




        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }
    }
}
