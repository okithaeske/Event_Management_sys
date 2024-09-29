using Evennt_management.Classes.Controller_Classes;
using System.Windows.Forms;

namespace Evennt_management
{
    internal class Participant : Person, Validations
    {
        // inheritance from peron class for regitser
        public Participant(string name, int age, string role, string username, string password) : base(name, age, role, username, password)
        {
        }
        // empty constructor
        public Participant()
        {

        }
        // inheritance from peron class for login
        public Participant(string username, string password) : base(username, password) { }

        public void JoinEvent() { }

        // Register as participant through inheriting person class 
        public override void Register(Person person, Form f1)
        {
            PersonController.register(person, f1);
        }

        // Login function override inheritng person class
        public override void login(string username, string password, Form f1)
        {
            PersonController.getUser(username, password, f1);

        }

        // Join a event associated with event class
        public void JoinEvent(string eventName, string pname, int age, int price)
        {
            Event e1 = new Event();
            e1.JoinEvent(eventName, pname, age, price);
            
        }

        // Leave a joined event associated with event class
        public void LeaveEvent(string eventName, Form leave)
        {
            Event e1 = new Event();
            e1.LeaveEvent(eventName, leave);
            
        }
        // view joined event  associated with event class
        public void ViewJoinedEvents(DataGridView dataGridView)
        {
            Event e1 = new Event();
            e1.ViewJoinedEvents(dataGridView);
        }










    }
}
