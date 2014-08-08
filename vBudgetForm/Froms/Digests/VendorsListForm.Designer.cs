namespace vBudgetForm
{
    partial class VendorsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataTable vendors = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorsListForm));
            this.lvVendors = new System.Windows.Forms.ListView();
            this.tsVendorsTools = new System.Windows.Forms.ToolStrip();
            this.tsbAddNewVendor = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblFilter = new System.Windows.Forms.ToolStripLabel();
            this.tstbxFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tsVendorsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvVendors
            // 
            this.lvVendors.AllowDrop = true;
            this.lvVendors.FullRowSelect = true;
            this.lvVendors.Location = new System.Drawing.Point(0, 28);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(725, 466);
            this.lvVendors.TabIndex = 0;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            this.lvVendors.View = System.Windows.Forms.View.Details;
            this.lvVendors.ItemActivate += new System.EventHandler(this.lvVendors_ItemActivate);
            this.lvVendors.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvVendors_ItemDrag);
            this.lvVendors.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvVendors_DragDrop);
            this.lvVendors.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvVendors_DragEnter);
            // 
            // tsVendorsTools
            // 
            this.tsVendorsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNewVendor,
            this.tslblFilter,
            this.tstbxFilter});
            this.tsVendorsTools.Location = new System.Drawing.Point(0, 0);
            this.tsVendorsTools.Name = "tsVendorsTools";
            this.tsVendorsTools.Size = new System.Drawing.Size(725, 25);
            this.tsVendorsTools.TabIndex = 1;
            this.tsVendorsTools.Text = "Панель инструментов";
            // 
            // tsbAddNewVendor
            // 
            this.tsbAddNewVendor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddNewVendor.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddNewVendor.Image")));
            this.tsbAddNewVendor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddNewVendor.Name = "tsbAddNewVendor";
            this.tsbAddNewVendor.Size = new System.Drawing.Size(23, 22);
            this.tsbAddNewVendor.Text = "toolStripButton1";
            this.tsbAddNewVendor.Click += new System.EventHandler(this.tsbAddNewVendor_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "ssVendorsStatus";
            // 
            // tslblFilter
            // 
            this.tslblFilter.Name = "tslblFilter";
            this.tslblFilter.Size = new System.Drawing.Size(48, 22);
            this.tslblFilter.Text = "Фильтр";
            // 
            // tstbxFilter
            // 
            this.tstbxFilter.Name = "tstbxFilter";
            this.tstbxFilter.Size = new System.Drawing.Size(150, 25);
            this.tstbxFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstbxFilter_KeyUp);
            // 
            // VendorsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsVendorsTools);
            this.Controls.Add(this.lvVendors);
            this.Name = "VendorsListForm";
            this.Text = "Перечень продавцов";
            this.Load += new System.EventHandler(this.VendorsListForm_Load);
            this.Resize += new System.EventHandler(this.VendorsListForm_Resize);
            this.tsVendorsTools.ResumeLayout(false);
            this.tsVendorsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvVendors;
        private System.Windows.Forms.ToolStrip tsVendorsTools;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddNewVendor;
        private System.Windows.Forms.ToolStripLabel tslblFilter;
        private System.Windows.Forms.ToolStripTextBox tstbxFilter;
    }
}