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
    public partial class UCCrudProductListAndPrice : UserControl
    {
        internal DataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        public UCCrudProductListAndPrice()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridViewForCrudProducts();
            this.AutoProductIdGenarate();
        }

        internal void AutoProductIdGenarate()
        {
            string sql = "select COUNT(*) from ProductList;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo = Convert.ToInt32(dt.Rows[0][0]);

            if (rowNo > 0)
            {
                Sql = "select productId from ProductList order by productId desc;";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string previousId = Dt.Rows[0][0].ToString();
                string[] temp = previousId.Split('-');
                int serialNo = Convert.ToInt32(temp[1]);
                string nextId = temp[0] + "-" + (++serialNo).ToString("0000");
                this.txtNewProductId.Text = nextId;
            }

            else
            {
                this.txtNewProductId.Text = "P-0001";
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valid())
                {
                    Sql = "insert into ProductList values('" + this.txtNewProductId.Text + "', '" + this.txtNewProductName.Text + "', " +
                    this.txtNewProductUnitPrice.Text + ", " + this.txtNewProductStock.Text + ");";

                    int row = this.Da.ExecuteUpdateQuery(Sql);
                    if (row == 1)
                    {
                        MessageBox.Show("Data inserted successfully in Database");
                    }
                    else
                        MessageBox.Show("Data insertion failed");

                    this.PopulateGridViewForCrudProducts();

                    this.ClearAll();

                    this.AutoProductIdGenarate();
                }

                else
                {
                    MessageBox.Show("Please fill all the information");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error!"+exc.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valid())
                {
                    this.Sql = "select * from ProductList where productId='" + this.txtNewProductId.Text + "'";
                    DataTable dt = this.Da.ExecuteQueryTable(Sql);

                    if (dt.Rows.Count == 1)
                    {
                        this.Sql = @"update ProductList 
                                 set productName = '" + txtNewProductName.Text + @"',
                                     unitPrice = '" + txtNewProductUnitPrice.Text + @"',
                                     quantity = '" + txtNewProductStock.Text + @"'
                                 where productId = '" + txtNewProductId.Text + "';";

                        int row = this.Da.ExecuteUpdateQuery(Sql);
                        if (row == 1)
                        {
                            MessageBox.Show(" Data updated successfully in Database");
                        }
                        else
                            MessageBox.Show("Data update operation failed");

                        this.ClearAll();
                        this.PopulateGridViewForCrudProducts();
                    }

                    else if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Please select a row from the table");
                    }

                }

                else
                {
                    MessageBox.Show("Please fill all the information");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvCrudProduct.CurrentRow.Cells["productId"].Value.ToString();
                string name = this.dgvCrudProduct.CurrentRow.Cells["productName"].Value.ToString();
                Sql = "delete from ProductList where productId = '" + id + "';";

                if (this.dgvCrudProduct.SelectedRows.Count>0)
                {
                    DialogResult result= MessageBox.Show("Are you sure you want to delete " +name+ " ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                   

                    if (result == DialogResult.Yes)
                    {
                        int row = this.Da.ExecuteUpdateQuery(Sql);
                        if (row == 1)
                        {
                            MessageBox.Show(name + " has been deleted successfully from Database");
                        }
                        else
                            MessageBox.Show("Data delete operation failed");

                        this.PopulateGridViewForCrudProducts();

                        this.AutoProductIdGenarate();
                    }

                }

                else
                {
                    MessageBox.Show("Please select a row first to delete");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }
        }

        internal void PopulateGridViewForCrudProducts(String sql = "select * from ProductList order by productId asc;")
        {
            this.Ds = Da.ExecuteQuery(sql);
            this.dgvCrudProduct.AutoGenerateColumns = false;
            this.dgvCrudProduct.DataSource = Ds.Tables[0];
        }

        private void txtSearchProductId_TextChanged(object sender, EventArgs e)
        {
            Sql = "select * from ProductList where productId like '%"+this.txtSearchProductId.Text+"%';";
            this.PopulateGridViewForCrudProducts(Sql);
        }

        private void txtSearchProductName_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from ProductList where productName like '%" +this. txtSearchProductName.Text + "%';";
            this.PopulateGridViewForCrudProducts(this.Sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.AutoProductIdGenarate();
            this.txtNewProductName.Text = "";
            this.txtNewProductUnitPrice.Text = "";
            this.txtNewProductStock.Text = "";
        }

        private void dgvCrudProduct_DoubleClick(object sender, EventArgs e)
        {
            this.txtNewProductId.Text = this.dgvCrudProduct.CurrentRow.Cells["productId"].Value.ToString();
            this.txtNewProductName.Text = this.dgvCrudProduct.CurrentRow.Cells["productName"].Value.ToString();
            this.txtNewProductUnitPrice.Text = this.dgvCrudProduct.CurrentRow.Cells["unitPrice"].Value.ToString();
            this.txtNewProductStock.Text = this.dgvCrudProduct.CurrentRow.Cells["quantity"].Value.ToString();
        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(this.txtNewProductId.Text) || string.IsNullOrEmpty(this.txtNewProductName.Text) ||
                string.IsNullOrEmpty(this.txtNewProductUnitPrice.Text) ||
                string.IsNullOrEmpty(this.txtNewProductStock.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void UCCrudProductListAndPrice_Load(object sender, EventArgs e)
        {
            this.dgvCrudProduct.ClearSelection();
        }
    }
}
