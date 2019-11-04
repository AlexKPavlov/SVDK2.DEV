namespace SVDK2
{
    partial class agentReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.codeLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.agentReportContent_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vs_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumForAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.helpStatusStrip = new System.Windows.Forms.StatusStrip();
            this.helpToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.helpStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.codeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.codeTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.helpStatusStrip, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.submitButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 439);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(3, 0);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(87, 17);
            this.codeLabel.TabIndex = 0;
            this.codeLabel.Text = "Код отчёта:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(3, 31);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(96, 17);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Дата отчёта:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agentReportContent_id,
            this.vs_name,
            this.count,
            this.sum,
            this.percent,
            this.sumForAgent,
            this.delete});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 4);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(551, 314);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValidated);
            this.dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            this.dataGridView.MouseEnter += new System.EventHandler(this.dataGridView_MouseEnter);
            // 
            // agentReportContent_id
            // 
            this.agentReportContent_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.agentReportContent_id.HeaderText = "Код строки";
            this.agentReportContent_id.MinimumWidth = 6;
            this.agentReportContent_id.Name = "agentReportContent_id";
            this.agentReportContent_id.ReadOnly = true;
            this.agentReportContent_id.Visible = false;
            this.agentReportContent_id.Width = 125;
            // 
            // vs_name
            // 
            this.vs_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vs_name.HeaderText = "Вид страхования";
            this.vs_name.MinimumWidth = 6;
            this.vs_name.Name = "vs_name";
            this.vs_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vs_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.vs_name.Width = 136;
            // 
            // count
            // 
            this.count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.count.HeaderText = "Количество (шт.)";
            this.count.MinimumWidth = 6;
            this.count.Name = "count";
            this.count.Width = 138;
            // 
            // sum
            // 
            this.sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sum.HeaderText = "Сумма (руб.)";
            this.sum.MinimumWidth = 6;
            this.sum.Name = "sum";
            this.sum.Width = 110;
            // 
            // percent
            // 
            this.percent.HeaderText = "%";
            this.percent.MinimumWidth = 6;
            this.percent.Name = "percent";
            this.percent.Visible = false;
            this.percent.Width = 125;
            // 
            // sumForAgent
            // 
            this.sumForAgent.HeaderText = "Сумма для агента (руб.)";
            this.sumForAgent.MinimumWidth = 6;
            this.sumForAgent.Name = "sumForAgent";
            this.sumForAgent.ReadOnly = true;
            this.sumForAgent.Width = 125;
            // 
            // delete
            // 
            this.delete.HeaderText = "Отметка удаления";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Visible = false;
            this.delete.Width = 125;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.codeTextBox.Location = new System.Drawing.Point(160, 3);
            this.codeTextBox.MaxLength = 20;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(158, 22);
            this.codeTextBox.TabIndex = 1;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(160, 34);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(158, 22);
            this.dateTimePicker.TabIndex = 2;
            // 
            // helpStatusStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.helpStatusStrip, 4);
            this.helpStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.helpStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripStatusLabel});
            this.helpStatusStrip.Location = new System.Drawing.Point(0, 417);
            this.helpStatusStrip.Name = "helpStatusStrip";
            this.helpStatusStrip.Size = new System.Drawing.Size(557, 22);
            this.helpStatusStrip.TabIndex = 5;
            this.helpStatusStrip.Text = "statusStrip1";
            // 
            // helpToolStripStatusLabel
            // 
            this.helpToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripStatusLabel.Name = "helpToolStripStatusLabel";
            this.helpToolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // submitButton
            // 
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitButton.Location = new System.Drawing.Point(440, 381);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(114, 33);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "&Подтвердить";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            this.submitButton.MouseEnter += new System.EventHandler(this.submitButton_MouseEnter);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(339, 381);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 33);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            // 
            // agentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "agentReport";
            this.Text = "Агентский отчёт";
            this.Load += new System.EventHandler(this.agentReport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.helpStatusStrip.ResumeLayout(false);
            this.helpStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.StatusStrip helpStatusStrip;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentReportContent_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn vs_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumForAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.ToolStripStatusLabel helpToolStripStatusLabel;
    }
}