namespace vBudgetForm
{
    partial class CaregoriesListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Data.DataTable categories = null;
        private System.Data.DataTable product_types = null;

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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.lvCategories = new System.Windows.Forms.ListView();
            this.scCategories = new System.Windows.Forms.SplitContainer();
            this.lvProductTypes = new System.Windows.Forms.ListView();
            this.cmsCategoriesAndTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.scCategories.Panel1.SuspendLayout();
            this.scCategories.Panel2.SuspendLayout();
            this.scCategories.SuspendLayout();
            this.cmsCategoriesAndTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(736, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "Главное меню";
            // 
            // lvCategories
            // 
            this.lvCategories.ContextMenuStrip = this.cmsCategoriesAndTypes;
            this.lvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCategories.FullRowSelect = true;
            this.lvCategories.Location = new System.Drawing.Point(0, 0);
            this.lvCategories.Name = "lvCategories";
            this.lvCategories.Size = new System.Drawing.Size(349, 342);
            this.lvCategories.TabIndex = 1;
            this.lvCategories.UseCompatibleStateImageBehavior = false;
            this.lvCategories.View = System.Windows.Forms.View.Details;
            this.lvCategories.ItemActivate += new System.EventHandler(this.lvCategories_ItemActivate);
            this.lvCategories.SelectedIndexChanged += new System.EventHandler(this.lvCategories_SelectedIndexChanged);
            // 
            // scCategories
            // 
            this.scCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCategories.Location = new System.Drawing.Point(0, 24);
            this.scCategories.Name = "scCategories";
            // 
            // scCategories.Panel1
            // 
            this.scCategories.Panel1.Controls.Add(this.lvCategories);
            // 
            // scCategories.Panel2
            // 
            this.scCategories.Panel2.Controls.Add(this.lvProductTypes);
            this.scCategories.Size = new System.Drawing.Size(736, 342);
            this.scCategories.SplitterDistance = 349;
            this.scCategories.TabIndex = 2;
            // 
            // lvProductTypes
            // 
            this.lvProductTypes.ContextMenuStrip = this.cmsCategoriesAndTypes;
            this.lvProductTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProductTypes.FullRowSelect = true;
            this.lvProductTypes.Location = new System.Drawing.Point(0, 0);
            this.lvProductTypes.Name = "lvProductTypes";
            this.lvProductTypes.Size = new System.Drawing.Size(383, 342);
            this.lvProductTypes.TabIndex = 2;
            this.lvProductTypes.UseCompatibleStateImageBehavior = false;
            this.lvProductTypes.View = System.Windows.Forms.View.Details;
            this.lvProductTypes.ItemActivate += new System.EventHandler(this.lvProductTypes_ItemActivate);
            // 
            // cmsCategoriesAndTypes
            // 
            this.cmsCategoriesAndTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreate,
            this.tsmiEdit,
            this.tsmiDelete});
            this.cmsCategoriesAndTypes.Name = "cmsCategoriesAndTypes";
            this.cmsCategoriesAndTypes.Size = new System.Drawing.Size(155, 92);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(154, 22);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiCreate
            // 
            this.tsmiCreate.Name = "tsmiCreate";
            this.tsmiCreate.Size = new System.Drawing.Size(154, 22);
            this.tsmiCreate.Text = "Создать";
            this.tsmiCreate.Click += new System.EventHandler(this.tsmiCreate_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(154, 22);
            this.tsmiEdit.Text = "Редактировать";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // CaregoriesListForm
            // 
            this.ClientSize = new System.Drawing.Size(736, 366);
            this.Controls.Add(this.scCategories);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "CaregoriesListForm";
            this.Text = "Список категорий";
            this.Load += new System.EventHandler(this.CaregoriesListForm_Load);
            this.scCategories.Panel1.ResumeLayout(false);
            this.scCategories.Panel2.ResumeLayout(false);
            this.scCategories.ResumeLayout(false);
            this.cmsCategoriesAndTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ListView lvCategories;
        private System.Windows.Forms.SplitContainer scCategories;
        private System.Windows.Forms.ListView lvProductTypes;
        private System.Windows.Forms.ContextMenuStrip cmsCategoriesAndTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
    }
}