using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm
{
    public partial class VendorForm : Form
    {
        public VendorForm(System.Data.SqlClient.SqlConnection inConnection, ref System.Data.DataRow inVendor ){
            this.InitializeComponent();
            this.cConnection = inConnection;
            this.vendor = inVendor;
        }

        private void VendorForm_Load(object sender, EventArgs e){

            System.Data.SqlClient.SqlCommand cmd = Brands.Companies.Select(Guid.Empty);
            cmd.Connection = this.cConnection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            this.companies = new System.Data.DataTable("Companies");
            sda.Fill(this.companies);
            DataRow dr = this.companies.NewRow();
            dr["CompanyName"] = "Компания не выбрана";
            dr["CompanyID"] = Guid.Empty;
            this.companies.Rows.InsertAt(dr, 0);

            this.cbxCompanies.DataSource = this.companies;
            this.cbxCompanies.DisplayMember = "CompanyName";
            this.cbxCompanies.ValueMember = "CompanyID";

            if (System.Convert.IsDBNull(this.vendor["VendorID"]) || (((Guid)this.vendor["VendorID"]) == Guid.Empty)){
                this.Text = "Добавление нового продавца";

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vBudgetForm));
                System.Drawing.Image n_usr = ((System.Drawing.Image)(resources.GetObject("no_user_96x96.bmp")));
                this.pbxLogo.Image = n_usr;

                this.isNewVendor = true;
            }else{
                this.Text = "Редактирование продавца #" + this.vendor["VendorID"].ToString();
                this.tbxName.Text = (string)this.vendor["VendorName"];
                Guid cid = Guid.Empty;
                if (!System.Convert.IsDBNull(this.vendor["ParentCompany"])) cid = (Guid)this.vendor["ParentCompany"];
                this.cbxCompanies.SelectedValue = cid;

                if( !System.Convert.IsDBNull(this.vendor["Address"]) ) this.tbxAddress.Text = (string)this.vendor["Address"];
                if (!System.Convert.IsDBNull(this.vendor["Phones"])) this.tbxPhones.Text = (string)this.vendor["Phones"];
                if (!System.Convert.IsDBNull(this.vendor["Logo"])){
                    System.Byte[] lg = (System.Byte[])(this.vendor["Logo"]);
                    if ( (lg != null) && ( lg.Length > 0 ) ) {
                        System.IO.MemoryStream mstrm = new System.IO.MemoryStream(lg);
                        this.pbxLogo.Image = System.Drawing.Image.FromStream(mstrm);
                        mstrm.Close();
                    }else{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vBudgetForm));
                        System.Drawing.Image n_usr = ((System.Drawing.Image)(resources.GetObject("no_user_96x96")));
                        this.pbxLogo.Image = n_usr;
                    }
                }else{
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vBudgetForm));
                    System.Drawing.Image n_usr = ((System.Drawing.Image)(resources.GetObject("no_user_96x96")));
                    this.pbxLogo.Image = n_usr;
                }
                if (!System.Convert.IsDBNull(this.vendor["INoTP"])) this.tbxPTI.Text = (string)this.vendor["INoTP"];
                if (!System.Convert.IsDBNull(this.vendor["Web"])) this.tbxWeb.Text = (string)this.vendor["Web"];
                if (!System.Convert.IsDBNull(this.vendor["Deleted"])) this.cbDeleted.Checked = (bool)this.vendor["Deleted"];
                this.isNewVendor = false;
            }

        }
        private void tsmiLoadPicture_Click(object sender, EventArgs e){
//            this.ofdLodaPictureDialog = (new System.Windows.Forms.OpenFileDialog());
//            byte[] img = null;
            this.ofdLodaPictureDialog.Title = "Выберите картинку для загрузки";
            this.ofdLodaPictureDialog.Filter = "JPEG Images (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp| PNG (*.png)|*.png";
            if (this.ofdLodaPictureDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                string FPath = this.ofdLodaPictureDialog.FileName;
                System.IO.FileInfo flinf = new System.IO.FileInfo(FPath);
                if (flinf.Length > 0){
//                    img = new byte[flinf.Length];
                    this.image = new byte[flinf.Length];
//                    System.Array.Resize(ref this.CurrentOrganization.Logo, (int)(flinf.Length));
                    System.IO.FileStream fs = new System.IO.FileStream(FPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
//                    fs.Read(img, 0, img.Length);
                    fs.Read(this.image, 0, this.image.Length);
                    fs.Close();

                    System.IO.MemoryStream mstrm = new System.IO.MemoryStream(this.image);
                    this.pbxLogo.Image = System.Drawing.Image.FromStream(mstrm);
                    mstrm.Close();
//                    this.vendor.BeginEdit();
                    this.vendor["Logo"] = this.image;
//                    this.vendor.EndEdit();
                }

            }

        }

        private void btnAccept_Click(object sender, EventArgs e){
            Guid cid = Guid.Empty;
            if (System.Convert.IsDBNull(this.cbxCompanies.SelectedValue))
            {
                this.vendor["ParentCompany"] = DBNull.Value;
                this.vendor["CompanyName"] = "";
            }
            else
            {
                this.vendor["ParentCompany"] = this.cbxCompanies.SelectedValue;
                this.vendor["CompanyName"] = this.cbxCompanies.Text;
            }
            this.vendor["VendorName"] = this.tbxName.Text;
            this.vendor["Address"] = this.tbxAddress.Text;
            this.vendor["Phones"] = this.tbxPhones.Text;
            this.vendor["INoTP"] = this.tbxPTI.Text;
            this.vendor["Web"] = this.tbxWeb.Text;
            this.vendor["Updated"] = System.DateTime.Now;
            this.vendor["Deleted"] = this.cbDeleted.Checked;

            if (this.image == null) this.vendor["Logo"] = new byte [0];

            string error = "";
            bool noerrors = true;
            if (this.isNewVendor){
                this.vendor["Created"] = System.DateTime.Now;
                Guid nvid = Purchases.Vendor.NewId(this.cConnection, out error);
                if (nvid != Guid.Empty)
                {
                    this.vendor["VendorID"] = nvid;
                    noerrors = Purchases.Vendor.Insert(this.cConnection, this.vendor, out error);
                    if (noerrors)
                    {
                        noerrors = error.Length == 0;
                    }
                }
            }else{
//                noerrors = Purchases.Vendor.Update(this.cConnection, this.vendor, this.image, out error);
                noerrors = Purchases.Vendor.Update(this.cConnection, this.vendor, out error);
            }
            if (noerrors) this.DialogResult = DialogResult.OK;
            else MessageBox.Show(error);
            return;
        }


    }
}