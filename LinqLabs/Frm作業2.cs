using LinqLabs.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class Frm作業2 : Form
    {
        public Frm作業2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(adventure.ProductPhoto);
            LoToCombobox();
            this.pictureBox1.Controls.Clear();



        }

        private void LoToCombobox()
        {
            this.comboBox3.Text = "--請輸入年份--";


            var q = from p in adventure.ProductPhoto
                    orderby p.ModifiedDate.Year ascending
                    select p.ModifiedDate.Year;

            foreach (var i in q)
            {
                if (comboBox3.Items.Contains(i))
                {
                    continue;
                }
                else
                {
                    comboBox3.Items.Add(i);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = adventure1.ProductPhoto;

            var q = from p in adventure.ProductPhoto
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;

            var q = adventure.ProductPhoto.Where(p => p.ModifiedDate > dt1 && p.ModifiedDate < dt2)
                /*OrderBy(p =>p.ModifiedDate  ascending)*/.Select(p => p);

            //var q = from p in adventure1.ProductPhoto
            //        where p.ModifiedDate > dt1 && p.ModifiedDate < dt2
            //        select p; 

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {



            if (comboBox3.Text == "--請輸入年份--")
            {
                MessageBox.Show("請輸入年份");
            }
            else
            {
                var q = adventure.ProductPhoto.Where(p => p.ModifiedDate.Year == (int)comboBox3.SelectedItem).Select(p => p);

                //var q = from p in adventure1.ProductPhoto
                //        where p.ModifiedDate.Year ==(int)comboBox3.SelectedItem
                //        select p;

                this.dataGridView1.DataSource = q.ToList();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {


            var q = adventure.ProductPhoto.Where(p => p.ModifiedDate.Year ==
          (int)comboBox3.SelectedItem && (p.ModifiedDate.Month > 1 && p.ModifiedDate.Month < 9)).Select(p => p);


            comboBox2.Items.Add(q.ToList());
            comboBox2.DisplayMember = "第一季";



            //this.dataGridView1.DataSource = q.ToList();


            //  var q= from p in adventure.ProductPhoto
            //           where p.ModifiedDate.Year ==
            //(int)comboBox3.SelectedItem && p.ModifiedDate.Month > 1 && p.ModifiedDate.Month < 9
            //           select new
            //           {//可以取名，也可不取，新建的資料行
            //               p,

            //               第一季 = p.ModifiedDate
            //           };


            //if (comboBox2.DisplayMember.Contains("第一季"))
            //{
            //    var q = adventure.ProductPhoto.Where(p => p.ModifiedDate.Year ==
            //      (int)comboBox3.SelectedItem && (p.ModifiedDate.Month > 1 && p.ModifiedDate.Month < 9)).Select(p => p);
            //}

            //var q2 = from p in nwDataSet11.Products
            //         where p.UnitPrice > 30
            //         select new
            //         {//可以取名，也可不取，新建的資料行
            //             ID = p.ProductID,
            //             產品名稱 = p.ProductName,
            //             單價 = p.UnitPrice,
            //             p.UnitsInStock,
            //             總價 = p.UnitPrice * p.UnitsInStock
            // };
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fillByS1ToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Frm作業2_Load(object sender, EventArgs e)
        {
         






        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           //this.pictureBox1.Controls.Clear();

                int productID = (int)this.dataGridView1.CurrentRow.Cells["productPHOTOid"].Value;
                MessageBox.Show("ProductID=" + productID);//尋找ID的值


            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.AdventureWorksConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from  [Production].[ProductPhoto] where ProductPhotoID='{productID}'";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        byte[] bytes = (byte[])reader["LargePhoto"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                        PictureBox p = new PictureBox();
                        p.Image = Image.FromStream(ms);
                        p.BackgroundImageLayout = ImageLayout.Stretch;

                        p.SizeMode = PictureBoxSizeMode.Zoom;
                        this.pictureBox1.Controls.Add(p);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //productPhotoTableAdapter1.FillByPhoto(adventure.ProductPhoto, productID);

            //if (e.ColumnIndex==productID)
            //{
            //    var q =
            //}
                //FrmPhotoDetail f = new FrmPhotoDetail();
                //f.ProductID = productID;
                //f.Text = productID.ToString();
                //f.Show();
            //}
        }
    }
}
