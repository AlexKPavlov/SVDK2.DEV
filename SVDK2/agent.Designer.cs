namespace SVDK2
{
    partial class agent
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.agentDataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.general = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.profileTabPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel_profile = new System.Windows.Forms.FlowLayoutPanel();
            this.mainInformationTableLayoutPanel_profile = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel_profile = new System.Windows.Forms.Label();
            this.kodAgentLabel_profile = new System.Windows.Forms.Label();
            this.branchCodeLabel_profile = new System.Windows.Forms.Label();
            this.saleChanelLabel_profile = new System.Windows.Forms.Label();
            this.cotactLabel_profile = new System.Windows.Forms.Label();
            this.nameTextBox_profile = new System.Windows.Forms.TextBox();
            this.kodAgentTextBox_profile = new System.Windows.Forms.TextBox();
            this.branchCodeTextBox_profile = new System.Windows.Forms.TextBox();
            this.saleChanelTextBox_profile = new System.Windows.Forms.TextBox();
            this.contactTextBox_profile = new System.Windows.Forms.TextBox();
            this.commissionTabPage = new System.Windows.Forms.TabPage();
            this.activeCheckBox_profile = new System.Windows.Forms.CheckBox();
            this.deleteAgentButton_profile = new System.Windows.Forms.Button();
            this.addNewAgentButton_profile = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            this.flowLayoutPanel_profile.SuspendLayout();
            this.mainInformationTableLayoutPanel_profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.agentDataGridView);
            this.splitContainer.Panel1.Controls.Add(this.searchTextBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(800, 450);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // agentDataGridView
            // 
            this.agentDataGridView.AllowUserToAddRows = false;
            this.agentDataGridView.AllowUserToDeleteRows = false;
            this.agentDataGridView.AllowUserToResizeColumns = false;
            this.agentDataGridView.AllowUserToResizeRows = false;
            this.agentDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.agentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentDataGridView.ColumnHeadersVisible = false;
            this.agentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.general,
            this.kod,
            this.name,
            this.active});
            this.agentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentDataGridView.Location = new System.Drawing.Point(0, 22);
            this.agentDataGridView.MultiSelect = false;
            this.agentDataGridView.Name = "agentDataGridView";
            this.agentDataGridView.RowHeadersVisible = false;
            this.agentDataGridView.RowHeadersWidth = 51;
            this.agentDataGridView.RowTemplate.Height = 24;
            this.agentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.agentDataGridView.Size = new System.Drawing.Size(200, 428);
            this.agentDataGridView.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "ИД";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // general
            // 
            this.general.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.general.HeaderText = "Отображаемоё";
            this.general.MinimumWidth = 6;
            this.general.Name = "general";
            this.general.ReadOnly = true;
            this.general.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // kod
            // 
            this.kod.HeaderText = "Код";
            this.kod.MinimumWidth = 6;
            this.kod.Name = "kod";
            this.kod.ReadOnly = true;
            this.kod.Visible = false;
            this.kod.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "ФИО";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Visible = false;
            this.name.Width = 197;
            // 
            // active
            // 
            this.active.HeaderText = "Активность";
            this.active.MinimumWidth = 6;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Visible = false;
            this.active.Width = 125;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 22);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Поиск...";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.profileTabPage);
            this.tabControl.Controls.Add(this.commissionTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(599, 450);
            this.tabControl.TabIndex = 0;
            // 
            // profileTabPage
            // 
            this.profileTabPage.Controls.Add(this.flowLayoutPanel_profile);
            this.profileTabPage.Location = new System.Drawing.Point(4, 25);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profileTabPage.Size = new System.Drawing.Size(591, 421);
            this.profileTabPage.TabIndex = 0;
            this.profileTabPage.Text = "Профиль";
            this.profileTabPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_profile
            // 
            this.flowLayoutPanel_profile.AutoScroll = true;
            this.flowLayoutPanel_profile.Controls.Add(this.mainInformationTableLayoutPanel_profile);
            this.flowLayoutPanel_profile.Controls.Add(this.addNewAgentButton_profile);
            this.flowLayoutPanel_profile.Controls.Add(this.numericUpDown1);
            this.flowLayoutPanel_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_profile.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_profile.Name = "flowLayoutPanel_profile";
            this.flowLayoutPanel_profile.Size = new System.Drawing.Size(585, 415);
            this.flowLayoutPanel_profile.TabIndex = 0;
            // 
            // mainInformationTableLayoutPanel_profile
            // 
            this.mainInformationTableLayoutPanel_profile.ColumnCount = 3;
            this.mainInformationTableLayoutPanel_profile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainInformationTableLayoutPanel_profile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.mainInformationTableLayoutPanel_profile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.nameLabel_profile, 0, 0);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.kodAgentLabel_profile, 0, 1);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.branchCodeLabel_profile, 0, 2);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.saleChanelLabel_profile, 0, 3);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.cotactLabel_profile, 0, 4);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.nameTextBox_profile, 1, 0);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.kodAgentTextBox_profile, 1, 1);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.branchCodeTextBox_profile, 1, 2);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.saleChanelTextBox_profile, 1, 3);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.contactTextBox_profile, 1, 4);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.activeCheckBox_profile, 2, 0);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.deleteAgentButton_profile, 2, 4);
            this.mainInformationTableLayoutPanel_profile.Location = new System.Drawing.Point(3, 3);
            this.mainInformationTableLayoutPanel_profile.Name = "mainInformationTableLayoutPanel_profile";
            this.mainInformationTableLayoutPanel_profile.RowCount = 5;
            this.mainInformationTableLayoutPanel_profile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainInformationTableLayoutPanel_profile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainInformationTableLayoutPanel_profile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainInformationTableLayoutPanel_profile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainInformationTableLayoutPanel_profile.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainInformationTableLayoutPanel_profile.Size = new System.Drawing.Size(577, 267);
            this.mainInformationTableLayoutPanel_profile.TabIndex = 0;
            // 
            // nameLabel_profile
            // 
            this.nameLabel_profile.AutoSize = true;
            this.nameLabel_profile.Location = new System.Drawing.Point(3, 0);
            this.nameLabel_profile.Name = "nameLabel_profile";
            this.nameLabel_profile.Size = new System.Drawing.Size(46, 17);
            this.nameLabel_profile.TabIndex = 0;
            this.nameLabel_profile.Text = "ФИО:";
            // 
            // kodAgentLabel_profile
            // 
            this.kodAgentLabel_profile.AutoSize = true;
            this.kodAgentLabel_profile.Location = new System.Drawing.Point(3, 50);
            this.kodAgentLabel_profile.Name = "kodAgentLabel_profile";
            this.kodAgentLabel_profile.Size = new System.Drawing.Size(85, 17);
            this.kodAgentLabel_profile.TabIndex = 1;
            this.kodAgentLabel_profile.Text = "Код агента:";
            // 
            // branchCodeLabel_profile
            // 
            this.branchCodeLabel_profile.AutoSize = true;
            this.branchCodeLabel_profile.Location = new System.Drawing.Point(3, 100);
            this.branchCodeLabel_profile.Name = "branchCodeLabel_profile";
            this.branchCodeLabel_profile.Size = new System.Drawing.Size(144, 17);
            this.branchCodeLabel_profile.TabIndex = 2;
            this.branchCodeLabel_profile.Text = "Код подразделения:";
            // 
            // saleChanelLabel_profile
            // 
            this.saleChanelLabel_profile.AutoSize = true;
            this.saleChanelLabel_profile.Location = new System.Drawing.Point(3, 150);
            this.saleChanelLabel_profile.Name = "saleChanelLabel_profile";
            this.saleChanelLabel_profile.Size = new System.Drawing.Size(106, 17);
            this.saleChanelLabel_profile.TabIndex = 3;
            this.saleChanelLabel_profile.Text = "Канал продаж:";
            // 
            // cotactLabel_profile
            // 
            this.cotactLabel_profile.AutoSize = true;
            this.cotactLabel_profile.Location = new System.Drawing.Point(3, 200);
            this.cotactLabel_profile.Name = "cotactLabel_profile";
            this.cotactLabel_profile.Size = new System.Drawing.Size(76, 17);
            this.cotactLabel_profile.TabIndex = 4;
            this.cotactLabel_profile.Text = "Контакты:";
            // 
            // nameTextBox_profile
            // 
            this.nameTextBox_profile.Location = new System.Drawing.Point(153, 3);
            this.nameTextBox_profile.Name = "nameTextBox_profile";
            this.nameTextBox_profile.Size = new System.Drawing.Size(204, 22);
            this.nameTextBox_profile.TabIndex = 5;
            // 
            // kodAgentTextBox_profile
            // 
            this.kodAgentTextBox_profile.Location = new System.Drawing.Point(153, 53);
            this.kodAgentTextBox_profile.Name = "kodAgentTextBox_profile";
            this.kodAgentTextBox_profile.Size = new System.Drawing.Size(204, 22);
            this.kodAgentTextBox_profile.TabIndex = 6;
            // 
            // branchCodeTextBox_profile
            // 
            this.branchCodeTextBox_profile.Location = new System.Drawing.Point(153, 103);
            this.branchCodeTextBox_profile.Name = "branchCodeTextBox_profile";
            this.branchCodeTextBox_profile.Size = new System.Drawing.Size(204, 22);
            this.branchCodeTextBox_profile.TabIndex = 7;
            // 
            // saleChanelTextBox_profile
            // 
            this.saleChanelTextBox_profile.Location = new System.Drawing.Point(153, 153);
            this.saleChanelTextBox_profile.Name = "saleChanelTextBox_profile";
            this.saleChanelTextBox_profile.Size = new System.Drawing.Size(204, 22);
            this.saleChanelTextBox_profile.TabIndex = 8;
            // 
            // contactTextBox_profile
            // 
            this.contactTextBox_profile.Location = new System.Drawing.Point(153, 203);
            this.contactTextBox_profile.Multiline = true;
            this.contactTextBox_profile.Name = "contactTextBox_profile";
            this.contactTextBox_profile.Size = new System.Drawing.Size(204, 61);
            this.contactTextBox_profile.TabIndex = 9;
            // 
            // commissionTabPage
            // 
            this.commissionTabPage.Location = new System.Drawing.Point(4, 25);
            this.commissionTabPage.Name = "commissionTabPage";
            this.commissionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commissionTabPage.Size = new System.Drawing.Size(591, 421);
            this.commissionTabPage.TabIndex = 1;
            this.commissionTabPage.Text = "Комиссионные";
            this.commissionTabPage.UseVisualStyleBackColor = true;
            // 
            // activeCheckBox_profile
            // 
            this.activeCheckBox_profile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activeCheckBox_profile.AutoSize = true;
            this.activeCheckBox_profile.Location = new System.Drawing.Point(469, 3);
            this.activeCheckBox_profile.Name = "activeCheckBox_profile";
            this.activeCheckBox_profile.Size = new System.Drawing.Size(105, 21);
            this.activeCheckBox_profile.TabIndex = 10;
            this.activeCheckBox_profile.Text = "Активность";
            this.activeCheckBox_profile.UseVisualStyleBackColor = true;
            // 
            // deleteAgentButton_profile
            // 
            this.deleteAgentButton_profile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAgentButton_profile.AutoSize = true;
            this.deleteAgentButton_profile.BackColor = System.Drawing.Color.LightCoral;
            this.deleteAgentButton_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAgentButton_profile.ForeColor = System.Drawing.Color.Black;
            this.deleteAgentButton_profile.Location = new System.Drawing.Point(449, 235);
            this.deleteAgentButton_profile.Name = "deleteAgentButton_profile";
            this.deleteAgentButton_profile.Size = new System.Drawing.Size(125, 29);
            this.deleteAgentButton_profile.TabIndex = 11;
            this.deleteAgentButton_profile.Text = "Удалить агента";
            this.deleteAgentButton_profile.UseVisualStyleBackColor = false;
            // 
            // addNewAgentButton_profile
            // 
            this.addNewAgentButton_profile.Location = new System.Drawing.Point(3, 276);
            this.addNewAgentButton_profile.Name = "addNewAgentButton_profile";
            this.addNewAgentButton_profile.Size = new System.Drawing.Size(574, 79);
            this.addNewAgentButton_profile.TabIndex = 1;
            this.addNewAgentButton_profile.Text = "Добавить нового агента";
            this.addNewAgentButton_profile.UseVisualStyleBackColor = true;
            this.addNewAgentButton_profile.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(3, 361);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 2;
            // 
            // agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.KeyPreview = true;
            this.Name = "agent";
            this.Text = "Агенты";
            this.Load += new System.EventHandler(this.agent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.agent_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.profileTabPage.ResumeLayout(false);
            this.flowLayoutPanel_profile.ResumeLayout(false);
            this.mainInformationTableLayoutPanel_profile.ResumeLayout(false);
            this.mainInformationTableLayoutPanel_profile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage profileTabPage;
        private System.Windows.Forms.TabPage commissionTabPage;
        private System.Windows.Forms.DataGridView agentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn general;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_profile;
        private System.Windows.Forms.TableLayoutPanel mainInformationTableLayoutPanel_profile;
        private System.Windows.Forms.Label nameLabel_profile;
        private System.Windows.Forms.Label kodAgentLabel_profile;
        private System.Windows.Forms.Label branchCodeLabel_profile;
        private System.Windows.Forms.Label saleChanelLabel_profile;
        private System.Windows.Forms.Label cotactLabel_profile;
        private System.Windows.Forms.TextBox nameTextBox_profile;
        private System.Windows.Forms.TextBox kodAgentTextBox_profile;
        private System.Windows.Forms.TextBox branchCodeTextBox_profile;
        private System.Windows.Forms.TextBox saleChanelTextBox_profile;
        private System.Windows.Forms.TextBox contactTextBox_profile;
        private System.Windows.Forms.CheckBox activeCheckBox_profile;
        private System.Windows.Forms.Button deleteAgentButton_profile;
        private System.Windows.Forms.Button addNewAgentButton_profile;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}