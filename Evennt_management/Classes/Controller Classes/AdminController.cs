using Evennt_management.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management.Classes.Controller_Classes
{
    internal class AdminController
    {

        // Veiw user details
        public static void VeiwUserInfo(DataGridView datagrid)
        {
          
            string query = "SELECT ID, Name, Age,Role, Username FROM user_info WHERE Role != 'admin'";
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand com = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(com);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        datagrid.DataSource = table;

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        // Admin remove user from event
        public static void RemoveParticipant(string usersName, string Tablename, Form kick)
        {

            string deleteEventQuery = $"DELETE FROM {Tablename} WHERE Name = @Name";


            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Delete he user from the event
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteEventQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@Name", usersName);


                        int deleteResult = deleteCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            MessageBox.Show("User kicked successfully!");
                            ViewBookingsadm_interface viewBookingsadm_Interface = new ViewBookingsadm_interface();
                            viewBookingsadm_Interface.Show();
                            kick.Hide();


                        }
                        else
                        {
                            MessageBox.Show("No user found to delete.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        // Delete user if user is organizer call separate fucntion
        public static void KickUser(string username)
        {

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the user is an organizer
                    string checkRole = "SELECT Role FROM user_info WHERE Username = @username";
                    string userRole = null;

                    using (MySqlCommand cmd = new MySqlCommand(checkRole, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userRole = result.ToString();
                        }
                    }

                    if (userRole == "organizer")
                    {
                        // If the user is an organizer, delete all their events and tables
                        DeleteEverythingofOrganizer(username);
                    }

                    // Delete the user from user_info table
                    string deleteUser = "DELETE FROM user_info WHERE Username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(deleteUser, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No user found with the given username.");
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        // delete all the events created by specific organizer
        private static void DeleteEverythingofOrganizer(string username)
        {
        

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    //Get all event names created by this organizer

                    string getEventNames = "SELECT Name FROM createevent WHERE Organizer_Name = @organizerName";
                    List<string> eventNames = new List<string>();

                    using (MySqlCommand getEventNamesCmd = new MySqlCommand(getEventNames, connection))
                    {
                        getEventNamesCmd.Parameters.AddWithValue("@organizerName", username);
                        using (MySqlDataReader reader = getEventNamesCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                eventNames.Add(reader["Name"].ToString());
                            }
                        }
                    }
                    //Delete all events created by this organizer
                    foreach (string eventName in eventNames)
                    {
                        // Delete the event from createevent table
                        string deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName";
                        using (MySqlCommand cmd = new MySqlCommand(deleteEventQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@eventName", eventName);
                            cmd.ExecuteNonQuery();
                        }

                        // Drop the event's from specific tables
                        string dropTableQuery = $"DROP TABLE IF EXISTS `{eventName.ToLower()}`";
                        using (MySqlCommand cmd = new MySqlCommand(dropTableQuery, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error deleting organizer and associated data: " + ex.Message);
                }

            }


        }

        // View the participants inside a event
        public static void VeiwBookingsData(string Table, DataGridView datagrid)
        {
            Table = Table.ToLower();

            string query = $"SELECT * FROM {Table}";
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand com = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(com);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        datagrid.DataSource = table;

                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }





    }
}
