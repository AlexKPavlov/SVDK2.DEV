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

        public agentReport(SQLiteConnection sqliteConnection, int agent_id, int year, int quarter, int report_id = -1)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
        }
    }
}
