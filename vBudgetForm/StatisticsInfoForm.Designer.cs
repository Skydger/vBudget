namespace vBudgetForm
{
    partial class StatisticsInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Guid receipt = System.Guid.Empty;

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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByProductTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByReceiver = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByBuyer = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(3, 27);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(384, 130);
            this.dgvData.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(157, 158);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStatistics});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(390, 24);
            this.msMainMenu.TabIndex = 2;
            this.msMainMenu.Text = "Main menu";
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByCategories,
            this.tsmiByProductTypes,
            this.tsmiByReceiver,
            this.tsmiByBuyer});
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(80, 20);
            this.tsmiStatistics.Text = "Статистика";
            // 
            // tsmiByCategories
            // 
            this.tsmiByCategories.Checked = true;
            this.tsmiByCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiByCategories.Name = "tsmiByCategories";
            this.tsmiByCategories.Size = new System.Drawing.Size(187, 22);
            this.tsmiByCategories.Text = "По категориям";
            this.tsmiByCategories.Click += new System.EventHandler(this.tsmiByCategories_Click);
            // 
            // tsmiByProductTypes
            // 
            this.tsmiByProductTypes.Name = "tsmiByProductTypes";
            this.tsmiByProductTypes.Size = new System.Drawing.Size(187, 22);
            this.tsmiByProductTypes.Text = "По видам продуктов";
            this.tsmiByProductTypes.Click += new System.EventHandler(this.tsmiByProductTypes_Click);
            // 
            // tsmiByReceiver
            // 
            this.tsmiByReceiver.Name = "tsmiByReceiver";
            this.tsmiByReceiver.Size = new System.Drawing.Size(187, 22);
            this.tsmiByReceiver.Text = "По получателю";
            this.tsmiByReceiver.Click += new System.EventHandler(this.tsmiByPersons_Click);
            // 
            // tsmiByBuyer
            // 
            this.tsmiByBuyer.Name = "tsmiByBuyer";
            this.tsmiByBuyer.Size = new System.Drawing.Size(187, 22);
            this.tsmiByBuyer.Text = "По покупателю";
            this.tsmiByBuyer.Click += new System.EventHandler(this.tsmiByBuyer_Click);
            // 
            // StatisticsInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 185);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "StatisticsInfoForm";
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.StatisticsInfoForm_Load);
            this.Resize += new System.EventHandler(this.StatisticsForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiByCategories;
        private System.Windows.Forms.ToolStripMenuItem tsmiByProductTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiByReceiver;
        private System.Windows.Forms.ToolStripMenuItem tsmiByBuyer;
    }
}