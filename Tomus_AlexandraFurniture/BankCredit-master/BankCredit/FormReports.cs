using BankCredit.BL;
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Furniture
{
    public partial class FormReports : Form
    {
        public FormReports()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            Activity activity = new Activity();


            activity.IdEmployee = Convert.ToInt32(textBox1.Text);
            string d1 = date1.Value.ToString("yyyy-MM-dd");
            string d2 = date2.Value.ToString("yyyy-MM-dd");
 
           // activity.DeliveryDate = date1.Value; 
          //  activity.DeliveryDate = date2.Value;
            ActivityOperations bl = new ActivityOperations();
            IList<Activity> pro = bl.RetrieveActivityList(activity.IdEmployee, d1, d2);
            foreach (Activity p in pro)
            {
                dataGridView1.Rows.Add(p.ID, p.IdEmployee, p.AddOp, p.UpdateOp, p.Viewproduct, p.DeliveryDate);

            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Activity activity= new Activity();


            ActivityOperations bl = new ActivityOperations();
            activity.IdEmployee= Convert.ToInt32(textBox1.Text);
            string d1 = date1.Value.ToString("yyyy-MM-dd");
            string d2 = date2.Value.ToString("yyyy-MM-dd");
            activity.DeliveryDate = d1;
            activity.DeliveryDate = d2;
            IList<Activity> pro = bl.RetrieveActivityList(activity.IdEmployee, d1, d2);
            dataGridView1.RowCount = 1;
            foreach (Activity p in pro)
            {
                dataGridView1.Rows.Add(p.ID, p.IdEmployee, p.AddOp, p.UpdateOp, p.Viewproduct, p.DeliveryDate);

            }

            MessageBox.Show("Operation succesful");
        }
    }
}
