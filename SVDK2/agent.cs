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
            preparingProfile();
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
                switch (e.KeyCode)
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
                        break;
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

        #endregion
        #endregion
    }
}
