namespace vBudgetForm
{
    partial class MakersListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataTable makers = null;

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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.lvMakers = new System.Windows.Forms.ListView();
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
            // lvMakers
            // 
            this.lvMakers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMakers.FullRowSelect = true;
            this.lvMakers.Location = new System.Drawing.Point(0, 24);
            this.lvMakers.Name = "lvMakers";
            this.lvMakers.Size = new System.Drawing.Size(736, 342);
            this.lvMakers.TabIndex = 1;
            this.lvMakers.UseCompatibleStateImageBehavior = false;
            this.lvMakers.View = System.Windows.Forms.View.Details;
            this.lvMakers.ItemActivate += new System.EventHandler(this.lvMakers_ItemActivate);
            // 
            // MakersListForm
            // 
            this.ClientSize = new System.Drawing.Size(736, 366);
            this.Controls.Add(this.lvMakers);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "MakersListForm";
            this.Text = "Список изготовителей";
            this.Load += new System.EventHandler(this.MakersListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ListView lvMakers;
    }
}