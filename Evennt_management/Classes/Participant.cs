using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Evennt_management
{
    internal class Participant:Person,Validations
    {

        public Participant(string name, int age, string role, string username, string password) : base(name, age, role, username, password)
        {
        }
        public Participant()
        {
            
        }

        public Participant(string username, string password):base(username,password) { }

        public void JoinEvent() { }


        public override void Register(Person person, Form f1)
        {
            Database.register(person, f1);
        }
        public override void login(string username, string password, Form f1)
        {
            Database.getUser(username, password, f1);

        }

        public void RegisterToEvent(string eventName,string pname, int age, int price) 
        {
            Database.RegisterPerson(eventName, pname, age, price);
        }
        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }




    }
}
