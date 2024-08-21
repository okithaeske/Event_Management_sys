using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal class Participant:Person,Validations
    {

        public Participant(string name, int age, string id, string username, string password, string description) : base(name, age, id, username, password, description)
        {
            
        }

        public void JoinEvent() { }



        public void Login() { }
        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }




    }
}
