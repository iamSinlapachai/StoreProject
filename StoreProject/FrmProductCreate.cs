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
    public partial class FrmProductCreate : Form
    {


        byte[] proImage; // ตัวแปรสำหรับเก็บข้อมูลรูปภาพในรูปแบบ byte array for save to database


        public FrmProductCreate()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void tbProPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // อนุญาตให้พิมพ์ตัวเลข (0-9)
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            // อนุญาตให้พิมพ์ Backspace เพื่อแก้ไขได้
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            // อนุญาตให้พิมพ์จุดทศนิยมได้แค่จุดเดียว
            else if (e.KeyChar == '.')
            {
                if (tb.Text.Contains('.'))
                {
                    // ถ้ามีจุดแล้ว ห้ามพิมพ์ซ้ำ
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                // ห้ามพิมพ์ตัวอื่น ๆ
                e.Handled = true;
            }
        }

        // Method to show warning message box
        private void showWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btSave_Click(object sender, EventArgs e)
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
                        string strSQL = "INSERT INTO product_tb (proName, proPrice, proQuan, proUnit, proStatus, proImage, createAt, updateAt) " +
                                       "VALUES (@proName, @proPrice, @proQuan, @proUnit, @proStatus, @proImage, @createAt, @updateAt)";

                        //SQL Parameters to command SQL working
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
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
                            sqlCommand.Parameters.Add("@createAt", SqlDbType.Date).Value = DateTime.Now.Date; //set createAt to current time
                            sqlCommand.Parameters.Add("@updateAt", SqlDbType.Date).Value = DateTime.Now.Date; //set updateAt to current time

                            // Execute the SQL command to insert data into the database
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();

                            //messege box to show the result of the operation
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //after validate input fields show message box to confirm save and close the form and go back to FrmProductShow
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            //reset all input fields
            proImage = null; //reset proImage to null
            tbProName.Clear(); //clear product name text box
            tbProPrice.Clear(); //clear product price text box
            nudProQuan.Value = 0; //reset product quantity to 0
            tbProUnit.Clear(); //clear product unit text box
            pcbProImage.Image = null; //clear product image PictureBox
        }
    }
}
