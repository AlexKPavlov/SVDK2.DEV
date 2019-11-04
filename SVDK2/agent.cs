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
using Microsoft.Office.Interop.Excel;

using Application = Microsoft.Office.Interop.Excel.Application;

namespace SVDK2
{
    public partial class agent : Form
    {
        SQLiteConnection sqliteConnection;

        public agent(SQLiteConnection sqliteConnection)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
        }

        private void agent_Load(object sender, EventArgs e)
        {
            loadAgentList();
            refreshAgentDataGrid();
            loadSettings();
            //preparingProfile();

            yearNumericUpDown_commission.Value = DateTime.Now.Year;
            yearNumericUpDown_report.Value = DateTime.Now.Year;
            quarterNumericUpDown_report.Value = (DateTime.Now.Month + 2) / 3;
            yearNumericUpDown_analytical.Value = DateTime.Now.Year;
            quarterNumericUpDown_analytical.Value = (DateTime.Now.Month + 2) / 3;
        }

        private void loadSettings()
        {
            IniFile settingsIni = new IniFile(@"setting.ini");
            this.Text = this.Text.Split(new string[] { @" (" }, StringSplitOptions.RemoveEmptyEntries)[0] + @" (" + settingsIni.Read("name", "settings") + ")";
            statusStrip.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
        }


        #region Обработка списка агентов и поиска в нём
        private void loadAgentList()
        {
            agentDataGridView.Rows.Clear();
            SQLiteCommand load = new SQLiteCommand("SELECT * FROM agent", sqliteConnection);

            sqliteConnection.Open();
            SQLiteDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                int rowNumber = agentDataGridView.Rows.Add();
                agentDataGridView.Rows[rowNumber].Cells["id"].Value = reader["agent_id"];
                agentDataGridView.Rows[rowNumber].Cells["name"].Value = reader["agent_name"];
                agentDataGridView.Rows[rowNumber].Cells["kod"].Value = Convert.ToInt32(reader["agent_lnr"]);
                if (Convert.ToBoolean(reader["agent_active"]))
                    agentDataGridView.Rows[rowNumber].Cells["active"].Value = -1;
                else
                    agentDataGridView.Rows[rowNumber].Cells["active"].Value = 1;
            }
            sqliteConnection.Close();

