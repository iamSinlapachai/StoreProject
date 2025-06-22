using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class FrmProductUpDel : Form
    {

        // สร้างตัวแปรเก็บ ProId from FrmProductShow
        int proId;
        byte[] proImage; // ตัวแปรสำหรับเก็บข้อมูลรูปภาพในรูปแบบ byte array for save to database


        public FrmProductUpDel(int proId)
        {
            InitializeComponent();
            this.proId = proId; // รับค่า proId จาก FrmProductShow
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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

        private void FrmProductUpDel_Load(object sender, EventArgs e)
        {
            //proId that u got from FrmProductShow and then go search in db
            //and show in FrmProductUpDel

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
                    string strSQL = "select proId, proName, proPrice, proQuan, proUnit, proStatus, proImage, createAt, updateAt from product_tb " +
                        "WHERE proId=@proId";

                    //จัดการให้ SQL ทำงาน
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {

                        // give int to SQL Parameters 
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@proId", proId);

                        //เอาข้อมูลที่ได้จาก strSQl ซึ่งเป็นก้อนใน dataAdapter มาทำให้เป็นตารางโดยใส่ไว้ใน dataTable
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // get data from dataTable โดยใส่ไว้ใน DataRow

                        DataRow row = dataTable.Rows[0]; // get first row from dataTable

                        //เอาข้อมูลที่ได้จาก dataRow มาใช้
                        tbProId.Text = row["proId"].ToString();
                        tbProName.Text = row["proName"].ToString();
                        tbProPrice.Text = row["proPrice"].ToString();
                        tbProUnit.Text = row["proUnit"].ToString();
                        //nudProQuan.Value = Convert.ToDecimal(row["proQuan"]);
                        nudProQuan.Value = int.Parse(row["proQuan"].ToString());
                        if (row["proStatus"].ToString() == "พร้อมขาย")
                        {
                            rdoProStatusOn.Checked = true; // set selected index to "ใช้งาน"
                        }
                        else
                        {
                            rdoProStatusOff.Checked = true; // set selected index to "ไม่ใช้งาน"
                        }
                        //แปลง byte array เป็นรูปภาพ
                        if (row["proImage"] == DBNull.Value)
                        {
                            pcbProImage.Image = null; // ถ้าไม่มีรูปภาพให้แสดงเป็น null
                        }
                        else
                        {
                            pcbProImage.Image = convertByteArrayToImage((byte[])row["proImage"]);
                        }

                    }





                }

                catch (Exception ex)
                {
                    MessageBox.Show("พบข้อผิดพลาด กรุณากรอกใหม่หรือติดต่อ IT : " + ex.Message);
                }

            }


        }

        private void btProDelete_Click(object sender, EventArgs e)
        {
            // delete product in table from database
            //Connect String เพื่อติตต่อไปยังฐานข้อมูล
            string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True;";

            //สร้าง connection ไปยังฐานข้อมูล
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open(); //open connectiong to db
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(); //begin transaction

                    //คำสั่ง SQL ให้เพิ่มข้อมูลลงในตาราง product_tb
                    string strSQL = "DELETE FROM product_tb WHERE proId=@proId";

                    //SQL Parameters to command SQL working
                    using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                    {
                        sqlCommand.Parameters.Add("@proId", SqlDbType.Int).Value = tbProId.Text;


                        // Execute the SQL command to insert data into the database
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();

                        //messege box to show the result of the operation
                        MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("พบข้อผิดพลาด กรุณากรอกใหม่หรือติดต่อ IT : " + ex.Message);
                }
                finally
                {
                    // ปิดฟอร์มหลังจากบันทึกเสร็จ
                    this.Close();
                }
            }
        }


        // Method to show warning message box
        private void showWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Method to convert Image to byte array
        private byte[] convertImageToByteArray(Image image, ImageFormat imageFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, imageFormat);
                return ms.ToArray();
            }
        }

        private void btProUpdate_Click(object sender, EventArgs e)
        {
            // Validate input fields ad save the product to the database
            if (proImage == null)
            {
                showWarningMessage("Please select a product image.");
                return;
            }
            else if (tbProName.Text.Length == 0)
            {
                showWarningMessage("Please enter the product name.");
            }
            else if (tbProPrice.Text.Length == 0)
            {

                showWarningMessage("Please enter the product price.");


            }
            else if (int.Parse(nudProQuan.Value.ToString()) <= 0)
            {
                showWarningMessage("Please enter quantity of the product.");
            }
            else if (tbProUnit.Text.Length == 0)
            {
                showWarningMessage("Please enter product unit.");
            }
            else
            {
                //save the data product to the database
                //Connect String เพื่อติตต่อไปยังฐานข้อมูล
                string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=store_db;Trusted_Connection=True;";

                //สร้าง connection ไปยังฐานข้อมูล
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open(); //open connectiong to db
                        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(); //begin transaction

                        //คำสั่ง SQL ให้เพิ่มข้อมูลลงในตาราง product_tb
                        string strSQL = "UPDATE product_tb SET " +
                            "proName=@proName, proPrice=@proPrice, proQuan=@proQuan, proUnit=@proUnit, " +
                            "proStatus=@proStatus, proImage=@proImage, updateAt=@updateAt WHERE proID=@proID";

                        //SQL Parameters to command SQL working
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.Parameters.Add("@proId", SqlDbType.Int).Value = int.Parse(tbProId.Text);
                            sqlCommand.Parameters.Add("@proName", SqlDbType.NVarChar, 300).Value = tbProName.Text.Trim();
                            sqlCommand.Parameters.Add("@proPrice", SqlDbType.Float).Value = float.Parse(tbProPrice.Text);
                            sqlCommand.Parameters.Add("@proQuan", SqlDbType.Int).Value = int.Parse(nudProQuan.Text.ToString());
                            sqlCommand.Parameters.Add("@proUnit", SqlDbType.NVarChar, 50).Value = tbProUnit.Text.Trim();
                            if (rdoProStatusOn.Checked == true)
                            {
                                sqlCommand.Parameters.Add("@proStatus", SqlDbType.NVarChar, 50).Value = "พร้อมขาย";
                            }
                            else
                            {
                                sqlCommand.Parameters.Add("@proStatus", SqlDbType.NVarChar, 50).Value = "ไม่พร้อมขาย";
                            }
                            sqlCommand.Parameters.Add("@proImage", SqlDbType.Image).Value = proImage; //save image as byte array
                            
                            sqlCommand.Parameters.Add("@updateAt", SqlDbType.Date).Value = DateTime.Now.Date; //set updateAt to current time

                            // Execute the SQL command to insert data into the database
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();

                            //messege box to show the result of the operation
                            MessageBox.Show("บันทึกแก้ไขข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาด กรุณากรอกใหม่หรือติดต่อ IT : " + ex.Message);
                    }
                    finally
                    {
                        // ปิดฟอร์มหลังจากบันทึกเสร็จ
                        this.Close();
                    }
                }
            }
 

        }

        private void btProImage_Click(object sender, EventArgs e)
        {
            //oepn file dialog to select image show only image files jpg, png

            //save the image to the database as byte array(Binary/Byte)
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:\";
            openFileDialog.Filter = "Image Files (*.Jpg;*.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // show the  image in the PictureBox 
                pcbProImage.Image = Image.FromFile(openFileDialog.FileName);
                // check the image format and convert the image to byte array
                if (pcbProImage.Image.RawFormat == ImageFormat.Jpeg)
                {
                    proImage = convertImageToByteArray(pcbProImage.Image, ImageFormat.Jpeg);
                }
                else //if (pcbProImage.Image.RawFormat == ImageFormat.Png)
                {
                    proImage = convertImageToByteArray(pcbProImage.Image, ImageFormat.Png);
                }
                //else
                //{
                //    MessageBox.Show("Please select a valid image file (JPG or PNG).", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

            }
        }
    }
}
