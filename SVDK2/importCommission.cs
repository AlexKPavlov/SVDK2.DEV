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
        int agent_id;

        public importCommission(SQLiteConnection sqliteConnection, int agent_id)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
            this.agent_id = agent_id;
        }

        private void importCommission_Load(object sender, EventArgs e)
        {
            loadAgentComboBox();
        }

        private void loadAgentComboBox() {
            sqliteConnection.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT agent_id, (CASE WHEN agent_active IS 'false' THEN agent_lnr||': '||agent_name||'(не акт.)' ELSE agent_lnr||': '||agent_name END) AS name FROM agent ORDER BY agent_active DESC", sqliteConnection);
            DataTable listAgent = new DataTable();
            adapter.Fill(listAgent);

            agentComboBox.DisplayMember = "name";
            agentComboBox.ValueMember = "agent_id";
            agentComboBox.DataSource = listAgent;
            agentComboBox.SelectedIndex = 0;
        }

        private void selectingAgentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectingAgentRadioButton.Checked)
                agentComboBox.Enabled = true;
            else
                agentComboBox.Enabled = false;
        }
    }
}
