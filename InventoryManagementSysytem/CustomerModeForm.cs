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
    public partial class CustomerModeForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C1MVF6R\SQLEXPRESS;Initial Catalog=inventoryms;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public CustomerModeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to you want save this customer", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("Insert into tbCustomer(cname,cphone)VALUES(@cname,@cphone)", con);
                    cmd.Parameters.AddWithValue("@cname", textCName.Text);
                  
                    cmd.Parameters.AddWithValue("@cphone", textPhone.Text);
                 
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been successfully saved");
                    Clear();

                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }
       
        public void Clear()
        {
            textCName.Clear();
          
            textPhone.Clear();
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnClear.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
