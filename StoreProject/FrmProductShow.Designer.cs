namespace StoreProject
{
    partial class FrmProductShow
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvAllProduct = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFrmProductCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(720, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "บริหารจัดการข้อมูลสินค้า";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvAllProduct
            // 
            this.lvAllProduct.HideSelection = false;
            this.lvAllProduct.Location = new System.Drawing.Point(37, 85);
            this.lvAllProduct.Name = "lvAllProduct";
            this.lvAllProduct.Size = new System.Drawing.Size(720, 249);
            this.lvAllProduct.TabIndex = 1;
            this.lvAllProduct.UseCompatibleStateImageBehavior = false;
            this.lvAllProduct.ItemActivate += new System.EventHandler(this.lvAllProduct_ItemActivate);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(439, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "*เมื่อต้องการแก้ไขหรือลบข้อมูลสินค้า ให้ดับเบิ้ลคลิกที่รายการ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnFrmProductCreate
            // 
            this.btnFrmProductCreate.Image = global::StoreProject.Properties.Resources.basket;
            this.btnFrmProductCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFrmProductCreate.Location = new System.Drawing.Point(613, 356);
            this.btnFrmProductCreate.Name = "btnFrmProductCreate";
            this.btnFrmProductCreate.Size = new System.Drawing.Size(144, 40);
            this.btnFrmProductCreate.TabIndex = 2;
            this.btnFrmProductCreate.Text = "เพิ่มข้อมูลสินค้า";
            this.btnFrmProductCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFrmProductCreate.UseVisualStyleBackColor = true;
            this.btnFrmProductCreate.Click += new System.EventHandler(this.btnFrmProductCreate_Click);
            // 
            // FrmProductShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFrmProductCreate);
            this.Controls.Add(this.lvAllProduct);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmProductShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บริการจัดการข้อมูลสินค้า";
            this.Load += new System.EventHandler(this.FrmProductShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvAllProduct;
        private System.Windows.Forms.Button btnFrmProductCreate;
        private System.Windows.Forms.Label label2;
    }
}

