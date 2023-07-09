using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSysytem
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C1MVF6R\SQLEXPRESS;Initial Catalog=inventoryms;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cmd = new SqlCommand("Select * From tbUser",con);
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read()) {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());

            }
            dr.Close(); 
            con.Close();

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                UserModelForm userModel = new UserModelForm();

                userModel.textUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModel.textFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModel.textPhone.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModel.textPass.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                userModel.btnSave.Enabled = false;
                userModel.btnEdit.Enabled = true;
                userModel.textUserName.Enabled = false;
                userModel.ShowDialog();

            }
            else if(colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to you want Delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully Deleted");

                }
            }
            LoadUser();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            UserModelForm userModelForm = new UserModelForm();
            userModelForm.btnSave.Enabled = true;
            userModelForm.btnEdit.Enabled = false;
            userModelForm.ShowDialog();
            LoadUser();

        }
    }
}
