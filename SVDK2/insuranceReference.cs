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
            changeModeToolStripButton_CheckStateChanged(null, null);
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

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == e.FormattedValue || dataGridView.Rows[e.RowIndex].Cells["vs_kod"].Value == null)
                return;

            string cell;
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                cell = "";
            else
                cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (cell.Length == 0 && e.FormattedValue.ToString() == "") {
                MessageBox.Show("Название не может быть пустым", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView.BeginEdit(false);
                return;
            }

            if (cell.Length > 0 && e.FormattedValue.ToString() == "") {
                MessageBox.Show("Название не может быть пустым", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            sqliteConnection.Open();
            SQLiteCommand update = new SQLiteCommand(@"UPDATE vs SET vs_name=$name WHERE vs_kod=$id;", sqliteConnection);
            update.Parameters.AddWithValue("$name", e.FormattedValue.ToString());
            update.Parameters.AddWithValue("$id", Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["vs_kod"].Value));
            update.ExecuteNonQuery();
            sqliteConnection.Close();
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT CASE WHEN vs_kod IS NULL THEN 0 ELSE MAX(vs_kod) END FROM vs", sqliteConnection);
            sqliteConnection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            int id = 0;

            while (reader.Read())
            {
                id = Convert.ToInt32(reader[0]) + 1;
            }

            dataGridView.Rows[e.Row.Index-1].Cells["vs_kod"].Value = id;

            command = new SQLiteCommand("INSERT INTO vs (vs_kod) VALUES($id)", sqliteConnection);
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
            
            sqliteConnection.Close();

            dataGridView.CurrentCell = dataGridView.Rows[e.Row.Index - 1].Cells["vs_name"];
            dataGridView.BeginEdit(false);

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


    }
}
