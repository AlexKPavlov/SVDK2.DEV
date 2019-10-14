using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SQLite;

namespace SVDK2
{
    public partial class main : Form
    {
        IniFile settingsIni = new IniFile(@"setting.ini");  //Файл настроек
        SQLiteConnection sqliteConnection;  //Строка подключения

        public main()
        {
            InitializeComponent();

            if (settingsIni.Read("dbPath", "db").Length == 0)
                settingsIni.Write("dbPath", @"db.db", "db");
            sqliteConnection = new SQLiteConnection(@"Data Source="+settingsIni.Read("dbPath", "db") + @"; Version=3;");
        }


        #region События
        #region События кнопок
        private void AgentToolStripButton_main_Click(object sender, EventArgs e)
        {

        }

        private void insuranceToolStripButton_main_Click(object sender, EventArgs e)
        {
            insuranceReference form = new insuranceReference(sqliteConnection);
            form.ShowDialog();
        }
        #endregion

        #endregion


    }
}
