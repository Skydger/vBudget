using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class CaregoriesListForm : Form
    {
        public CaregoriesListForm( System.Data.SqlClient.SqlConnection inConnection ){
            this.InitializeComponent();
            this.connection = inConnection;
        }

        private void CaregoriesListForm_Load(object sender, EventArgs e)
        {
            this.lvCategories.Columns.Add("№", 30);
            this.lvCategories.Columns.Add("Идентификатор", 30);
            this.lvCategories.Columns.Add("Наименование категории", 190);

            System.Data.SqlClient.SqlCommand cmd = Producer.Categories.Select(Guid.Empty);
            cmd.Connection = this.connection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.categories = new System.Data.DataTable("Categories");
            sda.Fill(this.categories);

            this.lvProductTypes.Columns.Add("№", 30);
            this.lvProductTypes.Columns.Add("Идентификатор", 30);
            this.lvProductTypes.Columns.Add("Наименование", 190);
            this.lvProductTypes.Columns.Add("Комментарий", 190);
            this.product_types = new System.Data.DataTable("ProductTypes");

            this.RefreshCategoriesList();
        }

        void AddNewCategoryRow(int position, System.Data.DataRow row){
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position).ToString();
            lvi.Text = (position).ToString();
            Guid mid = Guid.Empty;
            if (!System.Convert.IsDBNull(row["CategoryID"])) mid = (Guid)row["CategoryID"];
            string mtype = "";
            if (!System.Convert.IsDBNull(row["CategoryName"])) mtype = ((string)row["CategoryName"]);

            lvi.SubItems.Add(mid.ToString());
            lvi.SubItems.Add(mtype);
            lvi.Tag = row;
            this.lvCategories.Items.Add(lvi);
            return;
        }
        void RefreshCategoriesList(){
            int i = 0;
            this.lvCategories.Items.Clear();
            foreach (System.Data.DataRow drw in this.categories.Rows)
            {
                this.AddNewCategoryRow(++i, drw);
            }
            return;
        }

        private void EditSelectedCategory()
        {
            if (this.lvCategories.SelectedItems.Count > 0)
            {
                System.Data.DataRow drw = (System.Data.DataRow)this.lvCategories.SelectedItems[0].Tag;
                EditCategoryForm ef = new EditCategoryForm(this.connection, ref drw);
                if (ef.ShowDialog() == DialogResult.OK)
                {

                }
            }
            return;
        }

        private void lvCategories_ItemActivate(object sender, EventArgs e)
        {
            this.EditSelectedCategory();
            return;
        }

        #region ProdustTypes
        void AddNewProductTypeRow(int position, System.Data.DataRow row)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Name = (position).ToString();
            lvi.Text = (position).ToString();
            int tid = -1;
            string col_name = "TypeId";
            if (!System.Convert.IsDBNull(row[col_name])) tid = (int)row[col_name];
            col_name = "Name";
            string ptype = "";
            if (!System.Convert.IsDBNull(row[col_name])) ptype = ((string)row[col_name]);
            col_name = "Comment";
            string comment = "";
            if (!System.Convert.IsDBNull(row[col_name])) comment = ((string)row[col_name]);

            lvi.SubItems.Add(tid.ToString());
            lvi.SubItems.Add(ptype);
            lvi.SubItems.Add(comment);
            lvi.Tag = row;
            this.lvProductTypes.Items.Add(lvi);
            return;
        }
        void RefreshProductTypesList()
        {
            int i = 0;
            this.lvProductTypes.Items.Clear();
            foreach (System.Data.DataRow drw in this.product_types.Rows)
            {
                this.AddNewProductTypeRow(++i, drw);
            }
            return;
        }


        private void lvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCategories.SelectedItems.Count > 0)
            {
                int idx = this.lvCategories.SelectedItems[0].Index;
                System.Data.DataRow drw = this.categories.Rows[idx];
                System.Data.SqlClient.SqlCommand cmd = Producer.ProductTypes.Select((Guid)drw["CategoryID"]);
                cmd.Connection = this.connection;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                this.product_types = new System.Data.DataTable("ProductTypes");
                sda.Fill(this.product_types);
                this.RefreshProductTypesList();
            }
        }

        private void EditSelectedProductType()
        {
            if (this.lvProductTypes.SelectedItems.Count > 0)
            {
                System.Data.DataRow drw = (System.Data.DataRow)this.lvProductTypes.SelectedItems[0].Tag;
                ProductTypeForm ptf = new ProductTypeForm(this.connection, ref drw);
                if (ptf.ShowDialog() == DialogResult.OK)
                {

                }
            }
            return;
        }
        private void lvProductTypes_ItemActivate(object sender, EventArgs e)
        {
            this.EditSelectedProductType();
            return;
        }
        #endregion

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            if (this.lvCategories.Focused)
            {
                System.Data.DataRow drw = this.categories.NewRow();
                EditCategoryForm ef = new EditCategoryForm(this.connection, ref drw);
                if (ef.ShowDialog() == DialogResult.OK)
                {
                    this.AddNewCategoryRow(this.lvCategories.Items.Count + 1, drw);
                    this.categories.Rows.Add(drw);
                }
            }
            else if (this.lvProductTypes.Focused)
            {
                System.Data.DataRow drw = this.product_types.NewRow();
                System.Data.DataRow cdrw = (System.Data.DataRow)this.lvCategories.SelectedItems[0].Tag;
                drw["Category"] = cdrw["CategoryID"];
                ProductTypeForm ptf = new ProductTypeForm(this.connection, ref drw);
                if (ptf.ShowDialog() == DialogResult.OK)
                {
                    this.AddNewProductTypeRow(this.lvProductTypes.Items.Count + 1, drw);
                    this.product_types.Rows.Add(drw);
                }
            }
        }
        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (this.lvCategories.Focused)
                this.EditSelectedCategory();
            else if (this.lvProductTypes.Focused)
                this.EditSelectedProductType();
            return;
        }
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            bool noerror = true;
            int prods = 0, recps = 0;
            string error = "", action = "", a_name = "";
            System.Data.DataRow drw = null;
            int index = -1;
            if (this.lvCategories.Focused)
            {
                drw = (System.Data.DataRow)this.lvCategories.SelectedItems[0].Tag;
                index = this.lvCategories.SelectedItems[0].Index;
                a_name = "категории";
                noerror = Producer.Categories.Exists(this.connection, drw, out prods, out recps, out error);
            }
            else if (this.lvProductTypes.Focused)
            {
                drw = (System.Data.DataRow)this.lvProductTypes.SelectedItems[0].Tag;
                index = this.lvProductTypes.SelectedItems[0].Index;
                a_name = "типа";
                noerror = Producer.ProductTypes.Exists(this.connection, drw, out prods, out recps, out error);
            }else{
                noerror = false;
                error = "Необходимо выбрать объект для удаления!";
            }

            action = string.Format("Ошибка при удалении {0}", a_name);
            if (!noerror)
            {
                MessageBox.Show(error, action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((prods > 0) && (recps > 0))
            {
                MessageBox.Show(string.Format("Невозможно удаление {0}, так как существуют продукты ({1} шт.) и чеки ({2} шт.)", a_name, prods, recps),
                                 action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((prods > 0) && (recps == 0))
            {
                // TODO Implement cascade deletion
                MessageBox.Show(string.Format("Not implemented yet", prods, recps),
                                 action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (this.lvCategories.Focused)
                {
                    noerror = Producer.Categories.Delete(this.connection, drw, out error);
                    if (noerror)
                    {
                        this.categories.Rows.Remove(drw);
                        this.lvCategories.Items.RemoveAt(index);
                    }
                    
                }
                else if (this.lvProductTypes.Focused)
                {
                    noerror = Producer.ProductTypes.Delete(this.connection, drw, out error);
                    if (noerror)
                    {
                        this.product_types.Rows.Remove(drw);
                        this.lvProductTypes.Items.RemoveAt(index);
                    }
                }
            }

            return;
        }
    }
}