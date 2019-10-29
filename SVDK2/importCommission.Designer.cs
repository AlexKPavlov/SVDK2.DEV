namespace SVDK2
{
    partial class importCommission
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.currentAgentRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectingAgentRadioButton = new System.Windows.Forms.RadioButton();
            this.agentComboBox = new System.Windows.Forms.ComboBox();
            this.itemForImportLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.commissionPersentCheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanQuantity1CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanSum1CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanQuantity2CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanQuantity3CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanQuantity4CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanSum2CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanSum3CheckBox = new System.Windows.Forms.CheckBox();
            this.insurancePlanSum4CheckBox = new System.Windows.Forms.CheckBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.submitButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.fullResetModeRadioButton = new System.Windows.Forms.RadioButton();
            this.ignorModeRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.sourceLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.agentComboBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.itemForImportLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.yearLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.yearNumericUpDown, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.modeLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(592, 402);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(3, 146);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(60, 17);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Откуда:";
            // 
            // currentAgentRadioButton
            // 
            this.currentAgentRadioButton.AutoSize = true;
            this.currentAgentRadioButton.Location = new System.Drawing.Point(3, 3);
            this.currentAgentRadioButton.Name = "currentAgentRadioButton";
            this.currentAgentRadioButton.Size = new System.Drawing.Size(147, 21);
            this.currentAgentRadioButton.TabIndex = 9;
            this.currentAgentRadioButton.TabStop = true;
            this.currentAgentRadioButton.Text = "Из того же агента";
            this.currentAgentRadioButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.currentAgentRadioButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectingAgentRadioButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 149);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(191, 61);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // selectingAgentRadioButton
            // 
            this.selectingAgentRadioButton.AutoSize = true;
            this.selectingAgentRadioButton.Location = new System.Drawing.Point(3, 33);
            this.selectingAgentRadioButton.Name = "selectingAgentRadioButton";
            this.selectingAgentRadioButton.Size = new System.Drawing.Size(134, 21);
            this.selectingAgentRadioButton.TabIndex = 10;
            this.selectingAgentRadioButton.TabStop = true;
            this.selectingAgentRadioButton.Text = "Выбрать агента";
            this.selectingAgentRadioButton.UseVisualStyleBackColor = true;
            // 
            // agentComboBox
            // 
            this.agentComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.agentComboBox.Enabled = false;
            this.agentComboBox.FormattingEnabled = true;
            this.agentComboBox.Location = new System.Drawing.Point(397, 186);
            this.agentComboBox.Name = "agentComboBox";
            this.agentComboBox.Size = new System.Drawing.Size(192, 24);
            this.agentComboBox.TabIndex = 3;
            // 
            // itemForImportLabel
            // 
            this.itemForImportLabel.AutoSize = true;
            this.itemForImportLabel.Location = new System.Drawing.Point(3, 0);
            this.itemForImportLabel.Name = "itemForImportLabel";
            this.itemForImportLabel.Size = new System.Drawing.Size(142, 17);
            this.itemForImportLabel.TabIndex = 4;
            this.itemForImportLabel.Text = "Что импортировать:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.commissionPersentCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanQuantity1CheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanSum1CheckBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanQuantity2CheckBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanQuantity3CheckBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanQuantity4CheckBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanSum2CheckBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanSum3CheckBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.insurancePlanSum4CheckBox, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(200, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 140);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // commissionPersentCheckBox
            // 
            this.commissionPersentCheckBox.AutoSize = true;
            this.commissionPersentCheckBox.Location = new System.Drawing.Point(3, 3);
            this.commissionPersentCheckBox.Name = "commissionPersentCheckBox";
            this.commissionPersentCheckBox.Size = new System.Drawing.Size(154, 21);
            this.commissionPersentCheckBox.TabIndex = 0;
            this.commissionPersentCheckBox.Text = "% вознаграждения";
            this.commissionPersentCheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanQuantity1CheckBox
            // 
            this.insurancePlanQuantity1CheckBox.AutoSize = true;
            this.insurancePlanQuantity1CheckBox.Location = new System.Drawing.Point(3, 31);
            this.insurancePlanQuantity1CheckBox.Name = "insurancePlanQuantity1CheckBox";
            this.insurancePlanQuantity1CheckBox.Size = new System.Drawing.Size(108, 21);
            this.insurancePlanQuantity1CheckBox.TabIndex = 1;
            this.insurancePlanQuantity1CheckBox.Text = "Кол-во (Q1)";
            this.insurancePlanQuantity1CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanSum1CheckBox
            // 
            this.insurancePlanSum1CheckBox.AutoSize = true;
            this.insurancePlanSum1CheckBox.Location = new System.Drawing.Point(197, 31);
            this.insurancePlanSum1CheckBox.Name = "insurancePlanSum1CheckBox";
            this.insurancePlanSum1CheckBox.Size = new System.Drawing.Size(105, 21);
            this.insurancePlanSum1CheckBox.TabIndex = 2;
            this.insurancePlanSum1CheckBox.Text = "Сумма (Q1)";
            this.insurancePlanSum1CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanQuantity2CheckBox
            // 
            this.insurancePlanQuantity2CheckBox.AutoSize = true;
            this.insurancePlanQuantity2CheckBox.Location = new System.Drawing.Point(3, 59);
            this.insurancePlanQuantity2CheckBox.Name = "insurancePlanQuantity2CheckBox";
            this.insurancePlanQuantity2CheckBox.Size = new System.Drawing.Size(108, 21);
            this.insurancePlanQuantity2CheckBox.TabIndex = 3;
            this.insurancePlanQuantity2CheckBox.Text = "Кол-во (Q2)";
            this.insurancePlanQuantity2CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanQuantity3CheckBox
            // 
            this.insurancePlanQuantity3CheckBox.AutoSize = true;
            this.insurancePlanQuantity3CheckBox.Location = new System.Drawing.Point(3, 87);
            this.insurancePlanQuantity3CheckBox.Name = "insurancePlanQuantity3CheckBox";
            this.insurancePlanQuantity3CheckBox.Size = new System.Drawing.Size(108, 21);
            this.insurancePlanQuantity3CheckBox.TabIndex = 5;
            this.insurancePlanQuantity3CheckBox.Text = "Кол-во (Q3)";
            this.insurancePlanQuantity3CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanQuantity4CheckBox
            // 
            this.insurancePlanQuantity4CheckBox.AutoSize = true;
            this.insurancePlanQuantity4CheckBox.Location = new System.Drawing.Point(3, 115);
            this.insurancePlanQuantity4CheckBox.Name = "insurancePlanQuantity4CheckBox";
            this.insurancePlanQuantity4CheckBox.Size = new System.Drawing.Size(108, 21);
            this.insurancePlanQuantity4CheckBox.TabIndex = 7;
            this.insurancePlanQuantity4CheckBox.Text = "Кол-во (Q4)";
            this.insurancePlanQuantity4CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanSum2CheckBox
            // 
            this.insurancePlanSum2CheckBox.AutoSize = true;
            this.insurancePlanSum2CheckBox.Location = new System.Drawing.Point(197, 59);
            this.insurancePlanSum2CheckBox.Name = "insurancePlanSum2CheckBox";
            this.insurancePlanSum2CheckBox.Size = new System.Drawing.Size(105, 21);
            this.insurancePlanSum2CheckBox.TabIndex = 4;
            this.insurancePlanSum2CheckBox.Text = "Сумма (Q2)";
            this.insurancePlanSum2CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanSum3CheckBox
            // 
            this.insurancePlanSum3CheckBox.AutoSize = true;
            this.insurancePlanSum3CheckBox.Location = new System.Drawing.Point(197, 87);
            this.insurancePlanSum3CheckBox.Name = "insurancePlanSum3CheckBox";
            this.insurancePlanSum3CheckBox.Size = new System.Drawing.Size(105, 21);
            this.insurancePlanSum3CheckBox.TabIndex = 6;
            this.insurancePlanSum3CheckBox.Text = "Сумма (Q3)";
            this.insurancePlanSum3CheckBox.UseVisualStyleBackColor = true;
            // 
            // insurancePlanSum4CheckBox
            // 
            this.insurancePlanSum4CheckBox.AutoSize = true;
            this.insurancePlanSum4CheckBox.Location = new System.Drawing.Point(197, 115);
            this.insurancePlanSum4CheckBox.Name = "insurancePlanSum4CheckBox";
            this.insurancePlanSum4CheckBox.Size = new System.Drawing.Size(105, 21);
            this.insurancePlanSum4CheckBox.TabIndex = 8;
            this.insurancePlanSum4CheckBox.Text = "Сумма (Q4)";
            this.insurancePlanSum4CheckBox.UseVisualStyleBackColor = true;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(3, 213);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(36, 17);
            this.yearLabel.TabIndex = 6;
            this.yearLabel.Text = "Год:";
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(200, 216);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.yearNumericUpDown.TabIndex = 4;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(3, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 34);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отменна";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.submitButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cancelButton, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(397, 355);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(192, 44);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(99, 7);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(90, 34);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Импорт";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(3, 241);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(55, 17);
            this.modeLabel.TabIndex = 10;
            this.modeLabel.Text = "Режим:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.fullResetModeRadioButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ignorModeRadioButton, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.radioButton1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(200, 244);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(389, 105);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // fullResetModeRadioButton
            // 
            this.fullResetModeRadioButton.AutoSize = true;
            this.fullResetModeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.fullResetModeRadioButton.Name = "fullResetModeRadioButton";
            this.fullResetModeRadioButton.Size = new System.Drawing.Size(310, 21);
            this.fullResetModeRadioButton.TabIndex = 0;
            this.fullResetModeRadioButton.TabStop = true;
            this.fullResetModeRadioButton.Text = "Полная замена данных (удаление старых)";
            this.fullResetModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ignorModeRadioButton
            // 
            this.ignorModeRadioButton.AutoSize = true;
            this.ignorModeRadioButton.Location = new System.Drawing.Point(3, 71);
            this.ignorModeRadioButton.Name = "ignorModeRadioButton";
            this.ignorModeRadioButton.Size = new System.Drawing.Size(352, 21);
            this.ignorModeRadioButton.TabIndex = 2;
            this.ignorModeRadioButton.TabStop = true;
            this.ignorModeRadioButton.Text = "Добавление новых, игнорирование существущих";
            this.ignorModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(341, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Добавление новых, обновление существующих";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // importCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 402);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "importCommission";
            this.Text = "Импорт данных коммисионных";
            this.Load += new System.EventHandler(this.importCommission_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton currentAgentRadioButton;
        private System.Windows.Forms.RadioButton selectingAgentRadioButton;
        private System.Windows.Forms.ComboBox agentComboBox;
        private System.Windows.Forms.Label itemForImportLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox commissionPersentCheckBox;
        private System.Windows.Forms.CheckBox insurancePlanQuantity1CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanSum1CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanQuantity2CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanQuantity3CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanQuantity4CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanSum2CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanSum3CheckBox;
        private System.Windows.Forms.CheckBox insurancePlanSum4CheckBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton fullResetModeRadioButton;
        private System.Windows.Forms.RadioButton ignorModeRadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}