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
    public partial class UCProductList : UserControl
    {
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private string Sql { get; set; }
        public UCProductList()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridViewForProducts();
        }

        private void UcSalesInfo_Load(object sender, EventArgs e)
        {

        }

        private void PopulateGridViewForProducts(String sql = "select * from ProductList order by productId asc;")
        {
            this.Ds = Da.ExecuteQuery(sql);
            this.dgvProductList.AutoGenerateColumns = false;
            this.dgvProductList.DataSource = Ds.Tables[0];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridViewForProducts();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from ProductList where productName like '%" + this.txtSearchProductName.Text + "%';";
            this.PopulateGridViewForProducts(this.Sql);
        }

        private void txtSearchId_TextChanged(object sender, EventArgs e)
        {
            Sql = "select * from ProductList where productId like '%" + this.txtSearchProductId.Text + "%';";
            this.PopulateGridViewForProducts(Sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSearchProductId.Text = "";
            this.txtSearchProductName.Text = "";
        }
    }
}
