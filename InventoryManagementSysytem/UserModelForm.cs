using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace InventoryManagementSysytem
{
    public partial class UserModelForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C1MVF6R\SQLEXPRESS;Initial Catalog=inventoryms;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        internal object textPassword;

        public UserModelForm()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save
            try
            {
                if (MessageBox.Show("Are you sure to you want save this user","Saving Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                    cmd = new SqlCommand("Insert into tbUser(username,fullname,phone,password)VALUES(@username,@fullname,@phone,@password)",con);
                    cmd.Parameters.AddWithValue("@username", textUserName.Text);
                    cmd.Parameters.AddWithValue("@fullname", textFullName.Text);
                    cmd.Parameters.AddWithValue("@phone", textPhone.Text);
                    cmd.Parameters.AddWithValue("@password", textPass.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully saved");
                    Clear();

                }
            }
            catch(Exception ex)
            
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to you want Edit this user", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbUser SET fullname =@fullname,phone=@phone,password=@password WHERE username LIKE '"+textUserName.Text+"' ", con);
                  
                    cmd.Parameters.AddWithValue("@fullname", textFullName.Text);
                    cmd.Parameters.AddWithValue("@phone", textPhone.Text);
                    cmd.Parameters.AddWithValue("@password", textPass.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();  
                    con.Close();
                    MessageBox.Show("User has been successfully Edit");
                    this.Dispose();

                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }
        public void Clear()
        {
            textUserName.Clear();
            textFullName.Clear();
            textPhone.Clear();
            textPass.Clear();
        }
    }
}
