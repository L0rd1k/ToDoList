using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class ListViewTestMethods
    {

        //private void OpenConnectionToDB()
        //{
        //    connection = new MySqlConnection(connectionParam);
        //    connection.Open();
        //}
        //private void CloseConnectionToDB()
        //{
        //    connection.Close();
        //}


        private void ViewAllTasks()
        {
            //OpenConnectionToDB();
            //string sql = "SELECT * FROM tasks";
            //sqlCommand = new MySqlCommand(sql, connection);
            //sqlReader = sqlCommand.ExecuteReader();
            //listView1.Items.Clear();
            //while (sqlReader.Read())
            //{
            //    listView = new ListViewItem();
            //    for (int iter = 1; iter < 5; iter++)
            //    {
            //        //CHECK IF DONE - BACKGROUND GREEN
            //        listView.SubItems.Add(sqlReader.GetString(iter).ToString());
            //    }
            //    listView1.Items.Add(listView);
            //}
            //sqlReader.Close();
            //CloseConnectionToDB();
        }

        public void ButtonFirst_Info()
        {
            //List<string> list = new List<string>();
            //for (int i = 0; i < listView1.Items.Count; i++)
            //{
            //    if (listView1.Items[i].Checked)
            //        list.Add("Number Count" + i + " - Name: " + listView1.Items[i].Text + "  -  " + "Type: " + listView1.Items[i].SubItems[1].Text);
            //}
            //if (list.Count > 0)
            //{
            //    //showing the names:
            //    string names = null;
            //    foreach (string name in list)
            //        names += name + Environment.NewLine;
            //    MessageBox.Show("Selected names are:\n\n" + names);
            //}
            //else
            //    MessageBox.Show("No names selected.");
        }

        //private void mycheckbox(object sender, ItemCheckEventArgs e)
        //{
        //    if (e.CurrentValue == CheckState.Unchecked)
        //    {
        //        listView1.Items[e.Index].BackColor = Color.Red;
        //        taskName_TB.Text = listView1.Items[e.Index].SubItems[1].Text;
        //        description_TB.Text = listView1.Items[e.Index].SubItems[2].Text;
        //        importance_comboBox1.Text = listView1.Items[e.Index].SubItems[3].Text;

        //        dateTimePicker1.Text = listView1.Items[e.Index].SubItems[4].Text;

        //    }
        //    else if ((e.CurrentValue == CheckState.Checked))
        //    {
        //        listView1.Items[e.Index].BackColor = Color.White;
        //    }
        //}

    }
}
