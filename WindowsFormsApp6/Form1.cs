using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Product> Products = new List<Product>();
        private void button1_Click(object sender, EventArgs e)
        {
            Products.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            Product product = new Product();
            var form = new Form2(product);
            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(product);
                Products.Add(product);
            }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex != -1)
            {
                var form = new Form2(Products[listBox1.SelectedIndex]);
                form.ShowDialog();

                foreach (var item in Products)
                {
                    listBox1.Items.Remove(item);
                }
                foreach (var item in Products)
                {
                    listBox1.Items.Add(item);
                }

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var form = new Form3(Products[listBox1.SelectedIndex]);
                form.ShowDialog();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
          
            save.CreatePrompt = true;
            save.DefaultExt = ".txt";         
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                foreach (var item in Products)
                {
                    writer.Write(item.Name + Environment.NewLine);
                    writer.Write(item.Price + Environment.NewLine);
                    writer.Write(item.Number_of + Environment.NewLine); ;
                    writer.Write(item.Сountry_of_manufacture + Environment.NewLine);
                    writer.Write(item.Discount + Environment.NewLine);
                }
                writer.Close(); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);       
            open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            open.FilterIndex = 2;
            open.CheckFileExists = true;      
            if (open.ShowDialog() == DialogResult.OK)
            {
                Product product = new Product();
                StreamReader reader = new StreamReader(open.OpenFile());
                while (!reader.EndOfStream)
                {                                  
                        product.Name = reader.ReadLine();
                        product.Price = int.Parse(reader.ReadLine());
                        product.Number_of = int.Parse(reader.ReadLine());
                        product.Сountry_of_manufacture = reader.ReadLine();
                        product.Discount = int.Parse(reader.ReadLine());

                        listBox1.Items.Add(product.ToString());
                        Products.Add(product);

                }
                reader.Close();
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }     
        public decimal Price { get; set; }
        public decimal Number_of { get; set; }
        public string Сountry_of_manufacture { get; set; }
        public decimal Discount { get; set; }


        public override string ToString()
        {
            return $"Name: {Name} \n" +
                $"Price: {Price} \n" +
                $"Number of: {Number_of} \n" +
                $"Сountry of manufacture: {Сountry_of_manufacture} \n" +
                $"Discount: {Discount} \n";
        }
    }

}
