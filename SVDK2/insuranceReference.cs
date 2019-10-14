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
    public partial class insuranceReference : Form
    {
        SQLiteConnection sqliteConnection;

        public insuranceReference(SQLiteConnection sqliteConnection)
        {
            InitializeComponent();

            this.sqliteConnection = sqliteConnection;
        }

        #region События
        private void insuranceReference_Load(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void changeModeToolStripButton_Click(object sender, EventArgs e)
        {

            if (!changeModeToolStripButton.Checked)
            {
                if (MessageBox.Show("Вы уверены, что хотите\nвключить режим редактирования?", "Вы уверены?",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    changeModeToolStripButton.Checked = true;
            }
            else
                changeModeToolStripButton.Checked = false;

            if (changeModeToolStripButton.Checked)
                changeModeToolStripButton.ForeColor = Color.Blue;
            else
                changeModeToolStripButton.ForeColor = Color.Black;
        }

        private void changeModeToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            if (changeModeToolStripButton.Checked)
            {
                addToolStripButton.Enabled = true;
                renameToolStripButton.Enabled = true;
                removeToolStripButton.Enabled = true;

                dataGridView.Columns[1].ReadOnly = false;
                dataGridView.AllowUserToAddRows = true;
                dataGridView.AllowUserToDeleteRows = true;
            }
            else
            {
                addToolStripButton.Enabled = false;
                renameToolStripButton.Enabled = false;
                removeToolStripButton.Enabled = false;

                dataGridView.Columns[1].ReadOnly = true;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["vs_name"];
            dataGridView.BeginEdit(false);

        }

        private void renameToolStripButton_Click(object sender, EventArgs e)
        {
            dataGridView.BeginEdit(false);
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridView.SelectedRows.Count;
            int[] id = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
                id[i] = Convert.ToInt32(dataGridView.SelectedRows[i].Cells["vs_kod"].Value);

            if (deleteRowsFromDB(id))
            {
                dataGridView.AllowUserToAddRows = false;
                int i = dataGridView.SelectedRows.Count;
                while (i-- > 0)
                    dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                dataGridView.AllowUserToAddRows = true;
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            updateDataGridView();
        }
        #endregion

        private void updateDataGridView()
        {
            dataGridView.Rows.Clear();

            SQLiteCommand loadList = new SQLiteCommand("SELECT * FROM vs", sqliteConnection);
            sqliteConnection.Open();
            SQLiteDataReader reader = loadList.ExecuteReader();
            while (reader.Read())
            {
                int rowNumber = dataGridView.Rows.Add();
                dataGridView.Rows[rowNumber].Cells["vs_kod"].Value = reader["vs_kod"];
                dataGridView.Rows[rowNumber].Cells["vs_name"].Value = reader["vs_name"];
            }
            sqliteConnection.Close();
        }

        private Boolean deleteRowsFromDB(int[] id)
        {
            if (id.Count() <= 0)
                return true;

            if (MessageBox.Show("Вы уверены, что хотите\nудалить " + id.Count() + " строк?", "Вы уверены?",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;

            string command = "DELETE FROM vs WHERE vs_kod='" + id[0] + "'";
            for (int i = 1; i < id.Count(); i++)
                command += " OR vs_kod='" + id[i] + "'";
            sqliteConnection.Open();
            SQLiteCommand delRow = new SQLiteCommand(command, sqliteConnection);
            delRow.ExecuteNonQuery();
            sqliteConnection.Close();

            return true;
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46) 
            {
                removeToolStripButton.PerformClick();
            }
        }
    }
}
