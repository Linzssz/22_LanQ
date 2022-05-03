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
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 100;
            int n1 = 200;

            MessageBox.Show(n + " , " + n1);

            Swapint(ref n, ref n1);

            MessageBox.Show(n + " , " + n1);
            //=================================

            string a = "aaaaa";
            string b = "bbbbb";

            MessageBox.Show(a + " , " + b);

            SwapString(ref a, ref b);

            MessageBox.Show(a + " , " + b);
            //todo


        }

        private void Swap<T>(ref T a, ref T b)
        {


            T Temp = a;
            a = b;
            b = Temp;

        }
        private void SwapObject(ref Object a, ref Object b)
        {


            Object Temp = a;
            a = b;
            b = Temp;

        }

        private void Swapint(ref int a, ref int b)
        {


            int Temp = a;
            a = b;
            b = Temp;

        }

        private void SwapString(ref string a, ref string b)
        {


            string Temp = a;
            a = b;
            b = Temp;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            int n = 100;
            int n1 = 200;

            MessageBox.Show(n + " , " + n1);

            //Swap<int>(ref n, ref n1);
            //todo

            MessageBox.Show(n + " , " + n1);
        }
        //=============================================
        private void button2_Click(object sender, EventArgs e)
        {
            //this.buttonX.Click += ButtonX_Click;
            //C#1.0具名方法
            this.buttonX.Click += new EventHandler(aaa);
            this.buttonX.Click += bbb;
            //============================================
            //C#2.0匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
                                                                    {
                                                                        MessageBox.Show("C#2.0匿名方法");

                                                                    };

            //===========================================
            //C#3.0匿名方法 lamba運算式 (=>)goes to
            this.buttonX.Click += (object sender1, EventArgs e1) =>
                                                       {
                                                           MessageBox.Show("C#3.0匿名方法");
                                                       };
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonX_Click");
        }

        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
        private void bbb(object sender, EventArgs e)
        {
            MessageBox.Show("bbb");
        }


        //=========================================
        bool Test1(int n)//(int n,int x)<<不符合MyDelegate的期待
        {
            return n % 2 == 0;
        }

        bool Test(int n)
        {
            return n > 5;
        }

        //先建立委派
        delegate bool Mydelegate(int n);

        private void button9_Click(object sender, EventArgs e)
        {
            bool Result = Test(6);
            MessageBox.Show("result=" + Result);
            //=================================================
            //new一個委派
            Mydelegate delegateObj = new Mydelegate(Test);

            //call方法
            Result = delegateObj.Invoke(7);

            MessageBox.Show("result=" + Result);
            //===============================
            delegateObj = Test1;
            Result = delegateObj(2);
            MessageBox.Show("result=" + Result);

            //============================================
            //C#2.0匿名方法
            delegateObj = delegate (int n)
                                         {
                                             return n > 5;
                                         };

            Result = delegateObj(6);
            MessageBox.Show("result=" + Result);
            //===========================================
            //C#3.0匿名方法 lamba運算式 (=>)goes to
            //委派名稱=參數=>敘述
            delegateObj = n => n > 5;

            Result = delegateObj(1);
            MessageBox.Show("result=" + Result);

        }

        List<int> MyWhere(int[] nums, Mydelegate delegateobject)
        {
            List<int> list = new List<int>();
            foreach (int n in nums)
            {
                if (delegateobject(n))
                {
                    list.Add(n);
                }

            }
            return list;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> Large_List = MyWhere(nums, Test);

            foreach (int n in Large_List)
            {
                this.listBox1.Items.Add(n);
            }
            //===================================
            List<int> odd_List = MyWhere(nums, n => n % 2 == 1);
            foreach (int n in odd_List)
            {
                this.listBox1.Items.Add(n);
            }

            List<int> even_List = MyWhere(nums, n => n % 2 == 0);
            foreach (int n in even_List)
            {
                this.listBox2.Items.Add(n);
            }
            List<int> list = MyWhere(nums, n => n > 5);
            foreach (int n in list)
            {
                this.listBox2.Items.Add(n);
            }

        }
        IEnumerable<int> MyIterator(int[] nums, Mydelegate delegateobject)
        {
            foreach (int n in nums)
            {
                if (delegateobject(n))
                {
                    yield return n;
                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> q = MyIterator(nums, n => n > 5);

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var q = from n in nums
            //        where n > 5
            //        select n;

            IEnumerable<int> q = nums.Where(n => n > 5);
            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }
            //=====================================
            string[] Words = { "zzz", "aaaaaaa", "cccccccccccccccccc" };

            var q1 = Words.Where(w => w.Length > 3);

            foreach (string w in q1)
            {
                this.listBox2.Items.Add(w);
            }
            //===================================
            this.productsTableAdapter1.Fill(nwDataSet11.Products);

            var q2 = nwDataSet11.Products.Where(p => p.UnitPrice > 30);

            this.dataGridView2.DataSource = q2.ToList();

            //foreach (var p in q2)
            //{
            //    this.dataGridView2.DataSource = q2.ToList();
            //}
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //var可以是任意型別,不可寫在外面

            var n = 100;
            //int n1 = 110;

            var s = "aaa";
            //  string s1 = "bbb";

            var p = new Point(12, 21);
            //  Point p1 = new Point(11, 12);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            MyPoint Pt1 = new MyPoint();

            Pt1.P1 = 100;//set
            int w = Pt1.P1;//get

            Pt1.P2 = 300;

            // MessageBox.Show(Pt1.P1.ToString());
            List<MyPoint> list = new List<MyPoint>();

            list.Add(new MyPoint());
            list.Add(new MyPoint(100));
            list.Add(new MyPoint(100, 300));
            list.Add(new MyPoint("xxxx"));

            //================================
            //{ }3.0物件初始化

            list.Add(new MyPoint { P1 = 100, P2 = 300, Filed1 = "CCCCCC", Filed2 = "XXXXXXX" });
            list.Add(new MyPoint { P1 = 100 });
            list.Add(new MyPoint { P1 = 100, P2 = 300, Filed1 = "CCCCCC", Filed2 = "XXXXXXX" });


            this.dataGridView1.DataSource = list;
            //==================================
            //物件初始化List和類別 
            List<MyPoint> list2 = new List<MyPoint>
            {
                new MyPoint{P1 = 1, P2= 2, Filed1 = "CCCCCC", Filed2 = "XXXXXXX"},
                 new MyPoint{P1 = 11, P2= 22, Filed1 = "CCCCCC", Filed2 = "XXXXXXX"},
                  new MyPoint{P1 = 111, P2= 222, Filed1 = "CCCCCC", Filed2 = "XXXXXXX"},
                   new MyPoint{P1 = 11111, P2= 2111, Filed1 = "CCCCCC", Filed2 = "XXXXXXX"}
            };
            this.dataGridView2.DataSource = list2;

        }

        public class MyPoint
        {
            public MyPoint()
            {

            }
            public MyPoint(int p1)
            {
                this.P1 = p1;
            }
            //P1是屬性p1是參數
            public MyPoint(int p1, int p2)
            {
                this.P1 = p1;
                this.P2 = p2;

            }
            public MyPoint(string Filed)
            {

            }

            public string Filed1 = "zzz", Filed2 = "cccc";
            private int m_p1;
            public int P1
            {
                get
                {
                    return m_p1;
                }
                set
                {
                    m_p1 = value;
                }
            }

            public int P2 { get; set; }
            //沒運算式 { get; set; }寫法

        }

        private void button43_Click(object sender, EventArgs e)
        {
            //匿名型別
            var X = new/*省略型別*/ { P1 = 2222, P2 = 3333, P3 = 44323 };
            var Y = new { P1 = 212, P2 = 332333, P3 = 11223 };
            var Z = new { P1 = 23, P2 = 3323, P3 = 4431 };

            this.listBox1.Items.Add(X.GetType());
            this.listBox1.Items.Add(Y.GetType());
            this.listBox1.Items.Add(Z.GetType());

            //=================================
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                    where n > 5
                    select new { N = n, S = n*n, C = n*n * n };
            this.dataGridView1.DataSource = q.ToList();
            //==================================

            var q1 = nums.Where(n => n > 5).Select( n=>new {N = n, S = n * n, C = n * n * n });

            //this.dataGridView2.DataSource = q1.ToList();
            //==================================
            this.productsTableAdapter1.Fill(nwDataSet11.Products);

            var q2 = from p in nwDataSet11.Products
                     where p.UnitPrice > 30
                     select new
                     {//可以取名，也可不取，新建的資料行
                         ID = p.ProductID,
                         產品名稱 = p.ProductName,
                         單價 = p.UnitPrice,
                         p.UnitsInStock,
                         總價 = p.UnitPrice * p.UnitsInStock
                     };

            this.dataGridView2.DataSource = q2.ToList();

        }

        private void button32_Click(object sender, EventArgs e)
        {//擴充方法
            string s1 = "zxcv";

            int n = s1.WordCount();
            MessageBox.Show("WordCount=" + n);

            string s2 = "123546879";

            n = s2.WordCount();
            MessageBox.Show("WordCount=" + n);
            //=========================================
            char ch = s2.Chars(3);

            MessageBox.Show("ch=" + ch);

        }

        private void button34_Click(object sender, EventArgs e)
        {

        }
    }
    public static class MystringExtend
    {// button32，建立靜態類別
        //使用靜態類別靜態方法， 參數使用this開頭
        public static int WordCount(this string s)
        {
            return s.Length;
        }

        public static char Chars(this string s,int index)
        {
            return s[index];
        }
    }
}
