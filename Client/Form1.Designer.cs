namespace Client
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // getProductsBtn
            // 
            this.getProductsBtn.Location = new System.Drawing.Point(24, 12);
            this.getProductsBtn.Name = "getProductsBtn";
            this.getProductsBtn.Size = new System.Drawing.Size(141, 67);
            this.getProductsBtn.TabIndex = 0;
            this.getProductsBtn.Text = "Get Products";
            this.getProductsBtn.UseVisualStyleBackColor = true;
            this.getProductsBtn.Click += new System.EventHandler(this.getProductsBtn_Click);
            // 
            // itemListView1
            // 
            this.itemListView1.Location = new System.Drawing.Point(24, 97);
            this.itemListView1.Name = "itemListView1";
            this.itemListView1.Size = new System.Drawing.Size(453, 367);
            this.itemListView1.TabIndex = 1;
            this.itemListView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 476);
            this.Controls.Add(this.itemListView1);
            this.Controls.Add(this.getProductsBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getProductsBtn;
        private System.Windows.Forms.ListView itemListView1;
    }
}

