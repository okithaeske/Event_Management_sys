using Evennt_management.Forms;
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
            string organizer = UserSession.CurrentUser; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }

            string query = "INSERT INTO createevent (Name,Date,Time,Place,Price,Quantity,Organizer_Name) VALUES (@event,@date,@time,@place,@price,@quantity,@organizer)";
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    //validation to see whether organizer has put his regitsered name
                    if (e1.Organizer != organizer)
                    {
                        MessageBox.Show("The organizer name does not match the logged-in user. Please use the correct organizer name.");
                        return;
                    }

                    // creating event
                    connection.Open();

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
        public static void DeleteEvent(string eventName, Form deleteEventForm, string targetInterface)
        {
            string currentUser = UserSession.CurrentUser; // Get the stored current user's name
            if (string.IsNullOrEmpty(currentUser))
            {
                MessageBox.Show("User not found. Please login again.");
                return;
            }

            string deleteEventQuery;
            string dropTableQuery = $"DROP TABLE IF EXISTS `{eventName}`";

            // Check if the target interface is for CreatedEvent or Admin
            if (targetInterface == "CreatedEvent")
            {
                // Organizer logic: Can only delete their own event
                deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName AND Organizer_Name = @organizerName";
            }
            else if (targetInterface == "admin")
            {
                // Admin logic: Can delete any event without restriction
                deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName";
            }
            else
            {
                MessageBox.Show("Unknown target interface. Cannot proceed.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Delete the event record based on the chosen query
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteEventQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@eventName", eventName);

                        // Only add the organizer name if it is organizer 
                        if (targetInterface == "CreatedEvent")
                        {
                            deleteCmd.Parameters.AddWithValue("@organizerName", currentUser);
                        }

                        int deleteResult = deleteCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            // Drop the related table
                            using (MySqlCommand dropCmd = new MySqlCommand(dropTableQuery, connection))
                            {
                                dropCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Event deleted successfully!");

                            // Show the target interface based on the specified parameter
                            Form targetForm = null;
                            if (targetInterface == "CreatedEvent")
                            {
                                CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface();
                                targetForm = createdEvent_Interface;
                            }
                            else if (targetInterface == "admin")
                            {
                                Admin_interface admin_Interface = new Admin_interface();
                                targetForm = admin_Interface;
                            }

                            // Show the target interface if it is defined
                                if (targetForm != null)
                                {
                                    targetForm.Show();
                                    deleteEventForm.Hide();
                                }
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

        // Registering particpant into a event
        public static void RegisterPerson(string table, string name, int age, int price)
        {

            name = name.ToLower();
            string Participant = UserSession.CurrentUser; // Get the stored participants's name
            if (Participant != name)
            {
                MessageBox.Show("Participant is not registered. Please check whether your using the regitsered name.");
                return;
            }



         
            string checkIfRegisteredQuery = $"SELECT COUNT(*) FROM `{table}` WHERE Name = @name";
            string query = $"INSERT INTO `{table}` (Name, Age, Price) VALUES (@name, @age, @price)";

            // Get limit for the event
            string totalRegistrationsQuery = $"SELECT COUNT(*) FROM `{table}`";
            string eventQuantityQuery = "SELECT Quantity FROM createevent WHERE LOWER(Name) = @eventName";


            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand checkCmd = new MySqlCommand(checkIfRegisteredQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@name", name);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Participant is already registered for this event.");
                            return;
                        }
                    }
                    // Step 2: Get the total number of registrations for the event
                    int totalRegistrations = 0;
                    using (MySqlCommand totalRegistrationsCmd = new MySqlCommand(totalRegistrationsQuery, connection))
                    {
                        totalRegistrations = Convert.ToInt32(totalRegistrationsCmd.ExecuteScalar());
                    }
                    // Step 3: Get the event's quantity limit
                    int eventQuantity = 0;
                    using (MySqlCommand eventQuantityCmd = new MySqlCommand(eventQuantityQuery, connection))
                    {
                        eventQuantityCmd.Parameters.AddWithValue("@eventName", table.ToLower()); // Event name is the table name
                        eventQuantity = Convert.ToInt32(eventQuantityCmd.ExecuteScalar());
                    }

                    // Step 4: Check if the total registrations exceed the event's limit
                    if (totalRegistrations >= eventQuantity)
                    {
                        MessageBox.Show("Event is fully booked. No more registrations are allowed.");
                        return;
                    }


                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@price", price);



                        // Execute the command
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Regitsered for the event successfuly!");
                        }
                        else
                        {
                            MessageBox.Show("Registration unsuccessful.");

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


        // participant can leave an event
        public static void LeaveEvent(string Tablename, Form leave)
        {

            string Participant = UserSession.CurrentUser; // Get the stored Participants's name
            string deleteEventQuery = $"DELETE FROM {Tablename} WHERE Name = @Name";


            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
            {
                try
                {
                    connection.Open();

                    // Delete he user from the event
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteEventQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@Name", Participant);


                        int deleteResult = deleteCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            MessageBox.Show("You have left from the Event Successfully");
                            Joined_events joined_Events = new Joined_events();
                            joined_Events.Show();
                            leave.Hide();


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






    }























}
