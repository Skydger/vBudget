namespace vBudgetForm
{
    partial class PositionDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.SqlClient.SqlConnection cConnection = null;
        private System.Data.DataRow product = null;

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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblUnits = new System.Windows.Forms.Label();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.cbxBuyer = new System.Windows.Forms.ComboBox();
            this.cbxReceiver = new System.Windows.Forms.ComboBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.cbxUnits = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbxPrices = new System.Windows.Forms.ComboBox();
            this.lblPrices = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(368, 149);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(449, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 3;
            this.nudAmount.Location = new System.Drawing.Point(109, 75);
            this.nudAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(107, 20);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(14, 77);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(89, 13);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Количество/вес";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 54);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(68, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Стоимость: ";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(109, 52);
            this.nudPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(107, 20);
            this.nudPrice.TabIndex = 2;
            this.nudPrice.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            // 
            // nudDiscount
            // 
            this.nudDiscount.DecimalPlaces = 2;
            this.nudDiscount.Location = new System.Drawing.Point(420, 51);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(83, 20);
            this.nudDiscount.TabIndex = 6;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(364, 53);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(50, 13);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "Скидка: ";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(509, 54);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 8;
            this.lblPercent.Text = "%";
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(364, 77);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(55, 13);
            this.lblUnits.TabIndex = 9;
            this.lblUnits.Text = "Единицы:";
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Location = new System.Drawing.Point(15, 100);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(70, 13);
            this.lblBuyer.TabIndex = 11;
            this.lblBuyer.Text = "Покупатель:";
            // 
            // cbxBuyer
            // 
            this.cbxBuyer.FormattingEnabled = true;
            this.cbxBuyer.Location = new System.Drawing.Point(109, 97);
            this.cbxBuyer.Name = "cbxBuyer";
            this.cbxBuyer.Size = new System.Drawing.Size(415, 21);
            this.cbxBuyer.TabIndex = 12;
            // 
            // cbxReceiver
            // 
            this.cbxReceiver.FormattingEnabled = true;
            this.cbxReceiver.Location = new System.Drawing.Point(109, 122);
            this.cbxReceiver.Name = "cbxReceiver";
            this.cbxReceiver.Size = new System.Drawing.Size(415, 21);
            this.cbxReceiver.TabIndex = 14;
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(15, 125);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(70, 13);
            this.lblReceiver.TabIndex = 13;
            this.lblReceiver.Text = "Покупатель:";
            // 
            // cbxUnits
            // 
            this.cbxUnits.FormattingEnabled = true;
            this.cbxUnits.Items.AddRange(new object[] {
            "шт",
            "кг"});
            this.cbxUnits.Location = new System.Drawing.Point(420, 74);
            this.cbxUnits.Name = "cbxUnits";
            this.cbxUnits.Size = new System.Drawing.Size(104, 21);
            this.cbxUnits.TabIndex = 15;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProduct.Location = new System.Drawing.Point(15, 9);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(75, 16);
            this.lblProduct.TabIndex = 16;
            this.lblProduct.Text = "Продукт:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotal.Location = new System.Drawing.Point(15, 154);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 13);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Итог:";
            // 
            // cbxPrices
            // 
            this.cbxPrices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrices.FormattingEnabled = true;
            this.cbxPrices.Location = new System.Drawing.Point(110, 27);
            this.cbxPrices.Name = "cbxPrices";
            this.cbxPrices.Size = new System.Drawing.Size(415, 21);
            this.cbxPrices.TabIndex = 19;
            this.cbxPrices.SelectedIndexChanged += new System.EventHandler(this.cbxPrices_SelectedIndexChanged);
            // 
            // lblPrices
            // 
            this.lblPrices.AutoSize = true;
            this.lblPrices.Location = new System.Drawing.Point(16, 30);
            this.lblPrices.Name = "lblPrices";
            this.lblPrices.Size = new System.Drawing.Size(38, 13);
            this.lblPrices.TabIndex = 18;
            this.lblPrices.Text = "Цены:";
            // 
            // PositionDetailsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(538, 183);
            this.ControlBox = false;
            this.Controls.Add(this.cbxPrices);
            this.Controls.Add(this.lblPrices);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cbxUnits);
            this.Controls.Add(this.cbxReceiver);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.cbxBuyer);
            this.Controls.Add(this.lblBuyer);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Введите цену и количество";
            this.Load += new System.EventHandler(this.PositionDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.ComboBox cbxBuyer;
        private System.Windows.Forms.ComboBox cbxReceiver;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.ComboBox cbxUnits;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbxPrices;
        private System.Windows.Forms.Label lblPrices;
    }
}