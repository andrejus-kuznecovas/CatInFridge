namespace Client
{
    partial class ProductsStats
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
            this.getProductsBtn = new System.Windows.Forms.Button();
            this.itemListView1 = new System.Windows.Forms.ListView();
            this.OpenPictureBtn = new System.Windows.Forms.Button();
            this.openedPictureTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getProductsBtn
            // 
            this.getProductsBtn.Location = new System.Drawing.Point(253, 11);
            this.getProductsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.getProductsBtn.Name = "getProductsBtn";
            this.getProductsBtn.Size = new System.Drawing.Size(106, 54);
            this.getProductsBtn.TabIndex = 0;
            this.getProductsBtn.Text = "Get Products";
            this.getProductsBtn.UseVisualStyleBackColor = true;
            this.getProductsBtn.Click += new System.EventHandler(this.GetProductsBtn_Click);
            // 
            // itemListView1
            // 
            this.itemListView1.Location = new System.Drawing.Point(11, 79);
            this.itemListView1.Margin = new System.Windows.Forms.Padding(2);
            this.itemListView1.Name = "itemListView1";
            this.itemListView1.Size = new System.Drawing.Size(363, 258);
            this.itemListView1.TabIndex = 1;
            this.itemListView1.UseCompatibleStateImageBehavior = false;
            // 
            // OpenPictureBtn
            // 
            this.OpenPictureBtn.Location = new System.Drawing.Point(18, 11);
            this.OpenPictureBtn.Name = "OpenPictureBtn";
            this.OpenPictureBtn.Size = new System.Drawing.Size(80, 54);
            this.OpenPictureBtn.TabIndex = 2;
            this.OpenPictureBtn.Text = "Open Picture";
            this.OpenPictureBtn.UseVisualStyleBackColor = true;
            this.OpenPictureBtn.Click += new System.EventHandler(this.OpenPictureBtn_Click);
            // 
            // openedPictureTxt
            // 
            this.openedPictureTxt.Location = new System.Drawing.Point(104, 29);
            this.openedPictureTxt.Name = "openedPictureTxt";
            this.openedPictureTxt.Size = new System.Drawing.Size(144, 20);
            this.openedPictureTxt.TabIndex = 3;
            this.openedPictureTxt.TextChanged += new System.EventHandler(this.OpenedPicturesTxt_TextChanged);
            // 
            // ProductsStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 387);
            this.Controls.Add(this.openedPictureTxt);
            this.Controls.Add(this.OpenPictureBtn);
            this.Controls.Add(this.itemListView1);
            this.Controls.Add(this.getProductsBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductsStats";
            this.Text = "Products & Stats";
            this.Load += new System.EventHandler(this.ProductsStats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getProductsBtn;
        private System.Windows.Forms.ListView itemListView1;
        private System.Windows.Forms.Button OpenPictureBtn;
        private System.Windows.Forms.TextBox openedPictureTxt;
    }
}

