using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class vBudgetForm : Form
    {
        public vBudgetForm()
        {
            InitializeComponent();
            this.lvReceipts.Columns.Add("№", 50);
            this.lvReceipts.Columns.Add("ID", 70);
            this.lvReceipts.Columns.Add("Номер", 100);
            this.lvReceipts.Columns.Add("Оплачено", 100);
            this.lvReceipts.Columns.Add("Продавец", 200);
            this.lvReceipts.Columns.Add("Цена", 100);

            this.receipts = new DataTable("Receipts");
            this.lvColumnSorter = new Effects.ListViewColumnSorter();
            this.settings = new Settings.DataBaseSettingsForm();
        }

        protected void EnableControls(bool enable){
            this.tsmiNewReceipt.Enabled = enable;
        }

        private bool TryConnect(){
            bool done = false;
            string server = Properties.Settings.Default.DataServers[0];
//            string server = "YORKJOUGH";
            System.Data.SqlClient.SqlConnectionStringBuilder sqlConnBuilder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder();

            sqlConnBuilder.DataSource = server;
            sqlConnBuilder.InitialCatalog = Properties.Settings.Default.DefaultDataBase;
            if (Properties.Settings.Default.UseIntegratedSecurity){
                sqlConnBuilder.IntegratedSecurity = true;
            }else{
                sqlConnBuilder.UserID = Properties.Settings.Default.UserLogin;
                sqlConnBuilder.Password = Properties.Settings.Default.UserPassword;
            }
            sqlConnBuilder.ConnectTimeout = 30;
            this.cConnection = new System.Data.SqlClient.SqlConnection(sqlConnBuilder.ConnectionString);
            try{
                this.cConnection.Open();
                if (this.cConnection.State == ConnectionState.Open){
                    this.tsslConnectionState.Text = "Подключено к " + server;
                    this.Text = "vBudget (сервер: " + server + ")";
                    this.cConnection.Close();
                    done = true;
                }else{
                    done = false;
                    this.tsslConnectionState.Text = "Нет соединения";
                }
            }catch (System.Exception ex){
                this.tsslConnectionState.Text = "Нет соединения: " + ex.Message;
                done = false;
            }
            this.EnableControls(done);
            return done;
        }

        protected void AddNewRow(int row_num, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (row_num + 1).ToString();
            lvi.Text = (row_num + 1).ToString();
            DateTime r_dtm = new DateTime(1900, 1, 1 );
            if (!System.Convert.IsDBNull(row["Payed"])) r_dtm = ((DateTime)row["Payed"]);
            string num = "";
            if (!System.Convert.IsDBNull(row["Number"])) num = (string)row["Number"];
            string vendor = "";
            if (!System.Convert.IsDBNull(row["VendorName"])) vendor = (string)row["VendorName"];
            decimal price = 0;
            if (!System.Convert.IsDBNull(row["Price"])) price = (decimal)row["Price"];
            lvi.SubItems.Add( ((int)row["ReceiptID"]).ToString());
            lvi.SubItems.Add(num);
//            lvi.SubItems.Add(r_dtm.ToShortDateString() + " " + r_dtm.ToShortTimeString());
            string dformat = "dd.MM.yyyy HH:mm";
            lvi.SubItems.Add(r_dtm.ToString(dformat));
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(price.ToString("0.00"));
            this.lvReceipts.Items.Add(lvi);
        }

        protected void AddNewRow(ListViewGroup group, int row_num, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (row_num + 1).ToString();
            lvi.Text = (row_num + 1).ToString();
            DateTime r_dtm = new DateTime(1900, 1, 1);
            if (!System.Convert.IsDBNull(row["Payed"])) r_dtm = ((DateTime)row["Payed"]);
            string num = "";
            if (!System.Convert.IsDBNull(row["Number"])) num = (string)row["Number"];
            string vendor = "";
            if (!System.Convert.IsDBNull(row["VendorName"])) vendor = (string)row["VendorName"];
            decimal price = 0;
            if (!System.Convert.IsDBNull(row["Price"])) price = (decimal)row["Price"];
            lvi.SubItems.Add(((int)row["ReceiptID"]).ToString());
            lvi.SubItems.Add(num);
//            lvi.SubItems.Add(r_dtm.ToShortDateString() + " " + r_dtm.ToShortTimeString());
            string dformat = "dd.MM.yyyy HH:mm";
            lvi.SubItems.Add(r_dtm.ToString(dformat));
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(price.ToString("0.00"));
            lvi.Group = group;
            this.lvReceipts.Items.Add(lvi);
        }

        protected void AddSummaryRow(ListViewGroup group, decimal summ){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = group.Name;
            lvi.Text = "";
            lvi.SubItems.Add("Итого:");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add(summ.ToString());
            lvi.Group = group;
            this.lvReceipts.Items.Add(lvi);
        }

        protected void LoadReceipts( Purchases.Criteria criteries ){
            try{

                this.lvReceipts.ListViewItemSorter = this.lvColumnSorter;

                this.lvReceipts.Items.Clear();
                this.receipts.Rows.Clear();
                System.Data.SqlClient.SqlCommand cmd = Purchases.Commands.Receipts( criteries );
                cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                sda.Fill( this.receipts );
                string colname = "ReceiptID";
                if( !this.receipts.Columns.Contains( colname ) )
                    this.receipts.Columns.Add(colname);
                this.receipts.Columns[colname].AutoIncrement = true;
                this.receipts.Columns[colname].AutoIncrementSeed = -1;
                this.receipts.Columns[colname].AutoIncrementStep = -1;

                decimal total = 0;
                int i = 0;
                foreach (System.Data.DataRow drw in this.receipts.Rows){
                    this.AddNewRow(i++, drw);
                    total += (decimal)drw["Price"];
                }
                this.tsslQueryResult.Text = "Всего записей: " + i.ToString() + " на сумму " + total.ToString();
//                this.receipts.Columns[colname].AutoIncrement = true;
//                this.receipts.Columns[colname].AutoIncrementSeed = (int)this.receipts.Rows[i - 1][colname] + 1;
            }catch (System.Data.SqlClient.SqlException ex){
                this.tsslQueryResult.Text = ex.Message;
            }catch (System.Exception ex){
                this.tsslQueryResult.Text = ex.Message;
            }
            return;
        }

        private void vBudgetForm_Load(object sender, EventArgs e){
//            this.cmsReceiptsMenu.Items.Add(this.tsmiActions);
//            this.cmsReceiptsMenu.Items.Add(this.tsmiNewReceipt);
//            this.tsmiActions.DropDownItems.Add(this.tsmiNewReceipt);
            
            if (this.TryConnect()){
                Purchases.Criteria crt = new Purchases.Criteria();
                DateTime [] dates = new DateTime[1] { System.DateTime.Now.AddDays(-7.0) };
                crt.Dates = new DateTime[1];
                crt.Dates = dates;
                crt.DateFilter = Purchases.DateFilterType.MoreOrEqual;
                this.LoadReceipts(crt);
            }
        }

        private void tsmiNewReceipt_Click(object sender, EventArgs e){
            System.Data.DataRow new_row = this.receipts.NewRow();
            new_row["Created"] = System.DateTime.Now;
            new_row["Updated"] = System.DateTime.Now;
            ReceiptForm rptf = new ReceiptForm(this.cConnection, ref new_row, true );
            if (rptf.ShowDialog() == DialogResult.OK){
                this.receipts.Rows.Add(new_row);
                this.AddNewRow(this.receipts.Rows.Count - 1, new_row);
            }
        }

        private void lvReceipts_ItemActivate(object sender, EventArgs e){
            int row_num = -1;
            if (this.lvReceipts.SelectedIndices.Count == 1)
                row_num = this.lvReceipts.SelectedIndices[0];
            if (row_num >= 0){
                int idx = -1;
                string snum = this.lvReceipts.Items[row_num].Text;
                if( System.Int32.TryParse(snum, out idx) && (idx > 0) ){
                    System.Data.DataRow old_row = this.receipts.Rows[idx - 1];
                    ReceiptForm rptf = new ReceiptForm(this.cConnection, ref old_row, false);
                    if (rptf.ShowDialog() == DialogResult.OK){
                        this.lvReceipts.Items.Clear();
                        int i = 0;
                        foreach (System.Data.DataRow drw in this.receipts.Rows){
                            this.AddNewRow(i++, drw);
                        }
                        this.lvReceipts.SelectedIndices.Add(row_num);
    //                    this.receipts.Rows.Add(new_row);
    //                    this.AddNewRow(this.receipts.Rows.Count, new_row);
                    }
                }else{
                    MessageBox.Show("Ошибка получения чека!");
                }
            }
        }

        private void tsmiProducts_Click(object sender, EventArgs e){

//            AddProductForm apf = new AddProductForm( this.cConnection );
//            if (apf.ShowDialog() == DialogResult.OK){
//
//            }
            ProductsListForm plfrm = new ProductsListForm(this.cConnection);
            if (plfrm.ShowDialog() == DialogResult.OK){
            }
            return;
        }

        private void tsmiSettings_Click(object sender, EventArgs e){
//            Settings.DataBaseSettingsForm dbsf = new Settings.DataBaseSettingsForm();
//            if (dbsf.ShowDialog() == DialogResult.OK){
//            }
            this.settings.DataServers = Properties.Settings.Default.DataServers;
            this.settings.IsIntegratedSecurity = Properties.Settings.Default.UseIntegratedSecurity;
            this.settings.UserLogin = Properties.Settings.Default.UserLogin;
            this.settings.UserPassword = Properties.Settings.Default.UserPassword;
            this.settings.DefaultDataBase = Properties.Settings.Default.DefaultDataBase;
            if (this.settings.ShowDialog() == DialogResult.OK){
                Properties.Settings.Default.DataServers = this.settings.DataServers;
                Properties.Settings.Default.UseIntegratedSecurity = this.settings.IsIntegratedSecurity;
                Properties.Settings.Default.UserLogin = this.settings.UserLogin;
                Properties.Settings.Default.UserPassword = this.settings.UserPassword;
                Properties.Settings.Default.DefaultDataBase = this.settings.DefaultDataBase;
            }
            return;
        }

        private void tsmiExit_Click(object sender, EventArgs e){
            if( MessageBox.Show("Действительно выйти из программы?", "Подтверждение действия", MessageBoxButtons.YesNo ) == DialogResult.Yes ){
                this.Close();
            }
        }

        private void tsmiVendors_Click(object sender, EventArgs e){
            VendorsListForm vlf = new VendorsListForm(this.cConnection);
            if (vlf.ShowDialog() == DialogResult.OK){

            }
        }

        private void tsmiDiscountCards_Click(object sender, EventArgs e){
            DiscountCardsListForm dclf = new DiscountCardsListForm(this.cConnection);
            if (dclf.ShowDialog() == DialogResult.OK){

            }
            return;
        }

        private void lvReceipts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lvColumnSorter.SortColumn){
                if (this.lvColumnSorter.Order == SortOrder.Ascending){
                    this.lvColumnSorter.Order = SortOrder.Descending;
                }else{
                    this.lvColumnSorter.Order = SortOrder.Ascending;
                }
            }else{
                this.lvColumnSorter.SortColumn = e.Column;
                this.lvColumnSorter.Order = SortOrder.Ascending;
            }
            this.lvReceipts.Sort();
            return;

        }

        private void tsmiByWeeks_Click(object sender, EventArgs e){
            this.lvReceipts.Items.Clear();
            this.lvReceipts.Groups.Clear();
            ListViewGroup lgv = null;
            int i = 0;
            int l_doy = 0;
            decimal total = 0, sub_total = 0;
            foreach (System.Data.DataRow drw in this.receipts.Rows){
                System.DateTime dtm = (System.DateTime)drw["Payed"];
                if ( (dtm.DayOfWeek == DayOfWeek.Sunday ) ||
                     (dtm.DayOfYear - l_doy > 7)){
                    if (lgv != null)
                        this.AddSummaryRow(lgv, sub_total);
                    lgv = new ListViewGroup();
                    this.lvReceipts.Groups.Add(lgv);
                    string date = Effects.Dates.GetMonthName(dtm.Month) + ", " + dtm.Year.ToString() +
                                  " неделя " + (dtm.DayOfYear/7).ToString();
                    lgv.Name = date;
                    lgv.Header = date;
                    sub_total = 0;
                    l_doy = dtm.DayOfYear;
                }
                this.AddNewRow(lgv, i++, drw);
                total += (decimal)drw["Price"];
                sub_total += (decimal)drw["Price"];
            }
            if (lgv != null)
                this.AddSummaryRow(lgv, sub_total);
            this.tsslQueryResult.Text = "Всего записей: " + i.ToString() + " на сумму " + total.ToString();
            return;
        }

        private void tsmiByMonths_Click(object sender, EventArgs e){
            this.lvReceipts.Items.Clear();
            this.lvReceipts.Groups.Clear();
            int l_month = 0;
            int l_year = 0;
            ListViewGroup lgv = null;
            int i = 0;
            decimal total = 0, sub_total = 0;
            foreach (System.Data.DataRow drw in this.receipts.Rows){
                System.DateTime dtm = (System.DateTime)drw["Payed"];
                if ((dtm.Year != l_year) || (dtm.Month != l_month)){
                    if( lgv != null )
                        this.AddSummaryRow(lgv, sub_total);
                    lgv = new ListViewGroup();
                    this.lvReceipts.Groups.Add(lgv);
                    string date = Effects.Dates.GetMonthName( dtm.Month ) + ", " + dtm.Year.ToString();
                    lgv.Name = date;
                    lgv.Header = date;
                    l_month = dtm.Month;
                    l_year = dtm.Year;
                    sub_total = 0;
                }
                this.AddNewRow(lgv, i++, drw);
                total += (decimal)drw["Price"];
                sub_total += (decimal)drw["Price"];
            }
            if (lgv != null)
                this.AddSummaryRow(lgv, sub_total);
            this.tsslQueryResult.Text = "Всего записей: " + i.ToString() + " на сумму " + total.ToString();
            return;
        }

        private void tsmiByID_Click(object sender, EventArgs e){
            this.lvReceipts.Groups.Clear();
        }

        private void tsmiByVendorFilter_Click(object sender, EventArgs e){

            System.Data.SqlClient.SqlCommand command = Purchases.Vendor.Select(-1);
            command.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
            System.Data.DataTable tbl = new System.Data.DataTable("Vendors");
            sda.Fill(tbl);
            VisualControls.ElementsList elist = new VisualControls.ElementsList( new VisualControls.ListOptions(), "Продавцы", "VendorName", "VendorID", tbl);
            if (elist.ShowDialog() == DialogResult.OK){
                int i = 0;
                Purchases.Criteria crt = new Purchases.Criteria();
                crt.Vendors = new int[elist.Selected.Length];
                foreach (int vendor in elist.Selected){
                    crt.Vendors[i++] = vendor;
                }
                this.LoadReceipts(crt);
            }
            return;
        }

        private void tsmiClearFilter_Click(object sender, EventArgs e){
            this.LoadReceipts(null);
            return;
        }

        private void ByDateFilter( Purchases.Criteria criteria ){
            this.LoadReceipts(criteria);
        }


        private void ByPresetDateFilter( DateTime start ){
            Purchases.Criteria crt = new Purchases.Criteria();
            crt.DateFilter = Purchases.DateFilterType.Between;
            DateTime [] dates = new DateTime[2];
            dates[0] = start;
            dates[1] = System.DateTime.Now;
            crt.Dates = dates;
            this.ByDateFilter( crt );
        }

        private void tsmiByLastWeek_Click(object sender, EventArgs e){
            System.DateTime srt = System.DateTime.Now;
            srt = srt.AddDays(-7.0);
            this.ByPresetDateFilter(srt);
            this.tsmiByLastWeek.Checked = true;
            this.tsmiByLastMonth.Checked = false;
            this.tsmiByLastThreeMonths.Checked = false;
            this.tsmiByLastQuarter.Checked = false;
            this.tsmiOnPeriod.Checked = false;
            return;
        }

        private void tsmiByLastMonth_Click(object sender, EventArgs e){
            System.DateTime strt = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
            this.ByPresetDateFilter(strt);
            this.tsmiByLastMonth.Checked = true;
            this.tsmiByLastWeek.Checked = false;
            this.tsmiByLastThreeMonths.Checked = false;
            this.tsmiByLastQuarter.Checked = false;
            this.tsmiOnPeriod.Checked = false;
            return;
        }

        private void tsmiByLastThreeMonths_Click(object sender, EventArgs e){
            int cur_month = System.DateTime.Now.Month;
            int cur_year = System.DateTime.Now.Year;
            cur_month -= 3;
            if( cur_month < 1 ){
                cur_month += 12;
                cur_year -= 1;
            }
            System.DateTime strt = new DateTime(cur_year, cur_month, 1);
            this.ByPresetDateFilter(strt);
            this.tsmiByLastThreeMonths.Checked = true;
            this.tsmiByLastWeek.Checked = false;
            this.tsmiByLastMonth.Checked = false;
            this.tsmiByLastQuarter.Checked = false;
            this.tsmiOnPeriod.Checked = false;
            return;
        }

        private void tsmiByLastQuarter_Click(object sender, EventArgs e){
            this.tsmiByLastQuarter.Checked = true;
            this.tsmiByLastWeek.Checked = false;
            this.tsmiByLastMonth.Checked = false;
            this.tsmiByLastThreeMonths.Checked = false;
            this.tsmiOnPeriod.Checked = false;
            return;
        }

        private void tsmiOnPeriod_Click(object sender, EventArgs e){
            this.tsmiByLastQuarter.Checked = false;
            this.tsmiByLastWeek.Checked = false;
            this.tsmiByLastMonth.Checked = false;
            this.tsmiByLastThreeMonths.Checked = false;
            this.tsmiOnPeriod.Checked = true;
            return;
        }

        private void tsmiTopPurchases_Click(object sender, EventArgs e){
            Purchases.Criteria crt = new Purchases.Criteria();
            crt.Top = 23;
            this.LoadReceipts(crt);
        }

        private bool SaveSelected( string filename, out string error ){
            error = "";
            bool done = false;
            try{
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                string conditions = "";
                string[] o_ids = new string[this.lvReceipts.SelectedItems.Count];
                for (int i = 0; i < this.lvReceipts.SelectedItems.Count; i++){
                    ListViewItem lvi = this.lvReceipts.SelectedItems[i];
                    int id = -1;
                    string soid = lvi.SubItems[1].Text;
                    if (System.Int32.TryParse(soid, out id)){
                        o_ids[i] = string.Format("@ReceiptId{0}", id);
                        command.Parameters.AddWithValue(o_ids[i], id);
                    }
                }
                conditions += string.Format("r.ReceiptID IN( {0} )", string.Join(", ", o_ids));
                command.CommandText = "SELECT * FROM Purchases.Receipts AS r\nWHERE " +
                                      conditions +
                                      "SELECT * FROM Purchases.ReceiptContents AS r\nWHERE " +
                                      conditions +
                                      "SELECT * FROM Producer.Products AS p WHERE p.ProductID IN(\n" +
                                      "SELECT DISTINCT ProductID FROM Purchases.ReceiptContents AS r\n" +
                                      "WHERE " +conditions + ")" +
                                      // ProductTypes
                                      "SELECT pt.* FROM Producer.ProductTypes AS pt\n" + 
                                      "  JOIN Producer.Products AS p ON\n" +
                                      "       p.Category = pt.Category AND\n" +
                                      "       p.Type = pt.TypeID\n" +
                                      "WHERE p.ProductID IN(\n" +
                                      "SELECT DISTINCT ProductID FROM Purchases.ReceiptContents AS r\n" +
                                      "WHERE " + conditions + ")" +
                                      "SELECT c.* FROM Producer.Categories AS c\n" +
                                      "  JOIN Producer.Products AS p ON\n" +
                                      "       p.Category = c.CategoryID\n" +
                                      "WHERE p.ProductID IN(\n" +
                                      "SELECT DISTINCT ProductID FROM Purchases.ReceiptContents AS r\n" +
                                      "WHERE " + conditions + ")\n" +
                                      "SELECT * FROM Purchases.Vendors\n" +
                                      "WHERE VendorID IN (SELECT Vendor FROM Purchases.Receipts AS r\nWHERE " +
                                      conditions + ")" +
                                      "SELECT * FROM Purchases.DiscountCards\n" +
                                      "WHERE CardID IN (SELECT DiscountCard FROM Purchases.Receipts AS r\nWHERE " +
                                      conditions + ")" +
                                      // Makers
                                      "SELECT m.* FROM Producer.Makers AS m\n" + 
                                      "  JOIN Producer.Products AS p ON\n" +
                                      "       p.Maker = m.MakerId\n" +
                                      "WHERE p.ProductID IN(\n" +
                                      "SELECT DISTINCT ProductID FROM Purchases.ReceiptContents AS r\n" +
                                      "WHERE " + conditions + ")"
                                      ;
                command.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                string table = "Receipts";
                System.Data.DataSet rec_ds = new System.Data.DataSet(table);
                sda.Fill(rec_ds);
                rec_ds.Tables[0].TableName = "Receipts";
                rec_ds.Tables[1].TableName = "ReceiptContents";
                rec_ds.Tables[2].TableName = "Products";
                rec_ds.Tables[3].TableName = "ProductTypes";
                rec_ds.Tables[4].TableName = "Categories";
                rec_ds.Tables[5].TableName = "Vendors";
                rec_ds.Tables[6].TableName = "DiscountCards";
                rec_ds.Tables[7].TableName = "Makers";

                string xsd_file = "";
                string xml_file = "";
                if (filename.EndsWith(".xsd", true, System.Globalization.CultureInfo.CurrentCulture)){
                    xsd_file = filename;
                    xml_file = filename.Substring(0, filename.Length - 4 ) + ".xml";
                }else if (filename.EndsWith(".xml", true, System.Globalization.CultureInfo.CurrentCulture)){
                    xml_file = filename;
                    xsd_file = filename.Substring(0, filename.Length - 4) + ".xsd";
                }else{
                    xml_file = filename + ".xml";
                    xsd_file = filename + ".xsd";
                }
                rec_ds.WriteXmlSchema(xsd_file);
                rec_ds.WriteXml(xml_file);
                done = true;
            }catch( System.Exception ex ){
                error = ex.Message;
            }
            return done;
        }

        private void tsmiExportToolStripMenuItem_Click(object sender, EventArgs e){
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML файлы|*.xml|XSD схема|*.xsd";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK){
                string error_msg = "";
                if( !this.SaveSelected( sfd.FileName, out error_msg )){
                    MessageBox.Show( error_msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            return;
        }

        bool ImportSaved(string filename, out string error){
            bool done = false;
            error = "";
            try{
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.CommandText = "SELECT * FROM Purchases.Receipts\n" +
                                      "SELECT * FROM Purchases.ReceiptContents\n" +
                                      "SELECT * FROM Producer.Products\n" +
                                      "SELECT * FROM Producer.ProductTypes\n" +
                                      "SELECT * FROM Producer.Categories\n" +
                                      "SELECT * FROM Purchases.Vendors\n" +
                                      "SELECT * FROM Purchases.DiscountCards\n" +
                                      "SELECT * FROM Producer.Makers\n"
                                      ;
                command.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                string table = "Receipts";
                System.Data.DataSet dst_ds = new System.Data.DataSet(table);
                sda.Fill(dst_ds);
                dst_ds.Tables[0].TableName = "Receipts";
                dst_ds.Tables[1].TableName = "ReceiptContents";
                dst_ds.Tables[2].TableName = "Products";
                dst_ds.Tables[3].TableName = "ProductTypes";
                dst_ds.Tables[4].TableName = "Categories";
                dst_ds.Tables[5].TableName = "Vendors";
                dst_ds.Tables[6].TableName = "DiscountCards";
                dst_ds.Tables[7].TableName = "Makers";

                System.Data.DataSet rec_ds = new System.Data.DataSet(table);
                string xsd_file = "";
                string xml_file = "";
                if (filename.EndsWith(".xsd", true, System.Globalization.CultureInfo.CurrentCulture)){
                    xsd_file = filename;
                    xml_file = filename.Substring(0, filename.Length - 4 ) + ".xml";
                }else if (filename.EndsWith(".xml", true, System.Globalization.CultureInfo.CurrentCulture)){
                    xml_file = filename;
                    xsd_file = filename.Substring(0, filename.Length - 4) + ".xsd";
                }else{
                    xml_file = filename + ".xml";
                    xsd_file = filename + ".xsd";
                }
                rec_ds.ReadXmlSchema(xsd_file);
                rec_ds.ReadXml(xml_file);

                dst_ds.Merge(rec_ds, true);
//                dst_ds.
                System.Data.DataSet cng_ds = dst_ds.GetChanges(DataRowState.Modified);
                if (cng_ds != null){

                }
                done = true;
            }catch(Exception ex){
                error = ex.Message;
            }
            return done;
        }

        private void tsmiImport_Click(object sender, EventArgs e){
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML файлы|*.xml|XSD схема|*.xsd";
            if (ofd.ShowDialog() == DialogResult.OK){
                string error_msg = "";
                if( !this.ImportSaved(ofd.FileName, out error_msg ) ){
                    MessageBox.Show(error_msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return;
        }


    }
}