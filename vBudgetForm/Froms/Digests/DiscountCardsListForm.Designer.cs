namespace vBudgetForm.Froms.Digests
{
    partial class DiscountCardsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataTable cards = null;

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
            this.ssDiscountStates = new System.Windows.Forms.StatusStrip();
            this.lvDiscountCards = new System.Windows.Forms.ListView();
            this.cmsDiscountCardsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddDiscountCard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditDiscountCard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteDiscountCard = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDiscountCardsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssDiscountStates
            // 
            this.ssDiscountStates.Location = new System.Drawing.Point(0, 379);
            this.ssDiscountStates.Name = "ssDiscountStates";
            this.ssDiscountStates.Size = new System.Drawing.Size(752, 22);
            this.ssDiscountStates.TabIndex = 0;
            this.ssDiscountStates.Text = "statusStrip1";
            // 
            // lvDiscountCards
            // 
            this.lvDiscountCards.ContextMenuStrip = this.cmsDiscountCardsMenu;
            this.lvDiscountCards.FullRowSelect = true;
            this.lvDiscountCards.Location = new System.Drawing.Point(4, 4);
            this.lvDiscountCards.Name = "lvDiscountCards";
            this.lvDiscountCards.Size = new System.Drawing.Size(744, 372);
            this.lvDiscountCards.TabIndex = 1;
            this.lvDiscountCards.UseCompatibleStateImageBehavior = false;
            this.lvDiscountCards.View = System.Windows.Forms.View.Details;
            this.lvDiscountCards.ItemActivate += new System.EventHandler(this.lvDiscountCards_ItemActivate);
            // 
            // cmsDiscountCardsMenu
            // 
            this.cmsDiscountCardsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddDiscountCard,
            this.tsmiEditDiscountCard,
            this.tsmiDeleteDiscountCard});
            this.cmsDiscountCardsMenu.Name = "cmsDiscountCardsMenu";
            this.cmsDiscountCardsMenu.Size = new System.Drawing.Size(198, 92);
            this.cmsDiscountCardsMenu.Text = "Контекстное меню дисконтных карт";
            // 
            // tsmiAddDiscountCard
            // 
            this.tsmiAddDiscountCard.Name = "tsmiAddDiscountCard";
            this.tsmiAddDiscountCard.Size = new System.Drawing.Size(197, 22);
            this.tsmiAddDiscountCard.Text = "Добавить карту";
            this.tsmiAddDiscountCard.Click += new System.EventHandler(this.tsmiAddDiscountCard_Click);
            // 
            // tsmiEditDiscountCard
            // 
            this.tsmiEditDiscountCard.Name = "tsmiEditDiscountCard";
            this.tsmiEditDiscountCard.Size = new System.Drawing.Size(197, 22);
            this.tsmiEditDiscountCard.Text = "Редактировать карту";
            this.tsmiEditDiscountCard.Click += new System.EventHandler(this.tsmiEditDiscountCard_Click);
            // 
            // tsmiDeleteDiscountCard
            // 
            this.tsmiDeleteDiscountCard.Name = "tsmiDeleteDiscountCard";
            this.tsmiDeleteDiscountCard.Size = new System.Drawing.Size(197, 22);
            this.tsmiDeleteDiscountCard.Text = "Удалить карту";
            this.tsmiDeleteDiscountCard.Click += new System.EventHandler(this.tsmiDeleteDiscountCard_Click);
            // 
            // DiscountCardsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 401);
            this.Controls.Add(this.lvDiscountCards);
            this.Controls.Add(this.ssDiscountStates);
            this.Name = "DiscountCardsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дисконтные карты";
            this.Load += new System.EventHandler(this.DiscountCardsListForm_Load);
            this.Resize += new System.EventHandler(this.DiscountCardsListForm_Resize);
            this.cmsDiscountCardsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssDiscountStates;
        private System.Windows.Forms.ListView lvDiscountCards;
        private System.Windows.Forms.ContextMenuStrip cmsDiscountCardsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDiscountCard;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditDiscountCard;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteDiscountCard;
    }
}