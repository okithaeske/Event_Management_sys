
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal abstract class Person
    {
        private string name;
        private int age;
        private string id;
        private string username;
        private string password;
        private string description;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Id { get { return id; } set { id = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Description { get { return description; } set { description = value; } }

        public Person(string name,int age,string id,string username,string password,string description) 
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.username = username;
            this.password = password;
            this.description = description;
        }



        public static void DisplayPersonDetails()
        {

        }

        public static void ChangeDetails() 
        {  
            
        }

        public static void VeiwEvents()
        {

        }








    }
}
