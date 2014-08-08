using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vBudgetForm.Froms.Digests
{
    public partial class CompaniesListForm : Form
    {
        public CompaniesListForm(System.Data.SqlClient.SqlConnection inConnection)
        {
            InitializeComponent();
            this.connection = inConnection;
        }

        private void CompaniesListForm_Load(object sender, EventArgs e)
        {
            this.dataset = new DataSet();

            System.Data.SqlClient.SqlCommand cmd = Brands.Companies.SelectTree(Guid.Empty);
            cmd.Connection = this.connection;

            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataTable table = new System.Data.DataTable("Companies");
            sda.Fill(table);
            this.dataset.Tables.Add(table);
            this.BuildTree();
        }

        public void PopulateTree(DataRow dr, TreeNode node)
        {
            foreach (DataRow row in dr.GetChildRows("rsParentChild"))
            {
                TreeNode child = new TreeNode(row["CompanyName"].ToString());
                child.Tag = row;
                node.Nodes.Add(child);
                //Recursively build the tree
                PopulateTree(row, child);
            }
            return;
        }

        private void BuildTree()
        {
            this.tvCompanies.Nodes.Clear();
            string display = "CompanyName", value = "CompanyID", parent_field = "ParentID";

            this.dataset.Relations.Add("rsParentChild", this.dataset.Tables[0].Columns[value],
                                       this.dataset.Tables[0].Columns[parent_field]);

            System.Data.DataTable table = this.dataset.Tables[0];
            foreach (DataRow dr in table.Rows)
            {
                if (parent_field == null ||
                    parent_field.Length == 0 ||
                    dr[parent_field] == DBNull.Value)
                {
                    TreeNode root = new TreeNode(dr[display].ToString());
                    root.Tag = dr;
                    this.tvCompanies.Nodes.Add(root);
                    this.PopulateTree(dr, root);
                }
            }
            this.tvCompanies.ExpandAll();
            return;
        }

        private void AddChild(DataRow row)
        {
            TreeNode child = new TreeNode((string)row["CompanyName"]);
            child.Tag = row;
            //this.tvCompanies.SelectedNode.Nodes.Add(child);

            if( System.Convert.IsDBNull(row["ParentID"] ) ){
                this.tvCompanies.Nodes.Add(child);
            }else{
                foreach (TreeNode node in this.tvCompanies.Nodes)
                {
                    DataRow pr = (DataRow)node.Tag;
                    if ((Guid)pr["CompanyID"] == (Guid)row["ParentID"])
                    {
                        node.Nodes.Add(child);
                        break;
                    }
                }                
            }
        }

        private void tsmiAddCompany_Click(object sender, EventArgs e)
        {
            if (this.tvCompanies.SelectedNode != null)
            {
                DataRow pcmp = (DataRow)this.tvCompanies.SelectedNode.Tag;
                DataRow cmp = this.dataset.Tables[0].NewRow();
                EditCompanyForm ecf = new EditCompanyForm(this.connection, cmp, pcmp);
                if (ecf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string error = "";
                    if (!Brands.Companies.Insert(this.connection, ref cmp, out error))
                    {
                        MessageBox.Show("Ошибка при обновлении компании!\n" + error,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.dataset.Tables[0].Rows.Add(cmp);
                        this.AddChild(cmp);
                    }
                }
            }
        }

        private void tvCompanies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.tvCompanies.SelectedNode != null)
            {
                DataRow cmp = (DataRow)this.tvCompanies.SelectedNode.Tag;
                DataRow pcmp = null;
                if (this.tvCompanies.SelectedNode.Level > 0)
                {
                    pcmp = (DataRow)this.tvCompanies.SelectedNode.Parent.Tag;
                }
                EditCompanyForm ecf = new EditCompanyForm(this.connection, cmp, pcmp);
                if (ecf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.tvCompanies.SelectedNode.Text = (string)cmp["CmpanyName"];
                    this.tvCompanies.SelectedNode.Tag = cmp;
                    string error = "";
                    if (!Brands.Companies.Update(this.connection, cmp, out error))
                    {
                        MessageBox.Show("Ошибка при обновлении компании!\n" + error,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return;
        }

    }
}
