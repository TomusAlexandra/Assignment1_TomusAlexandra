using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Furniture.BL;
using Furniture.Models;

namespace Furniture
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.firstName = txtFirstName.Text;
            user.lastName = txtFirstName.Text;
            user.IsAdmin = chkAdmin.Checked;
            user.DateOfBirth = dtpDateOfBirth.Value;

            UserOperations bl = new UserOperations();
            bl.AddUser(user);

            MessageBox.Show("Operation succesful");
        }

      
    }
}
