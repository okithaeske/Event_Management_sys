﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evennt_management
{
    internal class Database
    {
        public static void register(string name, int age, string role,string username,string password,Form f1)
        {
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = "INSERT INTO user_info (Name,Age,Role,Username,Password) VALUES (@name,@age,@role,@username,@password)";
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
          

        public static void CreateEvent(string date, string place, int price, int quantity, string name, string organizer)
        {
            string connectionString = "Server=localhost;Database= event_management;User ID=root;Password=;";
            string query = "INSERT INTO createevent (Name,Date,Place,Price,Quantity,Organizer_Name) VALUES (@event,@date,@place,@price,@quantity,@organizer)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            { 
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@event", name);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@place",place);
                        cmd.Parameters.AddWithValue("@price",price);
                        cmd.Parameters.AddWithValue("@quantity",quantity);
                        cmd.Parameters.AddWithValue("@organizer",organizer);


                        // Execute the command
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Event created successfuly!");

                            CreateTableForEvent(name);


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
            using (MySqlConnection connection = new MySqlConnection(connectionString))
                try
                {
                    connection.Open();
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = connection;
                    string query = "SELECT * FROM createevent";
                    com.CommandText = query;

                    MySqlDataAdapter da = new MySqlDataAdapter(com);
                    DataTable table = new DataTable();
                    da.Fill(table); 
                    datagrid.DataSource = table;
                    connection.Close();
                }
            
                 catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }

        }

        public static void RegisterPerson(string table,string name,int age,int price)
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





























































    }
}
