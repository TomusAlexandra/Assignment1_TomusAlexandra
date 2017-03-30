using System;
using System.Windows.Forms;
using Furniture.Models;
using BankCredit.BL;
using System.Collections.Generic;

namespace Furniture
{
    public partial class FormProduct : Form
    {
        public string Title { get; private set; }

        public FormProduct()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void Product_Load(object sender, EventArgs e)
        {
             
        
            ProductOperations bl = new ProductOperations();
            IList<Product> pro = bl.RetrieveProductList();
            foreach (Product p in pro)
            {
                dataGridView1.Rows.Add(p.ID, p.Title, p.Description, p.Color, p.Size, p.Price, p.Stock);

            }
    
        }


    private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
            product.Description = textBox2.Text;
            product.Color = textBox3.Text;
            product.Size = Convert.ToDouble(textBox4.Text);
            product.Price = Convert.ToDouble(textBox5.Text);
            product.Stock = Convert.ToInt32(textBox6.Text);

            ProductOperations bl = new ProductOperations();
            bl.AddProduct(product);

            MessageBox.Show("Operation succesful");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
        //    product.Description = textBox2.Text;
       //     product.Color = textBox3.Text;
       //     product.Size = Convert.ToDouble(textBox4.Text);
       //     product.Price = Convert.ToDouble(textBox5.Text);
            product.Stock = Convert.ToInt32(textBox6.Text);

            ProductOperations bl = new ProductOperations();
            bl.UpdateProduct(product);

            MessageBox.Show("Operation succesful");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
            product.Description = textBox2.Text;
           product.Color = textBox3.Text;
         //  product.Size = Convert.ToDouble(textBox4.Text);
         //  product.Price = Convert.ToDouble(textBox5.Text);
           //product.Stock = Convert.ToInt32(textBox6.Text);

            ProductOperations bl = new ProductOperations();
            bl.DeleteProduct(product);

            MessageBox.Show("Operation succesful");
        }

        private void btnRet_Click(object sender, EventArgs e)
        {

            ProductOperations bl = new ProductOperations();
            IList<Product> pro = bl.RetrieveProductList();
            dataGridView1.RowCount = 1;
            foreach (Product p in pro)
            {
                dataGridView1.Rows.Add(p.ID,p.Title,p.Description,p.Color,p.Size,p.Price,p.Stock);

            }

        }
    }
}
