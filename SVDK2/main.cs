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

        private void main_Load(object sender, EventArgs e)
        {
            if (settingsIni.Read("name", "settings").Length == 0)
                settingsIni.Write("name", "ФИО", "settings");
            fioToolStripTextBox_main.TextBox.Text = settingsIni.Read("name", "settings");
            if (settingsIni.Read("help", "settings").Length == 0)
                settingsIni.Write("help", "true", "settings");
            helpToolStripMenuItem_main.Checked = Convert.ToBoolean(settingsIni.Read("help", "settings"));
            helpStatusStrip_main.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
        }

        #region События
        #region События кнопок
        private void AgentToolStripButton_main_Click(object sender, EventArgs e)
        {
            agent form = new agent(sqliteConnection);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void insuranceToolStripButton_main_Click(object sender, EventArgs e)
        {
            insuranceReference form = new insuranceReference(sqliteConnection);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }



        #endregion

        #region События изменения настроек
        private void fioToolStripTextBox_main_TextChanged(object sender, EventArgs e)
        {
            settingsIni.Write("name", fioToolStripTextBox_main.TextBox.Text, "settings");
            this.Text = this.Text.Split(new string[] { @" (" }, StringSplitOptions.RemoveEmptyEntries)[0] + @" (" + settingsIni.Read("name", "settings") + ")";
        }
        private void helpToolStripMenuItem_main_Click(object sender, EventArgs e)
        {
            helpToolStripMenuItem_main.Checked = !helpToolStripMenuItem_main.Checked;
            settingsIni.Write("help", helpToolStripMenuItem_main.Checked.ToString(), "settings");
            helpStatusStrip_main.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
        }
        #endregion

        #endregion

        private void
    }
}
