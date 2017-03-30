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
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

     

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;

            UserOperations bl = new UserOperations();
            bl.AddEmployee(employee);

            MessageBox.Show("Operation succesful");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;

            UserOperations bl = new UserOperations();
            bl.DeleteEmployee(employee);

            MessageBox.Show("Operation succesful");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;

            UserOperations bl = new UserOperations();
            bl.UpdateEmployee(employee);

            MessageBox.Show("Operation succesful");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    
        private void btnDelete_Click(object sender, EventArgs e)
        {





            UserOperations bl = new UserOperations();
            IList<Employee> us = bl.RetrieveEmployeeList();
            dataGridView1.RowCount = 1;
            foreach (Employee u in us)
            {
                dataGridView1.Rows.Add(u.ID, u.UserName, u.firstName, u.lastName);

            }


        }

        private Employee RetrieveEmployeeInformation()
        {
            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;
            return employee;
        }

    

        private void gridStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee employee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;

                if (employee != null)
                {
                    txtFirstName.Text = employee.firstName;
                    txtUserName.Text = employee.lastName;
                  
                  
                }
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            UserOperations bl = new UserOperations();
            IList<Employee> us = bl.RetrieveEmployeeList();
            foreach (Employee u in us)
            {
                dataGridView1.Rows.Add(u.ID, u.UserName,u.firstName, u.lastName);

            }
        }

    


    }
}
