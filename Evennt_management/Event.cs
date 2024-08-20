﻿using System;
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
        private string organizer;

        public string Date { get { return date; } set { date = value; } }
        public string Time { get { return time; } set { time = value; } }
        public string Place { get { return place; } set { place = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Organizer { get { return organizer; } set { organizer = value; } }

        public Event(string date,string time,string place,int price,int quantity,string name,string organizer)
        {
            this.date = date;
            this.time = time;
            this.place = place;
            this.quantity = quantity;
            this.name = name;
            this.organizer = organizer;
            
        }

        public void DisplayEvent() { }
        public void CreateEvent() { }
        public void UpdateEvent() { }
        public void DeleteEvent() { }

    }
}
