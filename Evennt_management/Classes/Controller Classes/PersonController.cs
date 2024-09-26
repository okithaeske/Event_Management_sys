using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management.Classes.Controller_Classes
{
    internal class PersonController
    {

        // Insert user information to the databse
        public static void register(Person person, Form f1)
        {

            string query = "INSERT INTO user_info (Name,Age,Role,Username,Password) VALUES (@name,@age,@role,@username,@password)";
            string checkUserQuery = "SELECT COUNT(*) FROM user_info WHERE Username = @username";
            string checkNameQuery = "SELECT COUNT(*) FROM user_info WHERE Name = @name";
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
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
          
            using (MySqlConnection connection = new MySqlConnection(Database.connectionString))
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


        // Veiw the created events
        public static void VeiwData(DataGridView datagrid)
        {
          
            string query = "SELECT * FROM createevent";
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
