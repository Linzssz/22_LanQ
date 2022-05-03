using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet11.Products);
            this.ordersTableAdapter1.Fill(this.nwDataSet11.Orders);


        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //    public interface IEnumerable
            //    System.Collections 的成員
            //摘要:
            //公開能逐一查看非泛型集合內容一次的列舉程式。

            int[] nums = { 1, 2, 3, 4 };
            foreach (int n in nums)
            {
                this.listBox1.Items.Add(n);
            }
            this.listBox1.Items.Add("================");
            //=========================================
            //C#轉譯

            System.Collections.IEnumerator en = nums.GetEnumerator();
            while (en.MoveNext())
            {
                this.listBox1.Items.Add(en.Current);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            List<int> list = new List<int>() { 1, 2, 3, 4 };
            foreach (int n in list)
            {
                this.listBox1.Items.Add(n);
            }
            this.listBox1.Items.Add("==============");
            //=========================================
            //C#轉譯
            System.Collections.IEnumerator en = list.GetEnumerator();

            while (en.MoveNext())
            {
                this.listBox1.Items.Add(en.Current);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                    where (5 <= n && n <= 8) && (n % 2 == 0)
                    //where (n<9||n<3)

                    select n;

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var q = from n in nums
                    where IsEven(n)
                    select n;
        }

        private bool IsEven(int n)
        {
            //if(n%2==0)
            //  {
            //      return   true;
            //  }
            //else
            //  {
            //      return false;
            //  }

            // return n % 2 == 0 ? true : false;
            return n % 2 == 0; 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //1.define Data Source
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //2.define Query

            //var q=
            //var可以是任意型別
            IEnumerable<Point> q = from n in nums
                                   where n > 5
                                   select new Point(n, n * n);
            //=========================
            //3.Execue Query

            foreach (Point pt in q)
            {
                this.listBox1.Items.Add(pt.X + " , " + pt.Y);
            }
            //=========================
            //3.Execue Query
            List<Point> list = q.ToList();
            this.dataGridView1.DataSource = list;
            //=======================

            this.chart1.DataSource = list;
            this.chart1.Series[0].XValueMember = "X";
            this.chart1.Series[0].YValueMembers = "Y";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void button1_Click(object sender, EventArgs e)

        {
            this.listBox1.Items.Clear();
            string[] word = { " aaa", "Apple", "pineApple", " xxxxApple" };

            IEnumerable<string> q = from w in word
                                    where w.ToLower().Contains("apple") && (w.Length > 5)
                                    select w;

            foreach (string s in q)
            {
                listBox1.Items.Add(s);
            }
            //==================================
            this.dataGridView1.DataSource = q.ToList();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.nwDataSet11.Products;

            IEnumerable<global::LinqLabs.NWDataSet1.ProductsRow> q = from p in this.nwDataSet11.Products
                                                                     where !p.IsUnitPriceNull() && p.UnitPrice > 30 && p.UnitPrice < 120 && p.ProductName.StartsWith("M")
                                                                     select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.nwDataSet11.Orders;

            var q = from p in this.nwDataSet11.Orders
                    where p.OrderDate.Year == 1997&&p.OrderDate.Month<    4
                    orderby p.OrderDate descending
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var q= 
        }
    }
}
