namespace vBudgetForm
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection connection;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.zgcStatistics = new ZedGraph.ZedGraphControl();
            this.scStatisticsContainer = new System.Windows.Forms.SplitContainer();
            this.lbxObjects = new System.Windows.Forms.ListBox();
            this.tsmiStatisticsType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSumByDates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAvgByDates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStatisticsTools = new System.Windows.Forms.ToolStrip();
            this.tssbtnStatisticsType = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiSummaryByDates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByWeeks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByMonths = new System.Windows.Forms.ToolStripMenuItem();
            this.scStatisticsContainer.Panel1.SuspendLayout();
            this.scStatisticsContainer.Panel2.SuspendLayout();
            this.scStatisticsContainer.SuspendLayout();
            this.tsStatisticsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // zgcStatistics
            // 
            this.zgcStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcStatistics.Location = new System.Drawing.Point(0, 0);
            this.zgcStatistics.Name = "zgcStatistics";
            this.zgcStatistics.ScrollGrace = 0;
            this.zgcStatistics.ScrollMaxX = 0;
            this.zgcStatistics.ScrollMaxY = 0;
            this.zgcStatistics.ScrollMaxY2 = 0;
            this.zgcStatistics.ScrollMinX = 0;
            this.zgcStatistics.ScrollMinY = 0;
            this.zgcStatistics.ScrollMinY2 = 0;
            this.zgcStatistics.Size = new System.Drawing.Size(513, 413);
            this.zgcStatistics.TabIndex = 2;
            // 
            // scStatisticsContainer
            // 
            this.scStatisticsContainer.Location = new System.Drawing.Point(1, 27);
            this.scStatisticsContainer.Name = "scStatisticsContainer";
            // 
            // scStatisticsContainer.Panel1
            // 
            this.scStatisticsContainer.Panel1.Controls.Add(this.lbxObjects);
            // 
            // scStatisticsContainer.Panel2
            // 
            this.scStatisticsContainer.Panel2.Controls.Add(this.zgcStatistics);
            this.scStatisticsContainer.Size = new System.Drawing.Size(775, 413);
            this.scStatisticsContainer.SplitterDistance = 258;
            this.scStatisticsContainer.TabIndex = 3;
            // 
            // lbxObjects
            // 
            this.lbxObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxObjects.FormattingEnabled = true;
            this.lbxObjects.Location = new System.Drawing.Point(0, 0);
            this.lbxObjects.Name = "lbxObjects";
            this.lbxObjects.Size = new System.Drawing.Size(258, 407);
            this.lbxObjects.TabIndex = 0;
            this.lbxObjects.SelectedIndexChanged += new System.EventHandler(this.lbxObjects_SelectedIndexChanged);
            // 
            // tsmiStatisticsType
            // 
            this.tsmiStatisticsType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSumByDates,
            this.tsmiAvgByDates});
            this.tsmiStatisticsType.Name = "tsmiStatisticsType";
            this.tsmiStatisticsType.Size = new System.Drawing.Size(103, 20);
            this.tsmiStatisticsType.Text = "Тип статистики";
            // 
            // tsmiSumByDates
            // 
            this.tsmiSumByDates.Name = "tsmiSumByDates";
            this.tsmiSumByDates.Size = new System.Drawing.Size(233, 22);
            this.tsmiSumByDates.Text = "Суммарно по датам";
            // 
            // tsmiAvgByDates
            // 
            this.tsmiAvgByDates.Name = "tsmiAvgByDates";
            this.tsmiAvgByDates.Size = new System.Drawing.Size(233, 22);
            this.tsmiAvgByDates.Text = "Средняя стоимость по датам";
            // 
            // tsStatisticsTools
            // 
            this.tsStatisticsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbtnStatisticsType});
            this.tsStatisticsTools.Location = new System.Drawing.Point(0, 0);
            this.tsStatisticsTools.Name = "tsStatisticsTools";
            this.tsStatisticsTools.Size = new System.Drawing.Size(776, 25);
            this.tsStatisticsTools.TabIndex = 4;
            this.tsStatisticsTools.Text = "Панель инструментов";
            // 
            // tssbtnStatisticsType
            // 
            this.tssbtnStatisticsType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbtnStatisticsType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSummaryByDates});
            this.tssbtnStatisticsType.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnStatisticsType.Image")));
            this.tssbtnStatisticsType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnStatisticsType.Name = "tssbtnStatisticsType";
            this.tssbtnStatisticsType.Size = new System.Drawing.Size(32, 22);
            this.tssbtnStatisticsType.Text = "Тип статистики";
            // 
            // tsmiSummaryByDates
            // 
            this.tsmiSummaryByDates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByWeeks,
            this.tsmiByMonths});
            this.tsmiSummaryByDates.Name = "tsmiSummaryByDates";
            this.tsmiSummaryByDates.Size = new System.Drawing.Size(185, 22);
            this.tsmiSummaryByDates.Text = "Суммарно по датам";
            // 
            // tsmiByWeeks
            // 
            this.tsmiByWeeks.Name = "tsmiByWeeks";
            this.tsmiByWeeks.Size = new System.Drawing.Size(142, 22);
            this.tsmiByWeeks.Text = "По неделям";
            // 
            // tsmiByMonths
            // 
            this.tsmiByMonths.Name = "tsmiByMonths";
            this.tsmiByMonths.Size = new System.Drawing.Size(142, 22);
            this.tsmiByMonths.Text = "По месяцам";
            this.tsmiByMonths.Click += new System.EventHandler(this.tsmiByMonths_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 443);
            this.Controls.Add(this.tsStatisticsTools);
            this.Controls.Add(this.scStatisticsContainer);
            this.Name = "StatisticsForm";
            this.Text = "Статистика покупок";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.Resize += new System.EventHandler(this.StatisticsForm_Resize);
            this.scStatisticsContainer.Panel1.ResumeLayout(false);
            this.scStatisticsContainer.Panel2.ResumeLayout(false);
            this.scStatisticsContainer.ResumeLayout(false);
            this.tsStatisticsTools.ResumeLayout(false);
            this.tsStatisticsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcStatistics;
        private System.Windows.Forms.SplitContainer scStatisticsContainer;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatisticsType;
        private System.Windows.Forms.ListBox lbxObjects;
        private System.Windows.Forms.ToolStripMenuItem tsmiSumByDates;
        private System.Windows.Forms.ToolStripMenuItem tsmiAvgByDates;
        private System.Windows.Forms.ToolStrip tsStatisticsTools;
        private System.Windows.Forms.ToolStripSplitButton tssbtnStatisticsType;
        private System.Windows.Forms.ToolStripMenuItem tsmiSummaryByDates;
        private System.Windows.Forms.ToolStripMenuItem tsmiByWeeks;
        private System.Windows.Forms.ToolStripMenuItem tsmiByMonths;
    }
}