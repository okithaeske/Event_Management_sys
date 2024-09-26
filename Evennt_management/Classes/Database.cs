using Evennt_management.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evennt_management
{
    internal class Database
    {

        public static string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";

        // creating a class to store the current user
        public static class UserSession
        {
            public static string CurrentUser { get; set; }
        }

        //Get the role of the usersname to be implifed in the polymorphism in login form
        public static string getRole(string username)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Role FROM user_info WHERE Username = @Username";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);



                    string role = cmd.ExecuteScalar()?.ToString();
                    if (role != null)
                    {
                        return role.ToLower();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password");
                        return "";

                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }

            }

        }



    }
}
