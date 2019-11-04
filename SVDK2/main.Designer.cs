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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.AgentToolStripButton_main = new System.Windows.Forms.ToolStripButton();
            this.insuranceToolStripButton_main = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton_main = new System.Windows.Forms.ToolStripDropDownButton();
            this.forFioToolStripMenuItem_main = new System.Windows.Forms.ToolStripMenuItem();
            this.fioToolStripTextBox_main = new System.Windows.Forms.ToolStripTextBox();
            this.helpToolStripMenuItem_main = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.helpStatusStrip_main = new System.Windows.Forms.StatusStrip();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip_main.SuspendLayout();
            this.tableLayoutPanel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgentToolStripButton_main,
            this.insuranceToolStripButton_main,
            this.toolStripDropDownButton_main});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(800, 31);
            this.toolStrip_main.TabIndex = 0;
            this.toolStrip_main.Text = "toolStrip1";
            // 
            // AgentToolStripButton_main
            // 
            this.AgentToolStripButton_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AgentToolStripButton_main.Image = ((System.Drawing.Image)(resources.GetObject("AgentToolStripButton_main.Image")));
            this.AgentToolStripButton_main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AgentToolStripButton_main.Name = "AgentToolStripButton_main";
            this.AgentToolStripButton_main.Size = new System.Drawing.Size(63, 28);
            this.AgentToolStripButton_main.Text = "&Агенты";
            this.AgentToolStripButton_main.Click += new System.EventHandler(this.AgentToolStripButton_main_Click);
            // 
            // insuranceToolStripButton_main
            // 
            this.insuranceToolStripButton_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.insuranceToolStripButton_main.Image = ((System.Drawing.Image)(resources.GetObject("insuranceToolStripButton_main.Image")));
            this.insuranceToolStripButton_main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insuranceToolStripButton_main.Name = "insuranceToolStripButton_main";
            this.insuranceToolStripButton_main.Size = new System.Drawing.Size(143, 28);
            this.insuranceToolStripButton_main.Text = "&Виды страхований";
            this.insuranceToolStripButton_main.Click += new System.EventHandler(this.insuranceToolStripButton_main_Click);
            // 
            // toolStripDropDownButton_main
            // 
            this.toolStripDropDownButton_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forFioToolStripMenuItem_main,
            this.helpToolStripMenuItem_main});
            this.toolStripDropDownButton_main.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_main.Image")));
            this.toolStripDropDownButton_main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_main.Name = "toolStripDropDownButton_main";
            this.toolStripDropDownButton_main.Size = new System.Drawing.Size(98, 28);
            this.toolStripDropDownButton_main.Text = "Настройки";
            // 
            // forFioToolStripMenuItem_main
            // 
            this.forFioToolStripMenuItem_main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fioToolStripTextBox_main});
            this.forFioToolStripMenuItem_main.Name = "forFioToolStripMenuItem_main";
            this.forFioToolStripMenuItem_main.Size = new System.Drawing.Size(165, 26);
            this.forFioToolStripMenuItem_main.Text = "ФИО";
            // 
            // fioToolStripTextBox_main
            // 
            this.fioToolStripTextBox_main.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fioToolStripTextBox_main.MaxLength = 50;
            this.fioToolStripTextBox_main.Name = "fioToolStripTextBox_main";
            this.fioToolStripTextBox_main.Size = new System.Drawing.Size(100, 27);
            this.fioToolStripTextBox_main.ToolTipText = "ФИО";
            this.fioToolStripTextBox_main.TextChanged += new System.EventHandler(this.fioToolStripTextBox_main_TextChanged);
            // 
            // helpToolStripMenuItem_main
            // 
            this.helpToolStripMenuItem_main.Name = "helpToolStripMenuItem_main";
            this.helpToolStripMenuItem_main.Size = new System.Drawing.Size(165, 26);
            this.helpToolStripMenuItem_main.Text = "Подсказки";
            this.helpToolStripMenuItem_main.Click += new System.EventHandler(this.helpToolStripMenuItem_main_Click);
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.ColumnCount = 1;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.Controls.Add(this.helpStatusStrip_main, 0, 1);
            this.tableLayoutPanel_main.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 2;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(800, 419);
            this.tableLayoutPanel_main.TabIndex = 1;
            // 
            // helpStatusStrip_main
            // 
            this.helpStatusStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.helpStatusStrip_main.Location = new System.Drawing.Point(0, 397);
            this.helpStatusStrip_main.Name = "helpStatusStrip_main";
            this.helpStatusStrip_main.Size = new System.Drawing.Size(800, 22);
            this.helpStatusStrip_main.TabIndex = 0;
            this.helpStatusStrip_main.Text = "statusStrip1";
            // 
            // chart1
            // 
            chartArea1.AxisX.MaximumAutoSize = 85F;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Выполнение плана\\nпо количеству (%)";
            series1.Name = "count";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.LegendText = "Выполнение плана\\nпо сумме (%)";
            series2.Name = "sum";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(794, 391);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel_main);
            this.Controls.Add(this.toolStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "СВДК2";
            this.Load += new System.EventHandler(this.main_Load);
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripButton AgentToolStripButton_main;
        private System.Windows.Forms.ToolStripButton insuranceToolStripButton_main;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_main;
        private System.Windows.Forms.ToolStripMenuItem forFioToolStripMenuItem_main;
        private System.Windows.Forms.ToolStripTextBox fioToolStripTextBox_main;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.StatusStrip helpStatusStrip_main;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

