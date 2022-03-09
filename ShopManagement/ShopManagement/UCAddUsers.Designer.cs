
namespace ShopManagement
{
    partial class UCAddUsers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNewUserFullName = new System.Windows.Forms.TextBox();
            this.txtNewUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewUserPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewUserUsername = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAccountUsers = new System.Windows.Forms.DataGridView();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchByUserName = new System.Windows.Forms.TextBox();
            this.txtSearchByUserId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewUserPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbNewUserType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNewUserFullName
            // 
            this.txtNewUserFullName.Location = new System.Drawing.Point(118, 82);
            this.txtNewUserFullName.Name = "txtNewUserFullName";
            this.txtNewUserFullName.Size = new System.Drawing.Size(100, 22);
            this.txtNewUserFullName.TabIndex = 1;
            // 
            // txtNewUserId
            // 
            this.txtNewUserId.Location = new System.Drawing.Point(118, 37);
            this.txtNewUserId.Name = "txtNewUserId";
            this.txtNewUserId.ReadOnly = true;
            this.txtNewUserId.Size = new System.Drawing.Size(100, 22);
            this.txtNewUserId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "User ID";
            // 
            // txtNewUserPhone
            // 
            this.txtNewUserPhone.Location = new System.Drawing.Point(118, 131);
            this.txtNewUserPhone.Name = "txtNewUserPhone";
            this.txtNewUserPhone.Size = new System.Drawing.Size(100, 22);
            this.txtNewUserPhone.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Username";
            // 
            // txtNewUserUsername
            // 
            this.txtNewUserUsername.Location = new System.Drawing.Point(118, 175);
            this.txtNewUserUsername.Name = "txtNewUserUsername";
            this.txtNewUserUsername.Size = new System.Drawing.Size(100, 22);
            this.txtNewUserUsername.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(23, 443);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(134, 383);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(134, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvAccountUsers
            // 
            this.dgvAccountUsers.AllowUserToAddRows = false;
            this.dgvAccountUsers.AllowUserToDeleteRows = false;
            this.dgvAccountUsers.AllowUserToResizeColumns = false;
            this.dgvAccountUsers.AllowUserToResizeRows = false;
            this.dgvAccountUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccountUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userId,
            this.fullName,
            this.phone,
            this.username,
            this.password,
            this.type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccountUsers.Location = new System.Drawing.Point(335, 202);
            this.dgvAccountUsers.Name = "dgvAccountUsers";
            this.dgvAccountUsers.ReadOnly = true;
            this.dgvAccountUsers.RowHeadersWidth = 51;
            this.dgvAccountUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAccountUsers.RowTemplate.Height = 24;
            this.dgvAccountUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountUsers.Size = new System.Drawing.Size(840, 368);
            this.dgvAccountUsers.TabIndex = 12;
            this.dgvAccountUsers.DoubleClick += new System.EventHandler(this.dgvAccountUsers_DoubleClick);
            // 
            // userId
            // 
            this.userId.DataPropertyName = "userId";
            this.userId.HeaderText = "User ID";
            this.userId.MinimumWidth = 6;
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            // 
            // fullName
            // 
            this.fullName.DataPropertyName = "fullName";
            this.fullName.HeaderText = "Full Name";
            this.fullName.MinimumWidth = 6;
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Phone";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "Password";
            this.password.MinimumWidth = 6;
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "User Type";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // txtSearchByUserName
            // 
            this.txtSearchByUserName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearchByUserName.Location = new System.Drawing.Point(788, 172);
            this.txtSearchByUserName.Name = "txtSearchByUserName";
            this.txtSearchByUserName.Size = new System.Drawing.Size(120, 22);
            this.txtSearchByUserName.TabIndex = 13;
            this.txtSearchByUserName.TextChanged += new System.EventHandler(this.txtSearchByUserName_TextChanged);
            // 
            // txtSearchByUserId
            // 
            this.txtSearchByUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByUserId.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearchByUserId.Location = new System.Drawing.Point(396, 170);
            this.txtSearchByUserId.Name = "txtSearchByUserId";
            this.txtSearchByUserId.Size = new System.Drawing.Size(110, 22);
            this.txtSearchByUserId.TabIndex = 14;
            this.txtSearchByUserId.TextChanged += new System.EventHandler(this.txtSearchByUserId_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Search";
            // 
            // txtNewUserPassword
            // 
            this.txtNewUserPassword.Location = new System.Drawing.Point(118, 235);
            this.txtNewUserPassword.Name = "txtNewUserPassword";
            this.txtNewUserPassword.Size = new System.Drawing.Size(100, 22);
            this.txtNewUserPassword.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Password";
            // 
            // CmbNewUserType
            // 
            this.CmbNewUserType.AllowDrop = true;
            this.CmbNewUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNewUserType.FormattingEnabled = true;
            this.CmbNewUserType.Items.AddRange(new object[] {
            "Manager",
            "Cashier"});
            this.CmbNewUserType.Location = new System.Drawing.Point(118, 284);
            this.CmbNewUserType.Name = "CmbNewUserType";
            this.CmbNewUserType.Size = new System.Drawing.Size(100, 24);
            this.CmbNewUserType.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "User Type";
            // 
            // UCAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbNewUserType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNewUserPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchByUserId);
            this.Controls.Add(this.txtSearchByUserName);
            this.Controls.Add(this.dgvAccountUsers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtNewUserUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewUserPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewUserId);
            this.Controls.Add(this.txtNewUserFullName);
            this.Controls.Add(this.btnAdd);
            this.Name = "UCAddUsers";
            this.Size = new System.Drawing.Size(1209, 591);
            this.Load += new System.EventHandler(this.UCAddUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNewUserFullName;
        private System.Windows.Forms.TextBox txtNewUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewUserPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewUserUsername;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAccountUsers;
        private System.Windows.Forms.TextBox txtSearchByUserName;
        private System.Windows.Forms.TextBox txtSearchByUserId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.TextBox txtNewUserPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbNewUserType;
        private System.Windows.Forms.Label label7;
    }
}
