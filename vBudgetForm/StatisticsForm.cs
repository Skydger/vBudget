using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{

    public enum StatisticsType { Makers = 0, Vendors, Products };
    public partial class StatisticsForm : Form
    {
        public static string[] StatisticsTypeString = new string[] { "Производители", "Продавцы", "Продукты" };
        private System.Data.DataTable products;

       
        public StatisticsForm(System.Data.SqlClient.SqlConnection connection){
            InitializeComponent();
            this.connection = connection;
 //           "SELECT  rc.ProductID, p.ProductName, SUM(Amount)
 // FROM Purchases.ReceiptContents AS rc
 // JOIN Producer.Products AS p
 //   ON p.ProductID = rc.ProductID
 //GROUP BY rc.ProductID, p.ProductName
 //ORDER BY 3 DESC"
        }

        private void cbxEntities_SelectedIndexChanged(object sender, EventArgs e){

        }

        private void StatisticsForm_Load(object sender, EventArgs e){
            //this.tsmiStatisticsType..Items.Insert(0, StatisticsTypeString[0]);
            //this.tsmiStatisticsType.Items.Insert(1, StatisticsTypeString[1]);
            //this.tsmiStatisticsType.Items.Insert(2, StatisticsTypeString[2]);
            //this.tsmiStatisticsType.SelectedIndex = 0;

            ZedGraph.GraphPane pane = this.zgcStatistics.GraphPane;

            // Set the titles and axis labels
            pane.Title.Text = "Статистика";
            pane.XAxis.Title.Text = "Даты";
            pane.YAxis.Title.Text = "Parameter A";
            pane.Y2Axis.Title.Text = "Parameter B";

        }

        private void StatisticsForm_Resize(object sender, EventArgs e)
        {
            this.scStatisticsContainer.Size = new Size(this.Width - 20, this.Height - 70);
        }

        private void lbxObjects_SelectedIndexChanged(object sender, EventArgs e){
            if (this.lbxObjects.SelectedItems.Count > 0){
                

            }
        }

        private void ByMonths(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlCommand mnth = Statistics.Purchases.ByMonths();
                mnth.Connection = this.connection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(mnth);
                System.Data.DataTable st = new System.Data.DataTable("Summary");
                sda.Fill(st);

                ZedGraph.GraphPane pane = this.zgcStatistics.GraphPane;
                pane.YAxis.Title.Text = "Сумма, р";
                ZedGraph.PointPairList list = new ZedGraph.PointPairList();
                foreach (System.Data.DataRow row in st.Rows)
                {
                    int year = 1970;
                    int month = 1;
                    if(!System.Convert.IsDBNull(row["Year"]) &&
                       !System.Convert.IsDBNull(row["Month"]) ){
                        year = (int)row["Year"];
                        month = (int)row["Month"];
                        System.DateTime dt = new DateTime(year, month, 1);
                        ZedGraph.XDate xDate = new ZedGraph.XDate(dt);
                        decimal val = (decimal)row["Summary"];
                        list.Add(xDate.XLDate, (double)val);
                    }
                }
                ZedGraph.BarItem curve = pane.AddBar("", list, Color.Blue);

                // Для оси X установим календарный тип
                pane.XAxis.Type = ZedGraph.AxisType.Date;

                // pretty it up a little
                pane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
                pane.Fill = new ZedGraph.Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);

                // Tell ZedGraph to calculate the axis ranges
                this.zgcStatistics.AxisChange();
                this.zgcStatistics.Invalidate();
            }catch (System.Exception ex){
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void ByVendorsPerMonth(object sender, EventArgs e)
        {
            try
            {
                if( this.lbxObjects.SelectedItems.Count > 0 ){
                    List<int> ids = new List<int>();
                    //foreach( ListViewItem obj in this.lbxObjects.SelectedItems ){
                    foreach( DataRowView obj in this.lbxObjects.SelectedItems ){
                        if (!System.Convert.IsDBNull(obj["VendorID"]))
                            ids.Add((int)obj["VendorID"]);
                    }
                    System.Data.SqlClient.SqlCommand mnth = Statistics.Purchases.ByVendorsPerMonth(ids);
                    mnth.Connection = this.connection;
                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(mnth);
                    System.Data.DataTable st = new System.Data.DataTable("Summary");
                    sda.Fill(st);

                    ZedGraph.GraphPane pane = this.zgcStatistics.GraphPane;
                    pane.CurveList.Clear();
                    pane.GraphObjList.Clear();

                    pane.YAxis.Title.Text = "Сумма, р";
                    System.Collections.Hashtable lsts = new System.Collections.Hashtable();
                    
                    foreach (System.Data.DataRow row in st.Rows)
                    {
                        ZedGraph.PointPairList list = null;
                        string v_name = (string)row["VendorName"];
                        if (lsts.ContainsKey(v_name))
                        {
                            list = (ZedGraph.PointPairList)lsts[v_name];
                        }
                        else
                        {
                            list = new ZedGraph.PointPairList();
                            lsts.Add(v_name, list);
                        }
                        int year = 1970;
                        int month = 1;
                        if (!System.Convert.IsDBNull(row["Year"]) &&
                           !System.Convert.IsDBNull(row["Month"]))
                        {
                            year = (int)row["Year"];
                            month = (int)row["Month"];
                            System.DateTime dt = new DateTime(year, month, 1);
                            ZedGraph.XDate xDate = new ZedGraph.XDate(dt);
                            decimal val = (decimal)row["Summary"];
                            list.Add(xDate.XLDate, (double)val);
                        }
                    }
                    
                    Random rand = new Random();
                    System.Collections.IEnumerator lenum = lsts.GetEnumerator();
                    while(lenum.MoveNext() )
                    {
                        int r = rand.Next(255);
                        int g = rand.Next(255);
                        int b = rand.Next(255);
                        Color clr = Color.FromArgb(r, g, b);
                        System.Collections.DictionaryEntry lde = (System.Collections.DictionaryEntry)lenum.Current;
                        ZedGraph.BarItem curve = pane.AddBar((string)lde.Key, (ZedGraph.PointPairList)lde.Value, clr);
                    }

                    // Для оси X установим календарный тип
                    pane.XAxis.Type = ZedGraph.AxisType.Date;

                    // pretty it up a little
                    pane.Chart.Fill = new ZedGraph.Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
                    pane.Fill = new ZedGraph.Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);

                    // Tell ZedGraph to calculate the axis ranges
                    this.zgcStatistics.AxisChange();
                    this.zgcStatistics.Invalidate();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void tsmiByVendors_Click(object sender, EventArgs e)
        {

            this.tsmiSummaryByDates.Checked = false;
            this.tsmiByVendors.Checked = true;
            this.cmsStatisticsMenu.Items.Clear();



            string query = "SELECT DISTINCT v.VendorID, v.VendorName\n" +
                           "  FROM Purchases.Vendors AS v\n" +
                           "  JOIN Purchases.Receipts AS r\n" +
                           "    ON r.Vendor = v.VendorID\n" +
                           " ORDER BY v.VendorName";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;

            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.products = new System.Data.DataTable("Vendors");
            sda.Fill(this.products);

            this.lbxObjects.DataSource = this.products;
            this.lbxObjects.DisplayMember = "VendorName";
            this.lbxObjects.ValueMember = "VendorID";

            this.cmsStatisticsMenu.Items.Clear();

            System.Windows.Forms.ToolStripItem sti = new System.Windows.Forms.ToolStripMenuItem();
            sti.Name = "tsmiByVendorsPerMonth";
            sti.Size = new System.Drawing.Size(152, 22);
            sti.Text = "По месяцам";
            //sti.Click += (l_sender, l_e) => { tsmiByMonths_Click( l_sender, e); }
            sti.Click += new EventHandler(ByVendorsPerMonth);

            //new System.EventHandler(this.tsmiSummaryByDates_Click);
            this.cmsStatisticsMenu.Items.Add(sti);

            sti = new System.Windows.Forms.ToolStripMenuItem();
            sti.Name = "tsmiByVendorsPerWeek";
            sti.Size = new System.Drawing.Size(152, 22);
            sti.Text = "По неделям";
            this.cmsStatisticsMenu.Items.Add(sti);

            //try
            //{
            //    System.Data.SqlClient.SqlCommand mnth = Statistics.Purchases.ByVendorInMonth(null);
            //    mnth.Connection = this.connection;
            //    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(mnth);
            //    System.Data.DataTable st = new System.Data.DataTable("Summary");
            //    sda.Fill(st);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            return;
        }

        private void tsmiSummaryByDates_Click(object sender, EventArgs e)
        {

            this.tsmiSummaryByDates.Checked = true;
            this.tsmiByVendors.Checked = false;

            string query = "SELECT DISTINCT pc.ProductID, p.ProductName\n" +
                           "  FROM Purchases.ReceiptContents AS pc\n" +
                           "  JOIN Producer.Products AS p\n" +
                           "    ON p.ProductID = pc.ProductID\n" +
                           " ORDER BY p.ProductName\n";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;

            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.products = new System.Data.DataTable("Products");
            sda.Fill(this.products);

            this.lbxObjects.DataSource = this.products;
            this.lbxObjects.DisplayMember = "ProductName";
            this.lbxObjects.ValueMember = "ProductID";

            this.cmsStatisticsMenu.Items.Clear();

            System.Windows.Forms.ToolStripItem sti = new System.Windows.Forms.ToolStripMenuItem();
            sti.Name = "tsmiByMonths";
            sti.Size = new System.Drawing.Size(152, 22);
            sti.Text = "По месяцам";
            //sti.Click += (l_sender, l_e) => { tsmiByMonths_Click( l_sender, e); }
            sti.Click += new EventHandler(ByMonths);
                
                //new System.EventHandler(this.tsmiSummaryByDates_Click);
            this.cmsStatisticsMenu.Items.Add(sti);

            sti = new System.Windows.Forms.ToolStripMenuItem();
            sti.Name = "tsmiByWeeks";
            sti.Size = new System.Drawing.Size(152, 22);
            sti.Text = "По неделям";
            this.cmsStatisticsMenu.Items.Add(sti);

            //this.tsmiSummaryByDates.DropDownItems.Clear();
            //this.tssbtnStatisticsType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.tsmiSummaryByDates,
            //this.tsmiByVendors});

        }
    }
}