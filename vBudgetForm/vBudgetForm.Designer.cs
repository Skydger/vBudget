namespace vBudgetForm
{
    partial class vBudgetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.DataTable receipts = null;
        private Effects.ListViewColumnSorter lvColumnSorter = null;
        private Settings.DataBaseSettingsForm settings = null;

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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewSection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByDatesSection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByLastWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByLastMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByLastThreeMonths = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByLastQuarter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOnPeriod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByCategoryFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByVendorFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTopPurchases = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByWeeks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByMonths = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByID = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSections = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDigests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMakers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVendors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiscountCards = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOftenlyBought = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMainStatus = new System.Windows.Forms.StatusStrip();
            this.tsslConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslQueryResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.cConnection = new System.Data.SqlClient.SqlConnection();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.lvReceipts = new System.Windows.Forms.ListView();
            this.cmsReceiptsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.ssMainStatus.SuspendLayout();
            this.cmsReceiptsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiViewSection,
            this.tsmiActions,
            this.tsmiDigests,
            this.tsmiStatistics});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(772, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "Главное меню";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(134, 22);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(134, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiViewSection
            // 
            this.tsmiViewSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFilters,
            this.tsmiSort,
            this.tsmiSections});
            this.tsmiViewSection.Name = "tsmiViewSection";
            this.tsmiViewSection.Size = new System.Drawing.Size(39, 20);
            this.tsmiViewSection.Text = "Вид";
            // 
            // tsmiFilters
            // 
            this.tsmiFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByDatesSection,
            this.tsmiByCategoryFilter,
            this.tsmiByVendorFilter,
            this.tsmiTopPurchases,
            this.tsmiClearFilter});
            this.tsmiFilters.Name = "tsmiFilters";
            this.tsmiFilters.Size = new System.Drawing.Size(140, 22);
            this.tsmiFilters.Text = "Фильтры";
            // 
            // tsmiByDatesSection
            // 
            this.tsmiByDatesSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByLastWeek,
            this.tsmiByLastMonth,
            this.tsmiByLastThreeMonths,
            this.tsmiByLastQuarter,
            this.tsmiOnPeriod});
            this.tsmiByDatesSection.Name = "tsmiByDatesSection";
            this.tsmiByDatesSection.Size = new System.Drawing.Size(161, 22);
            this.tsmiByDatesSection.Text = "По дате";
            // 
            // tsmiByLastWeek
            // 
            this.tsmiByLastWeek.Checked = true;
            this.tsmiByLastWeek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiByLastWeek.Name = "tsmiByLastWeek";
            this.tsmiByLastWeek.Size = new System.Drawing.Size(201, 22);
            this.tsmiByLastWeek.Text = "За последнюю неделю";
            this.tsmiByLastWeek.Click += new System.EventHandler(this.tsmiByLastWeek_Click);
            // 
            // tsmiByLastMonth
            // 
            this.tsmiByLastMonth.Name = "tsmiByLastMonth";
            this.tsmiByLastMonth.Size = new System.Drawing.Size(201, 22);
            this.tsmiByLastMonth.Text = "За последний месяц";
            this.tsmiByLastMonth.Click += new System.EventHandler(this.tsmiByLastMonth_Click);
            // 
            // tsmiByLastThreeMonths
            // 
            this.tsmiByLastThreeMonths.Name = "tsmiByLastThreeMonths";
            this.tsmiByLastThreeMonths.Size = new System.Drawing.Size(201, 22);
            this.tsmiByLastThreeMonths.Text = "За последние 3 месяца";
            this.tsmiByLastThreeMonths.Click += new System.EventHandler(this.tsmiByLastThreeMonths_Click);
            // 
            // tsmiByLastQuarter
            // 
            this.tsmiByLastQuarter.Name = "tsmiByLastQuarter";
            this.tsmiByLastQuarter.Size = new System.Drawing.Size(201, 22);
            this.tsmiByLastQuarter.Text = "За последний квартал";
            this.tsmiByLastQuarter.Click += new System.EventHandler(this.tsmiByLastQuarter_Click);
            // 
            // tsmiOnPeriod
            // 
            this.tsmiOnPeriod.Name = "tsmiOnPeriod";
            this.tsmiOnPeriod.Size = new System.Drawing.Size(201, 22);
            this.tsmiOnPeriod.Text = "За период....";
            this.tsmiOnPeriod.Click += new System.EventHandler(this.tsmiOnPeriod_Click);
            // 
            // tsmiByCategoryFilter
            // 
            this.tsmiByCategoryFilter.Name = "tsmiByCategoryFilter";
            this.tsmiByCategoryFilter.Size = new System.Drawing.Size(161, 22);
            this.tsmiByCategoryFilter.Text = "По категории";
            // 
            // tsmiByVendorFilter
            // 
            this.tsmiByVendorFilter.Name = "tsmiByVendorFilter";
            this.tsmiByVendorFilter.Size = new System.Drawing.Size(161, 22);
            this.tsmiByVendorFilter.Text = "По продавцу";
            this.tsmiByVendorFilter.Click += new System.EventHandler(this.tsmiByVendorFilter_Click);
            // 
            // tsmiTopPurchases
            // 
            this.tsmiTopPurchases.Name = "tsmiTopPurchases";
            this.tsmiTopPurchases.Size = new System.Drawing.Size(161, 22);
            this.tsmiTopPurchases.Text = "Топ-23 покупок";
            this.tsmiTopPurchases.Click += new System.EventHandler(this.tsmiTopPurchases_Click);
            // 
            // tsmiClearFilter
            // 
            this.tsmiClearFilter.Name = "tsmiClearFilter";
            this.tsmiClearFilter.Size = new System.Drawing.Size(161, 22);
            this.tsmiClearFilter.Text = "Сбросить";
            this.tsmiClearFilter.Click += new System.EventHandler(this.tsmiClearFilter_Click);
            // 
            // tsmiSort
            // 
            this.tsmiSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByWeeks,
            this.tsmiByMonths,
            this.tsmiByID});
            this.tsmiSort.Name = "tsmiSort";
            this.tsmiSort.Size = new System.Drawing.Size(140, 22);
            this.tsmiSort.Text = "Сортировка";
            // 
            // tsmiByWeeks
            // 
            this.tsmiByWeeks.Name = "tsmiByWeeks";
            this.tsmiByWeeks.Size = new System.Drawing.Size(184, 22);
            this.tsmiByWeeks.Text = "По неделям";
            this.tsmiByWeeks.Click += new System.EventHandler(this.tsmiByWeeks_Click);
            // 
            // tsmiByMonths
            // 
            this.tsmiByMonths.Name = "tsmiByMonths";
            this.tsmiByMonths.Size = new System.Drawing.Size(184, 22);
            this.tsmiByMonths.Text = "По месяцам";
            this.tsmiByMonths.Click += new System.EventHandler(this.tsmiByMonths_Click);
            // 
            // tsmiByID
            // 
            this.tsmiByID.Name = "tsmiByID";
            this.tsmiByID.Size = new System.Drawing.Size(184, 22);
            this.tsmiByID.Text = "По идентификатору";
            this.tsmiByID.Click += new System.EventHandler(this.tsmiByID_Click);
            // 
            // tsmiSections
            // 
            this.tsmiSections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReceipts,
            this.tsmiBalance});
            this.tsmiSections.Name = "tsmiSections";
            this.tsmiSections.Size = new System.Drawing.Size(140, 22);
            this.tsmiSections.Text = "Разделы";
            // 
            // tsmiReceipts
            // 
            this.tsmiReceipts.Name = "tsmiReceipts";
            this.tsmiReceipts.Size = new System.Drawing.Size(123, 22);
            this.tsmiReceipts.Text = "Чеки";
            // 
            // tsmiBalance
            // 
            this.tsmiBalance.Name = "tsmiBalance";
            this.tsmiBalance.Size = new System.Drawing.Size(123, 22);
            this.tsmiBalance.Text = "Платежи";
            // 
            // tsmiActions
            // 
            this.tsmiActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewReceipt,
            this.tsmiPersons});
            this.tsmiActions.Name = "tsmiActions";
            this.tsmiActions.Size = new System.Drawing.Size(70, 20);
            this.tsmiActions.Text = "Действия";
            // 
            // tsmiNewReceipt
            // 
            this.tsmiNewReceipt.Enabled = false;
            this.tsmiNewReceipt.Name = "tsmiNewReceipt";
            this.tsmiNewReceipt.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewReceipt.Text = "Новый чек";
            this.tsmiNewReceipt.Click += new System.EventHandler(this.tsmiNewReceipt_Click);
            // 
            // tsmiPersons
            // 
            this.tsmiPersons.Name = "tsmiPersons";
            this.tsmiPersons.Size = new System.Drawing.Size(152, 22);
            this.tsmiPersons.Text = "Пользователи";
            // 
            // tsmiDigests
            // 
            this.tsmiDigests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMakers,
            this.tsmiProducts,
            this.tsmiVendors,
            this.tsmiDiscountCards});
            this.tsmiDigests.Name = "tsmiDigests";
            this.tsmiDigests.Size = new System.Drawing.Size(94, 20);
            this.tsmiDigests.Text = "Справочники";
            // 
            // tsmiMakers
            // 
            this.tsmiMakers.Name = "tsmiMakers";
            this.tsmiMakers.Size = new System.Drawing.Size(178, 22);
            this.tsmiMakers.Text = "Изготовители";
            // 
            // tsmiProducts
            // 
            this.tsmiProducts.Name = "tsmiProducts";
            this.tsmiProducts.Size = new System.Drawing.Size(178, 22);
            this.tsmiProducts.Text = "Продукты";
            this.tsmiProducts.Click += new System.EventHandler(this.tsmiProducts_Click);
            // 
            // tsmiVendors
            // 
            this.tsmiVendors.Name = "tsmiVendors";
            this.tsmiVendors.Size = new System.Drawing.Size(178, 22);
            this.tsmiVendors.Text = "Продавцы";
            this.tsmiVendors.Click += new System.EventHandler(this.tsmiVendors_Click);
            // 
            // tsmiDiscountCards
            // 
            this.tsmiDiscountCards.Name = "tsmiDiscountCards";
            this.tsmiDiscountCards.Size = new System.Drawing.Size(178, 22);
            this.tsmiDiscountCards.Text = "Дисконтные карты";
            this.tsmiDiscountCards.Click += new System.EventHandler(this.tsmiDiscountCards_Click);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOftenlyBought});
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(80, 20);
            this.tsmiStatistics.Text = "Статистика";
            // 
            // tsmiOftenlyBought
            // 
            this.tsmiOftenlyBought.Name = "tsmiOftenlyBought";
            this.tsmiOftenlyBought.Size = new System.Drawing.Size(234, 22);
            this.tsmiOftenlyBought.Text = "Часто покупаемые продукты";
            this.tsmiOftenlyBought.Click += new System.EventHandler(this.tsmiOftenlyBought_Click);
            // 
            // ssMainStatus
            // 
            this.ssMainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectionState,
            this.tsslQueryResult});
            this.ssMainStatus.Location = new System.Drawing.Point(0, 401);
            this.ssMainStatus.Name = "ssMainStatus";
            this.ssMainStatus.Size = new System.Drawing.Size(772, 22);
            this.ssMainStatus.TabIndex = 1;
            this.ssMainStatus.Text = "Строка статуса";
            // 
            // tsslConnectionState
            // 
            this.tsslConnectionState.Name = "tsslConnectionState";
            this.tsslConnectionState.Size = new System.Drawing.Size(214, 17);
            this.tsslConnectionState.Text = "                                                                     ";
            // 
            // tsslQueryResult
            // 
            this.tsslQueryResult.Name = "tsslQueryResult";
            this.tsslQueryResult.Size = new System.Drawing.Size(178, 17);
            this.tsslQueryResult.Text = "                                                         ";
            // 
            // cConnection
            // 
            this.cConnection.FireInfoMessageEventOnUserErrors = false;
            // 
            // tsTools
            // 
            this.tsTools.Location = new System.Drawing.Point(0, 24);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(772, 25);
            this.tsTools.TabIndex = 2;
            this.tsTools.Text = "toolStrip1";
            // 
            // lvReceipts
            // 
            this.lvReceipts.ContextMenuStrip = this.cmsReceiptsMenu;
            this.lvReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReceipts.FullRowSelect = true;
            this.lvReceipts.Location = new System.Drawing.Point(0, 49);
            this.lvReceipts.Name = "lvReceipts";
            this.lvReceipts.Size = new System.Drawing.Size(772, 352);
            this.lvReceipts.TabIndex = 3;
            this.lvReceipts.UseCompatibleStateImageBehavior = false;
            this.lvReceipts.View = System.Windows.Forms.View.Details;
            this.lvReceipts.ItemActivate += new System.EventHandler(this.lvReceipts_ItemActivate);
            this.lvReceipts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvReceipts_ColumnClick);
            // 
            // cmsReceiptsMenu
            // 
            this.cmsReceiptsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportToolStripMenuItem,
            this.tsmiImport});
            this.cmsReceiptsMenu.Name = "cmsReceiptsMenu";
            this.cmsReceiptsMenu.Size = new System.Drawing.Size(129, 48);
            // 
            // tsmiExportToolStripMenuItem
            // 
            this.tsmiExportToolStripMenuItem.Name = "tsmiExportToolStripMenuItem";
            this.tsmiExportToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.tsmiExportToolStripMenuItem.Text = "Экспорт...";
            this.tsmiExportToolStripMenuItem.Click += new System.EventHandler(this.tsmiExportToolStripMenuItem_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(128, 22);
            this.tsmiImport.Text = "Импорт...";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // vBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 423);
            this.Controls.Add(this.lvReceipts);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.ssMainStatus);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "vBudgetForm";
            this.Text = "vBudget";
            this.Load += new System.EventHandler(this.vBudgetForm_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ssMainStatus.ResumeLayout(false);
            this.ssMainStatus.PerformLayout();
            this.cmsReceiptsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiActions;
        private System.Windows.Forms.StatusStrip ssMainStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewReceipt;
        private System.Windows.Forms.ToolStripMenuItem tsmiDigests;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectionState;
        private System.Data.SqlClient.SqlConnection cConnection;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ListView lvReceipts;
        private System.Windows.Forms.ToolStripStatusLabel tsslQueryResult;
        private System.Windows.Forms.ToolStripMenuItem tsmiMakers;
        private System.Windows.Forms.ToolStripMenuItem tsmiProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmiVendors;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiscountCards;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersons;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewSection;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilters;
        private System.Windows.Forms.ToolStripMenuItem tsmiSort;
        private System.Windows.Forms.ToolStripMenuItem tsmiByMonths;
        private System.Windows.Forms.ToolStripMenuItem tsmiByID;
        private System.Windows.Forms.ToolStripMenuItem tsmiByWeeks;
        private System.Windows.Forms.ToolStripMenuItem tsmiByCategoryFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiByVendorFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiByDatesSection;
        private System.Windows.Forms.ToolStripMenuItem tsmiByLastWeek;
        private System.Windows.Forms.ToolStripMenuItem tsmiByLastMonth;
        private System.Windows.Forms.ToolStripMenuItem tsmiByLastThreeMonths;
        private System.Windows.Forms.ToolStripMenuItem tsmiByLastQuarter;
        private System.Windows.Forms.ToolStripMenuItem tsmiTopPurchases;
        private System.Windows.Forms.ContextMenuStrip cmsReceiptsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiSections;
        private System.Windows.Forms.ToolStripMenuItem tsmiReceipts;
        private System.Windows.Forms.ToolStripMenuItem tsmiBalance;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiOftenlyBought;
        private System.Windows.Forms.ToolStripMenuItem tsmiOnPeriod;
    }
}