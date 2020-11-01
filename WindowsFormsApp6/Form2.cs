using System;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Product product { get; set; }

        public Form2(Product product1)
        {
            InitializeComponent();

            this.product = product1;

            if(product.Name != null)
            {
                label1.Text = "edit product";
                button1.Text = "edit";
                textBox1.Text = product.Name;
                numericUpDown2.Value  = product.Price;
                numericUpDown3.Value =  product.Number_of;
                comboBox1.Text = product.Сountry_of_manufacture;
                numericUpDown1.Value = product.Discount;
            }
            else
            {
                label1.Text = "Create Product";
                button1.Text = "Create";
            }                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter valid Name product!");
                return;
            }
            else
            {
                product.Name = textBox1.Text;
            }
            if (numericUpDown2.Value > 0)
            {
                product.Price = numericUpDown2.Value;
            }
            else
            {
                MessageBox.Show("Enter valid Price product!");
                return;
               
            }
            if (numericUpDown3.Value > 0)
            {
                product.Number_of = numericUpDown3.Value;
            }
            else
            {
                MessageBox.Show("Enter valid Number of product!");
                return;
             
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Enter valid Сountry of manufacture!");
                return;
            }
            else
            {
                product.Сountry_of_manufacture = comboBox1.Text;
            }
            if (numericUpDown1.Value > 0 )
            {
                product.Discount = numericUpDown1.Value;
            }
            else
            {
                MessageBox.Show("Enter valid Discount!");
                return;
               
            }
       
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

      
    }
}
