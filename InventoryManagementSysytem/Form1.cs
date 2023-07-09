using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSysytem
{
    public partial class Form1 : Form
    {
        public object Question { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1Pass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1Pass.Checked == false)
            {
                textPass.UseSystemPasswordChar = true;
            }
            else
            {
                textPass.UseSystemPasswordChar = false;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textPass.Clear();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            {
                Application.Exit();
            }
        }
    }
}
