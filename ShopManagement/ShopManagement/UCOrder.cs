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
    public partial class UCOrder : UserControl
    {
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private string Sql { get; set; }

       
        public UCOrder()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            AutoIdGenarate();
            ComboName();
            this.PopulateGridViewForOrderHistory();
        }

        internal void AutoIdGenarate()
        {
            string sql = "select COUNT(*) from SalesInfo;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo = Convert.ToInt32(dt.Rows[0][0]);

            if (rowNo > 0)
            {
                Sql = "select customerId from SalesInfo order by customerId desc;";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string previousId = Dt.Rows[0][0].ToString();
                string[] temp = previousId.Split('-');
                int serialNo = Convert.ToInt32(temp[1]);
                string nextId = temp[0] + "-" + (++serialNo).ToString("00000");
                this.txtCustomerId.Text = nextId;
            }

            else
            {
                this.txtCustomerId.Text = "CUS-00001";
            }

           
        }

        internal void ComboName()
        {
            string sql = "select COUNT(*) from ProductList;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo =Convert.ToInt32( dt.Rows[0][0]);
      
            int count = 0;
            while (count<rowNo)
            {
                Sql = "select productName from ProductList;";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string name = Dt.Rows[count][0].ToString();
                this.cmbProductName.Items.Add(name);

                count++;
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = cmbProductName.SelectedIndex;
            Sql = "select unitPrice from ProductList;";
            DataTable DT = this.Da.ExecuteQueryTable(this.Sql);
            string price = DT.Rows[count][0].ToString();
            txtUnitPrice.Text = price;

            Sql = "select quantity from ProductList;";
            DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
            string quantity = Dt.Rows[count][0].ToString();
            txtStock.Text = quantity;

            Sql = "select productId from ProductList;";
            DataTable dt = this.Da.ExecuteQueryTable(this.Sql);
            string id = dt.Rows[count][0].ToString();
            txtProductId.Text = id;
        }

        private void cmbProductName_TextChanged(object sender, EventArgs e)
        {
            if (cmbProductName.Text == "")
            {
                txtStock.Text = "";
                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
                txtProductId.Text = "";
                txtAmount.Text = "";
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text != "" && txtUnitPrice.Text != "")
                {
                    double price = double.Parse(txtUnitPrice.Text);
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    this.txtAmount.Text = (price * quantity).ToString();

                }

                else if (txtUnitPrice.Text == "")
                {
                    txtQuantity.Text = "";
                }
                else if (txtQuantity.Text == "")
                {
                    txtAmount.Text = "";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valid() && (Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(txtStock.Text)) && 
                    (Convert.ToInt32(txtQuantity.Text)>0))
                {
                    Sql = "insert into OrderHistory values('" + this.txtProductId.Text + "', '" + this.cmbProductName.Text + "', " +
                    this.txtUnitPrice.Text + ", " + this.txtQuantity.Text + "," + this.txtAmount.Text + ");";

                    int row = this.Da.ExecuteUpdateQuery(Sql);

                    this.PopulateGridViewForOrderHistory();

                    this.ClearProductInfo();

                    this.TotalAmount();
                }

                else
                {
                    if (Valid() == false)
                    {
                        MessageBox.Show("Please fill all the information");
                    }

                    else if((Convert.ToInt32(txtQuantity.Text) > Convert.ToInt32(txtStock.Text)))
                    {
                        MessageBox.Show("You do not have enough stock of this product");
                        txtQuantity.Text="";
                    }

                    else if ((Convert.ToInt32(txtQuantity.Text) <=0))
                    {
                        MessageBox.Show("Product Cannot be 0 or negative");
                        txtQuantity.Text = "";
                    }

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }

        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(this.txtProductId.Text) || string.IsNullOrEmpty(this.cmbProductName.Text) ||
                string.IsNullOrEmpty(this.txtUnitPrice.Text) || string.IsNullOrEmpty(this.txtQuantity.Text) ||
                string.IsNullOrEmpty(this.txtStock.Text)|| string.IsNullOrEmpty(this.txtStock.Text) ||
                string.IsNullOrEmpty(this.txtCustomerName.Text) || string.IsNullOrEmpty(this.txtAddress.Text) ||
                string.IsNullOrEmpty(this.txtPhone.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void ClearProductInfo()
        {
            this.cmbProductName.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtStock.Text = "";
            this.txtAmount.Text = "";
            this.txtProductId.Text = "";
            this.txtQuantity.Text = "";
        }

        private void ClearCustomerInfoAndAmount()
        {
            this.AutoIdGenarate();
            this.txtCustomerName.Text = "";
            this.txtPhone.Text = "";
            this.txtAddress.Text = "";
            this.txtAmount.Text = "";
            this.txtTotalAmount.Text = "";
            this.txtPaidAmount.Text = "";
            this.txtBalance.Text = "";
        }



        private void PopulateGridViewForOrderHistory(String sql = "select * from OrderHistory;")
        {
            this.Ds = Da.ExecuteQuery(sql);
            this.dgvOrderHistory.AutoGenerateColumns = false;
            this.dgvOrderHistory.DataSource = Ds.Tables[0];
        }

        private void TotalAmount()
        {
            string sql = "select COUNT(*) from OrderHistory;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo = Convert.ToInt32(dt.Rows[0][0]);
            double amount = 0;

            int count = 0;
            while (count < rowNo)
            {
                Sql = "select subTotal from OrderHistory;";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string am = Dt.Rows[count][0].ToString();
                double am2 = double.Parse(am);
                amount += am2;

                count++;
            }
            this.txtTotalAmount.Text = amount.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvOrderHistory.CurrentRow.Cells["productId"].Value.ToString();
                string name = this.dgvOrderHistory.CurrentRow.Cells["productName"].Value.ToString();
                Sql = "delete from OrderHistory where productId = '" + id + "';";

                int row = this.Da.ExecuteUpdateQuery(Sql);
                

                this.PopulateGridViewForOrderHistory();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }
        }

        internal void DeleteOrderHistory()
        {
            try
            {
                string id = this.dgvOrderHistory.CurrentRow.Cells["productId"].Value.ToString();
                string name = this.dgvOrderHistory.CurrentRow.Cells["productName"].Value.ToString();
                Sql = "delete from OrderHistory;";

                int row = this.Da.ExecuteUpdateQuery(Sql);


                this.PopulateGridViewForOrderHistory();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error!" + exc.Message);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (txtPaidAmount.Text != "")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cofirm your Payment ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Sql = "insert into SalesInfo values('" + this.txtCustomerId.Text + "', '" + this.txtCustomerName .Text + "', '" +
                    this.txtAddress.Text + "', '" + this.txtPhone.Text + "', " + this.txtTotalAmount.Text + ", " +
                    this.txtPaidAmount.Text + ", " + this.txtBalance.Text + ", '" + this.dtpDate.Text + "');";

                   

                    int row = this.Da.ExecuteUpdateQuery(Sql);
                    if (row == 1)
                    {
                        MessageBox.Show("Payment Successful");
                        this.UpdateStock();
                    }
                    else
                        MessageBox.Show("Payment Failed!");

                    this.ClearCustomerInfoAndAmount();
                    DeleteOrderHistory();

                }
            }

            else
            {
                MessageBox.Show("Please Enter your paid amount");
            }
        }

        private void UpdateStock()
        {
            string sql = "select COUNT(*) from OrderHistory;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo = Convert.ToInt32(dt.Rows[0][0]);

            int count = 0;
            while (count < rowNo)
            {
                    this.Sql = "select productId from OrderHistory;";
                    DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                    string id = Dt.Rows[count][0].ToString();

                    this.Sql = "select quantity from OrderHistory where productId='" + id + "';";
                    DataTable Dt1 = this.Da.ExecuteQueryTable(this.Sql);
                    int quantity = Convert.ToInt32(Dt1.Rows[0][0]);

                    this.Sql = "select quantity from ProductList where productId='" + id + "';";
                    DataTable Dt2 = this.Da.ExecuteQueryTable(this.Sql);
                    int stock = Convert.ToInt32(Dt2.Rows[0][0]);

                    int updateStock = (stock - quantity);

                    this.Sql = @"update ProductList 
                                 set quantity = " + updateStock + @"
                                 where productId = '" + id + "';";
                    int row = this.Da.ExecuteUpdateQuery(Sql);

                count++;
            }
                
           
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalAmount.Text == "")
            {
                txtPaidAmount.Text = "";
            }
            if (txtPaidAmount.Text != "")
            {
                double amount = double.Parse(txtTotalAmount.Text);
                double payment = double.Parse(txtPaidAmount.Text);

                txtBalance.Text = (amount - payment).ToString();
            }

            else
            {
                txtBalance.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearCustomerInfoAndAmount();
            this.ClearProductInfo();
        }

    }
}
