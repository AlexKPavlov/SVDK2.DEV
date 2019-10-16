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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.profileTabPage = new System.Windows.Forms.TabPage();
            this.commissionTabPage = new System.Windows.Forms.TabPage();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
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
            this.agentDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.agentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentDataGridView.ColumnHeadersVisible = false;
            this.agentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.active});
            this.agentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentDataGridView.Location = new System.Drawing.Point(0, 22);
            this.agentDataGridView.Name = "agentDataGridView";
            this.agentDataGridView.RowHeadersVisible = false;
            this.agentDataGridView.RowHeadersWidth = 51;
            this.agentDataGridView.RowTemplate.Height = 24;
            this.agentDataGridView.Size = new System.Drawing.Size(200, 428);
            this.agentDataGridView.TabIndex = 1;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 22);
            this.searchTextBox.TabIndex = 0;
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
            this.profileTabPage.Location = new System.Drawing.Point(4, 25);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profileTabPage.Size = new System.Drawing.Size(591, 421);
            this.profileTabPage.TabIndex = 0;
            this.profileTabPage.Text = "Профиль";
            this.profileTabPage.UseVisualStyleBackColor = true;
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
            // id
            // 
            this.id.HeaderText = "Код";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "ФИО";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
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
            // agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "agent";
            this.Text = "Агенты";
            this.Load += new System.EventHandler(this.agent_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
    }
}