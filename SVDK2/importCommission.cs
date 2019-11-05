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
    public partial class importCommission : Form
    {
        SQLiteConnection sqliteConnection;
        int agent_id, year;

        public importCommission(SQLiteConnection sqliteConnection, int agent_id, int year)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
            this.agent_id = agent_id;
            this.year = year;
            yearNumericUpDown.Value = Convert.ToDecimal(year);
        }

        private void importCommission_Load(object sender, EventArgs e)
        {
            loadAgentComboBox();
        }

        private void loadAgentComboBox()
        {
            sqliteConnection.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT agent_id, (CASE WHEN agent_active IS 'false' THEN agent_lnr||': '||agent_name||'(не акт.)' ELSE agent_lnr||': '||agent_name END) AS name FROM agent ORDER BY agent_active DESC", sqliteConnection);
            DataTable listAgent = new DataTable();
            adapter.Fill(listAgent);
            sqliteConnection.Close();

            agentComboBox.DisplayMember = "name";
            agentComboBox.ValueMember = "agent_id";
            agentComboBox.DataSource = listAgent;
            agentComboBox.SelectedIndex = 0;
        }

        private void selectingAgentRadioButton_CheckedChanged(object sender, EventArgs e)   //Выключение выбора агента при выборе варианта источника "данный агент"
        {
            if (selectingAgentRadioButton.Checked)
                agentComboBox.Enabled = true;
            else
                agentComboBox.Enabled = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            sumbit();
        }

        private void sumbit()
        {
            Mode mode = Mode.add;
            int sourseAgentID;
            int year;
            bool commissionPercentEnabled = false;
            bool[] insurancePlanEnabled = new bool[4];

            if (fullResetModeRadioButton.Checked)   //Считывание параметров импортирования
                mode = Mode.fullImport;
            if (updateModeRadioButton.Checked)
                mode = Mode.update;
            if (addModeRadioButton.Checked)
                mode = Mode.add;
            if (commissionPercentCheckBox.Checked)
                commissionPercentEnabled = true;
            if (insurancePlan1CheckBox.Checked)
                insurancePlanEnabled[0] = true;
            if (insurancePlan2CheckBox.Checked)
                insurancePlanEnabled[1] = true;
            if (insurancePlan3CheckBox.Checked)
                insurancePlanEnabled[2] = true;
            if (insurancePlan4CheckBox.Checked)
                insurancePlanEnabled[3] = true;
            if (currentAgentRadioButton.Checked)
                sourseAgentID = agent_id;
            else
                sourseAgentID = Convert.ToInt32(agentComboBox.SelectedValue);
            year = Convert.ToInt32(yearNumericUpDown.Value);

            switch (mode)
            {
                case Mode.fullImport:   //При полном импортировании (удаление всех существующих данных)
                    {
                        sqliteConnection.Open();
                        SQLiteCommand loadCommand;
                        SQLiteDataReader reader;
                        SQLiteCommand deleteCommand;
                        SQLiteCommand addCommand;

                        if (commissionPercentEnabled)
                        {   //Загружаем данные из источника
                            loadCommand = new SQLiteCommand("SELECT vs_id, commissionPercent_percent FROM commissionPercent WHERE agent_id=@source AND commissionPercent_year=@year", sqliteConnection);
                            loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                            loadCommand.Parameters.AddWithValue("@year", year);
                            reader = loadCommand.ExecuteReader();   //Удаляем текущие данные
                            deleteCommand = new SQLiteCommand("DELETE FROM commissionPercent WHERE agent_id=@id AND commissionPercent_year=@year", sqliteConnection);
                            deleteCommand.Parameters.AddWithValue("@id", agent_id);
                            deleteCommand.Parameters.AddWithValue("@year", this.year);
                            deleteCommand.ExecuteNonQuery();
                            while (reader.Read())
                            {   //Добавляем новые данные
                                addCommand = new SQLiteCommand("INSERT INTO commissionPercent (agent_id, vs_id, commissionPercent_year, commissionPercent_percent) VALUES (@agent_id, @vs_id, @year, @persent)", sqliteConnection);
                                addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                addCommand.Parameters.AddWithValue("@year", this.year);
                                addCommand.Parameters.AddWithValue("@persent", reader["commissionPercent_percent"]);
                                addCommand.ExecuteNonQuery();
                            }
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            if (insurancePlanEnabled[i])
                            {       //Тоже саоме, но для остальных показателей
                                loadCommand = new SQLiteCommand("SELECT vs_id, insurancePlan_quantity, insurancePlan_sum FROM insurancePlan WHERE agent_id=@source AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
                                loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                                loadCommand.Parameters.AddWithValue("@year", year);
                                loadCommand.Parameters.AddWithValue("@quarter", i + 1);
                                reader = loadCommand.ExecuteReader();
                                deleteCommand = new SQLiteCommand("DELETE FROM insurancePlan WHERE agent_id=@id AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
                                deleteCommand.Parameters.AddWithValue("@id", agent_id);
                                deleteCommand.Parameters.AddWithValue("@year", this.year);
                                deleteCommand.Parameters.AddWithValue("@quarter", i + 1);
                                deleteCommand.ExecuteNonQuery();
                                while (reader.Read())
                                {
                                    addCommand = new SQLiteCommand("INSERT INTO insurancePlan (agent_id, vs_id, insurancePlan_year, insurancePlan_quarter, insurancePlan_quantity, insurancePlan_sum) VALUES (@agent_id, @vs_id, @year, @quarter, @quantity, @sum)", sqliteConnection);
                                    addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                    addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                    addCommand.Parameters.AddWithValue("@year", this.year);
                                    addCommand.Parameters.AddWithValue("@quarter", i + 1);
                                    addCommand.Parameters.AddWithValue("@quantity", reader["insurancePlan_quantity"]);
                                    addCommand.Parameters.AddWithValue("@sum", reader["insurancePlan_sum"]);
                                    addCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    break;
                case Mode.update:   //Добавление новых, обновление старых (оставляют данные которых нет в импортированых)
                    {
                        sqliteConnection.Open();
                        SQLiteCommand loadCommand;
                        SQLiteDataReader reader;
                        SQLiteCommand deleteCommand;
                        SQLiteCommand addCommand;

                        if (commissionPercentEnabled)
                        {   //Получение данных для импорта
                            loadCommand = new SQLiteCommand("SELECT vs_id, commissionPercent_percent FROM commissionPercent WHERE agent_id=@source AND commissionPercent_year=@year", sqliteConnection);
                            loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                            loadCommand.Parameters.AddWithValue("@year", year);
                            reader = loadCommand.ExecuteReader();
                            while (reader.Read())
                            {       //Удаление текущих данных для данного вида страхования (если данных нет, то ничего не произойдёт)
                                deleteCommand = new SQLiteCommand("DELETE FROM commissionPercent WHERE agent_id=@id AND commissionPercent_year=@year AND vs_id=@vs_id", sqliteConnection);
                                deleteCommand.Parameters.AddWithValue("@id", agent_id);
                                deleteCommand.Parameters.AddWithValue("@year", this.year);
                                deleteCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                deleteCommand.ExecuteNonQuery();
                                    //Добавление новых данных 
                                addCommand = new SQLiteCommand("INSERT INTO commissionPercent (agent_id, vs_id, commissionPercent_year, commissionPercent_percent) VALUES (@agent_id, @vs_id, @year, @persent)", sqliteConnection);
                                addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                addCommand.Parameters.AddWithValue("@year", this.year);
                                addCommand.Parameters.AddWithValue("@persent", reader["commissionPercent_percent"]);
                                addCommand.ExecuteNonQuery();
                            }
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            if (insurancePlanEnabled[i])
                            {       //Тоже саоме, но для остальных показателей
                                loadCommand = new SQLiteCommand("SELECT vs_id, insurancePlan_quantity, insurancePlan_sum FROM insurancePlan WHERE agent_id=@source AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
                                loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                                loadCommand.Parameters.AddWithValue("@year", year);
                                loadCommand.Parameters.AddWithValue("@quarter", i + 1);
                                reader = loadCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    deleteCommand = new SQLiteCommand("DELETE FROM insurancePlan WHERE agent_id=@id AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter AND vs_id=@vs_id", sqliteConnection);
                                    deleteCommand.Parameters.AddWithValue("@id", agent_id);
                                    deleteCommand.Parameters.AddWithValue("@year", this.year);
                                    deleteCommand.Parameters.AddWithValue("@quarter", i + 1);
                                    deleteCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                    deleteCommand.ExecuteNonQuery();

                                    addCommand = new SQLiteCommand("INSERT INTO insurancePlan (agent_id, vs_id, insurancePlan_year, insurancePlan_quarter, insurancePlan_quantity, insurancePlan_sum) VALUES (@agent_id, @vs_id, @year, @quarter, @quantity, @sum)", sqliteConnection);
                                    addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                    addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                    addCommand.Parameters.AddWithValue("@year", this.year);
                                    addCommand.Parameters.AddWithValue("@quarter", i + 1);
                                    addCommand.Parameters.AddWithValue("@quantity", reader["insurancePlan_quantity"]);
                                    addCommand.Parameters.AddWithValue("@sum", reader["insurancePlan_sum"]);
                                    addCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    break;
                case Mode.add:  //Добавление только новых данных (остальные игнорируются)
                    {
                        sqliteConnection.Open();
                        SQLiteCommand loadCommand;
                        SQLiteDataReader reader;
                        SQLiteCommand checkCommand;
                        SQLiteDataAdapter checkAdapter = new SQLiteDataAdapter();
                        SQLiteCommand addCommand = new SQLiteCommand();
                        DataTable currentData = new DataTable();
                        bool itExist;

                        if (commissionPercentEnabled)
                        {       //Загрузка списка существующих данных
                            checkCommand = new SQLiteCommand("SELECT vs_id FROM commissionPercent WHERE agent_id=@id AND commissionPercent_year=@year", sqliteConnection);
                            checkCommand.Parameters.AddWithValue("@id", agent_id);
                            checkCommand.Parameters.AddWithValue("@year", this.year);
                            checkAdapter = new SQLiteDataAdapter(checkCommand);
                            checkAdapter.Fill(currentData); //Загрузка новых данных
                            loadCommand = new SQLiteCommand("SELECT vs_id, commissionPercent_percent FROM commissionPercent WHERE agent_id=@source AND commissionPercent_year=@year", sqliteConnection);
                            loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                            loadCommand.Parameters.AddWithValue("@year", year);
                            reader = loadCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                itExist = false;    //Проверка на существование данных
                                foreach (DataRow item in currentData.Rows)
                                    if (Convert.ToInt32(reader["vs_id"]) == Convert.ToInt32(item.ItemArray[0]))
                                        itExist = true;
                                if (!itExist)
                                {       //Добовление новых данных
                                    addCommand = new SQLiteCommand("INSERT INTO commissionPercent (agent_id, vs_id, commissionPercent_year, commissionPercent_percent) VALUES (@agent_id, @vs_id, @year, @persent)", sqliteConnection);
                                    addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                    addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                    addCommand.Parameters.AddWithValue("@year", this.year);
                                    addCommand.Parameters.AddWithValue("@persent", reader["commissionPercent_percent"]);
                                    addCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            if (insurancePlanEnabled[i])
                            {       //Тоже саоме, но для остальных показателей
                                checkCommand = new SQLiteCommand("SELECT vs_id FROM insurancePlan WHERE agent_id=@source AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
                                checkCommand.Parameters.AddWithValue("@source", this.agent_id);
                                checkCommand.Parameters.AddWithValue("@year", year);
                                checkCommand.Parameters.AddWithValue("@quarter", i + 1);
                                currentData.Clear();
                                checkAdapter = new SQLiteDataAdapter(checkCommand);
                                checkAdapter.Fill(currentData);
                                loadCommand = new SQLiteCommand("SELECT vs_id, insurancePlan_quantity, insurancePlan_sum FROM insurancePlan WHERE agent_id=@source AND insurancePlan_year=@year AND insurancePlan_quarter=@quarter", sqliteConnection);
                                loadCommand.Parameters.AddWithValue("@source", sourseAgentID);
                                loadCommand.Parameters.AddWithValue("@year", year);
                                loadCommand.Parameters.AddWithValue("@quarter", i + 1);
                                reader = loadCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    itExist = false;
                                    foreach (DataRow item in currentData.Rows)
                                        if (Convert.ToInt32(reader["vs_id"]) == Convert.ToInt32(item.ItemArray[0]))
                                            itExist = true;
                                    if (!itExist)
                                    {
                                        addCommand = new SQLiteCommand("INSERT INTO insurancePlan (agent_id, vs_id, insurancePlan_year, insurancePlan_quarter, insurancePlan_quantity, insurancePlan_sum) VALUES (@agent_id, @vs_id, @year, @quarter, @quantity, @sum)", sqliteConnection);
                                        addCommand.Parameters.AddWithValue("@agent_id", agent_id);
                                        addCommand.Parameters.AddWithValue("@vs_id", reader["vs_id"]);
                                        addCommand.Parameters.AddWithValue("@year", this.year);
                                        addCommand.Parameters.AddWithValue("@quarter", i + 1);
                                        addCommand.Parameters.AddWithValue("@quantity", reader["insurancePlan_quantity"]);
                                        addCommand.Parameters.AddWithValue("@sum", reader["insurancePlan_sum"]);
                                        addCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            sqliteConnection.Close();
            this.Close();
        }

        enum Mode
        {
            fullImport,
            update,
            add
        }
    }
}
