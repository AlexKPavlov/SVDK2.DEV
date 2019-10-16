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
                agentDataGridView.Rows[rowNumber].Cells["kod"].Value = reader["agent_lnr"];
                agentDataGridView.Rows[rowNumber].Cells["active"].Value = reader["agent_active"];
            }
            sqliteConnection.Close();

            int additionRowNumber = agentDataGridView.Rows.Add();
            agentDataGridView.Rows[additionRowNumber].Cells["id"].Value = -1;
            agentDataGridView.Rows[additionRowNumber].Cells["general"].Value = "<-Добавить агента->";
            agentDataGridView.Rows[additionRowNumber].Cells["active"].Value = false;
        }

        private void refreshAgentDataGrid()
        {
            foreach (DataGridViewRow item in agentDataGridView.Rows)    //Порядок отображения
                if (Convert.ToInt32(item.Cells["id"].Value) != -1)
                    item.Cells["general"].Value = item.Cells["kod"].Value + ": " + item.Cells["name"].Value;
            agentDataGridView.Sort(agentDataGridView.Columns["kod"], ListSortDirection.Ascending);
            agentDataGridView.Sort(agentDataGridView.Columns["active"], ListSortDirection.Descending);

            foreach (DataGridViewRow item in agentDataGridView.Rows)    //Оформление строк
            {
                if (Convert.ToBoolean(item.Cells["active"].Value))  //Активные строки
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
                searchInAgentDataGrid("");

                return true;
            }
            if (countVisibleString == 0)
            {
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
    }
}
