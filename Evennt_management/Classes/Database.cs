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
        // Insert user information to the databse
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
                            MessageBox.Show("successfully Regitsered!");
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


        // Get the users username and according to the role direct to the specific interface
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


        // Create event and insert data into create event table
        public static void CreateEvent(Event e1, Form create)
        {

            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string checkOrganizerQuery = "SELECT COUNT(*) FROM user_info WHERE Username = @organizer";
            string query = "INSERT INTO createevent (Name,Date,Time,Place,Price,Quantity,Organizer_Name) VALUES (@event,@date,@time,@place,@price,@quantity,@organizer)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error creating table: " + ex.Message);
                }
            }
        }


        // Veiw the created events
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



            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string checkIfRegisteredQuery = $"SELECT COUNT(*) FROM `{table}` WHERE Name = @name";
            string query = $"INSERT INTO `{table}` (Name, Age, Price) VALUES (@name, @age, @price)";

            // Get limit for the event
            string totalRegistrationsQuery = $"SELECT COUNT(*) FROM `{table}`";
            string eventQuantityQuery = "SELECT Quantity FROM createevent WHERE LOWER(Name) = @eventName";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        // participant can leave an event
        public static void LeaveEvent(string Tablename, Form leave)
        {

            string Participant = UserSession.CurrentUser; // Get the stored Participants's name
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string deleteEventQuery = $"DELETE FROM {Tablename} WHERE Name = @Name";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        // Organizer can see the events they have created
        public static void DisplayEventsByOrganizer(DataGridView datatable)
        {
            string organizer = UserSession.CurrentUser; // Get the stored organizer's name
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

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = "UPDATE createevent SET Name = @newName,Date = @newDate,Time = @newtime, Place = @newPlace, Price = @newPrice, Quantity = @newQuantity WHERE Name = @eventName AND Organizer_Name = @organizerName";
            string renameTableQuery = $"RENAME TABLE `{EventName}` TO `{e1.Name}`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        // View the participants inside a event
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


        // Veiw user details
        public static void VeiwUserInfo(DataGridView datagrid)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string query = "SELECT ID, Name, Age,Role, Username FROM user_info WHERE Role != 'admin'";
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


        // Delete user if user is organizer call separate fucntion
        public static void DeleteUser(string username)
        {
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        // admin delete event
        public static void AdminDeleteEvent(string eventName)
        {
            // username to lower
            string Eventname = eventName.ToLower();

            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string deleteEventQuery = "DELETE FROM createevent WHERE Name = @eventName";
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


                        int deleteResult = deleteCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            // Drop the relating table
                            using (MySqlCommand dropCmd = new MySqlCommand(dropTableQuery, connection))
                            {
                                dropCmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Event and associated table deleted successfully!");

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


        // Admin kick user from event
        public static void kickUser(string usersName, string Tablename, Form kick)
        {


            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
            string deleteEventQuery = $"DELETE FROM {Tablename} WHERE Name = @Name";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
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


        
        // Delete Event
        public static void Deleteevent(string eventName, Form deleteEventForm, string targetInterface)
        {
            string currentUser = UserSession.CurrentUser; // Get the stored current user's name
            if (string.IsNullOrEmpty(currentUser))
            {
                MessageBox.Show("User not found. Please login again.");
                return;
            }

            
            string connectionString = "Server=localhost;Database=event_management;User ID=root;Password=;";
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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Delete the event record based on the chosen query
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteEventQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@eventName", eventName);

                        // Only add the organizer name if it is organizer logic
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
                            MessageBox.Show("Event and associated table deleted successfully!");

                            // Show the target interface based on the specified parameter
                            Form targetForm = null;
                            if (targetInterface == "CreatedEvent")
                            {
                                CreatedEvent_interface createdEvent_Interface = new CreatedEvent_interface ();
                                targetForm = createdEvent_Interface;
                            }
                            else if (targetInterface == "Admin")
                            {
                                Admin_interface admin_Interface = new Admin_interface ();
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























    }
}
