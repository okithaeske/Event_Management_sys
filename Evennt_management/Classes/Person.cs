namespace Evennt_management
{
    internal abstract class Person
    {
        private string name;
        private int age;
        private string username;
        private string password;
        private string role;

        public Person()
        {

        }


        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

        public string Role { get { return role; } set { role = value; } }

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }


        protected Person(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Person(string name, int age, string role, string username, string password)
        {
            this.name = name;
            this.age = age;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public Person(string username)
        {
   
            this.username = username;
           
        }
        public abstract void Register(Person person, Form f1);


        public abstract void login(string username, string password, Form f1);




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
