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
    public partial class FormCashier : Form
    {
        internal DataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        private FormLogin Fl { get; set; }
        
        UCSalesInfo salesInfo = new UCSalesInfo();
        UCProductList productList = new UCProductList();
        UCOrder order = new UCOrder();
        UCCrudProductListAndPrice crudProduct = new UCCrudProductListAndPrice();
        UCAddUsers addUsers = new UCAddUsers();
        public FormCashier()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        public FormCashier(FormLogin fl)
        {
            InitializeComponent();
            this.Fl = fl;
        }

        private void FormCashier_Load(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Add(order);
        }

        private void FormCashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(order);
            order.AutoIdGenarate();
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(productList);
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Fl.Visible = true;
            this.Visible = false;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(salesInfo);
            this.salesInfo.PopulateGridViewForSales();
            this.salesInfo.btnDelete.Hide();
        }
    }
}
