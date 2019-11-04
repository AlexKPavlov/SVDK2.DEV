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
            this.report_id = report_id;

            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT agent_id, agentReport_date, agentReport_code FROM agentReport WHERE agentReport_id=@report_id", sqliteConnection);
            command.Parameters.AddWithValue("@report_id", report_id);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.agent_id = Convert.ToInt32(reader["agent_id"]);
                this.year = DateTime.Parse(reader["agentReport_date"].ToString()).Year;
                this.quarter = (DateTime.Parse(reader["agentReport_date"].ToString()).Month + 2) / 3;
                dateTimePicker.Value = DateTime.Parse(reader["agentReport_date"].ToString());
                codeTextBox.Text = reader["agentReport_code"].ToString();
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

            if (report_id != -1)
                loadDateGridView();

            loadSettings();
        }

        private void loadSettings()
        {
            IniFile settingsIni = new IniFile(@"setting.ini");
            this.Text = this.Text.Split(new string[] { @" (" }, StringSplitOptions.RemoveEmptyEntries)[0] + @" (" + settingsIni.Read("name", "settings") + ")";
            helpStatusStrip.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
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
            foreach (DataGridViewRow item in dataGridView.Rows) //Проверка на незаполненные ячейки
            {
                if (item.Cells["vs_name"].Value == null && item.Index != dataGridView.Rows.Count - 1)
                {
                    MessageBox.Show("Не указан тип страхования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.CurrentCell = item.Cells["vs_name"];
                    return;
                }
                if (item.Cells["count"].Value == null && item.Index != dataGridView.Rows.Count - 1)
                {
                    MessageBox.Show("Не указано количество страхований!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.CurrentCell = item.Cells["count"];
                    return;
                }
                if (item.Cells["sum"].Value == null && item.Index != dataGridView.Rows.Count - 1)
                {
                    MessageBox.Show("Не указана сумма страхований!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.CurrentCell = item.Cells["sum"];
                    return;
                }
            }

            sqliteConnection.Open();
            if (report_id == -1)    //В случае если создаем отчёт
            {
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
            else //В случае если обновляем отчёт
            {
                SQLiteCommand update = new SQLiteCommand("UPDATE agentReport SET agentReport_date=@date, agentReport_code=@code WHERE agentReport_id=@id", sqliteConnection);
                update.Parameters.AddWithValue("@id", report_id);
                update.Parameters.AddWithValue("@code", codeTextBox.Text);
                update.Parameters.AddWithValue("@date", dateTimePicker.Value);
                update.ExecuteNonQuery();
            }

            foreach (DataGridViewRow item in dataGridView.Rows)
                if (item.Index != dataGridView.Rows.Count - 1)  //Проверка на последнюю строку
                {
                    if (item.Cells["agentReportContent_id"].Value == null)  //Строка ещё не создана в бд (Добавление)
                    {
                        SQLiteCommand add = new SQLiteCommand("INSERT INTO agentReportContent (agentReport_id, vs_id, agentReportContent_count, agentReportContent_sum) VALUES (@report_id, @vs_id, @count, @sum)", sqliteConnection);
                        add.Parameters.AddWithValue("@report_id", report_id);
                        add.Parameters.AddWithValue("@vs_id", item.Cells["vs_name"].Value);
                        add.Parameters.AddWithValue("@count", item.Cells["count"].Value);
                        add.Parameters.AddWithValue("@sum", item.Cells["sum"].Value);
                        add.ExecuteNonQuery();
                    }
                    else  //Строка уже создана в бд (Изменение)
                    {
                        if (item.Cells["delete"].Value == null) //Обновление записи если нет метки
                        {
                            SQLiteCommand update = new SQLiteCommand("UPDATE agentReportContent SET vs_id=@vs_id, agentReportContent_count=@count, agentReportContent_sum=@sum WHERE agentReportContent_id=@reportContent_id", sqliteConnection);
                            update.Parameters.AddWithValue("@reportContent_id", item.Cells["agentReportContent_id"].Value);
                            update.Parameters.AddWithValue("@vs_id", item.Cells["vs_name"].Value);
                            update.Parameters.AddWithValue("@count", item.Cells["count"].Value);
                            update.Parameters.AddWithValue("@sum", item.Cells["sum"].Value);
                            update.ExecuteNonQuery();
                        }
                        else //Удаление записи если есть метка
                        {
                            SQLiteCommand delete = new SQLiteCommand("DELETE FROM agentReportContent WHERE agentReportContent_id=@reportContent_id", sqliteConnection);
                            delete.Parameters.AddWithValue("@reportContent_id", item.Cells["agentReportContent_id"].Value);
                            delete.ExecuteNonQuery();
                        }
                    }
                }
            sqliteConnection.Close();
            this.Close();
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "vs_name")
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bool isOpen = false;
                    if (sqliteConnection.State == ConnectionState.Open)
                        isOpen = true;
                    if (!isOpen)
                        sqliteConnection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT commissionPersent_persent AS percent FROM commissionPersent WHERE agent_id=@agent_id AND vs_id=@vs_id AND commissionPersent_year=@year", sqliteConnection);
                    command.Parameters.AddWithValue("@agent_id", agent_id);
                    command.Parameters.AddWithValue("@vs_id", dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    command.Parameters.AddWithValue("@year", dateTimePicker.Value.Year);
                    decimal percent = 0;
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        percent = Convert.ToDecimal(reader["percent"]);
                    }
                    dataGridView.Rows[e.RowIndex].Cells["percent"].Value = percent;
                    if (!isOpen)
                        sqliteConnection.Close();
                }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "sum" || dataGridView.Columns[e.ColumnIndex].Name == "percent")
                if (dataGridView.Rows[e.RowIndex].Cells["sum"].Value != null && dataGridView.Rows[e.RowIndex].Cells["percent"].Value != null)
                    dataGridView.Rows[e.RowIndex].Cells["sumForAgent"].Value = Convert.ToDecimal(dataGridView.Rows[e.RowIndex].Cells["sum"].Value) * (Convert.ToDecimal(dataGridView.Rows[e.RowIndex].Cells["percent"].Value) / 100);
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index == dataGridView.Rows.Count - 1)
                return;

            if (e.Row.Cells["agentReportContent_id"].Value == null)
                return;

            if (e.Row.Cells["delete"].Value == null)
            {
                e.Row.Cells["delete"].Value = true;
                e.Row.DefaultCellStyle.BackColor = Color.DarkRed;
                e.Row.DefaultCellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                e.Row.Cells["delete"].Value = null;
                e.Row.DefaultCellStyle.BackColor = Color.Empty;
                e.Row.DefaultCellStyle.SelectionBackColor = Color.Empty;
            }

            e.Cancel = true;
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

        private void loadDateGridView()
        {
            sqliteConnection.Open();
            SQLiteCommand load = new SQLiteCommand("SELECT * FROM agentReportContent WHERE agentReport_id=@report_id", sqliteConnection);
            load.Parameters.AddWithValue("@report_id", report_id);
            SQLiteDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells["agentReportContent_id"].Value = Convert.ToInt32(reader["agentReportContent_id"]);
                dataGridView.Rows[index].Cells["vs_name"].Value = Convert.ToInt64(reader["vs_id"]);
                dataGridView.CurrentCell = dataGridView.Rows[index].Cells["vs_name"];
                dataGridView.BeginEdit(false);
                dataGridView.EndEdit();
                dataGridView.Rows[index].Cells["count"].Value = Convert.ToInt32(reader["agentReportContent_count"]);
                dataGridView.Rows[index].Cells["sum"].Value = Convert.ToDecimal(reader["agentReportContent_sum"]);
            }
            sqliteConnection.Close();
        }

        #region Подсказки
        private void dataGridView_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = @"Del - Удаление/Отмена уд.; Красные строки удалятся при подтверждении";
        }
        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = @"Alt+О - Отмена";
        }
        private void submitButton_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = @"Alt+П - Подтвердить";
        }
        #endregion
    }
}
