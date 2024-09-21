using Evennt_management.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evennt_management
{
    internal interface Validations
    {
        // View the participants inside a event
        public void VeiwBookingsData(string Table, DataGridView datagrid)
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
                    MessageBox.Show($"The event '{Table}' does not exist. Please check the event name.");
                }

            }

        }

    }
}
