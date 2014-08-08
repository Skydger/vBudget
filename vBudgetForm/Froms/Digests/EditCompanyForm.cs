using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm.Froms.Digests
{
    public partial class EditCompanyForm : Form
    {
        public EditCompanyForm(System.Data.SqlClient.SqlConnection inConnection, System.Data.DataRow inCompany, System.Data.DataRow inParent)
        {
            this.InitializeComponent();
            this.connection = inConnection;
            this.company = inCompany;
            this.parent = inParent;
        }

        private void EditCompanyForm_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = Brands.Companies.Select(Guid.Empty);
            cmd.Connection = this.connection;
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataTable companies = new System.Data.DataTable("Companies");
            sda.Fill(companies);
            DataRow dr = companies.NewRow();
            dr["CompanyName"] = "Компания не выбрана";
            dr["CompanyID"] = DBNull.Value;
            companies.Rows.InsertAt(dr, 0);
            this.cbxCompanies.DataSource = companies;
            this.cbxCompanies.DisplayMember = "CompanyName";
            this.cbxCompanies.ValueMember = "CompanyID";
            if (this.parent != null)
                this.cbxCompanies.SelectedValue = this.parent["CompanyID"];
            else if (!System.Convert.IsDBNull(this.company["ParentID"]))
                this.cbxCompanies.SelectedValue = this.company["ParentID"];
            else
                this.cbxCompanies.SelectedValue = DBNull.Value;

            // A new company or existing?
            if (this.company.RowState == DataRowState.Unchanged ||
                this.company.RowState == DataRowState.Added)
            {
                this.Text = string.Format("Редактирование компании ID: {0}", this.company["CompanyID"]);
                string col_name = "CompanyName";
                if (!System.Convert.IsDBNull(this.company[col_name]))
                    this.tbxCompanyName.Text = (string)this.company[col_name];
                col_name = "Address";
                if (!System.Convert.IsDBNull(this.company[col_name]))
                    this.tbxAddress.Text = (string)this.company[col_name];
                col_name = "WebSite";
                if (!System.Convert.IsDBNull(this.company[col_name]))
                    this.tbxWebAddress.Text = (string)this.company[col_name];
                col_name = "Phones";
                if (!System.Convert.IsDBNull(this.company[col_name]))
                    this.tbxPhones.Text = (string)this.company[col_name];
            }
            else
            {
                this.Text = "Создание новой компании";
            }
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (System.Convert.IsDBNull(this.cbxCompanies.SelectedValue))
                this.company["ParentID"] = DBNull.Value;
            else
                this.company["ParentID"] = this.cbxCompanies.SelectedValue;
            this.company["CompanyName"] = this.tbxCompanyName.Text;
            this.company["Address"] = this.tbxAddress.Text;
            this.company["WebSite"] = this.tbxWebAddress.Text;
            this.company["Phones"] = this.tbxPhones.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            return;
        }

        private void btnAddParentCompany_Click(object sender, EventArgs e)
        {
            //EditCompanyForm ecf = new EditCompanyForm(this.connection, new_comp, null);
        }
    }
}
