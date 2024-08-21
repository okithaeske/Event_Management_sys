using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal class Database
    {
        public static void register(string name, int age, string role,string id,string username,string password,Form f1)
        {
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = "INSERT INTO user_info (Name,Age,Role,ID,Username,Password) VALUES (@name,@age,@role,@id,@username,@password)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);


                        // Execute the command
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("successful!");
                            Login log = new Login();
                            log.Show();
                            f1.Hide();

                        }
                        else
                        {
                            MessageBox.Show("unsuccessful");

                        }


                    }
                    connection.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }


        }













































    }
}
