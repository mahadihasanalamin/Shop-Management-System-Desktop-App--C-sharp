using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class UCSalesInfo : UserControl
    {
        internal DataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        private string Sql { get; set; }
        public UCSalesInfo()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridViewForSales();
        }

        internal void PopulateGridViewForSales(String sql = "select * from SalesInfo order by customerId asc;")
        {
            this.Ds = Da.ExecuteQuery(sql);
            this.dgvSales.AutoGenerateColumns = false;
            this.dgvSales.DataSource = Ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvSales.CurrentRow.Cells["customerId"].Value.ToString();
                string name = this.dgvSales.CurrentRow.Cells["customerName"].Value.ToString();
                Sql = "delete from SalesInfo where customerId = '" + id + "';";

                if (this.dgvSales.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        int row = this.Da.ExecuteUpdateQuery(Sql);
                        if (row == 1)
                        {
                            MessageBox.Show(name + " has been deleted successfully from Database");
                        }
                        else
                            MessageBox.Show("Data delete operation failed");

                        this.PopulateGridViewForSales();
                    }

                }     

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }
        }

        private void UCSalesInfo_Load(object sender, EventArgs e)
        {
            this.dgvSales.ClearSelection();
        }

        private void txtSearchCustomerId_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from SalesInfo where customerId like '%" + this.txtSearchCustomerId.Text + "%';";
            this.PopulateGridViewForSales(this.Sql);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from SalesInfo where customerName like '%" + this.txtSearchCustomerName.Text + "%';";
            this.PopulateGridViewForSales(this.Sql);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from SalesInfo where phone like '%" + this.txtSearchCustomerPhone.Text + "%';";
            this.PopulateGridViewForSales(this.Sql);
        }

        private void txtSearchDate_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from SalesInfo where date like '%" + this.txtSearchDate.Text + "%';";
            this.PopulateGridViewForSales(this.Sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {
            this.txtSearchDate.Text = "";
            this.txtSearchCustomerName.Text = "";
            this.txtSearchCustomerId.Text = "";
            this.txtSearchCustomerPhone.Text = "";
            this.txtSearchCustomerAddress.Text = "";
        }
    }
}
