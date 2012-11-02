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
            this.cbxEntities = new System.Windows.Forms.ComboBox();
            this.lblEntities = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxEntities
            // 
            this.cbxEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEntities.FormattingEnabled = true;
            this.cbxEntities.Location = new System.Drawing.Point(58, 26);
            this.cbxEntities.Name = "cbxEntities";
            this.cbxEntities.Size = new System.Drawing.Size(121, 21);
            this.cbxEntities.TabIndex = 0;
            this.cbxEntities.SelectedIndexChanged += new System.EventHandler(this.cbxEntities_SelectedIndexChanged);
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Location = new System.Drawing.Point(26, 29);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Size = new System.Drawing.Size(26, 13);
            this.lblEntities.TabIndex = 1;
            this.lblEntities.Text = "Тип";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 219);
            this.Controls.Add(this.lblEntities);
            this.Controls.Add(this.cbxEntities);
            this.Name = "StatisticsForm";
            this.Text = "Статистика покупок";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEntities;
        private System.Windows.Forms.Label lblEntities;
    }
}