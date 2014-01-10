using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class ProductsListForm : Form
    {
        public ProductsListForm(System.Data.SqlClient.SqlConnection inConnection)
        {
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.bBlockContent = false;
            return;
        }

        private void ProductsListForm_Resize(object sender, EventArgs e){
//            this.lvProducts.Size = new Size(this.Width - 32, this.Height - 58);
            this.scProductsContainer.Size = new Size(this.Width - 32, this.Height - 58);
            this.clbxTypes.Size = new Size(this.scProductsContainer.SplitterDistance - 6, this.scProductsContainer.Size.Height - 34);
            return;
        }

        private void scProductsContainer_SplitterMoved(object sender, SplitterEventArgs e){
            this.clbxTypes.Size = new Size(this.scProductsContainer.SplitterDistance - 6, this.scProductsContainer.Size.Height - 34);
            return;
        }

        private void ProductsListForm_Load(object sender, EventArgs e){
            this.bBlockContent = true;
            System.Data.SqlClient.SqlCommand cat_cmd = Producer.Categories.Select(-1);
            cat_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter catda = new System.Data.SqlClient.SqlDataAdapter(cat_cmd);
            this.categories = new System.Data.DataTable("Categories");
            catda.Fill(this.categories);
            this.categories.Rows.Add(new object[] { -1, "<Без категории>" });
            this.cbxCategories.DataSource = this.categories;
            this.cbxCategories.DisplayMember = "CategoryName";
            this.cbxCategories.ValueMember = "CategoryID";
            this.cbxCategories.SelectedValue = -1;


            System.Data.SqlClient.SqlCommand tp_cmd = Producer.ProductTypes.Select(-1);
            tp_cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter tpda = new System.Data.SqlClient.SqlDataAdapter(tp_cmd);
            this.types_table = new System.Data.DataTable("Types");
            tpda.Fill(this.types_table);
            this.clbxTypes.DataSource = this.types_table;
            this.clbxTypes.DisplayMember = "Name";
            this.clbxTypes.ValueMember = "TypeId";

            this.bBlockContent = false;
            this.lvProducts.Columns.Add("№", 70 );
            this.lvProducts.Columns.Add("Наименование", 250);
            this.lvProducts.Columns.Add("Тип", 70);
            this.lvProducts.Columns.Add("Производитель", 100);
            this.lvProducts.Columns.Add("Штрих-код", 50);
            this.lvProducts.Columns.Add("Создан", 50);
            this.lvProducts.Columns.Add("Комментарий", 100);
            this.RefreshProductList( -1, null );
            return;
        }

        protected void AddNewRow(int row_num, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();

            lvi.Name = (row_num + 1).ToString();
            lvi.Text = (row_num + 1).ToString();
            string p_name = "";
            if (!System.Convert.IsDBNull(row["ProductName"])) p_name = ((string)row["ProductName"]);
            lvi.SubItems.Add(p_name);

            string t_name = "";
            if (!System.Convert.IsDBNull(row["TypeName"])) t_name = ((string)row["TypeName"]);
            lvi.SubItems.Add(t_name);

            string p_maker = "";
            if (!System.Convert.IsDBNull(row["MakerName"])) p_maker = ((string)row["MakerName"]);
            lvi.SubItems.Add(p_maker);
            string p_barcode = "";
            if (!System.Convert.IsDBNull(row["Barcode"])) p_barcode = ((string)row["Barcode"]);
            lvi.SubItems.Add(p_barcode);

            string p_made = "";
            if (!System.Convert.IsDBNull(row["Created"])) p_made = ((DateTime)row["Created"]).ToShortDateString();
            lvi.SubItems.Add(p_made);

            string p_comment = "";
            if (!System.Convert.IsDBNull(row["Comment"])) p_comment = ((string)row["Comment"]);
            lvi.SubItems.Add(p_comment);

/*
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
            lvi.SubItems.Add(r_dtm.ToShortDateString() + " " + r_dtm.ToShortTimeString());
            lvi.SubItems.Add(vendor);
            lvi.SubItems.Add(price.ToString("0.00"));
 */
            this.lvProducts.Items.Add(lvi);
            return;
        }

        private void RefreshProductList(int cat_id, int [] type_id){
            this.lvProducts.Items.Clear();
//            if ( (cat_id > 0) || (type_id > 0)){
            List<Producer.Product.OrderColumn> ord = new List<Producer.Product.OrderColumn>();
            ord.Add(Producer.Product.OrderColumn.ProductName);
            System.Data.SqlClient.SqlCommand prd_cmd = Producer.Product.Select(cat_id, type_id, null, ord);
                prd_cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter pda = new System.Data.SqlClient.SqlDataAdapter(prd_cmd);
                this.products = new DataTable("Products");
                pda.Fill(this.products);
                string colname = "ProductID";
                if (!this.products.Columns.Contains(colname))
                    this.products.Columns.Add(colname);
                //this.products.Columns[colname].AutoIncrement = true;
                //this.products.Columns[colname].AutoIncrementSeed = -1;
                //this.products.Columns[colname].AutoIncrementStep = -1;

                int i = 0;
                foreach (System.Data.DataRow drw in this.products.Rows){
                    this.AddNewRow(i++, drw);
                }

//            }
        }


        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e){
            if (!this.bBlockContent && !System.Convert.IsDBNull( this.cbxCategories.SelectedValue )){
                int cat_id = (int)this.cbxCategories.SelectedValue;
                System.Data.SqlClient.SqlCommand tp_cmd = Producer.ProductTypes.Select(cat_id);
                tp_cmd.Connection = this.cConnection;
                System.Data.SqlClient.SqlDataAdapter tpda = new System.Data.SqlClient.SqlDataAdapter(tp_cmd);
                this.types_table = new System.Data.DataTable("Types");
                tpda.Fill(this.types_table);
                this.clbxTypes.DataSource = this.types_table;
                this.clbxTypes.DisplayMember = "Name";
                this.clbxTypes.ValueMember = "TypeId";
                this.RefreshProductList(cat_id, null );
            }
            return;
        }

        // Изменение типов
        private void clbxTypes_SelectedIndexChanged(object sender, EventArgs e){
            //if (this.clbxTypes.CheckedItems.Count > 0){
            //    int[] ids = new int[this.clbxTypes.CheckedItems.Count];
            //    for (int i = 0; i < this.clbxTypes.CheckedItems.Count; i++){
            //        int index = (int)this.clbxTypes.CheckedIndices[i];
            //        ids[i] = (int)this.clbxTypes.SelectedValue;
            //    }
            //}
        }

        private void btnAddCategory_Click(object sender, EventArgs e){
            System.Data.DataRow new_category = this.categories.NewRow();
            EditCategoryForm ecf = new EditCategoryForm(this.cConnection, ref new_category);
            if (ecf.ShowDialog() == DialogResult.OK){
                this.categories.Rows.Add(new_category);
            }
            return;
        }
        private void tsmiEditType_Click(object sender, EventArgs e){

        }

        private void tsmiDeleteCategory_Click(object sender, EventArgs e){
            try{
                if (this.clbxTypes.SelectedItems.Count > 0){

                    int idx = this.clbxTypes.Items.IndexOf( this.clbxTypes.SelectedItems[0] );
                    System.Data.DataRow row = this.types_table.Rows[idx];
                    this.cConnection.Open();
                    string sQuery = "SELECT ISNULL(COUNT(*), 0) FROM Producer.Products WHERE Category = @Category AND Type = @Type";
                    System.Data.SqlClient.SqlCommand check_cmd = new System.Data.SqlClient.SqlCommand();
                    check_cmd.Parameters.AddWithValue("@Category", row["Category"]);
                    check_cmd.Parameters.AddWithValue("@Type", row["TypeId"]);
                    check_cmd.Connection = this.cConnection;
                    check_cmd.CommandTimeout = 0;
                    check_cmd.CommandType = System.Data.CommandType.Text;
                    check_cmd.CommandText = sQuery;

                    int cnt = (int)check_cmd.ExecuteScalar();


                    if (( cnt > 0 ) &&
                         (MessageBox.Show("Найдены товары (" + cnt.ToString() + "), содержащие выбранный продукт, переназначить (это действие нельзы отменить)?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        ){
                        System.Data.SqlClient.SqlCommand command = Producer.ProductTypes.Select((int)row["Category"] );
                        command.Connection = this.cConnection;
                        System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                        System.Data.DataTable tbl = new System.Data.DataTable("ProductTypes");
                        sda.Fill(tbl);

                        VisualControls.ListOptions options = new VisualControls.ListOptions(false);
                        VisualControls.ElementsList elist = new VisualControls.ElementsList(options, "Подкатегории", "Name", "TypeId", tbl);
                        if (elist.ShowDialog() == DialogResult.OK)
                        {
                            if (elist.Selected.Length == 1){
                                int new_id = (int)elist.Selected[0];
                                string query = "UPDATE Producer.Products SET Type = @NewType WHERE Category = @Category AND Type = @OldType";
                                command = new System.Data.SqlClient.SqlCommand();
                                command.Connection = this.cConnection;
                                command.Parameters.AddWithValue("@OldType", row["TypeId"]);
                                command.Parameters.AddWithValue("@NewType", new_id);
                                command.Parameters.AddWithValue("@Category", row["Category"]);
                                command.CommandTimeout = 0;
                                command.CommandType = System.Data.CommandType.Text;
                                command.CommandText = query;

                            }
                        }

                    }

                }
            }catch (System.Exception ex){
                MessageBox.Show("Ошибка при удалении категории товаров:\n" + ex.Message);
            }
            return;
        }

        private void clbxTypes_ItemCheck(object sender, ItemCheckEventArgs e){
            int [] type_ids = new int[0];
            for (int i = 0; i < this.clbxTypes.Items.Count; i++){
                int tpsz = type_ids.Length;
                if ( ( (e.Index == i ) && (e.NewValue == CheckState.Checked ) ) ||
                    this.clbxTypes.GetItemChecked(i) ){
                    System.Array.Resize<int>( ref type_ids, tpsz + 1);
                    type_ids[tpsz] = (int)this.types_table.Rows[i]["TypeId"];
                }
            }
            int cat_id = (int)this.cbxCategories.SelectedValue;
            this.RefreshProductList(cat_id, type_ids);
            return;
        }

        private void tsmiAddNewProduct_Click(object sender, EventArgs e){
            System.Data.DataRow new_product = this.products.NewRow();
            if (!System.Convert.IsDBNull(this.cbxCategories.SelectedValue)) new_product["Category"] = this.cbxCategories.SelectedValue;
            if (!System.Convert.IsDBNull(this.clbxTypes.SelectedValue) && (this.clbxTypes.SelectedValue != null) ) new_product["Type"] = this.clbxTypes.SelectedValue;
            AddProductForm apf = new AddProductForm( this.cConnection, ref new_product );
            if( apf.ShowDialog() == DialogResult.OK ){
                this.AddNewRow(this.lvProducts.Items.Count, new_product);
                this.products.Rows.Add(new_product);
            }
            return;
        }

        private void tsmiAddNewType_Click(object sender, EventArgs e){
            System.Data.DataRow new_type = this.types_table.NewRow();
            if (!System.Convert.IsDBNull(this.cbxCategories.SelectedValue)) new_type["Category"] = this.cbxCategories.SelectedValue;
            ProductTypeForm ptf = new ProductTypeForm(this.cConnection, ref new_type);
            if (ptf.ShowDialog() == DialogResult.OK){
                this.types_table.Rows.Add(new_type);
            }
            return;
        }

        private void tsmiChangeProduct_Click(object sender, EventArgs e){
            if (this.lvProducts.SelectedItems.Count > 0){
                int idx = this.lvProducts.SelectedItems[0].Index;
                System.Data.DataRow row = this.products.Rows[idx];
                AddProductForm ptf = new AddProductForm(this.cConnection, ref row);
                if (ptf.ShowDialog() == DialogResult.OK){
//                    this.types_table.Rows.Add(new_type);
                    this.RefreshProductList((int)row["Category"], new int[] { (int)row["Type"] });
                }
            }
            return;
        }

        private void tsmiDeleteProduct_Click(object sender, EventArgs e){
            if (this.lvProducts.SelectedItems.Count > 0){
                int idx = this.lvProducts.SelectedItems[0].Index;
                System.Data.DataRow row = this.products.Rows[idx];
                bool no_errors = true;
                int cnt = 0;
                try{
                    this.cConnection.Open();
                    string sQuery = "SELECT ISNULL(COUNT(*), 0) FROM Purchases.ReceiptContents WHERE ProductID = @Product";
                    System.Data.SqlClient.SqlCommand check_cmd = new System.Data.SqlClient.SqlCommand();
                    check_cmd.Parameters.AddWithValue( "@Product", row["ProductID"] );
                    check_cmd.Connection = this.cConnection;
                    check_cmd.CommandTimeout = 0;
                    check_cmd.CommandType = System.Data.CommandType.Text;
                    check_cmd.CommandText = sQuery;

                    cnt = (int)check_cmd.ExecuteScalar();
                }catch(System.Exception ex ){
                    no_errors = false;
                    MessageBox.Show(ex.Message);
                }finally{
                    this.cConnection.Close();
                }
                if (no_errors &&
                    (cnt > 0) &&
                     (MessageBox.Show("Найдены заказы (" + cnt.ToString() + "), содержащие выбранный продукт, переназначить (это действие нельзы отменить)?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    ){
                    List<Producer.Product.OrderColumn> ord = new List<Producer.Product.OrderColumn>();
                    ord.Add(Producer.Product.OrderColumn.ProductName);
                    System.Data.SqlClient.SqlCommand command = Producer.Product.Select((int)row["Category"], null, null, ord);
                    command.Connection = this.cConnection;
                    System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(command);
                    System.Data.DataTable tbl = new System.Data.DataTable("Products");
                    sda.Fill(tbl);

                    VisualControls.ListOptions options = new VisualControls.ListOptions(false);
                    VisualControls.ElementsList elist = new VisualControls.ElementsList(options, "Товары", "ProductName", "ProductID", tbl);
                    if (elist.ShowDialog() == DialogResult.OK){
                        if (elist.Selected.Length == 1){
                            int new_id = (int)elist.Selected[0];
                            string query = "UPDATE Purchases.ReceiptContents SET ProductID = @NewId WHERE ProductID = @OldId";
                            command = new System.Data.SqlClient.SqlCommand();
                            command.Connection = this.cConnection;
                            command.Parameters.AddWithValue("@OldId", row["ProductID"]);
                            command.Parameters.AddWithValue("@NewId", new_id);
                            command.CommandTimeout = 0;
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandText = query;

                        }
                    }

                }
            }

        }

        private void cmsProductTypesMenu_Opening(object sender, CancelEventArgs e)
        {

        }





    }
}