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

        }

        private void loadAgentComboBox() {
            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT ", sqliteConnection);
        }
    }
}
