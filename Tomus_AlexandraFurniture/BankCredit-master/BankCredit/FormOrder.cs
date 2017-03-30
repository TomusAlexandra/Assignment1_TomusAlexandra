using BankCredit.BL;
using BankCredit.Models;
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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            OrdersOperations bl = new OrdersOperations();
            IList<Order> pro = bl.RetrieveOrderList();
            foreach (Order p in pro)
            {
               dataGridView1.Rows.Add(p.ID,p.IdCustomer,p.IdEmployee,p.ShippindAddress,p.IdentificationNr,p.DeliveryDate,p.Status);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OrdersOperations bl = new OrdersOperations();
            IList<Order> pro = bl.RetrieveOrderList();
            dataGridView1.RowCount = 1;
            foreach (Order p in pro)
            {
                dataGridView1.Rows.Add(p.ID, p.IdCustomer, p.IdEmployee, p.ShippindAddress,p.IdentificationNr, p.DeliveryDate, p.Status);

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add order
            Order order = new Order();
       

            OrdersOperations bl = new OrdersOperations();
            order.ID = Convert.ToInt32(textBox1.Text);
            order.IdCustomer = Convert.ToInt32(textBox2.Text);
            order.IdEmployee = Convert.ToInt32(textBox3.Text);
            order.ShippindAddress = textBox4.Text;
            order.IdentificationNr = Convert.ToInt32(textBox5.Text);
            order.DeliveryDate = date.Value;
            order.Status = textBox7.Text;

            bl.AddOrder(order);

            //add ativity employee
            Activity activity = new Activity();
            ActivityOperations blll = new ActivityOperations();
            activity.IdEmployee = Convert.ToInt32(textBox3.Text);
            activity.AddOp = 1;
            activity.UpdateOp = 0;
            activity.Viewproduct = 0;
            activity.DeliveryDate = date.Value.ToString("yyyy-MM-dd");
         //   string d1 = date1.Value.ToString("yyyy-MM-dd");
            blll.AddActivity(activity);



            //total order
            double sum = 0;
            OrderProduct po = new OrderProduct();
           //  Product prod = new Product();
            po.IdOrder= Convert.ToInt32(textBox1.Text);

            OrderProductOperations y = new OrderProductOperations();
            IList<OrderProduct> listIdProdus = y.RetrieveOrderProductList(po.IdOrder);

           
            ProductOperations op1 = new ProductOperations();
          

            foreach (OrderProduct i in listIdProdus)
            {
                IList<Product> listP = op1.RetrieveProductOrderList(i.IdProduct);

                foreach (Product j in listP)
                {
                    sum += j.Price;
                }
                
              

            }
            Console.WriteLine(sum);

            //suma = Convert.ToString(sum);


            textBox8.Text = sum.ToString();
            MessageBox.Show("Operation succesful");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Order order = new Order();


            OrdersOperations bl = new OrdersOperations();
            order.ID = Convert.ToInt32(textBox1.Text);
         //   order.IdCustomer = Convert.ToInt32(textBox2.Text);
         //   order.IdEmployee = Convert.ToInt32(textBox3.Text);
          //  order.ShippindAddress = textBox4.Text;
          //  order.IdentificationNr = Convert.ToInt32(textBox5.Text);
         //   order.DeliveryDate = date.Value;
            order.Status = textBox7.Text;
          
            bl.UpdateOrder(order);

            MessageBox.Show("Operation succesful");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomerEmployee customerForm = new FormCustomerEmployee();
            customerForm.Show();

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee employeeForm = new FormEmployee();
            employeeForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormReports reportsForm = new FormReports();
            reportsForm.Show();
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            FormProduct productsForm = new FormProduct();
            productsForm.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            OrderProduct op = new OrderProduct();


            OrderProductOperations bl = new OrderProductOperations();
            op.IdOrder = Convert.ToInt32(textBox1.Text);
            op.IdProduct = Convert.ToInt32(textBox6.Text);
         //   op.Stock = Convert.ToInt32(textBox3.Text);
       
         

            bl.AddProductOrder(op);

            //- stock 

            Product p = new Product();
            p.ID = Convert.ToInt32(textBox6.Text);
            ProductOperations x = new ProductOperations();
            IList<Product> pro = x.RetrieveProductOrderList(p.ID);
            foreach (Product pp in pro)
            {
                
                pp.Stock = pp.Stock - 1;
                
                x.UpdateProduct(p.ID, pp.Stock);
               

            }


            ///test
            ///
               //total order
            double sum = 0;
            OrderProduct po = new OrderProduct();
            //  Product prod = new Product();
            po.IdOrder = Convert.ToInt32(textBox1.Text);

            OrderProductOperations y = new OrderProductOperations();
            IList<OrderProduct> listIdProdus = y.RetrieveOrderProductList(po.IdOrder);


            ProductOperations op1 = new ProductOperations();


            foreach (OrderProduct i in listIdProdus)
            {
                IList<Product> listP = op1.RetrieveProductOrderList(i.IdProduct);

                foreach (Product j in listP)
                {
                    sum += j.Price;
                }



            }
            Console.WriteLine(sum);

            //suma = Convert.ToString(sum);


            textBox8.Text = sum.ToString();

        }
    }
}
