using System;

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
            this.openPicBtn = new System.Windows.Forms.Button();
            this.productsView = new System.Windows.Forms.ListView();
            this.picLocationBox = new System.Windows.Forms.TextBox();
            this.getProdsBtn = new System.Windows.Forms.Button();
            this.getStatsBtn = new System.Windows.Forms.Button();
            this.spendingsByCategoryLabel = new System.Windows.Forms.Label();
            this.spendingsByCategoryView = new System.Windows.Forms.ListView();
            this.spendingsByShopLabel = new System.Windows.Forms.Label();
            this.spendingsByShopView = new System.Windows.Forms.ListView();
            this.avgSpendingsByCategoryLabel = new System.Windows.Forms.Label();
            this.avgSpendingsByCategoryView = new System.Windows.Forms.ListView();
            this.avgSpendingsByShopView = new System.Windows.Forms.ListView();
            this.avgSpendingsByShopLabel = new System.Windows.Forms.Label();
            this.mostPopularByCategoryLabel = new System.Windows.Forms.Label();
            this.mostPopularByShopLabel = new System.Windows.Forms.Label();
            this.cheapestByCategoryLabel = new System.Windows.Forms.Label();
            this.cheapestByShopLabel = new System.Windows.Forms.Label();
            this.mostPopularByCategoryView = new System.Windows.Forms.ListView();
            this.mostPopularByShopView = new System.Windows.Forms.ListView();
            this.cheapestByCategoryView = new System.Windows.Forms.ListView();
            this.cheapestByShopView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // openPicBtn
            // 
            this.openPicBtn.ForeColor = System.Drawing.Color.Black;
            this.openPicBtn.Location = new System.Drawing.Point(12, 12);
            this.openPicBtn.Name = "openPicBtn";
            this.openPicBtn.Size = new System.Drawing.Size(87, 49);
            this.openPicBtn.TabIndex = 0;
            this.openPicBtn.Text = "Open Picture";
            this.openPicBtn.UseVisualStyleBackColor = true;
            this.openPicBtn.Click += new System.EventHandler(this.OpenPicBtn_Click);
            // 
            // productsView
            // 
            this.productsView.Location = new System.Drawing.Point(12, 67);
            this.productsView.Name = "productsView";
            this.productsView.Size = new System.Drawing.Size(645, 165);
            this.productsView.TabIndex = 1;
            this.productsView.UseCompatibleStateImageBehavior = false;
            this.productsView.SelectedIndexChanged += new System.EventHandler(this.productsView_SelectedIndexChanged);
            // 
            // picLocationBox
            // 
            this.picLocationBox.Location = new System.Drawing.Point(105, 30);
            this.picLocationBox.Name = "picLocationBox";
            this.picLocationBox.Size = new System.Drawing.Size(358, 22);
            this.picLocationBox.TabIndex = 2;
            this.picLocationBox.TextChanged += new System.EventHandler(this.picLocationBox_TextChanged);
            // 
            // getProdsBtn
            // 
            this.getProdsBtn.ForeColor = System.Drawing.Color.Black;
            this.getProdsBtn.Location = new System.Drawing.Point(469, 12);
            this.getProdsBtn.Name = "getProdsBtn";
            this.getProdsBtn.Size = new System.Drawing.Size(92, 49);
            this.getProdsBtn.TabIndex = 3;
            this.getProdsBtn.Text = "Get Products";
            this.getProdsBtn.UseVisualStyleBackColor = true;
            this.getProdsBtn.Click += new System.EventHandler(this.getProdsBtn_Click);
            // 
            // getStatsBtn
            // 
            this.getStatsBtn.ForeColor = System.Drawing.Color.Black;
            this.getStatsBtn.Location = new System.Drawing.Point(567, 12);
            this.getStatsBtn.Name = "getStatsBtn";
            this.getStatsBtn.Size = new System.Drawing.Size(90, 49);
            this.getStatsBtn.TabIndex = 4;
            this.getStatsBtn.Text = "Get Statistics";
            this.getStatsBtn.UseVisualStyleBackColor = true;
            this.getStatsBtn.Click += new System.EventHandler(this.GetStatsBtn_Click);
            // 
            // spendingsByCategoryLabel
            // 
            this.spendingsByCategoryLabel.AutoSize = true;
            this.spendingsByCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.spendingsByCategoryLabel.Location = new System.Drawing.Point(12, 244);
            this.spendingsByCategoryLabel.Name = "spendingsByCategoryLabel";
            this.spendingsByCategoryLabel.Size = new System.Drawing.Size(156, 17);
            this.spendingsByCategoryLabel.TabIndex = 5;
            this.spendingsByCategoryLabel.Text = "Spendings By Category";
            this.spendingsByCategoryLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // spendingsByCategoryView
            // 
            this.spendingsByCategoryView.Location = new System.Drawing.Point(12, 264);
            this.spendingsByCategoryView.Name = "spendingsByCategoryView";
            this.spendingsByCategoryView.Size = new System.Drawing.Size(156, 199);
            this.spendingsByCategoryView.TabIndex = 6;
            this.spendingsByCategoryView.UseCompatibleStateImageBehavior = false;
            this.spendingsByCategoryView.SelectedIndexChanged += new System.EventHandler(this.spendingsByCategoryView_SelectedIndexChanged);
            // 
            // spendingsByShopLabel
            // 
            this.spendingsByShopLabel.AutoSize = true;
            this.spendingsByShopLabel.ForeColor = System.Drawing.Color.Black;
            this.spendingsByShopLabel.Location = new System.Drawing.Point(174, 244);
            this.spendingsByShopLabel.Name = "spendingsByShopLabel";
            this.spendingsByShopLabel.Size = new System.Drawing.Size(132, 17);
            this.spendingsByShopLabel.TabIndex = 7;
            this.spendingsByShopLabel.Text = "Spendings By Shop";
            // 
            // spendingsByShopView
            // 
            this.spendingsByShopView.Location = new System.Drawing.Point(177, 264);
            this.spendingsByShopView.Name = "spendingsByShopView";
            this.spendingsByShopView.Size = new System.Drawing.Size(156, 199);
            this.spendingsByShopView.TabIndex = 8;
            this.spendingsByShopView.UseCompatibleStateImageBehavior = false;
            // 
            // avgSpendingsByCategoryLabel
            // 
            this.avgSpendingsByCategoryLabel.AutoSize = true;
            this.avgSpendingsByCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.avgSpendingsByCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.avgSpendingsByCategoryLabel.Location = new System.Drawing.Point(337, 246);
            this.avgSpendingsByCategoryLabel.Name = "avgSpendingsByCategoryLabel";
            this.avgSpendingsByCategoryLabel.Size = new System.Drawing.Size(158, 15);
            this.avgSpendingsByCategoryLabel.TabIndex = 9;
            this.avgSpendingsByCategoryLabel.Text = "Avg. Spendings By Category";
            this.avgSpendingsByCategoryLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // avgSpendingsByCategoryView
            // 
            this.avgSpendingsByCategoryView.Location = new System.Drawing.Point(339, 264);
            this.avgSpendingsByCategoryView.Name = "avgSpendingsByCategoryView";
            this.avgSpendingsByCategoryView.Size = new System.Drawing.Size(156, 199);
            this.avgSpendingsByCategoryView.TabIndex = 10;
            this.avgSpendingsByCategoryView.UseCompatibleStateImageBehavior = false;
            // 
            // avgSpendingsByShopView
            // 
            this.avgSpendingsByShopView.Location = new System.Drawing.Point(501, 264);
            this.avgSpendingsByShopView.Name = "avgSpendingsByShopView";
            this.avgSpendingsByShopView.Size = new System.Drawing.Size(156, 199);
            this.avgSpendingsByShopView.TabIndex = 11;
            this.avgSpendingsByShopView.UseCompatibleStateImageBehavior = false;
            this.avgSpendingsByShopView.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // avgSpendingsByShopLabel
            // 
            this.avgSpendingsByShopLabel.AutoSize = true;
            this.avgSpendingsByShopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.avgSpendingsByShopLabel.ForeColor = System.Drawing.Color.Black;
            this.avgSpendingsByShopLabel.Location = new System.Drawing.Point(498, 246);
            this.avgSpendingsByShopLabel.Name = "avgSpendingsByShopLabel";
            this.avgSpendingsByShopLabel.Size = new System.Drawing.Size(139, 15);
            this.avgSpendingsByShopLabel.TabIndex = 12;
            this.avgSpendingsByShopLabel.Text = "Avg. Spendings By Shop";
            this.avgSpendingsByShopLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // mostPopularByCategoryLabel
            // 
            this.mostPopularByCategoryLabel.AutoSize = true;
            this.mostPopularByCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.mostPopularByCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.mostPopularByCategoryLabel.Location = new System.Drawing.Point(9, 477);
            this.mostPopularByCategoryLabel.Name = "mostPopularByCategoryLabel";
            this.mostPopularByCategoryLabel.Size = new System.Drawing.Size(147, 15);
            this.mostPopularByCategoryLabel.TabIndex = 13;
            this.mostPopularByCategoryLabel.Text = "Most Popular By Category";
            // 
            // mostPopularByShopLabel
            // 
            this.mostPopularByShopLabel.AutoSize = true;
            this.mostPopularByShopLabel.ForeColor = System.Drawing.Color.Black;
            this.mostPopularByShopLabel.Location = new System.Drawing.Point(174, 477);
            this.mostPopularByShopLabel.Name = "mostPopularByShopLabel";
            this.mostPopularByShopLabel.Size = new System.Drawing.Size(148, 17);
            this.mostPopularByShopLabel.TabIndex = 14;
            this.mostPopularByShopLabel.Text = "Most Popular By Shop";
            // 
            // cheapestByCategoryLabel
            // 
            this.cheapestByCategoryLabel.AutoSize = true;
            this.cheapestByCategoryLabel.ForeColor = System.Drawing.Color.Black;
            this.cheapestByCategoryLabel.Location = new System.Drawing.Point(336, 477);
            this.cheapestByCategoryLabel.Name = "cheapestByCategoryLabel";
            this.cheapestByCategoryLabel.Size = new System.Drawing.Size(149, 17);
            this.cheapestByCategoryLabel.TabIndex = 15;
            this.cheapestByCategoryLabel.Text = "Cheapest By Category";
            // 
            // cheapestByShopLabel
            // 
            this.cheapestByShopLabel.AutoSize = true;
            this.cheapestByShopLabel.ForeColor = System.Drawing.Color.Black;
            this.cheapestByShopLabel.Location = new System.Drawing.Point(498, 477);
            this.cheapestByShopLabel.Name = "cheapestByShopLabel";
            this.cheapestByShopLabel.Size = new System.Drawing.Size(125, 17);
            this.cheapestByShopLabel.TabIndex = 16;
            this.cheapestByShopLabel.Text = "Cheapest By Shop";
            // 
            // mostPopularByCategoryView
            // 
            this.mostPopularByCategoryView.Location = new System.Drawing.Point(12, 495);
            this.mostPopularByCategoryView.Name = "mostPopularByCategoryView";
            this.mostPopularByCategoryView.Size = new System.Drawing.Size(156, 199);
            this.mostPopularByCategoryView.TabIndex = 17;
            this.mostPopularByCategoryView.UseCompatibleStateImageBehavior = false;
            // 
            // mostPopularByShopView
            // 
            this.mostPopularByShopView.Location = new System.Drawing.Point(177, 497);
            this.mostPopularByShopView.Name = "mostPopularByShopView";
            this.mostPopularByShopView.Size = new System.Drawing.Size(156, 199);
            this.mostPopularByShopView.TabIndex = 18;
            this.mostPopularByShopView.UseCompatibleStateImageBehavior = false;
            // 
            // cheapestByCategoryView
            // 
            this.cheapestByCategoryView.Location = new System.Drawing.Point(340, 497);
            this.cheapestByCategoryView.Name = "cheapestByCategoryView";
            this.cheapestByCategoryView.Size = new System.Drawing.Size(156, 199);
            this.cheapestByCategoryView.TabIndex = 19;
            this.cheapestByCategoryView.UseCompatibleStateImageBehavior = false;
            // 
            // cheapestByShopView
            // 
            this.cheapestByShopView.Location = new System.Drawing.Point(501, 497);
            this.cheapestByShopView.Name = "cheapestByShopView";
            this.cheapestByShopView.Size = new System.Drawing.Size(156, 199);
            this.cheapestByShopView.TabIndex = 20;
            this.cheapestByShopView.UseCompatibleStateImageBehavior = false;
            // 
            // ProductsStats
            // 
            this.ClientSize = new System.Drawing.Size(666, 703);
            this.Controls.Add(this.cheapestByShopView);
            this.Controls.Add(this.cheapestByCategoryView);
            this.Controls.Add(this.mostPopularByShopView);
            this.Controls.Add(this.mostPopularByCategoryView);
            this.Controls.Add(this.cheapestByShopLabel);
            this.Controls.Add(this.cheapestByCategoryLabel);
            this.Controls.Add(this.mostPopularByShopLabel);
            this.Controls.Add(this.mostPopularByCategoryLabel);
            this.Controls.Add(this.avgSpendingsByShopLabel);
            this.Controls.Add(this.avgSpendingsByShopView);
            this.Controls.Add(this.avgSpendingsByCategoryView);
            this.Controls.Add(this.avgSpendingsByCategoryLabel);
            this.Controls.Add(this.spendingsByShopView);
            this.Controls.Add(this.spendingsByShopLabel);
            this.Controls.Add(this.spendingsByCategoryView);
            this.Controls.Add(this.spendingsByCategoryLabel);
            this.Controls.Add(this.getStatsBtn);
            this.Controls.Add(this.getProdsBtn);
            this.Controls.Add(this.picLocationBox);
            this.Controls.Add(this.productsView);
            this.Controls.Add(this.openPicBtn);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "ProductsStats";
            this.Load += new System.EventHandler(this.ProductsStats_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button openPicBtn;
        private System.Windows.Forms.ListView productsView;
        private System.Windows.Forms.TextBox picLocationBox;
        private System.Windows.Forms.Button getProdsBtn;
        private System.Windows.Forms.Button getStatsBtn;
        private System.Windows.Forms.Label spendingsByCategoryLabel;
        private System.Windows.Forms.ListView spendingsByCategoryView;
        private System.Windows.Forms.Label spendingsByShopLabel;
        private System.Windows.Forms.ListView spendingsByShopView;
        private System.Windows.Forms.Label avgSpendingsByCategoryLabel;
        private System.Windows.Forms.ListView avgSpendingsByCategoryView;
        private System.Windows.Forms.ListView avgSpendingsByShopView;
        private System.Windows.Forms.Label avgSpendingsByShopLabel;
        private System.Windows.Forms.Label mostPopularByCategoryLabel;
        private System.Windows.Forms.Label mostPopularByShopLabel;
        private System.Windows.Forms.Label cheapestByCategoryLabel;
        private System.Windows.Forms.Label cheapestByShopLabel;
        private System.Windows.Forms.ListView mostPopularByCategoryView;
        private System.Windows.Forms.ListView mostPopularByShopView;
        private System.Windows.Forms.ListView cheapestByCategoryView;
        private System.Windows.Forms.ListView cheapestByShopView;
    }
}

