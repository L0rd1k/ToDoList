using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TodoList
{

    public class DataBaseExecutor
    {
        private string serverName, userName, database, password;
        private string connectionParam;
        MySqlConnection connection;
        MySqlCommand sqlCommand;
        MySqlDataReader sqlReader;
    
        public DataBaseExecutor()
        {
            this.serverName = "localhost";
            this.userName = "root";
            this.database = "todolist";
            this.password = "root";

            connectionParam = "SERVER=" + serverName +
                            @";USER=" + userName +
                            @";DATABASE=" + database +
                            @";PASSWORD=" + password;

        }

        public void OpenConnectionToDB()
        {
            connection = new MySqlConnection(connectionParam);
            connection.Open();
        }

        public void CloseConnectionToDB()
        {
            connection.Close();

        }

        public void DeleteInfoQuery(string query, int value_id)
        {
            sqlCommand = new MySqlCommand(query, connection);
            using (sqlCommand)
            {
                sqlCommand.Parameters.AddWithValue("@value_task_id", value_id);
            }
            sqlCommand.ExecuteNonQuery();
        }

        public void ShowAllInfoQuery(ref DataTable table, string query, int cols)//4
        {
            table.Clear();
            sqlCommand = new MySqlCommand(query, connection);
            sqlReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlReader.Read())
                {
                    DataRow dr = table.NewRow();
                    for (int iter = 0; iter < cols-1; iter++)
                    {
                        if (iter == 0)
                        {
                            if (sqlReader[5].ToString() == "1")
                                dr[0] = true;
                            else
                                dr[0] = false;
                        }
                        dr[iter + 1] = sqlReader[iter].ToString();
                    }
                    table.Rows.Add(dr);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlReader.Close();
        }

        public void InsertNewInfoQuery(string query, string TxtBoxName, string TxtBoxDescription, string ComboBoxImportance, DateTime DataTimePickerDay)
        {
            sqlCommand = new MySqlCommand(query, connection);
            try
            {
                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@taskName_TB", TxtBoxName);
                    sqlCommand.Parameters.AddWithValue("@description_TB", TxtBoxDescription);
                    sqlCommand.Parameters.AddWithValue("@importance_comboBox1", ComboBoxImportance);
                    sqlCommand.Parameters.AddWithValue("@dateTimePicker1", DataTimePickerDay);
                }
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
