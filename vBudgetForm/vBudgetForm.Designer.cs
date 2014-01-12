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
        private System.DateTime[] dates;
        private System.Resources.ResourceManager manager = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vBudgetForm));
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileI = new System.Windows.Forms.ToolStripSeparator();
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
            this.tsmiByDays = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByWeeks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByMonths = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByID = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByCreationDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSections = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewClonedReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataExchange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDigests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMakers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVendors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiscountCards = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOftenlyBought = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductPrices = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMainStatus = new System.Windows.Forms.StatusStrip();
            this.tsslConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslQueryResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.cConnection = new System.Data.SqlClient.SqlConnection();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.lvReceipts = new System.Windows.Forms.ListView();
            this.cmsReceiptsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddClonedReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.ssMainStatus.SuspendLayout();
            this.cmsReceiptsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            resources.ApplyResources(this.msMainMenu, "msMainMenu");
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiViewSection,
            this.tsmiActions,
            this.tsmiDigests,
            this.tsmiStatistics});
            this.msMainMenu.Name = "msMainMenu";
            // 
            // tsmiFile
            // 
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiFileI,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            // 
            // tsmiSettings
            // 
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiFileI
            // 
            resources.ApplyResources(this.tsmiFileI, "tsmiFileI");
            this.tsmiFileI.Name = "tsmiFileI";
            // 
            // tsmiExit
            // 
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiViewSection
            // 
            resources.ApplyResources(this.tsmiViewSection, "tsmiViewSection");
            this.tsmiViewSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFilters,
            this.tsmiSort,
            this.tsmiSections});
            this.tsmiViewSection.Name = "tsmiViewSection";
            // 
            // tsmiFilters
            // 
            resources.ApplyResources(this.tsmiFilters, "tsmiFilters");
            this.tsmiFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByDatesSection,
            this.tsmiByCategoryFilter,
            this.tsmiByVendorFilter,
            this.tsmiTopPurchases,
            this.tsmiClearFilter});
            this.tsmiFilters.Name = "tsmiFilters";
            // 
            // tsmiByDatesSection
            // 
            resources.ApplyResources(this.tsmiByDatesSection, "tsmiByDatesSection");
            this.tsmiByDatesSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByLastWeek,
            this.tsmiByLastMonth,
            this.tsmiByLastThreeMonths,
            this.tsmiByLastQuarter,
            this.tsmiOnPeriod});
            this.tsmiByDatesSection.Name = "tsmiByDatesSection";
            // 
            // tsmiByLastWeek
            // 
            resources.ApplyResources(this.tsmiByLastWeek, "tsmiByLastWeek");
            this.tsmiByLastWeek.Checked = true;
            this.tsmiByLastWeek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiByLastWeek.Name = "tsmiByLastWeek";
            this.tsmiByLastWeek.Click += new System.EventHandler(this.tsmiByLastWeek_Click);
            // 
            // tsmiByLastMonth
            // 
            resources.ApplyResources(this.tsmiByLastMonth, "tsmiByLastMonth");
            this.tsmiByLastMonth.Name = "tsmiByLastMonth";
            this.tsmiByLastMonth.Click += new System.EventHandler(this.tsmiByLastMonth_Click);
            // 
            // tsmiByLastThreeMonths
            // 
            resources.ApplyResources(this.tsmiByLastThreeMonths, "tsmiByLastThreeMonths");
            this.tsmiByLastThreeMonths.Name = "tsmiByLastThreeMonths";
            this.tsmiByLastThreeMonths.Click += new System.EventHandler(this.tsmiByLastThreeMonths_Click);
            // 
            // tsmiByLastQuarter
            // 
            resources.ApplyResources(this.tsmiByLastQuarter, "tsmiByLastQuarter");
            this.tsmiByLastQuarter.Name = "tsmiByLastQuarter";
            this.tsmiByLastQuarter.Click += new System.EventHandler(this.tsmiByLastQuarter_Click);
            // 
            // tsmiOnPeriod
            // 
            resources.ApplyResources(this.tsmiOnPeriod, "tsmiOnPeriod");
            this.tsmiOnPeriod.Name = "tsmiOnPeriod";
            this.tsmiOnPeriod.Click += new System.EventHandler(this.tsmiOnPeriod_Click);
            // 
            // tsmiByCategoryFilter
            // 
            resources.ApplyResources(this.tsmiByCategoryFilter, "tsmiByCategoryFilter");
            this.tsmiByCategoryFilter.Name = "tsmiByCategoryFilter";
            this.tsmiByCategoryFilter.Click += new System.EventHandler(this.tsmiByCategoryFilter_Click);
            // 
            // tsmiByVendorFilter
            // 
            resources.ApplyResources(this.tsmiByVendorFilter, "tsmiByVendorFilter");
            this.tsmiByVendorFilter.Name = "tsmiByVendorFilter";
            this.tsmiByVendorFilter.Click += new System.EventHandler(this.tsmiByVendorFilter_Click);
            // 
            // tsmiTopPurchases
            // 
            resources.ApplyResources(this.tsmiTopPurchases, "tsmiTopPurchases");
            this.tsmiTopPurchases.Name = "tsmiTopPurchases";
            this.tsmiTopPurchases.Click += new System.EventHandler(this.tsmiTopPurchases_Click);
            // 
            // tsmiClearFilter
            // 
            resources.ApplyResources(this.tsmiClearFilter, "tsmiClearFilter");
            this.tsmiClearFilter.Name = "tsmiClearFilter";
            this.tsmiClearFilter.Click += new System.EventHandler(this.tsmiClearFilter_Click);
            // 
            // tsmiSort
            // 
            resources.ApplyResources(this.tsmiSort, "tsmiSort");
            this.tsmiSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByDays,
            this.tsmiByWeeks,
            this.tsmiByMonths,
            this.tsmiByID,
            this.tsmiByCreationDate});
            this.tsmiSort.Name = "tsmiSort";
            // 
            // tsmiByDays
            // 
            resources.ApplyResources(this.tsmiByDays, "tsmiByDays");
            this.tsmiByDays.Name = "tsmiByDays";
            this.tsmiByDays.Click += new System.EventHandler(this.tsmiByDays_Click);
            // 
            // tsmiByWeeks
            // 
            resources.ApplyResources(this.tsmiByWeeks, "tsmiByWeeks");
            this.tsmiByWeeks.Name = "tsmiByWeeks";
            this.tsmiByWeeks.Click += new System.EventHandler(this.tsmiByWeeks_Click);
            // 
            // tsmiByMonths
            // 
            resources.ApplyResources(this.tsmiByMonths, "tsmiByMonths");
            this.tsmiByMonths.Name = "tsmiByMonths";
            this.tsmiByMonths.Click += new System.EventHandler(this.tsmiByMonths_Click);
            // 
            // tsmiByID
            // 
            resources.ApplyResources(this.tsmiByID, "tsmiByID");
            this.tsmiByID.Name = "tsmiByID";
            this.tsmiByID.Click += new System.EventHandler(this.tsmiByID_Click);
            // 
            // tsmiByCreationDate
            // 
            resources.ApplyResources(this.tsmiByCreationDate, "tsmiByCreationDate");
            this.tsmiByCreationDate.Name = "tsmiByCreationDate";
            this.tsmiByCreationDate.Click += new System.EventHandler(this.tsmiByCreationDate_Click);
            // 
            // tsmiSections
            // 
            resources.ApplyResources(this.tsmiSections, "tsmiSections");
            this.tsmiSections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReceipts,
            this.tsmiBalance});
            this.tsmiSections.Name = "tsmiSections";
            // 
            // tsmiReceipts
            // 
            resources.ApplyResources(this.tsmiReceipts, "tsmiReceipts");
            this.tsmiReceipts.Name = "tsmiReceipts";
            // 
            // tsmiBalance
            // 
            resources.ApplyResources(this.tsmiBalance, "tsmiBalance");
            this.tsmiBalance.Name = "tsmiBalance";
            // 
            // tsmiActions
            // 
            resources.ApplyResources(this.tsmiActions, "tsmiActions");
            this.tsmiActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewReceipt,
            this.tsmiNewClonedReceipt,
            this.tsmiPersons,
            this.tsmiDataExchange});
            this.tsmiActions.Name = "tsmiActions";
            // 
            // tsmiNewReceipt
            // 
            resources.ApplyResources(this.tsmiNewReceipt, "tsmiNewReceipt");
            this.tsmiNewReceipt.Name = "tsmiNewReceipt";
            this.tsmiNewReceipt.Click += new System.EventHandler(this.tsmiNewReceipt_Click);
            // 
            // tsmiNewClonedReceipt
            // 
            resources.ApplyResources(this.tsmiNewClonedReceipt, "tsmiNewClonedReceipt");
            this.tsmiNewClonedReceipt.Name = "tsmiNewClonedReceipt";
            this.tsmiNewClonedReceipt.Click += new System.EventHandler(this.tsmiNewClonedReceiptToolStripMenuItem_Click);
            // 
            // tsmiPersons
            // 
            resources.ApplyResources(this.tsmiPersons, "tsmiPersons");
            this.tsmiPersons.Name = "tsmiPersons";
            // 
            // tsmiDataExchange
            // 
            resources.ApplyResources(this.tsmiDataExchange, "tsmiDataExchange");
            this.tsmiDataExchange.Name = "tsmiDataExchange";
            // 
            // tsmiDigests
            // 
            resources.ApplyResources(this.tsmiDigests, "tsmiDigests");
            this.tsmiDigests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMakers,
            this.tsmiProducts,
            this.tsmiVendors,
            this.tsmiDiscountCards});
            this.tsmiDigests.Name = "tsmiDigests";
            // 
            // tsmiMakers
            // 
            resources.ApplyResources(this.tsmiMakers, "tsmiMakers");
            this.tsmiMakers.Name = "tsmiMakers";
            this.tsmiMakers.Click += new System.EventHandler(this.tsmiMakers_Click);
            // 
            // tsmiProducts
            // 
            resources.ApplyResources(this.tsmiProducts, "tsmiProducts");
            this.tsmiProducts.Name = "tsmiProducts";
            this.tsmiProducts.Click += new System.EventHandler(this.tsmiProducts_Click);
            // 
            // tsmiVendors
            // 
            resources.ApplyResources(this.tsmiVendors, "tsmiVendors");
            this.tsmiVendors.Name = "tsmiVendors";
            this.tsmiVendors.Click += new System.EventHandler(this.tsmiVendors_Click);
            // 
            // tsmiDiscountCards
            // 
            resources.ApplyResources(this.tsmiDiscountCards, "tsmiDiscountCards");
            this.tsmiDiscountCards.Name = "tsmiDiscountCards";
            this.tsmiDiscountCards.Click += new System.EventHandler(this.tsmiDiscountCards_Click);
            // 
            // tsmiStatistics
            // 
            resources.ApplyResources(this.tsmiStatistics, "tsmiStatistics");
            this.tsmiStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOftenlyBought,
            this.tsmiProductPrices});
            this.tsmiStatistics.Name = "tsmiStatistics";
            // 
            // tsmiOftenlyBought
            // 
            resources.ApplyResources(this.tsmiOftenlyBought, "tsmiOftenlyBought");
            this.tsmiOftenlyBought.Name = "tsmiOftenlyBought";
            this.tsmiOftenlyBought.Click += new System.EventHandler(this.tsmiOftenlyBought_Click);
            // 
            // tsmiProductPrices
            // 
            resources.ApplyResources(this.tsmiProductPrices, "tsmiProductPrices");
            this.tsmiProductPrices.Name = "tsmiProductPrices";
            this.tsmiProductPrices.Click += new System.EventHandler(this.tsmiProductPrices_Click);
            // 
            // ssMainStatus
            // 
            resources.ApplyResources(this.ssMainStatus, "ssMainStatus");
            this.ssMainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectionState,
            this.tsslQueryResult});
            this.ssMainStatus.Name = "ssMainStatus";
            // 
            // tsslConnectionState
            // 
            resources.ApplyResources(this.tsslConnectionState, "tsslConnectionState");
            this.tsslConnectionState.Name = "tsslConnectionState";
            // 
            // tsslQueryResult
            // 
            resources.ApplyResources(this.tsslQueryResult, "tsslQueryResult");
            this.tsslQueryResult.Name = "tsslQueryResult";
            // 
            // cConnection
            // 
            this.cConnection.FireInfoMessageEventOnUserErrors = false;
            // 
            // tsTools
            // 
            resources.ApplyResources(this.tsTools, "tsTools");
            this.tsTools.Name = "tsTools";
            // 
            // lvReceipts
            // 
            resources.ApplyResources(this.lvReceipts, "lvReceipts");
            this.lvReceipts.ContextMenuStrip = this.cmsReceiptsMenu;
            this.lvReceipts.FullRowSelect = true;
            this.lvReceipts.Name = "lvReceipts";
            this.lvReceipts.UseCompatibleStateImageBehavior = false;
            this.lvReceipts.View = System.Windows.Forms.View.Details;
            this.lvReceipts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvReceipts_ColumnClick);
            this.lvReceipts.ItemActivate += new System.EventHandler(this.lvReceipts_ItemActivate);
            // 
            // cmsReceiptsMenu
            // 
            resources.ApplyResources(this.cmsReceiptsMenu, "cmsReceiptsMenu");
            this.cmsReceiptsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddReceipt,
            this.tsmiAddClonedReceipt,
            this.toolStripMenuItem2,
            this.tsmiDeleteReceipt,
            this.toolStripMenuItem1,
            this.tsmiExportToolStripMenuItem,
            this.tsmiImport});
            this.cmsReceiptsMenu.Name = "cmsReceiptsMenu";
            this.cmsReceiptsMenu.Opened += new System.EventHandler(this.cmsReceiptsMenu_Opened);
            // 
            // tsmiAddReceipt
            // 
            resources.ApplyResources(this.tsmiAddReceipt, "tsmiAddReceipt");
            this.tsmiAddReceipt.Name = "tsmiAddReceipt";
            this.tsmiAddReceipt.Click += new System.EventHandler(this.tsmiAddReceipt_Click);
            // 
            // tsmiAddClonedReceipt
            // 
            resources.ApplyResources(this.tsmiAddClonedReceipt, "tsmiAddClonedReceipt");
            this.tsmiAddClonedReceipt.Name = "tsmiAddClonedReceipt";
            this.tsmiAddClonedReceipt.Click += new System.EventHandler(this.tsmiAddClonedReceiptToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // tsmiDeleteReceipt
            // 
            resources.ApplyResources(this.tsmiDeleteReceipt, "tsmiDeleteReceipt");
            this.tsmiDeleteReceipt.Name = "tsmiDeleteReceipt";
            this.tsmiDeleteReceipt.Click += new System.EventHandler(this.tsmiDeleteReceipt_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // tsmiExportToolStripMenuItem
            // 
            resources.ApplyResources(this.tsmiExportToolStripMenuItem, "tsmiExportToolStripMenuItem");
            this.tsmiExportToolStripMenuItem.Name = "tsmiExportToolStripMenuItem";
            this.tsmiExportToolStripMenuItem.Click += new System.EventHandler(this.tsmiExportToolStripMenuItem_Click);
            // 
            // tsmiImport
            // 
            resources.ApplyResources(this.tsmiImport, "tsmiImport");
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // vBudgetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvReceipts);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.ssMainStatus);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "vBudgetForm";
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
        private System.Windows.Forms.ToolStripMenuItem tsmiProductPrices;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataExchange;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddReceipt;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteReceipt;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewClonedReceipt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddClonedReceipt;
        private System.Windows.Forms.ToolStripMenuItem tsmiByCreationDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiByDays;
        private System.Windows.Forms.ToolStripSeparator tsmiFileI;
    }
}