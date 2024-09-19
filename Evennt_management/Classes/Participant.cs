using Evennt_management.Classes.Controller_Classes;
using System.Windows.Forms;

namespace Evennt_management
{
    internal class Participant : Person, Validations
    {

        public Participant(string name, int age, string role, string username, string password) : base(name, age, role, username, password)
        {
        }
        public Participant()
        {

        }

        public Participant(string username, string password) : base(username, password) { }

        public void JoinEvent() { }


        public override void Register(Person person, Form f1)
        {
            PersonController.register(person, f1);
        }
        public override void login(string username, string password, Form f1)
        {
            PersonController.getUser(username, password, f1);

        }

        public void JoinEvent(string eventName, string pname, int age, int price)
        {
            EventController.RegisterPerson(eventName, pname, age, price);
        }

        public void LeaveEvent(string eventName, Form leave)
        {
            EventController.LeaveEvent(eventName, leave);
        }

        public void ViewJoinedEvents(DataGridView dataGridView)
        {
            Database.GetRegisteredTables(dataGridView);
        }










    }
}
