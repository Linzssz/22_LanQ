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
            Result =delegateObj(2);
            MessageBox.Show("result=" + Result);


        }
    }
}
