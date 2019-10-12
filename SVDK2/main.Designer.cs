namespace SVDK2
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.AgentToolStripButton_main = new System.Windows.Forms.ToolStripButton();
            this.insuranceToolStripButton_main = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgentToolStripButton_main,
            this.insuranceToolStripButton_main});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(800, 27);
            this.toolStrip_main.TabIndex = 0;
            this.toolStrip_main.Text = "toolStrip1";
            // 
            // AgentToolStripButton_main
            // 
            this.AgentToolStripButton_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AgentToolStripButton_main.Image = ((System.Drawing.Image)(resources.GetObject("AgentToolStripButton_main.Image")));
            this.AgentToolStripButton_main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AgentToolStripButton_main.Name = "AgentToolStripButton_main";
            this.AgentToolStripButton_main.Size = new System.Drawing.Size(63, 24);
            this.AgentToolStripButton_main.Text = "&Агенты";
            this.AgentToolStripButton_main.Click += new System.EventHandler(this.AgentToolStripButton_main_Click);
            // 
            // insuranceToolStripButton_main
            // 
            this.insuranceToolStripButton_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.insuranceToolStripButton_main.Image = ((System.Drawing.Image)(resources.GetObject("insuranceToolStripButton_main.Image")));
            this.insuranceToolStripButton_main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insuranceToolStripButton_main.Name = "insuranceToolStripButton_main";
            this.insuranceToolStripButton_main.Size = new System.Drawing.Size(143, 24);
            this.insuranceToolStripButton_main.Text = "&Виды страхований";
            this.insuranceToolStripButton_main.Click += new System.EventHandler(this.insuranceToolStripButton_main_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip_main);
            this.Name = "main";
            this.Text = "СВДК2";
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton AgentToolStripButton_main;
        private System.Windows.Forms.ToolStripButton insuranceToolStripButton_main;
    }
}

