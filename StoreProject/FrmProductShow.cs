using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class FrmProductShow : Form
    {
        public FrmProductShow()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private Image convertByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                // อาจเกิดขึ้นถ้า byte array ไม่ใช่ข้อมูลรูปภาพที่ถูกต้อง
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                return null;
            }
        }

        private void getAllProductToLV()
        {
            //Connect String เพื่อติตต่อไปยังฐานข้อมูล
            string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True;";

            //สร้าง connection ไปยังฐานข้อมูล
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open(); //open connectiong to db

                    //การทำงานกับตารางในฐานข้อมูล (SELECT, INSERT, UPDATE, DELETE)
                    //สร้างคำสั่ง SQL ให้ดึงข้อมูลจากตาราง product_db
                    string strSQL = "select proId, proName, proPrice, proQuan, proUnit, proStatus, proImage, createAt, updateAt from product_tb";

                    //จัดการให้ SQL ทำงาน
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {
                        //เอาข้อมูลที่ได้จาก strSQl ซึ่งเป็นก้อนใน dataAdapter มาทำให้เป็นตารางโดยใส่ไว้ใน dataTable
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        //ตึ้งค่าทั่วไปของ ListView 
                        lvAllProduct.Items.Clear();
                        lvAllProduct.Columns.Clear();
                        lvAllProduct.FullRowSelect = true;
                        lvAllProduct.View = View.Details;

                        //ตึ้งค่าการแสดงรูปของ ListView 
                        if (lvAllProduct.SmallImageList == null)
                        {
                            lvAllProduct.SmallImageList = new ImageList();
                            lvAllProduct.SmallImageList.ImageSize = new Size(50, 50);
                            lvAllProduct.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;

                        }
                        lvAllProduct.SmallImageList.Images.Clear();

                        //กำหนดรายละเอียดของ Colum ใน ListView
                        lvAllProduct.Columns.Add("รูปภาพ", 100, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("รหัสสินค้า", 80, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("ชื่อสินค้า", 230, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("ราคา", 100, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("จำนวน", 80, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("หน่วย", 50, HorizontalAlignment.Left);
                        lvAllProduct.Columns.Add("สถานะ", 80, HorizontalAlignment.Left);

                        //Loop วนเข้าไปใน DataTable
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(); //create item for store data list
                            //put image in items
                            Image proImage = null;
                            if (dataRow["proImage"] != DBNull.Value)
                            {
                                byte[] imgByte = (byte[])dataRow["proImage"];
                                proImage = convertByteArrayToImage(imgByte);
                            }
                            string imageKey = null;
                            if (proImage != null)
                            {
                                imageKey = $"pro_{dataRow["proId"]}";
                                lvAllProduct.SmallImageList.Images.Add(imageKey, proImage);
                                item.ImageKey = imageKey;
                            }
                            else
                            {
                                item.ImageIndex = -1;
                            }

                            item.SubItems.Add(dataRow["proId"].ToString());
                            item.SubItems.Add(dataRow["proName"].ToString());
                            item.SubItems.Add(dataRow["proPrice"].ToString());
                            item.SubItems.Add(dataRow["proQuan"].ToString());
                            item.SubItems.Add(dataRow["proUnit"].ToString());
                            item.SubItems.Add(dataRow["proStatus"].ToString());

                            lvAllProduct.Items.Add(item);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("พบข้อผิดพลาด กรุณากรอกใหม่หรือติดต่อ IT : " + ex.Message);
                }
            }
        }

        //Form Load จะทำงานทุกครั้งที่ Form เปิดขึ้นมา

        private void FrmProductShow_Load(object sender, EventArgs e)
        {
            //pull data from data base
            getAllProductToLV();

        }

        private void btnFrmProductCreate_Click(object sender, EventArgs e)
        {
            //เปิด Form FrmProductCreate ขึ้นมา แบบ Dialog
            //create a new instance of FrmProductCreate
            FrmProductCreate frmProductCreate = new FrmProductCreate();
            //show the form
            //frmProductCreate.Show();
            //show the form as dialog
            frmProductCreate.ShowDialog(); //ถ้าใช้ ShowDialog จะไม่สามารถเปิด Form อื่นได้จนกว่าจะปิด Form นี้
            getAllProductToLV();
        }

        private void lvAllProduct_ItemActivate(object sender, EventArgs e)
        {
            //every time user double click on item in ListView Oepen FrmProductUpDel
            //with data from selected item in dialog form

            FrmProductUpDel frmPoductUpDel = new FrmProductUpDel(
            int.Parse(lvAllProduct.SelectedItems[0].SubItems[1].Text) //get proId from selected item



             );
            frmPoductUpDel.ShowDialog();
            getAllProductToLV();



        }
    }
}
