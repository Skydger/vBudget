namespace vBudgetForm.Froms.Digests
{
    partial class CompaniesListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.DataSet dataset = null;
        System.Data.SqlClient.SqlConnection connection = null;

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
            this.tvCompanies = new System.Windows.Forms.TreeView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCompanies
            // 
            this.tvCompanies.ContextMenuStrip = this.cmsMenu;
            this.tvCompanies.Location = new System.Drawing.Point(12, 12);
            this.tvCompanies.Name = "tvCompanies";
            this.tvCompanies.Size = new System.Drawing.Size(544, 331);
            this.tvCompanies.TabIndex = 0;
            this.tvCompanies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvCompanies_MouseDoubleClick);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddCompany,
            this.tsmiDeleteCompany});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(127, 48);
            // 
            // tsmiAddCompany
            // 
            this.tsmiAddCompany.Name = "tsmiAddCompany";
            this.tsmiAddCompany.Size = new System.Drawing.Size(152, 22);
            this.tsmiAddCompany.Text = "Добавить";
            this.tsmiAddCompany.Click += new System.EventHandler(this.tsmiAddCompany_Click);
            // 
            // tsmiDeleteCompany
            // 
            this.tsmiDeleteCompany.Name = "tsmiDeleteCompany";
            this.tsmiDeleteCompany.Size = new System.Drawing.Size(152, 22);
            this.tsmiDeleteCompany.Text = "Удалить";
            // 
            // CompaniesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 355);
            this.Controls.Add(this.tvCompanies);
            this.Name = "CompaniesListForm";
            this.Text = "CompaniesListForm";
            this.Load += new System.EventHandler(this.CompaniesListForm_Load);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCompanies;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCompany;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCompany;
    }
}