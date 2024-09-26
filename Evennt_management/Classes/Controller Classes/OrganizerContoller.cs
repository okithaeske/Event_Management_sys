using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evennt_management.Database;

namespace Evennt_management.Classes.Controller_Classes
{
    internal class OrganizerContoller
    {

        // Organizer can see the events they have created
        public static void DisplayEventsByOrganizer(DataGridView datatable)
        {
            string organizer = UserSession.CurrentUser; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }

            string query = "SELECT Name, Date, Place, Price, Quantity FROM createevent WHERE Organizer_Name = @organizer";

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@organizer", organizer);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            datatable.DataSource = dt;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




    }

}
