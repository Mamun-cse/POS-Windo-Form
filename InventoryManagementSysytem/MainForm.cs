using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSysytem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private Form childForm;
        private Form panelMain;

        //private object GetPanelMain()
        //{
        //    return panelMain;
        //}

        //private void openChildForm(Form chilForm)
        //{
        //    if (activeForm != null)
        //        activeForm.Close();
        //    activeForm = childForm;
        //    chilForm.TopLevel = false;
        //    chilForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    panelMain.Controls.Add(chilForm);
        //    panelMain.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();

        //}


        private void customerButton4_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();

            // Show the new form
            userForm.Show();
        }

        private void customerButton2_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();

            // Show the new form
            customerForm.Show();
        }
    }
}
