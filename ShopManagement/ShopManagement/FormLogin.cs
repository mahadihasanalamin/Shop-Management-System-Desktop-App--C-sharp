using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ShopManagement
{
    public partial class FormLogin : MetroForm
    {
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private string Sql { get; set; }
        private FormManager Fm { get; set; }
        private FormCashier Fc { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Sql = "select username from AccountUsers where username='" + txtUsername.Text + "';";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string uName = Dt.Rows[0][0].ToString();

                this.Sql = "select password from AccountUsers where username ='" + uName + "';";
                DataTable Dt1 = this.Da.ExecuteQueryTable(this.Sql);
                string password = Dt1.Rows[0][0].ToString();

                this.Sql = "select type from AccountUsers where username ='" + uName + "';";
                DataTable Dt2 = this.Da.ExecuteQueryTable(this.Sql);
                string userType = Dt2.Rows[0][0].ToString();

                if (txtPassword.Text == password && userType=="Manager")
                {
                        this.Clear();
                        this.Visible = false;
                        this.Fm = new FormManager(this);
                        Fm.Visible = true;
                        MessageBox.Show("Success");
                    
                }
                else if (txtPassword.Text == password && userType == "Cashier")
                {
                    this.Clear();
                    this.Visible = false;
                    this.Fc = new FormCashier(this);
                    Fc.Visible = true;
                    MessageBox.Show("Success");
                }
                else
                    MessageBox.Show("Password is not correct");
            }

            catch (Exception )
            {
                MessageBox.Show("User not found" );
            }
        }

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

       
    }
}
