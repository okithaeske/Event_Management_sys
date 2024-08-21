using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
namespace Evennt_management
{
    internal class Organizer:Person,Validations
    {
        public Organizer(string name, int age, string id, string username, string password, string description):base(name, age, id, username, password, description)
        {
            
        }
        public void Login() { }
        public void Logout() { }
        public void Register() { }
        public void Veiw_details() { }
        public void Change_details() { }
    }
}
