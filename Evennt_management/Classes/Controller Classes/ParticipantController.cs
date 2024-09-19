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
    internal class ParticipantController
    {


        // participant being able to seee the joined events 
        public static void GetRegisteredTables(DataGridView dataGridView)
        {
            string Participant = UserSession.CurrentUser; // Get the stored Participants's name
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = "SHOW TABLES";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable allTables = new DataTable();
                            adapter.Fill(allTables);

                            // Creating a new DataTable to store tables containing the participant
                            DataTable participantTables = new DataTable();
                            participantTables.Columns.Add("Joined_Events"); // Column for table names

                            foreach (DataRow row in allTables.Rows)
                            {
                                string tableName = row[0].ToString();

                                // Skip the user_info table
                                if (tableName == "user_info")
                                    continue;

                                // Check if the participant exists in the table
                                string checkParticipantQuery = $"SELECT COUNT(*) FROM `{tableName}` WHERE Name = @name";
                                using (MySqlCommand checkCmd = new MySqlCommand(checkParticipantQuery, connection))
                                {
                                    checkCmd.Parameters.AddWithValue("@name", Participant);
                                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                    if (count > 0)
                                    {
                                        // Add the table name to the participantTables DataTable if the participant exists
                                        DataRow newRow = participantTables.NewRow();
                                        newRow["Joined_Events"] = tableName;
                                        participantTables.Rows.Add(newRow);
                                    }
                                }
                            }

                            // Bind the DataTable to the DataGridView
                            dataGridView.DataSource = participantTables;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



    }
}
