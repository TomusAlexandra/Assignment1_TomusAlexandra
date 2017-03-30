using BankCredit.BL;
using Farniture.Models;
using Furniture.BL;
using Furniture.Models;
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
    public partial class FormCustomerEmployee : Form
    {
        public FormCustomerEmployee()
        {
            InitializeComponent();
        }

        private void FormCustomerEmployee_Load(object sender, EventArgs e)
        {
            UserOperations bl = new UserOperations();
            IList<Employee> us = bl.RetrieveEmployeeList();
            foreach (Employee u in us)
            {
                dataGridView1.Rows.Add(u.ID, u.UserName, u.firstName, u.lastName);

            }

            CustomerOperations c = new CustomerOperations();
            IList<Customer> cc = c.RetrieveCustomerList();
            foreach (Customer co in cc)
            {
                dataGridView2.Rows.Add(co.ID,co.Cnp,co.Address);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
