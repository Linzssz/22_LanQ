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
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList arrlist = new System.Collections.ArrayList();

            arrlist.Add(4);
            arrlist.Add(5);
            arrlist.Add(1);

            //arrlist要接cast，且角括號型態不可省略
            var q = from n in arrlist.Cast<int>()
                    where n > 2
                    select new { 大於二的數 = n };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(nwDataSet11.Products);
            //混合查詢括號後再點take
            var q = (from p in nwDataSet11.Products
                     orderby p.UnitsInStock descending
                     select p).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }
    }
}