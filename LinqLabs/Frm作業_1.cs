using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        int take_old;
        int skip = 0;
        //bool flag = true;
        

        public Frm作業_1()
        {
            InitializeComponent();
            this.ordersTableAdapter1.Fill(nwDataSet11.Orders);
            this.order_DetailsTableAdapter1.Fill(nwDataSet11.Order_Details);
            this.productsTableAdapter1.Fill(nwDataSet11.Products);
            //  this.dataGridView1.DataSource = this.nwDataSet11.Products;


            LoToCombobox();


        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

            int take = int.Parse(textBox1.Text);

            var q = from p in nwDataSet11.Products
                    select p;



             skip += take;

            this.dataGridView1.DataSource = q.Skip(skip).Take(take).ToList();

           
            take_old = take;
            //this.nwDataSet11.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
        }



        private void button14_Click(object sender, EventArgs e)
        {

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from l in files
                    where l.Extension == ".log"
                    select l;

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {


            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            this.dataGridView1.DataSource = files;
            var q = from l in files
                    where l.CreationTime.Year == 2019
                    orderby l.CreationTime descending
                    select l;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            this.dataGridView1.DataSource = files;

            var q = from l in files
                    where l.Length > 4999999
                    select l;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {



            this.dataGridView1.DataSource = this.nwDataSet11.Orders;
            this.dataGridView2.DataSource = this.nwDataSet11.Order_Details;

        }

        private void LoToCombobox()
        {
            comboBox1.Text = "--請選擇年分--";


            var q = from o in this.nwDataSet11.Orders
                    select o.OrderDate.Year;

            foreach (var i in q)
            {
                if (comboBox1.Items.Contains(i))
                {
                    continue;
                }
                else
                {
                    comboBox1.Items.Add(i);
                }

            }

            //this.comboBox1.DataSource = q.Distinct().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "--請選擇年分--")
            {
                MessageBox.Show("請選擇年分");
            }
            else
            {
                var q = from o in nwDataSet11.Orders
                        where o.OrderDate.Year == (int)comboBox1.SelectedItem
                        select o;

                this.dataGridView1.DataSource = q.ToList();



                var a = from o in nwDataSet11.Orders
                        join od in nwDataSet11.Order_Details
                        on o.OrderID equals od.OrderID
                        where o.OrderDate.Year.ToString() == comboBox1.Text
                        select o;

                this.dataGridView2.DataSource = a.ToList();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int take = int.Parse(textBox1.Text);

            var q = from p in nwDataSet11.Products
                    select p;
            //if(skip>nwDataSet11.Products.Rows.Count)
            //{
            //    return;
            //}

            skip -= take;

            this.dataGridView1.DataSource = q.Skip(skip).Take(take).ToList();


            take_old = take;
        }
    }
}
