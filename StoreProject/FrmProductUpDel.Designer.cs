﻿namespace StoreProject
{
    partial class FrmProductUpDel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(248, 424);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 17);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.Text = "ไม่พร้อมขาย";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(147, 364);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(184, 20);
            this.numericUpDown1.TabIndex = 23;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(147, 424);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "พร้อมขาย";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(140, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 148);
            this.panel1.TabIndex = 20;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(147, 393);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(184, 20);
            this.textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 333);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 20);
            this.textBox2.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 20);
            this.textBox1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(38, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "สถานะสินค้า";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(38, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "หน่วยสินค้า";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(38, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "จำนวนสินค้า";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(38, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "ราคาสินค้า";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(38, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "ชื่อสินค้า";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 53);
            this.label1.TabIndex = 11;
            this.label1.Text = "แก้ไข/ลบสินค้า";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Image = global::StoreProject.Properties.Resources.update;
            this.button3.Location = new System.Drawing.Point(234, 476);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 48);
            this.button3.TabIndex = 25;
            this.button3.Text = "บันทึกแก้ไขสินค้า";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::StoreProject.Properties.Resources.delete;
            this.button2.Location = new System.Drawing.Point(109, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 48);
            this.button2.TabIndex = 26;
            this.button2.Text = "ยกเลิก";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 142);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(147, 275);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(184, 20);
            this.textBox4.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(38, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 27;
            this.label7.Text = "รหัสสินค้า";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmProductUpDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 554);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmProductUpDel";
            this.Text = "แก้ไข/ลบสินค้า - บริการจัดการข้อมูลสินค้า";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
    }
}