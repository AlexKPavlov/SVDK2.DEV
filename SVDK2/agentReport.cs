using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SVDK2
{
    public partial class agentReport : Form
    {
        SQLiteConnection sqliteConnection;
        int agent_id, year, quarter, report_id;
        DataTable listVS = new DataTable();

        public agentReport(SQLiteConnection sqliteConnection, int agent_id, int year, int quarter)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
            this.agent_id = agent_id;
            this.year = year;
            this.quarter = quarter;
            this.report_id = -1;
        }
        public agentReport(SQLiteConnection sqliteConnection, int report_id)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;

            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT agent_id FROM agentReport WHERE agentReport_id=@report_id", sqliteConnection);
            command.Parameters.AddWithValue("@report_id", report_id);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                report_id = Convert.ToInt32(reader["agent_id"]);
            }
            sqliteConnection.Close();
            if (report_id == -1)
            {
                MessageBox.Show("Не найдено выбранного отчёта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void agentReport_Load(object sender, EventArgs e)
        {
            loadVsList();

            dateTimePicker.MinDate = DateTime.Parse(year.ToString() + ".1").AddMonths((1 + ((quarter - 1) * 3)) - 1);
            dateTimePicker.MaxDate = DateTime.Parse(year.ToString() + ".1").AddMonths((1 + ((quarter) * 3)) - 1).AddDays(-1);
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null && dataGridView.CurrentCell.Value == null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            if (comboBox != null && dataGridView.CurrentCell.Value != null)
                dataGridView.CurrentCell.ReadOnly = true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                if (item.Cells["vs_name"].Value == null && item.Index != dataGridView.Rows.Count-1)
                {
                    MessageBox.Show("Не указан тип страхования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.CurrentCell = item.Cells["vs_name"];
                    return;
                }
                if (item.Cells["code"].Value == null && item.Index != dataGridView.Rows.Count - 1)
                {
                    MessageBox.Show("Не указан тип страхования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.CurrentCell = item.Cells["code"];
                    return;
                }
            }

            if (report_id == -1)
            {
                sqliteConnection.Open();
                SQLiteCommand add = new SQLiteCommand("INSERT INTO agentReport (agent_id, agentReport_date, agentReport_code) VALUES (@agent_id, @date, @code); SELECT last_insert_rowid()", sqliteConnection);
                add.Parameters.AddWithValue("@agent_id", agent_id);
                add.Parameters.AddWithValue("@date", dateTimePicker.Value);
                add.Parameters.AddWithValue("@code", codeTextBox.Text);
                SQLiteDataReader reader = add.ExecuteReader();
                while (reader.Read())
                {
                    report_id = Convert.ToInt32(reader[0]);
                }
            }
        }

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() == "")
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "count")
                if (!Int32.TryParse(e.FormattedValue.ToString(), out int qwe))
                {
                    MessageBox.Show("В данный столбец можно вводить только целые числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            if (dataGridView.Columns[e.ColumnIndex].Name == "sum")
                if (!Decimal.TryParse(e.FormattedValue.ToString(), out decimal qwe))
                {
                    MessageBox.Show("В данный столбец можно вводить только числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadVsList()
        {
            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT DISTINCT vs.vs_id, (vs.vs_kod || ': ' || vs.vs_name) AS name FROM commissionPersent LEFT JOIN vs ON vs.vs_id=commissionPersent.vs_id WHERE commissionPersent.agent_id=@agent_id AND commissionPersent.commissionPersent_year=@year UNION SELECT DISTINCT vs.vs_id, (vs.vs_kod || ': ' || vs.vs_name) AS name FROM agentReportContent LEFT JOIN vs ON vs.vs_id=agentReportContent.vs_id WHERE agentReportContent.agentReport_id=@report_id", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@report_id", report_id); //На случай если удалиться запись процента страхования из бд
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(listVS);
            ((DataGridViewComboBoxColumn)dataGridView.Columns["vs_name"]).DataSource = listVS;
            ((DataGridViewComboBoxColumn)dataGridView.Columns["vs_name"]).ValueMember = "vs_id";
            ((DataGridViewComboBoxColumn)dataGridView.Columns["vs_name"]).DisplayMember = "name";
            sqliteConnection.Close();
        }
    }
}
