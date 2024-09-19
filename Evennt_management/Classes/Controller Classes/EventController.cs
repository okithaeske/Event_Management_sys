using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evennt_management.Database;

namespace Evennt_management.Classes.Controller_Classes
{
    internal class EventController
    {

        // Create event and insert data into create event table
        public static void CreateEvent(Event e1, Form create)
        {
            string checkOrganizerQuery = "SELECT COUNT(*) FROM user_info WHERE Username = @organizer";
            string query = "INSERT INTO createevent (Name,Date,Time,Place,Price,Quantity,Organizer_Name) VALUES (@event,@date,@time,@place,@price,@quantity,@organizer)";
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();
                    //validation to see whether organizer has put his regitsered name

                    using (MySqlCommand checkOrganizerCmd = new MySqlCommand(checkOrganizerQuery, connection))
                    {
                        checkOrganizerCmd.Parameters.AddWithValue("@organizer", e1.Organizer);
                        int organizerExists = Convert.ToInt32(checkOrganizerCmd.ExecuteScalar());

                        if (organizerExists == 0)
                        {
                            MessageBox.Show("Organizer is not registered. Please check whether your using the regitsered name.");
                            return;
                        }
                    }

                    // creating event

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@event", e1.Name);
                        cmd.Parameters.AddWithValue("@date", e1.Date);
                        cmd.Parameters.AddWithValue("@time", e1.Time);
                        cmd.Parameters.AddWithValue("@place", e1.Place);
                        cmd.Parameters.AddWithValue("@price", e1.Price);
                        cmd.Parameters.AddWithValue("@quantity", e1.Quantity);
                        cmd.Parameters.AddWithValue("@organizer", e1.Organizer);


                        // Execute the command
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Event created successfuly!");
                            Organizer_interface organizer_Interface = new Organizer_interface();
                            organizer_Interface.Show();
                            create.Hide();

                            CreateTableForEvent(e1.Name);


                        }
                        else
                        {
                            MessageBox.Show("Event creation was unsuccessful!");

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


        // create a specific table for the created table
        public static void CreateTableForEvent(string tableName)
        {
            string createTableQuery = $@"
            CREATE TABLE `{tableName}` (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                Name NVARCHAR(100) NOT NULL,
                Age INT NOT NULL,
                Price INT NOT NULL
            );
        ";

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Create the table within the existing database
                    using (MySqlCommand createTableCmd = new MySqlCommand(createTableQuery, connection))
                    {
                        createTableCmd.ExecuteNonQuery();

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error creating table: " + ex.Message);
                }
            }
        }

        // update event
        public static void UpdateEvent(Event e1, Form updateEvent)
        {
            string organizer = UserSession.CurrentUser; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }
            string EventName = e1.CurrentName.ToLower();

            string query = "UPDATE createevent SET Name = @newName,Date = @newDate,Time = @newtime, Place = @newPlace, Price = @newPrice, Quantity = @newQuantity WHERE Name = @eventName AND Organizer_Name = @organizerName";
            string renameTableQuery = $"RENAME TABLE `{EventName}` TO `{e1.Name}`";

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@eventName", e1.CurrentName);
                        cmd.Parameters.AddWithValue("@newName", e1.Name);
                        cmd.Parameters.AddWithValue("@newDate", e1.Date);
                        cmd.Parameters.AddWithValue("@newtime", e1.Time);
                        cmd.Parameters.AddWithValue("@newPlace", e1.Place);
                        cmd.Parameters.AddWithValue("@newPrice", e1.Price);
                        cmd.Parameters.AddWithValue("@newQuantity", e1.Quantity);
                        cmd.Parameters.AddWithValue("@organizerName", organizer);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            using (MySqlCommand renameCmd = new MySqlCommand(renameTableQuery, connection))
                            {
                                renameCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Event updated successfully!");
                            CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
                            createdEvent_Interface.Show();
                            updateEvent.Hide();

                        }
                        else
                        {
                            MessageBox.Show("No event found to update.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Delete Event
        public static void DeleteEvent(string eventName, Form deleteEventForm)
        {
            string organizer = UserSession.CurrentUser; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }

            string Eventname = eventName.ToLower();

            string deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName AND Organizer_Name = @organizerName";
            string dropTableQuery = $"DROP TABLE IF EXISTS `{Eventname}`";

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Delete the event record
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteEventQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@eventName", eventName);
                        deleteCmd.Parameters.AddWithValue("@organizerName", organizer);

                        int deleteResult = deleteCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            // Drop the relating table
                            using (MySqlCommand dropCmd = new MySqlCommand(dropTableQuery, connection))
                            {
                                dropCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Event and associated table deleted successfully!");
                            CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
                            createdEvent_Interface.Show();
                            deleteEventForm.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No event found to delete.");
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
