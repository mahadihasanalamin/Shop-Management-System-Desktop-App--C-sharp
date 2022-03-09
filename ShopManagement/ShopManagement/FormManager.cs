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
    public partial class FormManager : Form
    {
        internal DataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        private FormLogin Fl { get; set; }
     
        UCSalesInfo  salesInfo = new UCSalesInfo();
        UCProductList productList = new UCProductList();
        UCOrder order = new UCOrder();
        UCCrudProductListAndPrice crudProduct = new UCCrudProductListAndPrice();
        UCAddUsers addUsers = new UCAddUsers();

        public FormManager()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        public FormManager(FormLogin fl)
        {
            InitializeComponent();
            this.Fl = fl;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(salesInfo);
            this.salesInfo.PopulateGridViewForSales();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Add(order);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(order);
            order.AutoIdGenarate();
            order.cmbProductName.Items.Clear();
            order.ComboName();
        }

        private void btnAddNewProducts_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(crudProduct);
            crudProduct.PopulateGridViewForCrudProducts();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Fl.Visible = true;
            this.Visible = false;
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(addUsers);
            addUsers.PopulateGridViewForAccountUsers();
        }
    }
}
