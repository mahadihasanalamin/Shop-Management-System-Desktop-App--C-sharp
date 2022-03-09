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
    public partial class UCAddUsers : UserControl
    {
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private string Sql { get; set; }
        public UCAddUsers()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.AutoUserIdGenarate();
        }

        internal void AutoUserIdGenarate()
        {
            string sql = "select COUNT(*) from AccountUsers;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            int rowNo = Convert.ToInt32(dt.Rows[0][0]);

            if (rowNo > 0)
            {
                Sql = "select userId from AccountUsers order by userId desc;";
                DataTable Dt = this.Da.ExecuteQueryTable(this.Sql);
                string previousId = Dt.Rows[0][0].ToString();
                string[] temp = previousId.Split('-');
                int serialNo = Convert.ToInt32(temp[1]);
                string nextId = temp[0] + "-" + (++serialNo).ToString("0000");
                this.txtNewUserId.Text = nextId;
            }

            else
            {
                this.txtNewUserId.Text = "U-0001";
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valid())
                {
                    Sql = "insert into AccountUsers values('" + this.txtNewUserId.Text + "'," +
                        " '" + this.txtNewUserFullName.Text + "', '" +this.txtNewUserPhone.Text + "'," +
                        " '" + this.txtNewUserUsername.Text + "','" + this.txtNewUserPassword.Text + "', " +
                        "'" + this.CmbNewUserType.Text + "' );";

                    int row = this.Da.ExecuteUpdateQuery(Sql);
                    if (row == 1)
                    {
                        MessageBox.Show("Data inserted successfully in Database");
                    }
                    else
                        MessageBox.Show("Data insertion failed");

                    this.PopulateGridViewForAccountUsers();

                    this.ClearAll();

                    this.AutoUserIdGenarate();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valid())
                {
                    this.Sql = "select * from AccountUsers where userId='" + this.txtNewUserId.Text + "'";
                    DataTable dt = this.Da.ExecuteQueryTable(Sql);

                    if (dt.Rows.Count == 1)
                    {
                        this.Sql = @"update AccountUsers 
                                 set fullName = '" + txtNewUserFullName.Text + @"',
                                     phone = '" + txtNewUserPhone.Text + @"',
                                     username = '" + txtNewUserUsername.Text + @"',
                                     password = '" + txtNewUserPassword.Text + @"',
                                     type = '" + CmbNewUserType.Text + @"'
                                 where userId = '" + txtNewUserId.Text + "';";

                        int row = this.Da.ExecuteUpdateQuery(Sql);
                        if (row == 1)
                        {
                            MessageBox.Show(" Data updated successfully in Database");
                        }
                        else
                            MessageBox.Show("Data update operation failed");

                        this.ClearAll();
                        this.PopulateGridViewForAccountUsers();
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
                string id = this.dgvAccountUsers.CurrentRow.Cells["userId"].Value.ToString();
                string name = this.dgvAccountUsers.CurrentRow.Cells["fullName"].Value.ToString();
                Sql = "delete from AccountUsers where userId = '" + id + "';";

                if (this.dgvAccountUsers.SelectedRows.Count > 0)
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

                        this.PopulateGridViewForAccountUsers(); ;

                        this.AutoUserIdGenarate();
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

        internal void PopulateGridViewForAccountUsers(String sql = "select * from AccountUsers order by userId asc" + ";")
        {
            this.Ds = Da.ExecuteQuery(sql);
            this.dgvAccountUsers.AutoGenerateColumns = false;
            this.dgvAccountUsers.DataSource = Ds.Tables[0];
        }

        private void txtSearchByUserId_TextChanged(object sender, EventArgs e)
        {
            Sql = "select * from AccountUsers where userId like '%" + this.txtSearchByUserId.Text + "%';";
            this.PopulateGridViewForAccountUsers(Sql);
        }

        private void txtSearchByUserName_TextChanged(object sender, EventArgs e)
        {
            this.Sql = "select * from AccountUsers where userame like '%" + this.txtSearchByUserName.Text + "%';";
            this.PopulateGridViewForAccountUsers(this.Sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.AutoUserIdGenarate();
            this.txtNewUserFullName.Text = "";
            this.txtNewUserPhone.Text = "";
            this.txtNewUserUsername.Text = "";
            this.txtNewUserPassword.Text = "";
            this.CmbNewUserType.Text = "";
        }

        private void dgvAccountUsers_DoubleClick(object sender, EventArgs e)
        {
            this.txtNewUserId.Text = this.dgvAccountUsers.CurrentRow.Cells["userId"].Value.ToString();
            this.txtNewUserFullName.Text = this.dgvAccountUsers.CurrentRow.Cells["fullName"].Value.ToString();
            this.txtNewUserPhone.Text = this.dgvAccountUsers.CurrentRow.Cells["phone"].Value.ToString();
            this.txtNewUserUsername.Text = this.dgvAccountUsers.CurrentRow.Cells["username"].Value.ToString();
            this.txtNewUserPassword.Text = this.dgvAccountUsers.CurrentRow.Cells["password"].Value.ToString();
            this.CmbNewUserType.Text = this.dgvAccountUsers.CurrentRow.Cells["type"].Value.ToString();
        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(this.txtNewUserId.Text) || string.IsNullOrEmpty(this.txtNewUserFullName.Text) ||
                string.IsNullOrEmpty(this.txtNewUserPhone.Text) || string.IsNullOrEmpty(this.txtNewUserFullName.Text)||
                string.IsNullOrEmpty(this.txtNewUserUsername.Text) || string.IsNullOrEmpty(this.txtNewUserPassword.Text)||
                string.IsNullOrEmpty(this.CmbNewUserType.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void UCAddUsers_Load(object sender, EventArgs e)
        {
            this.dgvAccountUsers.ClearSelection();
        }

    }
}
