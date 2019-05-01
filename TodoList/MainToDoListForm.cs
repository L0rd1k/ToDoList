using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;


namespace TodoList
{

    public partial class MainToDoListForm : Form
    {
        private DataBaseExecutor _dbExecutor;
        public string sqlQuery;
        private DataTable table = new DataTable();
        //DataGridViewCheckBoxColumn checkColumn;
        DataGridViewButtonColumn buttonColumn;
        Button button;

        public MainToDoListForm()
        {
            InitializeComponent();
            _dbExecutor = new DataBaseExecutor();
            //checkColumn = new DataGridViewCheckBoxColumn();
            buttonColumn = new DataGridViewButtonColumn();
            button = new Button();
        }

        public string TxtBoxName { get { return taskName_TB.Text; } }
        public string TxtBoxDescription { get { return description_TB.Text; } }
        public string ComboBoxImportance { get { return importance_comboBox1.Text; } }
        public DateTime DataTimePickerDay { get { return dateTimePicker1.Value; } }


        public void GridView_HeaderCreation()
        {
            string[] colonsArr = new string[5] { "ID","Name", "Description", "Importance", "Date" };
            table.Columns.Add("Done", typeof(bool));
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Text = "Delete Item";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Name = "Delete";

            dataGridView1.Columns.Add(buttonColumn);
            foreach (String item in colonsArr)
            {
                table.Columns.Add(item, System.Type.GetType("System.String"));
            }
        }

        private void DataGridViewShowInfo()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            _dbExecutor.OpenConnectionToDB();
            sqlQuery = "SELECT * FROM tasks";
            _dbExecutor.ShowAllInfoQuery(ref table,sqlQuery,6);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[2].Visible = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[1].Value) == true)
                    row.DefaultCellStyle.BackColor = Color.MediumSpringGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
            }
            _dbExecutor.CloseConnectionToDB();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && e.ColumnIndex != 0)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    taskName_TB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    description_TB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    importance_comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                } 
                if (e.ColumnIndex == 0)
                {
                    int value_id = int.Parse(string.Format("{0}", dataGridView1.Rows[e.RowIndex].Cells[2].Value));
                    _dbExecutor.OpenConnectionToDB();
                    sqlQuery = "DELETE FROM tasks WHERE task_id = @value_task_id";
                    _dbExecutor.DeleteInfoQuery(sqlQuery, value_id);
                    DataGridViewShowInfo();
                    _dbExecutor.CloseConnectionToDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addElemnt_Click(object sender, EventArgs e)
        {
            _dbExecutor.OpenConnectionToDB();
            string sqlADD = "INSERT INTO tasks(task_name,task_description,task_importance,task_date) VALUES(@taskName_TB,@description_TB,@importance_comboBox1,@dateTimePicker1)";
            _dbExecutor.InsertNewInfoQuery(sqlADD, TxtBoxName, TxtBoxDescription, ComboBoxImportance, DataTimePickerDay);
            DataGridViewShowInfo();
            _dbExecutor.CloseConnectionToDB();
        }

        private void MainToDoListForm_Load(object sender, EventArgs e)
        {
            GridView_HeaderCreation();
            DataGridViewShowInfo();
            importance_comboBox1.Items.AddRange(new string[] { "Important", "AveSignificance", "NoMatter" });
            importance_comboBox1.SelectedIndex = 1;
            radioButton1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
            else if (radioButton2.Checked)
            {
                radioButton2.Checked = true;
            }
        }
    }
}
