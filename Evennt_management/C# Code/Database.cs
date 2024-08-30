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
        public static class UserSession
        {
            public static string CurrentOrganizer { get; set; }
        }
        public static void register(Person person, Form f1)
        {
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = "INSERT INTO user_info (Name,Age,Role,Username,Password) VALUES (@name,@age,@role,@username,@password)";
            string checkUserQuery = "SELECT COUNT(*) FROM user_info WHERE Username = @username";
            string checkNameQuery = "SELECT COUNT(*) FROM user_info WHERE Name = @name";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // checking whether username exists and sending error message
                    using (MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, connection))
                    {
                        checkUserCmd.Parameters.AddWithValue("@username", person.Username);
                        int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());
                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.");
                            return;
                        }
                    }
                    // checking whether the name exists
                    using (MySqlCommand checknameCmd = new MySqlCommand(checkNameQuery, connection))
                    {
                        checknameCmd.Parameters.AddWithValue("@name", person.Name);
                        int nameExists = Convert.ToInt32(checknameCmd.ExecuteScalar());
                        if (nameExists > 0)
                        {
                            MessageBox.Show("Name already exists. Please choose a different Name.");
                            return;
                        }
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", person.Name);
                        cmd.Parameters.AddWithValue("@age", person.Age);
                        cmd.Parameters.AddWithValue("@role", person.Role);
                        cmd.Parameters.AddWithValue("@username", person.Username);
                        cmd.Parameters.AddWithValue("@password", person.Password);


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

        public static void getUser(string username, string password, Form f1)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Role FROM user_info WHERE Username = @Username AND Password = @Password";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);


                    string role = cmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(role))
                    {
                        switch (role.ToLower())
                        {
                            case "admin":
                                MessageBox.Show("Login successful as Admin!");
                                Admin_interface formAdmin = new Admin_interface();
                                formAdmin.Show();
                                break;

                            case "organizer":
                                MessageBox.Show("Login successful as Organizer!");
                                Organizer_interface formOrganizer = new Organizer_interface();
                                formOrganizer.Show();
                                break;

                            case "participant":
                                MessageBox.Show("Login successful as Participant!");
                                Participant_interface formParticipant = new Participant_interface();
                                formParticipant.Show();
                                break;

                            default:
                                MessageBox.Show("Unknown role detected.");
                                break;
                        }
                        f1.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }

                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


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
                    return role.ToLower();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }

            }

        }



        public static void CreateEvent(Event e1)
        {
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string checkOrganizerQuery = "SELECT COUNT(*) FROM user_info WHERE Username = @organizer";
            string query = "INSERT INTO createevent (Name,Date,Time,Place,Price,Quantity,Organizer_Name) VALUES (@event,@date,@time,@place,@price,@quantity,@organizer)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // validation to see whether organizer has put his regitsered name

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


        public static void CreateTableForEvent(string tableName)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string createTableQuery = $@"
            CREATE TABLE `{tableName}` (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                Name NVARCHAR(100) NOT NULL,
                Age INT NOT NULL,
                Price INT NOT NULL
            );
        ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create the table within the existing database
                    using (MySqlCommand createTableCmd = new MySqlCommand(createTableQuery, connection))
                    {
                        createTableCmd.ExecuteNonQuery();
                        MessageBox.Show($"Table '{tableName}' with columns Name, Age, and Price created successfully.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error creating table: " + ex.Message);
                }
            }
        }



        public static void VeiwData(DataGridView datagrid)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = "SELECT * FROM createevent";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        public static void RegisterPerson(string table, string name, int age, int price)
        {
            name = name.ToLower();

            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = $"INSERT INTO `{table}` (Name, Age, Price) VALUES (@name, @age, @price)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
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

        public static void DisplayEventsByOrganizer(DataGridView datatable)
        {
            string organizer = UserSession.CurrentOrganizer; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = "SELECT Name, Date, Place, Price, Quantity FROM createevent WHERE Organizer_Name = @organizer";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        public static void UpdateEvent(string newName, string eventName, string newDate, string newPlace, int newPrice, int newQuantity, Form updateEvent)
        {
            string organizer = UserSession.CurrentOrganizer; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }
            string EventName = eventName.ToLower();

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = "UPDATE createevent SET Name = @newName,Date = @newDate, Place = @newPlace, Price = @newPrice, Quantity = @newQuantity WHERE Name = @eventName AND Organizer_Name = @organizerName";
            string renameTableQuery = $"RENAME TABLE `{EventName}` TO `{newName}`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@eventName", eventName);
                        cmd.Parameters.AddWithValue("@newName", newName);
                        cmd.Parameters.AddWithValue("@newDate", newDate);
                        cmd.Parameters.AddWithValue("@newPlace", newPlace);
                        cmd.Parameters.AddWithValue("@newPrice", newPrice);
                        cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
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

        public static void DeleteEvent(string eventName, Form deleteEventForm)
        {
            string organizer = UserSession.CurrentOrganizer; // Get the stored organizer's name
            if (string.IsNullOrEmpty(organizer))
            {
                MessageBox.Show("Organizer not found. Please login again.");
                return;
            }

            string Eventname = eventName.ToLower();

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName AND Organizer_Name = @organizerName";
            string dropTableQuery = $"DROP TABLE IF EXISTS `{Eventname}`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

        public static void VeiwBookingsData(string Table, DataGridView datagrid)
        {
            Table = Table.ToLower();

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = $"SELECT * FROM {Table}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
