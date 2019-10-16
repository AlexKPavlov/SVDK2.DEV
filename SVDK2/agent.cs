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
        }

        private void loadAgentList() {
            SQLiteCommand load = new SQLiteCommand("SELECT * FROM agent", sqliteConnection);

            sqliteConnection.Open();
            SQLiteDataReader reader = load.ExecuteReader();
            while (reader.Read())
            {
                int rowNumber = agentDataGridView.Rows.Add();
                agentDataGridView.Rows[rowNumber].Cells["id"].Value = reader["agent_lnr"];
                agentDataGridView.Rows[rowNumber].Cells["name"].Value = reader["agent_lnr"]+": "+reader["agent_name"];
                agentDataGridView.Rows[rowNumber].Cells["active"].Value = reader["agent_active"];
            }
        }
    }
}
