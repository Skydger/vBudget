using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualControls{

    public partial class ElementsList : Form{
        private bool is_simple_array;
        private object [] chosen;
        private string sValueColumn;
        private ListOptions options;
        private string sDisplayColumn;
        private System.Data.DataTable source;

        public object [] Selected{
            get { return this.chosen; }
        }

        public ElementsList( ListOptions in_options, string object_types, string display, string value, System.Data.DataTable table){
            InitializeComponent();
            this.options = in_options;
            this.chosen = new object[0];
            this.Text += " " + object_types;
            this.clbElements.DataSource = table;
            this.clbElements.DisplayMember = display;
            this.clbElements.ValueMember = value;
            this.is_simple_array = false;

            this.sDisplayColumn = display;
            this.sValueColumn = value;
            this.source = table;
        }
        public ElementsList( ListOptions in_options, string object_types, object[] elements){
            InitializeComponent();
            this.chosen = new object[0];
            this.Text += " " + object_types;
            foreach (object element in elements){
                this.clbElements.Items.Add(element);
            }
            this.is_simple_array = true;
        }

        private void ObjectListForm_Resize(object sender, EventArgs e){
            this.clbElements.Size = new Size( this.Width - 40, this.Height - 100 );
            this.tbxSearch.Size = new Size( this.Width - 88, this.tbxSearch.Height );
            this.btnAdd.Location = new Point(12, this.Height - 63);
            this.btnCancel.Location = new System.Drawing.Point(this.Width - 95, this.Height - 63);
        }

        private void btnAdd_Click(object sender, EventArgs e){
            System.Array.Resize<object>(ref chosen, this.clbElements.CheckedItems.Count);
            for( int i = 0; i < this.clbElements.CheckedItems.Count; i++ ){
                if (this.is_simple_array){
                    chosen[i] = this.clbElements.CheckedItems[i];
                }else{
                    System.Data.DataRowView drv = (System.Data.DataRowView)this.clbElements.CheckedItems[i];
                    chosen[i] = drv.Row[this.clbElements.ValueMember];
                }
            }
//            System.Array.ConvertAll<object, int>(this.clbElements.SelectedItems, chosen);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void clbElements_ItemCheck(object sender, ItemCheckEventArgs e){
            if( !this.options.IsMultiSelect ){
                if (e.NewValue == CheckState.Checked){
                    if (this.clbElements.CheckedItems.Count == 1){
                        e.NewValue = CheckState.Unchecked;
                    }
                }
            }
        }

        private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.tbxSearch.Text.Length > 0)
            {
                DataTable dtb = null;
                if (e.KeyCode == Keys.Back)
                {
                    dtb = this.source;
                }
                else
                {
                    dtb = (DataTable)this.clbElements.DataSource;
                }
                string filter = string.Format("{0} like '%{1}%'", this.sDisplayColumn, this.tbxSearch.Text);
                DataRow[] dr = dtb.Select(filter);
                DataTable dtb2 = dtb.Clone();
                foreach (DataRow d in dr)
                {
                    dtb2.ImportRow(d);
                }
                this.clbElements.DataSource = dtb2;
            }
            else
            {
                this.clbElements.DataSource = this.source;
            }
            this.clbElements.DisplayMember = this.sDisplayColumn;
            this.clbElements.ValueMember = this.sValueColumn;
            return;
        }
    }
}