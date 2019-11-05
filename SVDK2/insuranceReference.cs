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

        private void changeModeToolStripButton_CheckStateChanged(object sender, EventArgs e)    //Выключеие/включение кнопок и возможности редактирования
        {
            if (changeModeToolStripButton.Checked)
            {
                addToolStripButton.Enabled = true;
                renameToolStripButton.Enabled = true;
                removeToolStripButton.Enabled = true;

                dataGridView.Columns[1].ReadOnly = false;
                dataGridView.Columns[2].ReadOnly = false;
                dataGridView.AllowUserToAddRows = true;
                dataGridView.AllowUserToDeleteRows = true;
            }
            else
            {
                addToolStripButton.Enabled = false;
                renameToolStripButton.Enabled = false;
                removeToolStripButton.Enabled = false;

                dataGridView.Columns[1].ReadOnly = true;
                dataGridView.Columns[2].ReadOnly = true;
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
                id[i] = Convert.ToInt32(dataGridView.SelectedRows[i].Cells["vs_id"].Value);

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

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)  //Сохранение данных в БД
        {
            if (dataGridView.Rows.Count - 1 == e.RowIndex)
                return;
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == e.FormattedValue.ToString() || dataGridView.Rows[e.RowIndex].Cells["vs_id"].Value == null)
                return;

            string cell;
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                cell = "";
            else
                cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (cell.Length == 0 && e.FormattedValue.ToString() == "") {
                MessageBox.Show("Данная ячейка не может быть пустой", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView.BeginEdit(false);
                return;
            }

            if (cell.Length > 0 && e.FormattedValue.ToString() == "") {
                MessageBox.Show("Данная ячейка не может быть пустой", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "vs_kod" && !Int32.TryParse(e.FormattedValue.ToString(), out int i))
            {
                MessageBox.Show("Данное поле должно содержать только цифры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "vs_kod")
                dataGridView.Rows[e.RowIndex].Cells["vs_kod"].Value = Convert.ToInt32(e.FormattedValue);

            sqliteConnection.Open();
            SQLiteCommand update;
            if (dataGridView.Columns[e.ColumnIndex].Name == "vs_name")
                update = new SQLiteCommand(@"UPDATE vs SET vs_name=$param WHERE vs_id=$id;", sqliteConnection);
            else
                update = new SQLiteCommand(@"UPDATE vs SET vs_kod=$param WHERE vs_id=$id;", sqliteConnection);
            update.Parameters.AddWithValue("$param", e.FormattedValue.ToString());
            update.Parameters.AddWithValue("$id", Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["vs_id"].Value));
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

            command = new SQLiteCommand("INSERT INTO vs (vs_kod) VALUES($id); SELECT last_insert_rowid();", sqliteConnection);
            command.Parameters.AddWithValue("$id", id);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView.Rows[e.Row.Index - 1].Cells["vs_id"].Value = id = Convert.ToInt32(reader[0]);
            }
            sqliteConnection.Close();
            dataGridView.Rows[e.Row.Index - 1].Cells["vs_name"].Value = "";
            dataGridView.CurrentCell = dataGridView.Rows[e.Row.Index - 1].Cells["vs_name"];
            dataGridView.BeginEdit(false);

        }
        #endregion

        private void updateDataGridView()   //Загрузка данных в таблицу
        {
            dataGridView.Rows.Clear();

            SQLiteCommand loadList = new SQLiteCommand("SELECT * FROM vs", sqliteConnection);
            sqliteConnection.Open();
            SQLiteDataReader reader = loadList.ExecuteReader();
            while (reader.Read())
            {
                int rowNumber = dataGridView.Rows.Add();
                dataGridView.Rows[rowNumber].Cells["vs_id"].Value = Convert.ToInt32(reader["vs_id"]);
                dataGridView.Rows[rowNumber].Cells["vs_kod"].Value = Convert.ToInt32(reader["vs_kod"]);
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

            sqliteConnection.Open();
            for (int j = 0; j < id.Count(); j+=50)
            {
                string command = "DELETE FROM vs WHERE vs_id='" + id[j] + "'";
                for (int i = 1; i + j < id.Count() && i < 50; i++)
                    command += " OR vs_id='" + id[i+j] + "'";
                SQLiteCommand delRow = new SQLiteCommand(command, sqliteConnection);
                delRow.ExecuteNonQuery();
            }
            
            sqliteConnection.Close();

            return true;
        }


    }
}