            int additionRowNumber = agentDataGridView.Rows.Add();
            agentDataGridView.Rows[additionRowNumber].Cells["id"].Value = -1;
            agentDataGridView.Rows[additionRowNumber].Cells["general"].Value = "<-Добавить агента->";
            agentDataGridView.Rows[additionRowNumber].Cells["kod"].Value = -1;
            agentDataGridView.Rows[additionRowNumber].Cells["active"].Value = 0;
        }

        private void refreshAgentDataGrid()
        {
            foreach (DataGridViewRow item in agentDataGridView.Rows)    //Порядок отображения
                if (Convert.ToInt32(item.Cells["id"].Value) != -1)
                    item.Cells["general"].Value = item.Cells["kod"].Value + ": " + item.Cells["name"].Value;
            agentDataGridView.Sort(agentDataGridView.Columns["kod"], ListSortDirection.Ascending);
            agentDataGridView.Sort(agentDataGridView.Columns["active"], ListSortDirection.Ascending);

            foreach (DataGridViewRow item in agentDataGridView.Rows)    //Оформление строк
            {
                if (Convert.ToInt32(item.Cells["active"].Value) == -1)  //Активные строки
                {
                    item.Cells["general"].Style.ForeColor = Color.Black;
                    item.Cells["general"].Style.SelectionForeColor = Color.Black;
                    item.Cells["general"].Style.SelectionBackColor = Color.LightBlue;
                    item.Cells["general"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else    //Выключенные строки
                {
                    item.Cells["general"].Style.ForeColor = Color.Gray;
                    item.Cells["general"].Style.SelectionForeColor = Color.Gray;
                    item.Cells["general"].Style.SelectionBackColor = Color.LightBlue;
                    item.Cells["general"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                if ((Convert.ToInt32(item.Cells["id"].Value)) == -1) //Строка добавления
                {
                    item.Cells["general"].Style.ForeColor = Color.Black;
                    item.Cells["general"].Style.SelectionForeColor = Color.Black;
                    item.Cells["general"].Style.SelectionBackColor = Color.LightBlue;
                    item.Cells["general"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
        }

        private Boolean searchInAgentDataGrid(string text)
        {
            int countVisibleString = 0;
            int lastVisibleIndex = -1;

            foreach (DataGridViewRow item in agentDataGridView.Rows)
            {
                if (item.Cells["general"].Value.ToString().ToUpper().Contains(text.ToUpper()))
                {
                    if (lastVisibleIndex == -1 && text != "")
                        agentDataGridView.CurrentCell = item.Cells["general"];
                    item.Visible = true;
                    lastVisibleIndex = item.Index;
                    countVisibleString++;
                }
                else
                    item.Visible = false;
            }

            if (countVisibleString == 1)
            {
                agentDataGridView.CurrentCell = agentDataGridView.Rows[lastVisibleIndex].Cells["general"];
                if (agentDataGridView.Rows.Count > 1)
                    searchInAgentDataGrid("");

                return true;
            }
            if (countVisibleString == 0)
            {
                if (agentDataGridView.Rows.Count > 0)
                    searchInAgentDataGrid("");

                return true;
            }

            return false;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            Boolean endSearch = false;
            if (searchTextBox.Text == "Поиск...")
                endSearch = searchInAgentDataGrid("");
            else
                endSearch = searchInAgentDataGrid(searchTextBox.Text);

            if (endSearch)
            {
                searchTextBox.Text = "";
                tabControl.Focus();
            }


        }
        #endregion

        #region Placeholder для поля поиска
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Поиск...")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }
        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Поиск...";
                searchTextBox.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Горячие клавиши
        private void agent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)  //Общие горячие клавиши
                {
                    case Keys.G:    //Поиск
                        searchTextBox.Focus();
                        e.SuppressKeyPress = true;
                        break;
                    #region Цифры под вкладки на правой части
                    case Keys.D1:
                        if (tabControl.Controls.Count < 1)
                            break;
                        tabControl.SelectedIndex = 0;
                        tabControl.Controls[0].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D2:
                        if (tabControl.Controls.Count < 2)
                            break;
                        tabControl.SelectedIndex = 1;
                        tabControl.Controls[1].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D3:
                        if (tabControl.Controls.Count < 3)
                            break;
                        tabControl.SelectedIndex = 2;
                        tabControl.Controls[2].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D4:
                        if (tabControl.Controls.Count < 4)
                            break;
                        tabControl.SelectedIndex = 3;
                        tabControl.Controls[3].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D5:
                        if (tabControl.Controls.Count < 5)
                            break;
                        tabControl.SelectedIndex = 4;
                        tabControl.Controls[4].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D6:
                        if (tabControl.Controls.Count < 6)
                            break;
                        tabControl.SelectedIndex = 5;
                        tabControl.Controls[5].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D7:
                        if (tabControl.Controls.Count < 7)
                            break;
                        tabControl.SelectedIndex = 6;
                        tabControl.Controls[6].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D8:
                        if (tabControl.Controls.Count < 8)
                            break;
                        tabControl.SelectedIndex = 7;
                        tabControl.Controls[7].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D9:
                        if (tabControl.Controls.Count < 9)
                            break;
                        tabControl.SelectedIndex = 8;
                        tabControl.Controls[8].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    #endregion
                    #region Переключение в списке агентов
                    case Keys.A:    //Переключение на агента выше по списку
                        if (agentDataGridView.Rows.Count > 0)
                        {
                            int iter = 0;
                            int index = agentDataGridView.SelectedRows[0].Index - 1;
                            if (index < 0)
                                index = agentDataGridView.Rows.Count - 1;
                            while (!agentDataGridView.Rows[index].Visible && iter + 1 <= agentDataGridView.Rows.Count)
                            {
                                index--;
                                if (index < 0)
                                    index = agentDataGridView.Rows.Count - 1;
                                iter++;
                            }
                            if (iter <= agentDataGridView.Rows.Count)
                                agentDataGridView.CurrentCell = agentDataGridView.Rows[index].Cells["general"];

                            e.SuppressKeyPress = true;
                        }
                        break;
                    case Keys.Z:    //Переключение на агента ниже по списку
                        if (agentDataGridView.Rows.Count > 0)
                        {
                            int iter = 0;
                            int index = agentDataGridView.SelectedRows[0].Index + 1;
                            if (index > agentDataGridView.Rows.Count - 1)
                                index = 0;
                            while (!agentDataGridView.Rows[index].Visible && iter + 1 <= agentDataGridView.Rows.Count)
                            {
                                index++;
                                if (index > agentDataGridView.Rows.Count - 1)
                                    index = 0;
                                iter++;
                            }
                            if (iter <= agentDataGridView.Rows.Count)
                                agentDataGridView.CurrentCell = agentDataGridView.Rows[index].Cells["general"];

                            e.SuppressKeyPress = true;
                        }
                        break;
                    #endregion
                    case Keys.J:    //Обновление формы
                        tabControl.Focus();
                        loadAgentList();
                        refreshAgentDataGrid();
                        e.SuppressKeyPress = true;
                        break;
                }

                switch (tabControl.SelectedTab.Name)    //Горячие клавиши вкладок
                {
                    #region Комиссионные
                    case "commissionTabPage":
                        {
                            switch (e.KeyCode)
                            {
                                case Keys.S:
                                    {
                                        yearNumericUpDown_commission.UpButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.X:
                                    {
                                        yearNumericUpDown_commission.DownButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Отчёты агентов
                    case "reportTabPage":
                        {
                            switch (e.KeyCode)
                            {
                                case Keys.S:
                                    {
                                        yearNumericUpDown_report.UpButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.X:
                                    {
                                        yearNumericUpDown_report.DownButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.D:
                                    {
                                        quarterNumericUpDown_report.UpButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.C:
                                    {
                                        quarterNumericUpDown_report.DownButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Аналитика
                    case "analyticalTabPage":
                        {
                            switch (e.KeyCode)
                            {
                                case Keys.S:
                                    {
                                        yearNumericUpDown_analytical.UpButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.X:
                                    {
                                        yearNumericUpDown_analytical.DownButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.D:
                                    {
                                        quarterNumericUpDown_analytical.UpButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                                case Keys.C:
                                    {
                                        quarterNumericUpDown_analytical.DownButton();
                                        e.SuppressKeyPress = true;
                                    }
                                    break;
                            }
                        }
                        break;
                        #endregion
                }
            }
        }
        #endregion

        private void loadSelectedUserInCurrentTabPage() //Загрузка данных выбранного агента В выбранную вкладку
        {
            if (agentDataGridView.CurrentRow == null)
                return;

            switch (tabControl.SelectedTab.Name)
            {
                case "profileTabPage":
                    loadProfileAgent(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value));
                    break;
                case "commissionTabPage":
                    loadCommissionDataGrid(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value));
                    break;
                case "reportTabPage":
                    loadReportTreeView(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_report.Value), Convert.ToInt32(quarterNumericUpDown_report.Value));
                    break;
                case "analyticalTabPage":
                    loadAnalyticalDataGridView(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_analytical.Value), Convert.ToInt32(quarterNumericUpDown_analytical.Value));
                    break;
            }
        }

        private void agentDataGridView_CurrentCellChanged(object sender, EventArgs e)   //События для вызова обновления данных
        {
            loadSelectedUserInCurrentTabPage();
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSelectedUserInCurrentTabPage();
        }

        #region Функции работы с данными вкладок + их события
        #region Профиль - profileTabPage
        private void preparingProfile()
        {
            kodAgentNumericUpDown_profile.Controls[0].Visible = false;
            branchCodeNumericUpDown_profile.Controls[0].Visible = false;
            saleChanelNumericUpDown_profile.Controls[0].Visible = false;
        }

        private void loadProfileAgent(int idAgent)
        {
            nameTextBox_profile.Text = "";    //Очистка полей
            kodAgentNumericUpDown_profile.Value = 0;
            branchCodeNumericUpDown_profile.Value = 13700000;
            saleChanelNumericUpDown_profile.Value = 0;
            contactTextBox_profile.Text = "";
            activeCheckBox_profile.Checked = false;

            if (idAgent == -1)  //Активация/дезактивация полей для добавления нового агента
            {
                nameTextBox_profile.Enabled = false;
                kodAgentNumericUpDown_profile.Enabled = false;
                branchCodeNumericUpDown_profile.Enabled = false;
                saleChanelNumericUpDown_profile.Enabled = false;
                contactTextBox_profile.Enabled = false;
                activeCheckBox_profile.Enabled = false;
                deleteAgentButton_profile.Enabled = false;
                addNewAgentButton_profile.Visible = true;
                return;
            }
            else
            {
                nameTextBox_profile.Enabled = true;
                kodAgentNumericUpDown_profile.Enabled = true;
                branchCodeNumericUpDown_profile.Enabled = true;
                saleChanelNumericUpDown_profile.Enabled = true;
                contactTextBox_profile.Enabled = true;
                activeCheckBox_profile.Enabled = true;
                deleteAgentButton_profile.Enabled = true;
                addNewAgentButton_profile.Visible = false;
            }

            Boolean connectionOppened = false;
            if (sqliteConnection.State == ConnectionState.Open)
                connectionOppened = true;
            if (!connectionOppened)
                sqliteConnection.Open();
            SQLiteCommand load = new SQLiteCommand(@"SELECT * FROM agent WHERE agent_id=$id", sqliteConnection);
            load.Parameters.AddWithValue("id", idAgent);
            SQLiteDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                nameTextBox_profile.Text = reader["agent_name"].ToString();
                kodAgentNumericUpDown_profile.Value = Convert.ToInt32(reader["agent_lnr"]);
                branchCodeNumericUpDown_profile.Value = Convert.ToInt32(reader["agent_branch_code"]);
                saleChanelNumericUpDown_profile.Value = Convert.ToInt32(reader["agent_sale_chanel"]);
                contactTextBox_profile.Lines = reader["agent_contact"].ToString().Split(new string[] { @"\n" }, StringSplitOptions.None);
                activeCheckBox_profile.Checked = Convert.ToBoolean(reader["agent_active"]);
            }
            if (!connectionOppened)
                sqliteConnection.Close();
        }

        private void nameTextBox_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_name=$name WHERE agent_id=$id", sqliteConnection);
            update.Parameters.AddWithValue("$name", nameTextBox_profile.Text);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
            agentDataGridView.SelectedRows[0].Cells["general"].Value += "*";
        }
        private void kodAgentNumericUpDown_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_lnr=$kod WHERE agent_id=$id", sqliteConnection);
            update.Parameters.AddWithValue("$kod", kodAgentNumericUpDown_profile.Value);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
            agentDataGridView.SelectedRows[0].Cells["general"].Value += "*";
        }
        private void branchCodeNumericUpDown_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_branch_code=$code WHERE agent_id=$id", sqliteConnection);
            update.Parameters.AddWithValue("$code", branchCodeNumericUpDown_profile.Value);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
        }
        private void saleChanelNumericUpDown_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_sale_chanel=$chanel WHERE agent_id=$id", sqliteConnection);
            update.Parameters.AddWithValue("$chanel", saleChanelNumericUpDown_profile.Value);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
        }
        private void contactTextBox_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_contact=$contact WHERE agent_id=$id", sqliteConnection);
            string contact = "";
            foreach (string item in contactTextBox_profile.Lines)
            {
                if (contact != "")
                    contact += @"\n";
                contact += @item;
            }
            update.Parameters.AddWithValue("$contact", contact);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
        }
        private void activeCheckBox_profile_Leave(object sender, EventArgs e)
        {
            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand("UPDATE agent SET agent_active=$active WHERE agent_id=$id", sqliteConnection);
            update.Parameters.AddWithValue("$active", activeCheckBox_profile.Checked);
            update.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            update.ExecuteNonQuery();
            sqliteConnection.Close();
            agentDataGridView.SelectedRows[0].Cells["general"].Value += "*";
        }

        private void deleteAgentButton_profile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить агента?\nЭто действие нельзя отменить.",
                "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            sqliteConnection.Open();
            SQLiteCommand delete = new SQLiteCommand("DELETE FROM agent WHERE agent_id=$id", sqliteConnection);
            delete.Parameters.AddWithValue("$id", agentDataGridView.SelectedRows[0].Cells["id"].Value);
            delete.ExecuteNonQuery();
            sqliteConnection.Close();
            agentDataGridView.Rows.Remove(agentDataGridView.SelectedRows[0]);
        }

        private void addNewAgentButton_profile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите\nсоздать нового агента?",
                "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            sqliteConnection.Open();
            SQLiteCommand add = new SQLiteCommand("INSERT INTO agent (agent_name, agent_sale_chanel, agent_contact) VALUES ('','0',''); select seq from sqlite_sequence where name='agent';", sqliteConnection);
            SQLiteDataReader reader = add.ExecuteReader();
            while (reader.Read())
            {
                agentDataGridView.Rows.Insert(0, 1);
                agentDataGridView.Rows[0].Cells["id"].Value = Convert.ToInt32(reader["seq"]);
                agentDataGridView.Rows[0].Cells["general"].Value = "Новый агент";
            }
            sqliteConnection.Close();

        }

        #endregion
        #region Комиссионные и плановые показатели - commissionTabPage
        private void loadCommissionDataGrid(int agent_id, int year)
        {
            dataGridView_commission.Rows.Clear();
            dataGridView_commission.Rows.Add();
            dataGridView_commission.Rows.Add();
            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT vs_id as id, (vs_kod || ': ' || vs_name) as name FROM vs", sqliteConnection);
            System.Data.DataTable tableVs = new System.Data.DataTable();
            adapter.AcceptChangesDuringFill = false;
            adapter.Fill(tableVs);
            comboBoxCell.DisplayMember = "name";
            comboBoxCell.ValueMember = "id";
            comboBoxCell.DataSource = tableVs;
            comboBoxCell.AutoComplete = true;
            dataGridView_commission.Rows[1].Cells["vs_name"] = comboBoxCell;
            dataGridView_commission.Rows[1].Visible = false;
            dataGridView_commission.Rows[0].Cells["vs_name"] = (DataGridViewComboBoxCell)dataGridView_commission.Rows[1].Cells["vs_name"].Clone();
            dataGridView_commission.Rows[0].Cells["vs_name"].ReadOnly = false;

            if (agent_id == -1 || year < DateTime.Now.Year)  //Активация/дезактивация полей для добавления нового агента
            {
                dataGridView_commission.Enabled = false;
                //yearNumericUpDown_commission.Enabled = false;
                importButton_commission.Enabled = false;
            }
            else
            {
                dataGridView_commission.Enabled = true;
                //yearNumericUpDown_commission.Enabled = true;
                importButton_commission.Enabled = true;
            }
            if (agent_id == -1)
                return;

            sqliteConnection.Open();
            List<int> vs_id = new List<int> { };
            SQLiteCommand command = new SQLiteCommand("SELECT DISTINCT insurancePlan.vs_id FROM insurancePlan WHERE insurancePlan.agent_id=$agent_id AND insurancePlan.insurancePlan_year=$year", sqliteConnection);
            command.Parameters.AddWithValue("$agent_id", agent_id);
            command.Parameters.AddWithValue("$year", Convert.ToInt32(yearNumericUpDown_commission.Value));
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                vs_id.Add(Convert.ToInt32(reader[0]));
            }
            command = new SQLiteCommand("SELECT DISTINCT commissionPercent.vs_id FROM commissionPercent WHERE commissionPercent.agent_id=$agent_id AND commissionPercent.commissionPercent_year=$year", sqliteConnection);
            command.Parameters.AddWithValue("$agent_id", agent_id);
            command.Parameters.AddWithValue("$year", Convert.ToInt32(yearNumericUpDown_commission.Value));
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                vs_id.Add(Convert.ToInt32(reader[0]));
            }
            IEnumerable<int> vs_id_distinct = vs_id.Distinct();
            foreach (int item in vs_id_distinct)
            {
                dataGridView_commission.Rows.InsertCopy(dataGridView_commission.Rows.Count - 1, dataGridView_commission.Rows.Count - 2);
                int index = dataGridView_commission.Rows.Count - 3;
                dataGridView_commission.Rows[index].Cells["vs_id"].Value = item;
                Int64 indexInTable = 0;
                foreach (DataRow row in tableVs.Rows)
                    if (Convert.ToInt64(item) == Convert.ToInt64(row.ItemArray[0]))
                        indexInTable = Convert.ToInt64(row.ItemArray[0]);
                dataGridView_commission.Rows[index].Cells["vs_name"].Value = indexInTable;
                dataGridView_commission.Rows[index].Visible = true;

                int commissionId;
                decimal commissionPercent;
                findIdOrCreateCommission(agent_id, item, year, out commissionId, out commissionPercent);
                dataGridView_commission.Rows[index].Cells["commissionPercent_id"].Value = commissionId;
                dataGridView_commission.Rows[index].Cells["commissionPercent_id"].ReadOnly = false;
                dataGridView_commission.Rows[index].Cells["commissionPercent_persent"].Value = commissionPercent;
                dataGridView_commission.Rows[index].Cells["commissionPercent_persent"].ReadOnly = false;

                for (int i = 1; i <= 4; i++)
                {
                    int insurancePlanId, insurancePlanQuantity;
                    decimal insurancePlanSum;
                    findIdOrCreateInsurancePlan(agent_id, item, year, i, out insurancePlanId, out insurancePlanQuantity, out insurancePlanSum);
                    dataGridView_commission.Rows[index].Cells["insurancePlan_id_" + i].Value = insurancePlanId;
                    dataGridView_commission.Rows[index].Cells["insurancePlan_id_" + i].ReadOnly = false;
                    dataGridView_commission.Rows[index].Cells["insurancePlan_quantity_" + i].Value = insurancePlanQuantity;
                    dataGridView_commission.Rows[index].Cells["insurancePlan_quantity_" + i].ReadOnly = false;
                    dataGridView_commission.Rows[index].Cells["insurancePlan_sum_" + i].Value = insurancePlanSum;
                    dataGridView_commission.Rows[index].Cells["insurancePlan_sum_" + i].ReadOnly = false;
                }
            }
            sqliteConnection.Close();
        }

        private void findIdOrCreateCommission(int agent_id, int vs_id, int year, out int commissionId, out decimal commissionPercent)
        {
            commissionId = -1;
            commissionPercent = 0;
            Boolean connectionOpen = false;
            if (sqliteConnection.State == ConnectionState.Open)
                connectionOpen = true;
            if (!connectionOpen)
                sqliteConnection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT commissionPercent_id AS id, commissionPercent_persent AS persent FROM commissionPercent WHERE agent_id=@agent_id AND vs_id=@vs_id AND commissionPercent_year=@year", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@vs_id", vs_id);
            command.Parameters.AddWithValue("@year", year);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                commissionId = Convert.ToInt32(reader[0]);
                commissionPercent = Convert.ToDecimal(reader[1]);
            }
            if (commissionId != -1)
                return;

            command = new SQLiteCommand("INSERT INTO commissionPercent (agent_id, vs_id, commissionPercent_year, commissionPercent_persent) VALUES (@agent_id, @vs_id, @year, @persent); SELECT last_insert_rowid()", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@vs_id", vs_id);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@persent", 0);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                commissionId = Convert.ToInt32(reader[0]);
                commissionPercent = 0;
            }

            if (!connectionOpen)
                sqliteConnection.Close();
        }

        private void findIdOrCreateInsurancePlan(int agent_id, int vs_id, int year, int quarter, out int insurancePlanId, out int insurancePlanQuantity, out decimal insurancePlanSum)
        {
            insurancePlanId = -1;
            insurancePlanQuantity = 0;
            insurancePlanSum = 0;
            Boolean connectionOpen = false;
            if (sqliteConnection.State == ConnectionState.Open)
                connectionOpen = true;
            if (!connectionOpen)
                sqliteConnection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT insurancePlan_id AS id, insurancePlan_quantity AS quantity, insurancePlan_sum AS sum FROM insurancePlan WHERE agent_id=@agent_id AND vs_id=@vs_id AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@vs_id", vs_id);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@quarter", quarter);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                insurancePlanId = Convert.ToInt32(reader[0]);
                insurancePlanQuantity = Convert.ToInt32(reader[1]);
                insurancePlanSum = Convert.ToDecimal(reader[2]);
            }
            if (insurancePlanId != -1)
                return;

            command = new SQLiteCommand("INSERT INTO insurancePlan (agent_id, vs_id, insurancePlan_year, insurancePlan_quarter, insurancePlan_quantity, insurancePlan_sum) VALUES (@agent_id, @vs_id, @year, @quarter, @quantity, @sum); SELECT last_insert_rowid()", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@vs_id", vs_id);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@quarter", quarter);
            command.Parameters.AddWithValue("@quantity", 0);
            command.Parameters.AddWithValue("@sum", 0);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                insurancePlanId = Convert.ToInt32(reader[0]);
                insurancePlanQuantity = 0;
                insurancePlanSum = 0;
            }

            if (!connectionOpen)
                sqliteConnection.Close();
        }

        private void dataGridView_commission_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null && dataGridView_commission.CurrentCell.Value == null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            if (comboBox != null && dataGridView_commission.CurrentCell.Value != null)
                dataGridView_commission.CurrentCell.ReadOnly = true;
        }

        private void dataGridView_commission_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex != dataGridView_commission.Rows.Count - 1 && e.RowIndex != dataGridView_commission.Rows.Count - 2)
            {
                switch (dataGridView_commission.Columns[e.ColumnIndex].Name)
                {
                    case "commissionPercent_persent":
                        {
                            decimal persent;
                            if (!decimal.TryParse(e.FormattedValue.ToString(), out persent))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE commissionPercent SET commissionPercent_persent=@persent WHERE commissionPercent_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@persent", persent);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["commissionPercent_id"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_quantity_1":
                        {
                            int quantity;
                            if (!Int32.TryParse(e.FormattedValue.ToString(), out quantity))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_quantity=@quantity WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_1"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_quantity_2":
                        {
                            int quantity;
                            if (!Int32.TryParse(e.FormattedValue.ToString(), out quantity))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_quantity=@quantity WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_2"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_quantity_3":
                        {
                            int quantity;
                            if (!Int32.TryParse(e.FormattedValue.ToString(), out quantity))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_quantity=@quantity WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_3"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_quantity_4":
                        {
                            int quantity;
                            if (!Int32.TryParse(e.FormattedValue.ToString(), out quantity))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_quantity=@quantity WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_4"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_sum_1":
                        {
                            decimal sum;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out sum))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_sum=@sum WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@sum", sum);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_1"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_sum_2":
                        {
                            decimal sum;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out sum))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_sum=@sum WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@sum", sum);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_2"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_sum_3":
                        {
                            decimal sum;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out sum))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_sum=@sum WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@sum", sum);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_3"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                    case "insurancePlan_sum_4":
                        {
                            decimal sum;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out sum))
                            {
                                MessageBox.Show("Недопустимое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }

                            sqliteConnection.Open();
                            SQLiteCommand command = new SQLiteCommand("UPDATE insurancePlan SET insurancePlan_sum=@sum WHERE insurancePlan_id=@id", sqliteConnection);
                            command.Parameters.AddWithValue("@sum", sum);
                            command.Parameters.AddWithValue("@id", dataGridView_commission.Rows[e.RowIndex].Cells["insurancePlan_id_4"].Value);
                            command.ExecuteNonQuery();
                            sqliteConnection.Close();
                        }
                        break;
                }
            }
        }

        private void dataGridView_commission_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_commission.Rows.Count - e.RowIndex == 2 && dataGridView_commission.Columns[e.ColumnIndex].Name == "vs_name")
            {
                int id = Convert.ToInt32(dataGridView_commission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (id == 0)
                    return;
                for (int i = 0; i <= dataGridView_commission.Rows.Count - 3; i++)
                    if (Convert.ToInt32(dataGridView_commission.Rows[i].Cells["vs_id"].Value) == id)
                    {
                        MessageBox.Show("Данный вид страхования уже находится в списке", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView_commission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }

                dataGridView_commission.Rows[e.RowIndex].Cells["vs_id"].Value = Convert.ToInt32(dataGridView_commission.Rows[e.RowIndex].Cells["vs_name"].Value);

                timer_commission.Start();
            }
        }

        private void loadRowGrid()
        {
            int index = dataGridView_commission.Rows.Count - 2;
            dataGridView_commission.Rows[index].Cells["vs_name"].ReadOnly = true;
            int commissionId;
            decimal commissionPercent;
            findIdOrCreateCommission(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(dataGridView_commission.Rows[index].Cells["vs_id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value), out commissionId, out commissionPercent);
            dataGridView_commission.Rows[index].Cells["commissionPercent_id"].Value = commissionId;
            dataGridView_commission.Rows[index].Cells["commissionPercent_id"].ReadOnly = false;
            dataGridView_commission.Rows[index].Cells["commissionPercent_persent"].Value = commissionPercent;
            dataGridView_commission.Rows[index].Cells["commissionPercent_persent"].ReadOnly = false;

            for (int i = 1; i <= 4; i++)
            {
                int insurancePlanId, insurancePlanQuantity;
                decimal insurancePlanSum;
                findIdOrCreateInsurancePlan(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(dataGridView_commission.Rows[index].Cells["vs_id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value), i, out insurancePlanId, out insurancePlanQuantity, out insurancePlanSum);
                dataGridView_commission.Rows[index].Cells["insurancePlan_id_" + i].Value = insurancePlanId;
                dataGridView_commission.Rows[index].Cells["insurancePlan_id_" + i].ReadOnly = false;
                dataGridView_commission.Rows[index].Cells["insurancePlan_quantity_" + i].Value = insurancePlanQuantity;
                dataGridView_commission.Rows[index].Cells["insurancePlan_quantity_" + i].ReadOnly = false;
                dataGridView_commission.Rows[index].Cells["insurancePlan_sum_" + i].Value = insurancePlanSum;
                dataGridView_commission.Rows[index].Cells["insurancePlan_sum_" + i].ReadOnly = false;
            }

            dataGridView_commission.Rows.InsertCopy(dataGridView_commission.Rows.Count - 1, dataGridView_commission.Rows.Count - 1);
            foreach (DataGridViewCell item in dataGridView_commission.Rows[dataGridView_commission.Rows.Count - 2].Cells)
                item.ReadOnly = true;
            dataGridView_commission.Rows[dataGridView_commission.Rows.Count - 2].Visible = true;
            dataGridView_commission.Rows[dataGridView_commission.Rows.Count - 2].Cells["vs_name"].ReadOnly = false;
        }

        private void timer_commission_Tick(object sender, EventArgs e)
        {
            timer_commission.Stop();
            loadRowGrid();
        }

        private void yearNumericUpDown_commission_ValueChanged(object sender, EventArgs e)
        {
            loadCommissionDataGrid(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value));
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridView_commission.SelectedRows.Count > 0)
            {
                if (dataGridView_commission.SelectedRows[0].Index == dataGridView_commission.Rows.Count - 2)
                    return;
                sqliteConnection.Open();
                SQLiteCommand command = new SQLiteCommand("DELETE FROM commissionPercent WHERE commissionPercent_id=@commissionPercent_id; DELETE FROM insurancePlan WHERE insurancePlan_id=@insurancePlan_id1 OR insurancePlan_id=@insurancePlan_id2 OR insurancePlan_id=@insurancePlan_id3 OR insurancePlan_id=@insurancePlan_id4;", sqliteConnection);
                command.Parameters.AddWithValue("@commissionPercent_id", dataGridView_commission.SelectedRows[0].Cells["commissionPercent_id"].Value);
                command.Parameters.AddWithValue("@insurancePlan_id1", dataGridView_commission.SelectedRows[0].Cells["insurancePlan_id_1"].Value);
                command.Parameters.AddWithValue("@insurancePlan_id2", dataGridView_commission.SelectedRows[0].Cells["insurancePlan_id_2"].Value);
                command.Parameters.AddWithValue("@insurancePlan_id3", dataGridView_commission.SelectedRows[0].Cells["insurancePlan_id_3"].Value);
                command.Parameters.AddWithValue("@insurancePlan_id4", dataGridView_commission.SelectedRows[0].Cells["insurancePlan_id_4"].Value);
                command.ExecuteNonQuery();
                sqliteConnection.Close();
                dataGridView_commission.Rows.Remove(dataGridView_commission.SelectedRows[0]);
                e.SuppressKeyPress = true;
            }
        }

        private void importButton_commission_Click(object sender, EventArgs e)
        {
            importCommission form = new importCommission(sqliteConnection, Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value));
            form.ShowDialog();
            loadCommissionDataGrid(Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_commission.Value));
        }



        #endregion
        #region Агентские отчёты - reportTabPage
        private void loadReportTreeView(int agent_id, int year, int quarter)
        {
            SQLiteCommand reportCommand, contentReportCommand;
            SQLiteDataReader reportReader, contentReportReader;
            treeView_report.Nodes.Clear();

            if (agent_id == -1 || DateTime.Parse(year+"."+((quarter*3)-2)) < DateTime.Parse(DateTime.Now.Year + "." + ((((DateTime.Now.Month+2)/3) * 3) - 2)))  //Активация/дезактивация полей для добавления нового агента
            {
                addButton_report.Enabled = false;
                editButton_report.Enabled = false;
                deleteButton_report.Enabled = false;
            }
            else
            {
                addButton_report.Enabled = true;
                editButton_report.Enabled = true;
                deleteButton_report.Enabled = true;
            }
            if (agent_id == -1)
                return;

            sqliteConnection.Open();
            reportCommand = new SQLiteCommand("SELECT agentReport_id, agentReport_code, agentReport_date FROM agentReport WHERE agent_id=@agent_id AND cast(strftime('%Y', agentReport_date) as integer)=@year AND ((cast(strftime('%m', agentReport_date) as integer) + 2) / 3)=@quarter", sqliteConnection);
            reportCommand.Parameters.AddWithValue("@agent_id", agent_id);
            reportCommand.Parameters.AddWithValue("@year", year);
            reportCommand.Parameters.AddWithValue("@quarter", quarter);
            reportReader = reportCommand.ExecuteReader();
            while (reportReader.Read())
            {
                TreeNode nodeParent = treeView_report.Nodes.Add("");
                nodeParent.Tag = reportReader["agentReport_id"].ToString();
                decimal sum = 0;
                int count = 0;

                contentReportCommand = new SQLiteCommand("SELECT arc.agentReportContent_id, vs.vs_kod, vs.vs_name, arc.agentReportContent_count, arc.agentReportContent_sum FROM agentReportContent AS arc LEFT JOIN vs ON arc.vs_id=vs.vs_id WHERE arc.agentReport_id=@report_id", sqliteConnection);
                contentReportCommand.Parameters.AddWithValue("@report_id", reportReader["agentReport_id"]);
                contentReportReader = contentReportCommand.ExecuteReader();
                while (contentReportReader.Read())
                {
                    nodeParent.Nodes.Add(contentReportReader["vs_kod"].ToString() + ": " + contentReportReader["vs_name"].ToString() + " X " + contentReportReader["agentReportContent_count"].ToString() + " шт. = " + contentReportReader["agentReportContent_sum"].ToString() + " руб.").Tag = contentReportReader["agentReportContent_id"].ToString();
                    sum += Convert.ToDecimal(contentReportReader["agentReportContent_sum"]);
                    count += Convert.ToInt32(contentReportReader["agentReportContent_count"]);
                }
                nodeParent.Text = reportReader["agentReport_code"].ToString() + " от " + Convert.ToDateTime(reportReader["agentReport_date"]).ToLongDateString() + " (" + count + " шт. за " + sum + " руб.)";
            }
            sqliteConnection.Close();
        }

        private void yearNumericUpDown_report_ValueChanged(object sender, EventArgs e)
        {
            loadSelectedUserInCurrentTabPage();
        }

        private void quarterNumericUpDown_report_ValueChanged(object sender, EventArgs e)
        {
            loadSelectedUserInCurrentTabPage();
        }

        private void treeView_report_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;

            if (e.Node.Level == 0)
                foreach (TreeNode item in e.Node.Nodes)
                    item.Checked = e.Node.Checked;
            else
            {
                e.Node.Parent.Checked = e.Node.Checked;
                foreach (TreeNode item in e.Node.Parent.Nodes)
                    if (item.Tag != e.Node.Tag)
                        item.Checked = e.Node.Checked;
            }
        }

        private void addButton_report_Click(object sender, EventArgs e)
        {
            agentReport form = new agentReport(sqliteConnection, Convert.ToInt32(agentDataGridView.CurrentRow.Cells["id"].Value), Convert.ToInt32(yearNumericUpDown_report.Value), Convert.ToInt32(quarterNumericUpDown_report.Value));
            form.ShowDialog();
            loadSelectedUserInCurrentTabPage();
        }

        private void editButton_report_Click(object sender, EventArgs e)
        {
            List<TreeNode> collection = new List<TreeNode> { };
            foreach (TreeNode item in treeView_report.Nodes)
                if (item.Checked)
                    collection.Add(item);

            if (collection.Count > 1)
                if (MessageBox.Show("Вы отметили для редактирования больше 1 отчёта.\nОтчёты будут редактироваться по очереди.\nЖелаете продолжить редактирование?", "Продолжить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            for (int i = 0; i < collection.Count; i++)
            {
                agentReport form = new agentReport(sqliteConnection, Convert.ToInt32(collection[i].Tag));
                form.ShowDialog();
                loadSelectedUserInCurrentTabPage();
                if (i < collection.Count - 1)
                    if (MessageBox.Show("Осталось " + (collection.Count - (i + 1)) + " отчётов.\nПродолжить редактирование?", "Продолжить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
            }
        }

        private void deleteButton_report_Click(object sender, EventArgs e)
        {
            List<TreeNode> collection = new List<TreeNode> { };
            foreach (TreeNode item in treeView_report.Nodes)
                if (item.Checked)
                    collection.Add(item);

            if (collection.Count > 0)
                if (MessageBox.Show("Вы действительно хотите удалить " + collection.Count + " отчётов?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            sqliteConnection.Open();
            foreach (TreeNode item in collection)
            {
                SQLiteCommand command = new SQLiteCommand("DELETE FROM agentReport WHERE agentReport_id=@id; DELETE FROM agentReportContent WHERE agentReport_id=@id", sqliteConnection);
                command.Parameters.AddWithValue("@id", item.Tag);
                command.ExecuteNonQuery();
            }
            sqliteConnection.Close();
            loadSelectedUserInCurrentTabPage();
        }

        private void exportReportButton_report_Click(object sender, EventArgs e)
        {
            List<TreeNode> collection = new List<TreeNode> { };
            foreach (TreeNode item in treeView_report.Nodes)
                if (item.Checked)
                    collection.Add(item);

            if (collection.Count == 0)
                return;

            try
            {
                Application application = new Application { DisplayAlerts = false };
                Workbook workBook;
                Worksheet worksheet;

                string template = Environment.CurrentDirectory + @"\template\agentReport.xlsm";
                workBook = application.Workbooks.Open(template, ReadOnly: true);
                worksheet = workBook.ActiveSheet as Worksheet;
                int row = 1;

                sqliteConnection.Open();
                foreach (TreeNode item in collection)
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT (agent.agent_name || ' (' || agent.agent_branch_code|| ')') AS agent_name, agentReport.agentReport_date, agentReport.agentReport_code FROM agentReport LEFT JOIN agent ON agentReport.agent_id=agent.agent_id WHERE agentReport.agentReport_id=@report_id", sqliteConnection);
                    command.Parameters.AddWithValue("@report_id", item.Tag);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (row > 1)
                    {
                        row++;
                        worksheet.Range["H1:M4"].Copy();
                        worksheet.Range["A" + row + ":F" + (row + 3)].PasteSpecial();
                    }
                    while (reader.Read())
                    {
                        worksheet.Range["B" + (row++)].Value = reader["agent_name"].ToString();
                        worksheet.Range["B" + (row++)].Value = reader["agentReport_code"].ToString();
                        worksheet.Range["B" + (row++)].Value = DateTime.Parse(reader["agentReport_date"].ToString()).ToShortDateString();
                    }
                    command = new SQLiteCommand("SELECT vs.vs_kod, vs.vs_name, agentReportContent.agentReportContent_count, agentReportContent.agentReportContent_sum, (CASE WHEN commissionPercent.commissionPercent_persent IS NOT NULL THEN commissionPercent.commissionPercent_persent ELSE 0 END) AS commissionPercent_persent FROM agentReportContent " +
                                                "LEFT JOIN vs ON vs.vs_id=agentReportContent.vs_id " +
                                                "LEFT JOIN agentReport ON agentReport.agentReport_id=agentReportContent.agentReport_id " +
                                                "LEFT JOIN commissionPercent ON (commissionPercent.agent_id=agentReport.agent_id AND commissionPercent.vs_id=agentReportContent.vs_id AND commissionPercent.commissionPercent_year=strftime('%Y', agentReport.agentReport_date)) " +
                                                "WHERE agentReportContent.agentReport_id=@report_id", sqliteConnection);
                    command.Parameters.AddWithValue("@report_id", item.Tag);
                    reader = command.ExecuteReader();
                    row++;
                    int startRow = row;
                    while (reader.Read())
                    {
                        worksheet.Range["A" + row].Value = Convert.ToInt32(reader["vs_kod"]);
                        worksheet.Range["B" + row].Value = reader["vs_name"].ToString();
                        worksheet.Range["C" + row].Value = Convert.ToInt32(reader["agentReportContent_count"]);
                        worksheet.Range["D" + row].Value = Convert.ToDecimal(reader["agentReportContent_sum"]);
                        worksheet.Range["E" + row].Value = Convert.ToDecimal(reader["commissionPercent_persent"]);
                        worksheet.Range["F" + row].Formula = "=D" + row + "*E" + row;
                        row++;
                    }
                    worksheet.Range["A" + row].Value = "Сумма:";
                    worksheet.Range["C" + row].Formula = "=SUM(C" + startRow + ":C" + (row - 1) + ")";
                    worksheet.Range["D" + row].Formula = "=SUM(D" + startRow + ":D" + (row - 1) + ")";
                    worksheet.Range["F" + row].Formula = "=SUM(F" + startRow + ":F" + (row - 1) + ")";
                    row++;

                    worksheet.Range["A" + startRow + ":F" + (row - 1)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    worksheet.Range["A" + startRow + ":F" + (row - 1)].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                }
                worksheet.PageSetup.PrintArea = "A1:F" + (row - 1);
                worksheet.Columns["H:M"].Delete();
                sqliteConnection.Close();

                application.Visible = true;
                TopMost = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Похоже у вас не установлен Microsoft Excel", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
        #endregion
        #region Аналитика - analyticalTabPage
        private void loadAnalyticalDataGridView(int agent_id, int year, int quarter)
        {
            dataGridView__analytical.Rows.Clear();

            if (agent_id == -1)
                return;

            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT ", sqliteConnection);
            command.Parameters.AddWithValue("@agent_id", agent_id);
            command.Parameters.AddWithValue("@year", year.ToString());
            command.Parameters.AddWithValue("@quarter", quarter);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int index = dataGridView__analytical.Rows.Add();
                dataGridView__analytical.Rows[index].Cells["vs_kod"].Value = reader["vs_kod"].ToString();
                dataGridView__analytical.Rows[index].Cells["vs_name1"].Value = reader["vs_name"].ToString();
                dataGridView__analytical.Rows[index].Cells["percent"].Value = Convert.ToDecimal(reader["persent"]);
                dataGridView__analytical.Rows[index].Cells["countNow"].Value = Convert.ToInt32(reader["countNow"]);
                dataGridView__analytical.Rows[index].Cells["sumNow"].Value = Convert.ToDecimal(reader["sumNow"]);
                dataGridView__analytical.Rows[index].Cells["countRequired"].Value = Convert.ToInt32(reader["countRequired"]);
                dataGridView__analytical.Rows[index].Cells["sumRequired"].Value = Convert.ToDecimal(reader["sumRequired"]);
                dataGridView__analytical.Rows[index].Cells["countLeft1"].Value = Convert.ToInt32(dataGridView__analytical.Rows[index].Cells["countRequired"].Value) - Convert.ToInt32(dataGridView__analytical.Rows[index].Cells["countNow"].Value);
                dataGridView__analytical.Rows[index].Cells["sumLeft"].Value = Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["sumRequired"].Value) - Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["sumNow"].Value);
                dataGridView__analytical.Rows[index].Cells["agentSum"].Value = Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["sumNow"].Value) * (Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["percent"].Value) / 100);
                dataGridView__analytical.Rows[index].Cells["agentSumPlan"].Value = Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["sumRequired"].Value) * (Convert.ToDecimal(dataGridView__analytical.Rows[index].Cells["percent"].Value) / 100);
            }

            sqliteConnection.Close();
        }

        private void yearNumericUpDown_analytical_ValueChanged(object sender, EventArgs e)
        {
            loadSelectedUserInCurrentTabPage();
        }
        private void quarterNumericUpDown_analytical_ValueChanged(object sender, EventArgs e)
        {
            loadSelectedUserInCurrentTabPage();
        }
        #endregion
        #endregion

        #region Подсказки
        #region Список агентов
        private void searchTextBox_MouseEnter(object sender, EventArgs e) //Поиск агентов
        {
            helpToolStripStatusLabel.Text = "Alt+П - Быстрое переключение на поиск";
        }
        private void agentDataGridView_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Ф - Вверх по списку; Alt+Я - Вниз по списку";
        }
        #endregion
        #region Вкладки
        private void tabControl_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+<Номер вкладки> - Переход к n-ой вкладке";
        }
        #region Профиль
        private void deleteAgentButton_profile_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+У - Удаление агента";
        }
        private void addNewAgentButton_profile_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Д - Добавление агента";
        }

        #endregion
        #region Комиссионные
        private void yearLabel_commission_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Ы - Увеличить год; Alt+Ч - Уменьшить год";
        }
        private void importButton_commission_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+И - Импорт";
        }

        #endregion
        #region Агентские отчёты
        private void yearLabel_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Ы - Увеличить год; Alt+Ч - Уменьшить год";
        }
        private void quarterLabel_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+В - Увеличить квартал; Alt+С - Уменьшить квартал";
        }
        private void addButton_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Д - Добавить отчёт";
        }
        private void editButton_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Р - Редактировать отчёт";
        }
        private void exportReportButton_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Э - Экспортировать выбранные отчёты";
        }
        private void deleteButton_report_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+У - Удалить выбранные отчёты";
        }
        #endregion
        #region Аналитика
        private void yearLabel_analytical_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+Ы - Увеличить год; Alt+Ч - Уменьшить год";
        }
        private void quarterLabel_analytical_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel.Text = "Alt+В - Увеличить квартал; Alt+С - Уменьшить квартал";
        }
        #endregion
        #endregion

        #endregion


    }
}
