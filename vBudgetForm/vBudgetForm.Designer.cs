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
            this.msMainMenu.AccessibleDescription = null;
            this.msMainMenu.AccessibleName = null;
            resources.ApplyResources(this.msMainMenu, "msMainMenu");
            this.msMainMenu.BackgroundImage = null;
            this.msMainMenu.Font = null;
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
            this.tsmiFile.AccessibleDescription = null;
            this.tsmiFile.AccessibleName = null;
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            this.tsmiFile.BackgroundImage = null;
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.ShortcutKeyDisplayString = null;
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.AccessibleDescription = null;
            this.tsmiSettings.AccessibleName = null;
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.BackgroundImage = null;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.ShortcutKeyDisplayString = null;
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.AccessibleDescription = null;
            this.tsmiExit.AccessibleName = null;
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.BackgroundImage = null;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeyDisplayString = null;
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiViewSection
            // 
            this.tsmiViewSection.AccessibleDescription = null;
            this.tsmiViewSection.AccessibleName = null;
            resources.ApplyResources(this.tsmiViewSection, "tsmiViewSection");
            this.tsmiViewSection.BackgroundImage = null;
            this.tsmiViewSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFilters,
            this.tsmiSort,
            this.tsmiSections});
            this.tsmiViewSection.Name = "tsmiViewSection";
            this.tsmiViewSection.ShortcutKeyDisplayString = null;
            // 
            // tsmiFilters
            // 
            this.tsmiFilters.AccessibleDescription = null;
            this.tsmiFilters.AccessibleName = null;
            resources.ApplyResources(this.tsmiFilters, "tsmiFilters");
            this.tsmiFilters.BackgroundImage = null;
            this.tsmiFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByDatesSection,
            this.tsmiByCategoryFilter,
            this.tsmiByVendorFilter,
            this.tsmiTopPurchases,
            this.tsmiClearFilter});
            this.tsmiFilters.Name = "tsmiFilters";
            this.tsmiFilters.ShortcutKeyDisplayString = null;
            // 
            // tsmiByDatesSection
            // 
            this.tsmiByDatesSection.AccessibleDescription = null;
            this.tsmiByDatesSection.AccessibleName = null;
            resources.ApplyResources(this.tsmiByDatesSection, "tsmiByDatesSection");
            this.tsmiByDatesSection.BackgroundImage = null;
            this.tsmiByDatesSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByLastWeek,
            this.tsmiByLastMonth,
            this.tsmiByLastThreeMonths,
            this.tsmiByLastQuarter,
            this.tsmiOnPeriod});
            this.tsmiByDatesSection.Name = "tsmiByDatesSection";
            this.tsmiByDatesSection.ShortcutKeyDisplayString = null;
            // 
            // tsmiByLastWeek
            // 
            this.tsmiByLastWeek.AccessibleDescription = null;
            this.tsmiByLastWeek.AccessibleName = null;
            resources.ApplyResources(this.tsmiByLastWeek, "tsmiByLastWeek");
            this.tsmiByLastWeek.BackgroundImage = null;
            this.tsmiByLastWeek.Checked = true;
            this.tsmiByLastWeek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiByLastWeek.Name = "tsmiByLastWeek";
            this.tsmiByLastWeek.ShortcutKeyDisplayString = null;
            this.tsmiByLastWeek.Click += new System.EventHandler(this.tsmiByLastWeek_Click);
            // 
            // tsmiByLastMonth
            // 
            this.tsmiByLastMonth.AccessibleDescription = null;
            this.tsmiByLastMonth.AccessibleName = null;
            resources.ApplyResources(this.tsmiByLastMonth, "tsmiByLastMonth");
            this.tsmiByLastMonth.BackgroundImage = null;
            this.tsmiByLastMonth.Name = "tsmiByLastMonth";
            this.tsmiByLastMonth.ShortcutKeyDisplayString = null;
            this.tsmiByLastMonth.Click += new System.EventHandler(this.tsmiByLastMonth_Click);
            // 
            // tsmiByLastThreeMonths
            // 
            this.tsmiByLastThreeMonths.AccessibleDescription = null;
            this.tsmiByLastThreeMonths.AccessibleName = null;
            resources.ApplyResources(this.tsmiByLastThreeMonths, "tsmiByLastThreeMonths");
            this.tsmiByLastThreeMonths.BackgroundImage = null;
            this.tsmiByLastThreeMonths.Name = "tsmiByLastThreeMonths";
            this.tsmiByLastThreeMonths.ShortcutKeyDisplayString = null;
            this.tsmiByLastThreeMonths.Click += new System.EventHandler(this.tsmiByLastThreeMonths_Click);
            // 
            // tsmiByLastQuarter
            // 
            this.tsmiByLastQuarter.AccessibleDescription = null;
            this.tsmiByLastQuarter.AccessibleName = null;
            resources.ApplyResources(this.tsmiByLastQuarter, "tsmiByLastQuarter");
            this.tsmiByLastQuarter.BackgroundImage = null;
            this.tsmiByLastQuarter.Name = "tsmiByLastQuarter";
            this.tsmiByLastQuarter.ShortcutKeyDisplayString = null;
            this.tsmiByLastQuarter.Click += new System.EventHandler(this.tsmiByLastQuarter_Click);
            // 
            // tsmiOnPeriod
            // 
            this.tsmiOnPeriod.AccessibleDescription = null;
            this.tsmiOnPeriod.AccessibleName = null;
            resources.ApplyResources(this.tsmiOnPeriod, "tsmiOnPeriod");
            this.tsmiOnPeriod.BackgroundImage = null;
            this.tsmiOnPeriod.Name = "tsmiOnPeriod";
            this.tsmiOnPeriod.ShortcutKeyDisplayString = null;
            this.tsmiOnPeriod.Click += new System.EventHandler(this.tsmiOnPeriod_Click);
            // 
            // tsmiByCategoryFilter
            // 
            this.tsmiByCategoryFilter.AccessibleDescription = null;
            this.tsmiByCategoryFilter.AccessibleName = null;
            resources.ApplyResources(this.tsmiByCategoryFilter, "tsmiByCategoryFilter");
            this.tsmiByCategoryFilter.BackgroundImage = null;
            this.tsmiByCategoryFilter.Name = "tsmiByCategoryFilter";
            this.tsmiByCategoryFilter.ShortcutKeyDisplayString = null;
            this.tsmiByCategoryFilter.Click += new System.EventHandler(this.tsmiByCategoryFilter_Click);
            // 
            // tsmiByVendorFilter
            // 
            this.tsmiByVendorFilter.AccessibleDescription = null;
            this.tsmiByVendorFilter.AccessibleName = null;
            resources.ApplyResources(this.tsmiByVendorFilter, "tsmiByVendorFilter");
            this.tsmiByVendorFilter.BackgroundImage = null;
            this.tsmiByVendorFilter.Name = "tsmiByVendorFilter";
            this.tsmiByVendorFilter.ShortcutKeyDisplayString = null;
            this.tsmiByVendorFilter.Click += new System.EventHandler(this.tsmiByVendorFilter_Click);
            // 
            // tsmiTopPurchases
            // 
            this.tsmiTopPurchases.AccessibleDescription = null;
            this.tsmiTopPurchases.AccessibleName = null;
            resources.ApplyResources(this.tsmiTopPurchases, "tsmiTopPurchases");
            this.tsmiTopPurchases.BackgroundImage = null;
            this.tsmiTopPurchases.Name = "tsmiTopPurchases";
            this.tsmiTopPurchases.ShortcutKeyDisplayString = null;
            this.tsmiTopPurchases.Click += new System.EventHandler(this.tsmiTopPurchases_Click);
            // 
            // tsmiClearFilter
            // 
            this.tsmiClearFilter.AccessibleDescription = null;
            this.tsmiClearFilter.AccessibleName = null;
            resources.ApplyResources(this.tsmiClearFilter, "tsmiClearFilter");
            this.tsmiClearFilter.BackgroundImage = null;
            this.tsmiClearFilter.Name = "tsmiClearFilter";
            this.tsmiClearFilter.ShortcutKeyDisplayString = null;
            this.tsmiClearFilter.Click += new System.EventHandler(this.tsmiClearFilter_Click);
            // 
            // tsmiSort
            // 
            this.tsmiSort.AccessibleDescription = null;
            this.tsmiSort.AccessibleName = null;
            resources.ApplyResources(this.tsmiSort, "tsmiSort");
            this.tsmiSort.BackgroundImage = null;
            this.tsmiSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByWeeks,
            this.tsmiByMonths,
            this.tsmiByID});
            this.tsmiSort.Name = "tsmiSort";
            this.tsmiSort.ShortcutKeyDisplayString = null;
            // 
            // tsmiByWeeks
            // 
            this.tsmiByWeeks.AccessibleDescription = null;
            this.tsmiByWeeks.AccessibleName = null;
            resources.ApplyResources(this.tsmiByWeeks, "tsmiByWeeks");
            this.tsmiByWeeks.BackgroundImage = null;
            this.tsmiByWeeks.Name = "tsmiByWeeks";
            this.tsmiByWeeks.ShortcutKeyDisplayString = null;
            this.tsmiByWeeks.Click += new System.EventHandler(this.tsmiByWeeks_Click);
            // 
            // tsmiByMonths
            // 
            this.tsmiByMonths.AccessibleDescription = null;
            this.tsmiByMonths.AccessibleName = null;
            resources.ApplyResources(this.tsmiByMonths, "tsmiByMonths");
            this.tsmiByMonths.BackgroundImage = null;
            this.tsmiByMonths.Name = "tsmiByMonths";
            this.tsmiByMonths.ShortcutKeyDisplayString = null;
            this.tsmiByMonths.Click += new System.EventHandler(this.tsmiByMonths_Click);
            // 
            // tsmiByID
            // 
            this.tsmiByID.AccessibleDescription = null;
            this.tsmiByID.AccessibleName = null;
            resources.ApplyResources(this.tsmiByID, "tsmiByID");
            this.tsmiByID.BackgroundImage = null;
            this.tsmiByID.Name = "tsmiByID";
            this.tsmiByID.ShortcutKeyDisplayString = null;
            this.tsmiByID.Click += new System.EventHandler(this.tsmiByID_Click);
            // 
            // tsmiSections
            // 
            this.tsmiSections.AccessibleDescription = null;
            this.tsmiSections.AccessibleName = null;
            resources.ApplyResources(this.tsmiSections, "tsmiSections");
            this.tsmiSections.BackgroundImage = null;
            this.tsmiSections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReceipts,
            this.tsmiBalance});
            this.tsmiSections.Name = "tsmiSections";
            this.tsmiSections.ShortcutKeyDisplayString = null;
            // 
            // tsmiReceipts
            // 
            this.tsmiReceipts.AccessibleDescription = null;
            this.tsmiReceipts.AccessibleName = null;
            resources.ApplyResources(this.tsmiReceipts, "tsmiReceipts");
            this.tsmiReceipts.BackgroundImage = null;
            this.tsmiReceipts.Name = "tsmiReceipts";
            this.tsmiReceipts.ShortcutKeyDisplayString = null;
            // 
            // tsmiBalance
            // 
            this.tsmiBalance.AccessibleDescription = null;
            this.tsmiBalance.AccessibleName = null;
            resources.ApplyResources(this.tsmiBalance, "tsmiBalance");
            this.tsmiBalance.BackgroundImage = null;
            this.tsmiBalance.Name = "tsmiBalance";
            this.tsmiBalance.ShortcutKeyDisplayString = null;
            // 
            // tsmiActions
            // 
            this.tsmiActions.AccessibleDescription = null;
            this.tsmiActions.AccessibleName = null;
            resources.ApplyResources(this.tsmiActions, "tsmiActions");
            this.tsmiActions.BackgroundImage = null;
            this.tsmiActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewReceipt,
            this.tsmiPersons,
            this.tsmiDataExchange});
            this.tsmiActions.Name = "tsmiActions";
            this.tsmiActions.ShortcutKeyDisplayString = null;
            // 
            // tsmiNewReceipt
            // 
            this.tsmiNewReceipt.AccessibleDescription = null;
            this.tsmiNewReceipt.AccessibleName = null;
            resources.ApplyResources(this.tsmiNewReceipt, "tsmiNewReceipt");
            this.tsmiNewReceipt.BackgroundImage = null;
            this.tsmiNewReceipt.Name = "tsmiNewReceipt";
            this.tsmiNewReceipt.ShortcutKeyDisplayString = null;
            this.tsmiNewReceipt.Click += new System.EventHandler(this.tsmiNewReceipt_Click);
            // 
            // tsmiPersons
            // 
            this.tsmiPersons.AccessibleDescription = null;
            this.tsmiPersons.AccessibleName = null;
            resources.ApplyResources(this.tsmiPersons, "tsmiPersons");
            this.tsmiPersons.BackgroundImage = null;
            this.tsmiPersons.Name = "tsmiPersons";
            this.tsmiPersons.ShortcutKeyDisplayString = null;
            // 
            // tsmiDataExchange
            // 
            this.tsmiDataExchange.AccessibleDescription = null;
            this.tsmiDataExchange.AccessibleName = null;
            resources.ApplyResources(this.tsmiDataExchange, "tsmiDataExchange");
            this.tsmiDataExchange.BackgroundImage = null;
            this.tsmiDataExchange.Name = "tsmiDataExchange";
            this.tsmiDataExchange.ShortcutKeyDisplayString = null;
            // 
            // tsmiDigests
            // 
            this.tsmiDigests.AccessibleDescription = null;
            this.tsmiDigests.AccessibleName = null;
            resources.ApplyResources(this.tsmiDigests, "tsmiDigests");
            this.tsmiDigests.BackgroundImage = null;
            this.tsmiDigests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMakers,
            this.tsmiProducts,
            this.tsmiVendors,
            this.tsmiDiscountCards});
            this.tsmiDigests.Name = "tsmiDigests";
            this.tsmiDigests.ShortcutKeyDisplayString = null;
            // 
            // tsmiMakers
            // 
            this.tsmiMakers.AccessibleDescription = null;
            this.tsmiMakers.AccessibleName = null;
            resources.ApplyResources(this.tsmiMakers, "tsmiMakers");
            this.tsmiMakers.BackgroundImage = null;
            this.tsmiMakers.Name = "tsmiMakers";
            this.tsmiMakers.ShortcutKeyDisplayString = null;
            this.tsmiMakers.Click += new System.EventHandler(this.tsmiMakers_Click);
            // 
            // tsmiProducts
            // 
            this.tsmiProducts.AccessibleDescription = null;
            this.tsmiProducts.AccessibleName = null;
            resources.ApplyResources(this.tsmiProducts, "tsmiProducts");
            this.tsmiProducts.BackgroundImage = null;
            this.tsmiProducts.Name = "tsmiProducts";
            this.tsmiProducts.ShortcutKeyDisplayString = null;
            this.tsmiProducts.Click += new System.EventHandler(this.tsmiProducts_Click);
            // 
            // tsmiVendors
            // 
            this.tsmiVendors.AccessibleDescription = null;
            this.tsmiVendors.AccessibleName = null;
            resources.ApplyResources(this.tsmiVendors, "tsmiVendors");
            this.tsmiVendors.BackgroundImage = null;
            this.tsmiVendors.Name = "tsmiVendors";
            this.tsmiVendors.ShortcutKeyDisplayString = null;
            this.tsmiVendors.Click += new System.EventHandler(this.tsmiVendors_Click);
            // 
            // tsmiDiscountCards
            // 
            this.tsmiDiscountCards.AccessibleDescription = null;
            this.tsmiDiscountCards.AccessibleName = null;
            resources.ApplyResources(this.tsmiDiscountCards, "tsmiDiscountCards");
            this.tsmiDiscountCards.BackgroundImage = null;
            this.tsmiDiscountCards.Name = "tsmiDiscountCards";
            this.tsmiDiscountCards.ShortcutKeyDisplayString = null;
            this.tsmiDiscountCards.Click += new System.EventHandler(this.tsmiDiscountCards_Click);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.AccessibleDescription = null;
            this.tsmiStatistics.AccessibleName = null;
            resources.ApplyResources(this.tsmiStatistics, "tsmiStatistics");
            this.tsmiStatistics.BackgroundImage = null;
            this.tsmiStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOftenlyBought,
            this.tsmiProductPrices});
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.ShortcutKeyDisplayString = null;
            // 
            // tsmiOftenlyBought
            // 
            this.tsmiOftenlyBought.AccessibleDescription = null;
            this.tsmiOftenlyBought.AccessibleName = null;
            resources.ApplyResources(this.tsmiOftenlyBought, "tsmiOftenlyBought");
            this.tsmiOftenlyBought.BackgroundImage = null;
            this.tsmiOftenlyBought.Name = "tsmiOftenlyBought";
            this.tsmiOftenlyBought.ShortcutKeyDisplayString = null;
            this.tsmiOftenlyBought.Click += new System.EventHandler(this.tsmiOftenlyBought_Click);
            // 
            // tsmiProductPrices
            // 
            this.tsmiProductPrices.AccessibleDescription = null;
            this.tsmiProductPrices.AccessibleName = null;
            resources.ApplyResources(this.tsmiProductPrices, "tsmiProductPrices");
            this.tsmiProductPrices.BackgroundImage = null;
            this.tsmiProductPrices.Name = "tsmiProductPrices";
            this.tsmiProductPrices.ShortcutKeyDisplayString = null;
            this.tsmiProductPrices.Click += new System.EventHandler(this.tsmiProductPrices_Click);
            // 
            // ssMainStatus
            // 
            this.ssMainStatus.AccessibleDescription = null;
            this.ssMainStatus.AccessibleName = null;
            resources.ApplyResources(this.ssMainStatus, "ssMainStatus");
            this.ssMainStatus.BackgroundImage = null;
            this.ssMainStatus.Font = null;
            this.ssMainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectionState,
            this.tsslQueryResult});
            this.ssMainStatus.Name = "ssMainStatus";
            // 
            // tsslConnectionState
            // 
            this.tsslConnectionState.AccessibleDescription = null;
            this.tsslConnectionState.AccessibleName = null;
            resources.ApplyResources(this.tsslConnectionState, "tsslConnectionState");
            this.tsslConnectionState.BackgroundImage = null;
            this.tsslConnectionState.Name = "tsslConnectionState";
            // 
            // tsslQueryResult
            // 
            this.tsslQueryResult.AccessibleDescription = null;
            this.tsslQueryResult.AccessibleName = null;
            resources.ApplyResources(this.tsslQueryResult, "tsslQueryResult");
            this.tsslQueryResult.BackgroundImage = null;
            this.tsslQueryResult.Name = "tsslQueryResult";
            // 
            // cConnection
            // 
            this.cConnection.FireInfoMessageEventOnUserErrors = false;
            // 
            // tsTools
            // 
            this.tsTools.AccessibleDescription = null;
            this.tsTools.AccessibleName = null;
            resources.ApplyResources(this.tsTools, "tsTools");
            this.tsTools.BackgroundImage = null;
            this.tsTools.Font = null;
            this.tsTools.Name = "tsTools";
            // 
            // lvReceipts
            // 
            this.lvReceipts.AccessibleDescription = null;
            this.lvReceipts.AccessibleName = null;
            resources.ApplyResources(this.lvReceipts, "lvReceipts");
            this.lvReceipts.BackgroundImage = null;
            this.lvReceipts.ContextMenuStrip = this.cmsReceiptsMenu;
            this.lvReceipts.Font = null;
            this.lvReceipts.FullRowSelect = true;
            this.lvReceipts.Name = "lvReceipts";
            this.lvReceipts.UseCompatibleStateImageBehavior = false;
            this.lvReceipts.View = System.Windows.Forms.View.Details;
            this.lvReceipts.ItemActivate += new System.EventHandler(this.lvReceipts_ItemActivate);
            this.lvReceipts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvReceipts_ColumnClick);
            // 
            // cmsReceiptsMenu
            // 
            this.cmsReceiptsMenu.AccessibleDescription = null;
            this.cmsReceiptsMenu.AccessibleName = null;
            resources.ApplyResources(this.cmsReceiptsMenu, "cmsReceiptsMenu");
            this.cmsReceiptsMenu.BackgroundImage = null;
            this.cmsReceiptsMenu.Font = null;
            this.cmsReceiptsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddReceipt,
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
            this.tsmiAddReceipt.AccessibleDescription = null;
            this.tsmiAddReceipt.AccessibleName = null;
            resources.ApplyResources(this.tsmiAddReceipt, "tsmiAddReceipt");
            this.tsmiAddReceipt.BackgroundImage = null;
            this.tsmiAddReceipt.Name = "tsmiAddReceipt";
            this.tsmiAddReceipt.ShortcutKeyDisplayString = null;
            this.tsmiAddReceipt.Click += new System.EventHandler(this.tsmiAddReceipt_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AccessibleDescription = null;
            this.toolStripMenuItem2.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // tsmiDeleteReceipt
            // 
            this.tsmiDeleteReceipt.AccessibleDescription = null;
            this.tsmiDeleteReceipt.AccessibleName = null;
            resources.ApplyResources(this.tsmiDeleteReceipt, "tsmiDeleteReceipt");
            this.tsmiDeleteReceipt.BackgroundImage = null;
            this.tsmiDeleteReceipt.Name = "tsmiDeleteReceipt";
            this.tsmiDeleteReceipt.ShortcutKeyDisplayString = null;
            this.tsmiDeleteReceipt.Click += new System.EventHandler(this.tsmiDeleteReceipt_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleDescription = null;
            this.toolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // tsmiExportToolStripMenuItem
            // 
            this.tsmiExportToolStripMenuItem.AccessibleDescription = null;
            this.tsmiExportToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.tsmiExportToolStripMenuItem, "tsmiExportToolStripMenuItem");
            this.tsmiExportToolStripMenuItem.BackgroundImage = null;
            this.tsmiExportToolStripMenuItem.Name = "tsmiExportToolStripMenuItem";
            this.tsmiExportToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.tsmiExportToolStripMenuItem.Click += new System.EventHandler(this.tsmiExportToolStripMenuItem_Click);
            // 
            // tsmiImport
            // 
            this.tsmiImport.AccessibleDescription = null;
            this.tsmiImport.AccessibleName = null;
            resources.ApplyResources(this.tsmiImport, "tsmiImport");
            this.tsmiImport.BackgroundImage = null;
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.ShortcutKeyDisplayString = null;
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // vBudgetForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.lvReceipts);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.ssMainStatus);
            this.Controls.Add(this.msMainMenu);
            this.Font = null;
            this.Icon = null;
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
    }
}