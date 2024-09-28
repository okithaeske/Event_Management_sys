using Evennt_management.Classes.Controller_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal class Event
    {
        private string date;
        private string time;
        private string place;
        private int price;
        private int quantity;
        private string name;
        private string currentName;
        private string organizer;
        private string targetedInterface;

        public string Date { get { return date; } set { date = value; } }
        public string Time { get { return time; } set { time = value; } }
        public string Place { get { return place; } set { place = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Organizer { get { return organizer; } set { organizer = value; } }

        public string CurrentName { get { return currentName; } set { currentName = value; } }

        public string Targetform { get { return targetedInterface; } set { targetedInterface = value; } }

        public Event(string date, string time, string place, int price, int quantity, string name,string organizer)
        {
            this.date = date;
            this.time = time;
            this.place = place;
            this.price = price;
            this.quantity = quantity;
            this.name = name;
            this.organizer = organizer;
        
            
        }
        public Event(string currentName,string date, string time, string place, int price, int quantity, string name)
        {
            this.date = date;
            this.time = time;
            this.place = place;
            this.price = price;
            this.quantity = quantity;
            this.name = name;
            this.currentName = currentName;
           

        }

        public Event() { }



        // create an event calling the contoller class
        public void CreateEvent(Event e1, Form f1)     
        {
            EventController.CreateEvent(e1,f1);
        }
        // update an event calling the contoller class
        public void UpdateEvent(Event e1,Form updateEvent) 
        {
            EventController.UpdateEvent(e1,updateEvent);
        }
        // Delete an event calling the contoller class
        public void DeleteEvent(string Name,Form deleteEvent,string Targetform)
        {
            EventController.DeleteEvent(Name,deleteEvent,Targetform);
        }
        


    }
}
