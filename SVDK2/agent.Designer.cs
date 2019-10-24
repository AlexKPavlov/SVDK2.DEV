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
            this.components = new System.ComponentModel.Container();
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
            this.contactTextBox_profile = new System.Windows.Forms.TextBox();
            this.activeCheckBox_profile = new System.Windows.Forms.CheckBox();
            this.deleteAgentButton_profile = new System.Windows.Forms.Button();
            this.kodAgentNumericUpDown_profile = new System.Windows.Forms.NumericUpDown();
            this.branchCodeNumericUpDown_profile = new System.Windows.Forms.NumericUpDown();
            this.saleChanelNumericUpDown_profile = new System.Windows.Forms.NumericUpDown();
            this.addNewAgentButton_profile = new System.Windows.Forms.Button();
            this.commissionTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.yearLabel_commission = new System.Windows.Forms.Label();
            this.yearNumericUpDown_commission = new System.Windows.Forms.NumericUpDown();
            this.exportButton_commission = new System.Windows.Forms.Button();
            this.dataGridView_commission = new System.Windows.Forms.DataGridView();
            this.vs_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commissionPersent_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_id_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_id_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_id_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_id_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vs_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.commissionPersent_persent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_quantity_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_sum_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_quantity_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_sum_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_quantity_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_sum_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_quantity_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePlan_sum_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer_commission = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            this.flowLayoutPanel_profile.SuspendLayout();
            this.mainInformationTableLayoutPanel_profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kodAgentNumericUpDown_profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchCodeNumericUpDown_profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleChanelNumericUpDown_profile)).BeginInit();
            this.commissionTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown_commission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_commission)).BeginInit();
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
            this.splitContainer.Size = new System.Drawing.Size(982, 450);
            this.splitContainer.SplitterDistance = 140;
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
            this.agentDataGridView.Size = new System.Drawing.Size(140, 428);
            this.agentDataGridView.TabIndex = 1;
            this.agentDataGridView.CurrentCellChanged += new System.EventHandler(this.agentDataGridView_CurrentCellChanged);
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
            this.general.HeaderText = "Отображаемое";
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
            this.searchTextBox.Size = new System.Drawing.Size(140, 22);
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
            this.tabControl.Size = new System.Drawing.Size(841, 450);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // profileTabPage
            // 
            this.profileTabPage.Controls.Add(this.flowLayoutPanel_profile);
            this.profileTabPage.Location = new System.Drawing.Point(4, 25);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profileTabPage.Size = new System.Drawing.Size(833, 421);
            this.profileTabPage.TabIndex = 0;
            this.profileTabPage.Text = "Профиль";
            this.profileTabPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_profile
            // 
            this.flowLayoutPanel_profile.AutoScroll = true;
            this.flowLayoutPanel_profile.Controls.Add(this.mainInformationTableLayoutPanel_profile);
            this.flowLayoutPanel_profile.Controls.Add(this.addNewAgentButton_profile);
            this.flowLayoutPanel_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_profile.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_profile.Name = "flowLayoutPanel_profile";
            this.flowLayoutPanel_profile.Size = new System.Drawing.Size(827, 415);
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
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.contactTextBox_profile, 1, 4);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.activeCheckBox_profile, 2, 0);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.deleteAgentButton_profile, 2, 4);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.kodAgentNumericUpDown_profile, 1, 1);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.branchCodeNumericUpDown_profile, 1, 2);
            this.mainInformationTableLayoutPanel_profile.Controls.Add(this.saleChanelNumericUpDown_profile, 1, 3);
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
            this.nameTextBox_profile.MaxLength = 50;
            this.nameTextBox_profile.Name = "nameTextBox_profile";
            this.nameTextBox_profile.Size = new System.Drawing.Size(204, 22);
            this.nameTextBox_profile.TabIndex = 5;
            this.nameTextBox_profile.Leave += new System.EventHandler(this.nameTextBox_profile_Leave);
            // 
            // contactTextBox_profile
            // 
            this.contactTextBox_profile.Location = new System.Drawing.Point(153, 203);
            this.contactTextBox_profile.MaxLength = 100;
            this.contactTextBox_profile.Multiline = true;
            this.contactTextBox_profile.Name = "contactTextBox_profile";
            this.contactTextBox_profile.Size = new System.Drawing.Size(204, 61);
            this.contactTextBox_profile.TabIndex = 9;
            this.contactTextBox_profile.Leave += new System.EventHandler(this.contactTextBox_profile_Leave);
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
            this.activeCheckBox_profile.Leave += new System.EventHandler(this.activeCheckBox_profile_Leave);
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
            this.deleteAgentButton_profile.Click += new System.EventHandler(this.deleteAgentButton_profile_Click);
            // 
            // kodAgentNumericUpDown_profile
            // 
            this.kodAgentNumericUpDown_profile.Location = new System.Drawing.Point(153, 53);
            this.kodAgentNumericUpDown_profile.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.kodAgentNumericUpDown_profile.Name = "kodAgentNumericUpDown_profile";
            this.kodAgentNumericUpDown_profile.Size = new System.Drawing.Size(204, 22);
            this.kodAgentNumericUpDown_profile.TabIndex = 6;
            this.kodAgentNumericUpDown_profile.Leave += new System.EventHandler(this.kodAgentNumericUpDown_profile_Leave);
            // 
            // branchCodeNumericUpDown_profile
            // 
            this.branchCodeNumericUpDown_profile.Location = new System.Drawing.Point(153, 103);
            this.branchCodeNumericUpDown_profile.Maximum = new decimal(new int[] {
            13799999,
            0,
            0,
            0});
            this.branchCodeNumericUpDown_profile.Minimum = new decimal(new int[] {
            13700000,
            0,
            0,
            0});
            this.branchCodeNumericUpDown_profile.Name = "branchCodeNumericUpDown_profile";
            this.branchCodeNumericUpDown_profile.Size = new System.Drawing.Size(204, 22);
            this.branchCodeNumericUpDown_profile.TabIndex = 7;
            this.branchCodeNumericUpDown_profile.Value = new decimal(new int[] {
            13700000,
            0,
            0,
            0});
            this.branchCodeNumericUpDown_profile.Leave += new System.EventHandler(this.branchCodeNumericUpDown_profile_Leave);
            // 
            // saleChanelNumericUpDown_profile
            // 
            this.saleChanelNumericUpDown_profile.Location = new System.Drawing.Point(153, 153);
            this.saleChanelNumericUpDown_profile.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.saleChanelNumericUpDown_profile.Name = "saleChanelNumericUpDown_profile";
            this.saleChanelNumericUpDown_profile.Size = new System.Drawing.Size(204, 22);
            this.saleChanelNumericUpDown_profile.TabIndex = 8;
            this.saleChanelNumericUpDown_profile.Leave += new System.EventHandler(this.saleChanelNumericUpDown_profile_Leave);
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
            this.addNewAgentButton_profile.Click += new System.EventHandler(this.addNewAgentButton_profile_Click);
            // 
            // commissionTabPage
            // 
            this.commissionTabPage.Controls.Add(this.tableLayoutPanel1);
            this.commissionTabPage.Location = new System.Drawing.Point(4, 25);
            this.commissionTabPage.Name = "commissionTabPage";
            this.commissionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commissionTabPage.Size = new System.Drawing.Size(833, 421);
            this.commissionTabPage.TabIndex = 1;
            this.commissionTabPage.Text = "Комиссионные";
            this.commissionTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.yearLabel_commission, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.yearNumericUpDown_commission, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.exportButton_commission, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_commission, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(827, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // yearLabel_commission
            // 
            this.yearLabel_commission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearLabel_commission.AutoSize = true;
            this.yearLabel_commission.Location = new System.Drawing.Point(3, 383);
            this.yearLabel_commission.Name = "yearLabel_commission";
            this.yearLabel_commission.Size = new System.Drawing.Size(98, 17);
            this.yearLabel_commission.TabIndex = 0;
            this.yearLabel_commission.Text = "Год выборки:";
            this.yearLabel_commission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yearNumericUpDown_commission
            // 
            this.yearNumericUpDown_commission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearNumericUpDown_commission.Location = new System.Drawing.Point(107, 386);
            this.yearNumericUpDown_commission.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.yearNumericUpDown_commission.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yearNumericUpDown_commission.Name = "yearNumericUpDown_commission";
            this.yearNumericUpDown_commission.Size = new System.Drawing.Size(98, 22);
            this.yearNumericUpDown_commission.TabIndex = 1;
            this.yearNumericUpDown_commission.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yearNumericUpDown_commission.ValueChanged += new System.EventHandler(this.yearNumericUpDown_commission_ValueChanged);
            // 
            // exportButton_commission
            // 
            this.exportButton_commission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton_commission.AutoSize = true;
            this.exportButton_commission.Location = new System.Drawing.Point(700, 386);
            this.exportButton_commission.Name = "exportButton_commission";
            this.exportButton_commission.Size = new System.Drawing.Size(124, 26);
            this.exportButton_commission.TabIndex = 2;
            this.exportButton_commission.Text = "Экспорт данных";
            this.exportButton_commission.UseVisualStyleBackColor = true;
            // 
            // dataGridView_commission
            // 
            this.dataGridView_commission.AllowUserToAddRows = false;
            this.dataGridView_commission.AllowUserToDeleteRows = false;
            this.dataGridView_commission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_commission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vs_id,
            this.commissionPersent_id,
            this.insurancePlan_id_1,
            this.insurancePlan_id_2,
            this.insurancePlan_id_3,
            this.insurancePlan_id_4,
            this.vs_name,
            this.commissionPersent_persent,
            this.insurancePlan_quantity_1,
            this.insurancePlan_sum_1,
            this.insurancePlan_quantity_2,
            this.insurancePlan_sum_2,
            this.insurancePlan_quantity_3,
            this.insurancePlan_sum_3,
            this.insurancePlan_quantity_4,
            this.insurancePlan_sum_4});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_commission, 3);
            this.dataGridView_commission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_commission.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_commission.MultiSelect = false;
            this.dataGridView_commission.Name = "dataGridView_commission";
            this.dataGridView_commission.RowHeadersVisible = false;
            this.dataGridView_commission.RowHeadersWidth = 51;
            this.dataGridView_commission.RowTemplate.Height = 24;
            this.dataGridView_commission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_commission.Size = new System.Drawing.Size(821, 377);
            this.dataGridView_commission.TabIndex = 3;
            this.dataGridView_commission.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_commission_CellValidated);
            this.dataGridView_commission.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_commission_CellValidating);
            this.dataGridView_commission.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_commission_EditingControlShowing);
            this.dataGridView_commission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // vs_id
            // 
            this.vs_id.Frozen = true;
            this.vs_id.HeaderText = "ИД вида страхования";
            this.vs_id.MinimumWidth = 6;
            this.vs_id.Name = "vs_id";
            this.vs_id.ReadOnly = true;
            this.vs_id.Visible = false;
            this.vs_id.Width = 150;
            // 
            // commissionPersent_id
            // 
            this.commissionPersent_id.HeaderText = "ИД записи комиссионных вознаграждений";
            this.commissionPersent_id.MinimumWidth = 6;
            this.commissionPersent_id.Name = "commissionPersent_id";
            this.commissionPersent_id.ReadOnly = true;
            this.commissionPersent_id.Visible = false;
            this.commissionPersent_id.Width = 125;
            // 
            // insurancePlan_id_1
            // 
            this.insurancePlan_id_1.HeaderText = "ИД записи плана 1 квартала";
            this.insurancePlan_id_1.MinimumWidth = 6;
            this.insurancePlan_id_1.Name = "insurancePlan_id_1";
            this.insurancePlan_id_1.ReadOnly = true;
            this.insurancePlan_id_1.Visible = false;
            this.insurancePlan_id_1.Width = 125;
            // 
            // insurancePlan_id_2
            // 
            this.insurancePlan_id_2.HeaderText = "ИД записи плана 2 квартала";
            this.insurancePlan_id_2.MinimumWidth = 6;
            this.insurancePlan_id_2.Name = "insurancePlan_id_2";
            this.insurancePlan_id_2.ReadOnly = true;
            this.insurancePlan_id_2.Visible = false;
            this.insurancePlan_id_2.Width = 125;
            // 
            // insurancePlan_id_3
            // 
            this.insurancePlan_id_3.HeaderText = "ИД записи плана 3 квартала";
            this.insurancePlan_id_3.MinimumWidth = 6;
            this.insurancePlan_id_3.Name = "insurancePlan_id_3";
            this.insurancePlan_id_3.ReadOnly = true;
            this.insurancePlan_id_3.Visible = false;
            this.insurancePlan_id_3.Width = 125;
            // 
            // insurancePlan_id_4
            // 
            this.insurancePlan_id_4.HeaderText = "ИД записи плана 4 квартала";
            this.insurancePlan_id_4.MinimumWidth = 6;
            this.insurancePlan_id_4.Name = "insurancePlan_id_4";
            this.insurancePlan_id_4.ReadOnly = true;
            this.insurancePlan_id_4.Visible = false;
            this.insurancePlan_id_4.Width = 125;
            // 
            // vs_name
            // 
            this.vs_name.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.vs_name.Frozen = true;
            this.vs_name.HeaderText = "Вид страхования";
            this.vs_name.MinimumWidth = 6;
            this.vs_name.Name = "vs_name";
            this.vs_name.ReadOnly = true;
            this.vs_name.Width = 150;
            // 
            // commissionPersent_persent
            // 
            this.commissionPersent_persent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.commissionPersent_persent.HeaderText = "% воз.";
            this.commissionPersent_persent.MinimumWidth = 6;
            this.commissionPersent_persent.Name = "commissionPersent_persent";
            this.commissionPersent_persent.ReadOnly = true;
            this.commissionPersent_persent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.commissionPersent_persent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.commissionPersent_persent.Width = 50;
            // 
            // insurancePlan_quantity_1
            // 
            this.insurancePlan_quantity_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_quantity_1.HeaderText = "Кол-во (Q1)";
            this.insurancePlan_quantity_1.MinimumWidth = 6;
            this.insurancePlan_quantity_1.Name = "insurancePlan_quantity_1";
            this.insurancePlan_quantity_1.ReadOnly = true;
            this.insurancePlan_quantity_1.Width = 106;
            // 
            // insurancePlan_sum_1
            // 
            this.insurancePlan_sum_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_sum_1.HeaderText = "Сумма (Q1)";
            this.insurancePlan_sum_1.MinimumWidth = 6;
            this.insurancePlan_sum_1.Name = "insurancePlan_sum_1";
            this.insurancePlan_sum_1.ReadOnly = true;
            this.insurancePlan_sum_1.Width = 103;
            // 
            // insurancePlan_quantity_2
            // 
            this.insurancePlan_quantity_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_quantity_2.HeaderText = "Кол-во (Q2)";
            this.insurancePlan_quantity_2.MinimumWidth = 6;
            this.insurancePlan_quantity_2.Name = "insurancePlan_quantity_2";
            this.insurancePlan_quantity_2.ReadOnly = true;
            this.insurancePlan_quantity_2.Width = 106;
            // 
            // insurancePlan_sum_2
            // 
            this.insurancePlan_sum_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_sum_2.HeaderText = "Сумма (Q2)";
            this.insurancePlan_sum_2.MinimumWidth = 6;
            this.insurancePlan_sum_2.Name = "insurancePlan_sum_2";
            this.insurancePlan_sum_2.ReadOnly = true;
            this.insurancePlan_sum_2.Width = 103;
            // 
            // insurancePlan_quantity_3
            // 
            this.insurancePlan_quantity_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_quantity_3.HeaderText = "Кол-во (Q3)";
            this.insurancePlan_quantity_3.MinimumWidth = 6;
            this.insurancePlan_quantity_3.Name = "insurancePlan_quantity_3";
            this.insurancePlan_quantity_3.ReadOnly = true;
            this.insurancePlan_quantity_3.Width = 106;
            // 
            // insurancePlan_sum_3
            // 
            this.insurancePlan_sum_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_sum_3.HeaderText = "Сумма (Q3)";
            this.insurancePlan_sum_3.MinimumWidth = 6;
            this.insurancePlan_sum_3.Name = "insurancePlan_sum_3";
            this.insurancePlan_sum_3.ReadOnly = true;
            this.insurancePlan_sum_3.Width = 103;
            // 
            // insurancePlan_quantity_4
            // 
            this.insurancePlan_quantity_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_quantity_4.HeaderText = "Кол-во (Q4)";
            this.insurancePlan_quantity_4.MinimumWidth = 6;
            this.insurancePlan_quantity_4.Name = "insurancePlan_quantity_4";
            this.insurancePlan_quantity_4.ReadOnly = true;
            this.insurancePlan_quantity_4.Width = 106;
            // 
            // insurancePlan_sum_4
            // 
            this.insurancePlan_sum_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insurancePlan_sum_4.HeaderText = "Сумма (Q4)";
            this.insurancePlan_sum_4.MinimumWidth = 6;
            this.insurancePlan_sum_4.Name = "insurancePlan_sum_4";
            this.insurancePlan_sum_4.ReadOnly = true;
            this.insurancePlan_sum_4.Width = 103;
            // 
            // timer_commission
            // 
            this.timer_commission.Interval = 1;
            this.timer_commission.Tick += new System.EventHandler(this.timer_commission_Tick);
            // 
            // agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.kodAgentNumericUpDown_profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchCodeNumericUpDown_profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleChanelNumericUpDown_profile)).EndInit();
            this.commissionTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown_commission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_commission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage profileTabPage;
        private System.Windows.Forms.TabPage commissionTabPage;
        private System.Windows.Forms.DataGridView agentDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_profile;
        private System.Windows.Forms.TableLayoutPanel mainInformationTableLayoutPanel_profile;
        private System.Windows.Forms.Label nameLabel_profile;
        private System.Windows.Forms.Label kodAgentLabel_profile;
        private System.Windows.Forms.Label branchCodeLabel_profile;
        private System.Windows.Forms.Label saleChanelLabel_profile;
        private System.Windows.Forms.Label cotactLabel_profile;
        private System.Windows.Forms.TextBox nameTextBox_profile;
        private System.Windows.Forms.TextBox contactTextBox_profile;
        private System.Windows.Forms.CheckBox activeCheckBox_profile;
        private System.Windows.Forms.Button deleteAgentButton_profile;
        private System.Windows.Forms.Button addNewAgentButton_profile;
        private System.Windows.Forms.NumericUpDown kodAgentNumericUpDown_profile;
        private System.Windows.Forms.NumericUpDown branchCodeNumericUpDown_profile;
        private System.Windows.Forms.NumericUpDown saleChanelNumericUpDown_profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn general;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label yearLabel_commission;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown_commission;
        private System.Windows.Forms.Button exportButton_commission;
        private System.Windows.Forms.DataGridView dataGridView_commission;
        private System.Windows.Forms.DataGridViewTextBoxColumn vs_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn commissionPersent_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_id_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_id_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_id_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_id_4;
        private System.Windows.Forms.DataGridViewComboBoxColumn vs_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn commissionPersent_persent;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_quantity_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_sum_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_quantity_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_sum_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_quantity_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_sum_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_quantity_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePlan_sum_4;
        private System.Windows.Forms.Timer timer_commission;
    }
}