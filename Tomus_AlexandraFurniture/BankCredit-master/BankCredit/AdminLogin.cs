using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Furniture
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee employee = new FormEmployee();
            employee.Show();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormOrder order = new FormOrder();
            order.Show();
        }
    }
}
