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

        public override void Register(Person person, Form f1)
        {
            Database.register(person,f1);
        }
        public override void login(string username, string password, Form f1)
        {
            Database.getUser(username, password, f1);
        }
        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }

    }
}
