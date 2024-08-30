using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal interface Validations
    {
        public void login(string username, string password, Form f1);
        public void Logout();
        public void Register();
        public void Veiw_details();
        public void Change_details();

    }
}
