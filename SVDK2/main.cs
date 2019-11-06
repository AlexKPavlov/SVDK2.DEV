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
using System.IO.Compression;
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

            if (settingsIni.Read("dbPath", "db").Length == 0)   //Загрузка пути п создание строки плдключения
                settingsIni.Write("dbPath", @"db.db", "db");
            sqliteConnection = new SQLiteConnection(@"Data Source=" + settingsIni.Read("dbPath", "db") + @"; Version=3;");
            sqliteConnection.ConnectionString += "foreign keys=true;";  //Включение проверки внешних ключей
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (settingsIni.Read("name", "settings").Length == 0)   //Загрузка настроек в поля
                settingsIni.Write("name", "ФИО", "settings");
            fioToolStripTextBox_main.TextBox.Text = settingsIni.Read("name", "settings");
            if (settingsIni.Read("help", "settings").Length == 0)
                settingsIni.Write("help", "true", "settings");
            helpToolStripMenuItem_main.Checked = Convert.ToBoolean(settingsIni.Read("help", "settings"));
            helpStatusStrip_main.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
            if (settingsIni.Read("countDayBackup", "settings").Length == 0)
                settingsIni.Write("countDayBackup", "30", "settings");
            countDayBackupsToolStripTextBox_main.TextBox.Text = settingsIni.Read("countDayBackup", "settings");

            yearNumericUpDown_main.Value = DateTime.Now.Year;       //Установка даты
            quarterNumericUpDown_main.Value = (int)((DateTime.Now.Month + 2) / 3);
            loadChart();    //Загрузка диаграммы
        }

        #region События
        #region События кнопок
        private void AgentToolStripButton_main_Click(object sender, EventArgs e)    //Открытие формы агентов
        {
            agent form = new agent(sqliteConnection);
            this.Hide();
            form.ShowDialog();
            this.Show();
            loadChart();
        }

        private void insuranceToolStripButton_main_Click(object sender, EventArgs e)    //Открытие формы видов страхования
        {
            insuranceReference form = new insuranceReference(sqliteConnection);
            this.Hide();
            form.ShowDialog();
            this.Show();
            loadChart();
        }



        #endregion

        #region События изменения настроек
        private void fioToolStripTextBox_main_TextChanged(object sender, EventArgs e)   //Запись нового ФИО
        {
            settingsIni.Write("name", fioToolStripTextBox_main.TextBox.Text, "settings");
            this.Text = this.Text.Split(new string[] { @" (" }, StringSplitOptions.RemoveEmptyEntries)[0] + @" (" + settingsIni.Read("name", "settings") + ")";
        }
        private void helpToolStripMenuItem_main_Click(object sender, EventArgs e)   //Запись состояния подсказок
        {
            helpToolStripMenuItem_main.Checked = !helpToolStripMenuItem_main.Checked;
            settingsIni.Write("help", helpToolStripMenuItem_main.Checked.ToString(), "settings");
            helpStatusStrip_main.Visible = Convert.ToBoolean(settingsIni.Read("help", "settings"));
        }
        #endregion

        #endregion

        private void loadChart()    //Загрузка диаграммы
        {
            sqliteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT agent.agent_lnr, agent.agent_name, " +
                                                      "(SELECT SUM(agentReportContent.agentReportContent_count) FROM agentReport, agentReportContent WHERE agentReport.agentReport_id=agentReportContent.agentReport_id AND agentReport.agent_id=agent.agent_id AND strftime('%Y', " +
                                                      " agentReport.agentReport_date)=@year AND ((cast(strftime('%m', agentReport.agentReport_date) as integer) + 2) / 3)=@quarter) as countCur, " +
                                                      "(SELECT SUM(insurancePlan.insurancePlan_quantity) FROM insurancePlan WHERE insurancePlan.agent_id=agent.agent_id AND insurancePlan.insurancePlan_year=@year AND insurancePlan.insurancePlan_quarter=@quarter) as countReq, " +
                                                      "(SELECT SUM(agentReportContent.agentReportContent_sum) FROM agentReport, agentReportContent WHERE agentReport.agentReport_id=agentReportContent.agentReport_id AND agentReport.agent_id=agent.agent_id AND strftime('%Y', " +
                                                      " agentReport.agentReport_date)=@year AND ((cast(strftime('%m', agentReport.agentReport_date) as integer) + 2) / 3)=@quarter) as sumCur, " +
                                                      "(SELECT SUM(insurancePlan.insurancePlan_sum) FROM insurancePlan WHERE insurancePlan.agent_id=agent.agent_id AND insurancePlan.insurancePlan_year=@year AND insurancePlan.insurancePlan_quarter=@quarter) as sumReq " +
                                                      "FROM agent WHERE agent.agent_active='true'", sqliteConnection);
            command.Parameters.AddWithValue("@year", yearNumericUpDown_main.Value.ToString());
            command.Parameters.AddWithValue("@quarter", Convert.ToInt32(quarterNumericUpDown_main.Value));
            SQLiteDataReader reader = command.ExecuteReader();

            chart_main.Series["count"].Points.Clear();
            chart_main.Series["sum"].Points.Clear();

            while (reader.Read())
            {
                decimal countCur = 0;
                decimal.TryParse(reader["countCur"].ToString(), out countCur);
                decimal countReq = 0;
                decimal.TryParse(reader["countReq"].ToString(), out countReq);

                if (countReq == 0)
                    countReq = 1;

                decimal count = (countCur / countReq) * Convert.ToDecimal(100);
                chart_main.Series["count"].Points.AddXY(chart_main.Series["count"].Points.Count, count);
                chart_main.Series["count"].Points[chart_main.Series["count"].Points.Count - 1].Label = count.ToString();
                chart_main.Series["count"].Points[chart_main.Series["count"].Points.Count - 1].AxisLabel = reader["agent_name"].ToString().Replace(" ", "\n") + "\n(" + reader["agent_lnr"].ToString() + ")";

                decimal sumCur = 0;
                if (reader["sumCur"] != DBNull.Value)
                    sumCur = Convert.ToDecimal(reader["sumCur"]);
                decimal sumReq = 0;
                if (reader["sumReq"] != DBNull.Value)
                    sumReq = Convert.ToDecimal(reader["sumReq"]);
                if (sumReq == 0)
                    sumReq = 1;

                decimal sum = (sumCur / sumReq) * Convert.ToDecimal(100);
                chart_main.Series["sum"].Points.AddXY(chart_main.Series["sum"].Points.Count, sum);
                chart_main.Series["sum"].Points[chart_main.Series["sum"].Points.Count - 1].Label = sum.ToString();
            }

            sqliteConnection.Close();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы хотите создать резервную копию?", "Резервная копия?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            RemoveOldFile.DeleteOldFiles(Directory.GetCurrentDirectory() + @"\backup", Convert.ToUInt32(settingsIni.Read("countDayBackup", "settings")));
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\temp");
            File.Copy(Directory.GetCurrentDirectory() + @"\db.db", Directory.GetCurrentDirectory() + @"\temp\db.db");
            Random random = new Random();
            ZipFile.CreateFromDirectory(Directory.GetCurrentDirectory() + @"\temp", Directory.GetCurrentDirectory() + @"\backup\" + DateTime.Now.ToString("d") + "-" + random.Next(2147483647) + ".zip");
            Directory.Delete(Directory.GetCurrentDirectory() + @"\temp", true);
        }

        #region Подсказки
        private void AgentToolStripButton_main_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel_main.Text = "Alt+А - Агенты;";
        }
        private void insuranceToolStripButton_main_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel_main.Text = "Alt+В - Виды страхования;";
        }

        private void yearLabel_main_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel_main.Text = "Alt+Ф - Увеличить год; Alt+Я - Уменьшить год";
        }

        private void quarterLabel_main_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripStatusLabel_main.Text = "Alt+Ы - Увеличить квартал; Alt+Ч - Уменьшить квартал";
        }
        #endregion

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
                switch (e.KeyCode)  //Изменение даты
                {
                    case Keys.A:
                        {
                            yearNumericUpDown_main.UpButton();
                            loadChart();
                            e.SuppressKeyPress = true;
                        }
                        break;
                    case Keys.Z:
                        {
                            yearNumericUpDown_main.DownButton();
                            loadChart();
                            e.SuppressKeyPress = true;
                        }
                        break;
                    case Keys.S:
                        {
                            quarterNumericUpDown_main.UpButton();
                            loadChart();
                            e.SuppressKeyPress = true;
                        }
                        break;
                    case Keys.X:
                        {
                            quarterNumericUpDown_main.DownButton();
                            loadChart();
                            e.SuppressKeyPress = true;
                        }
                        break;
                }
        }

        private void countDayBackupsToolStripTextBox_main_TextChanged(object sender, EventArgs e)   //Запись дней хранения РК
        {
            UInt32 count = 30;
            if (!UInt32.TryParse(countDayBackupsToolStripTextBox_main.Text, out count))
            {
                MessageBox.Show("Количество дней должно быть целым положительным числом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            settingsIni.Write("countDayBackup", count.ToString(), "settings");
        }
    }
}
