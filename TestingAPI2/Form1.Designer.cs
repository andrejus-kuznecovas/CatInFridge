namespace TestingWindowsForms
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonStartCam = new System.Windows.Forms.Button();
            this.buttonTakePhoto = new System.Windows.Forms.Button();
            this.buttonStopCam = new System.Windows.Forms.Button();
            this.comboBoxCamDeviceSelect = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.listViewSimilar = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonGetResults = new System.Windows.Forms.Button();
            this.radioButtonShopSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonNewShop = new System.Windows.Forms.RadioButton();
            this.comboBoxShopSelect = new System.Windows.Forms.ComboBox();
            this.textBoxNewShop = new System.Windows.Forms.TextBox();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(756, 14);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(637, 465);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonStartCam
            // 
            this.buttonStartCam.Location = new System.Drawing.Point(756, 514);
            this.buttonStartCam.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.buttonStartCam.Name = "buttonStartCam";
            this.buttonStartCam.Size = new System.Drawing.Size(123, 43);
            this.buttonStartCam.TabIndex = 2;
            this.buttonStartCam.Text = "Start";
            this.buttonStartCam.UseVisualStyleBackColor = true;
            this.buttonStartCam.Click += new System.EventHandler(this.buttonStartCam_Click);
            // 
            // buttonTakePhoto
            // 
            this.buttonTakePhoto.Location = new System.Drawing.Point(1013, 514);
            this.buttonTakePhoto.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.buttonTakePhoto.Name = "buttonTakePhoto";
            this.buttonTakePhoto.Size = new System.Drawing.Size(121, 43);
            this.buttonTakePhoto.TabIndex = 3;
            this.buttonTakePhoto.Text = "Take a photo";
            this.buttonTakePhoto.UseVisualStyleBackColor = true;
            this.buttonTakePhoto.Click += new System.EventHandler(this.buttonTakePhoto_Click);
            // 
            // buttonStopCam
            // 
            this.buttonStopCam.Location = new System.Drawing.Point(1276, 514);
            this.buttonStopCam.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.buttonStopCam.Name = "buttonStopCam";
            this.buttonStopCam.Size = new System.Drawing.Size(117, 43);
            this.buttonStopCam.TabIndex = 4;
            this.buttonStopCam.Text = "Stop";
            this.buttonStopCam.UseVisualStyleBackColor = true;
            this.buttonStopCam.Click += new System.EventHandler(this.buttonStopCam_Click);
            // 
            // comboBoxCamDeviceSelect
            // 
            this.comboBoxCamDeviceSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCamDeviceSelect.FormattingEnabled = true;
            this.comboBoxCamDeviceSelect.Location = new System.Drawing.Point(756, 484);
            this.comboBoxCamDeviceSelect.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.comboBoxCamDeviceSelect.Name = "comboBoxCamDeviceSelect";
            this.comboBoxCamDeviceSelect.Size = new System.Drawing.Size(637, 24);
            this.comboBoxCamDeviceSelect.TabIndex = 5;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "jpg Image|*.jpg";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(16, 15);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(100, 28);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "Open";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 50;
            // 
            // listViewProducts
            // 
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewProducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewProducts.Location = new System.Drawing.Point(16, 63);
            this.listViewProducts.Margin = new System.Windows.Forms.Padding(4);
            this.listViewProducts.MultiSelect = false;
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(309, 490);
            this.listViewProducts.TabIndex = 7;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.Details;
            this.listViewProducts.SelectedIndexChanged += new System.EventHandler(this.listViewProducts_SelectedIndexChanged);
            // 
            // listViewSimilar
            // 
            this.listViewSimilar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewSimilar.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSimilar.Location = new System.Drawing.Point(360, 166);
            this.listViewSimilar.Margin = new System.Windows.Forms.Padding(4);
            this.listViewSimilar.MultiSelect = false;
            this.listViewSimilar.Name = "listViewSimilar";
            this.listViewSimilar.Size = new System.Drawing.Size(374, 387);
            this.listViewSimilar.TabIndex = 8;
            this.listViewSimilar.UseCompatibleStateImageBehavior = false;
            this.listViewSimilar.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 135;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 50;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(136, 14);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(95, 28);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(256, 14);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(95, 28);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonGetResults
            // 
            this.buttonGetResults.Location = new System.Drawing.Point(639, 15);
            this.buttonGetResults.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetResults.Name = "buttonGetResults";
            this.buttonGetResults.Size = new System.Drawing.Size(95, 28);
            this.buttonGetResults.TabIndex = 11;
            this.buttonGetResults.Text = "Get results";
            this.buttonGetResults.UseVisualStyleBackColor = true;
            this.buttonGetResults.Visible = false;
            this.buttonGetResults.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // radioButtonShopSelect
            // 
            this.radioButtonShopSelect.AutoSize = true;
            this.radioButtonShopSelect.Checked = true;
            this.radioButtonShopSelect.Location = new System.Drawing.Point(360, 63);
            this.radioButtonShopSelect.Name = "radioButtonShopSelect";
            this.radioButtonShopSelect.Size = new System.Drawing.Size(17, 16);
            this.radioButtonShopSelect.TabIndex = 12;
            this.radioButtonShopSelect.TabStop = true;
            this.radioButtonShopSelect.UseVisualStyleBackColor = true;
            this.radioButtonShopSelect.CheckedChanged += new System.EventHandler(this.radioButtonShopSelect_CheckedChanged);
            // 
            // radioButtonNewShop
            // 
            this.radioButtonNewShop.AutoSize = true;
            this.radioButtonNewShop.Location = new System.Drawing.Point(360, 94);
            this.radioButtonNewShop.Name = "radioButtonNewShop";
            this.radioButtonNewShop.Size = new System.Drawing.Size(17, 16);
            this.radioButtonNewShop.TabIndex = 13;
            this.radioButtonNewShop.TabStop = true;
            this.radioButtonNewShop.UseVisualStyleBackColor = true;
            this.radioButtonNewShop.CheckedChanged += new System.EventHandler(this.radioButtonNewShop_CheckedChanged);
            // 
            // comboBoxShopSelect
            // 
            this.comboBoxShopSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShopSelect.FormattingEnabled = true;
            this.comboBoxShopSelect.Location = new System.Drawing.Point(397, 53);
            this.comboBoxShopSelect.Name = "comboBoxShopSelect";
            this.comboBoxShopSelect.Size = new System.Drawing.Size(197, 24);
            this.comboBoxShopSelect.TabIndex = 14;
            // 
            // textBoxNewShop
            // 
            this.textBoxNewShop.Location = new System.Drawing.Point(397, 94);
            this.textBoxNewShop.Name = "textBoxNewShop";
            this.textBoxNewShop.ReadOnly = true;
            this.textBoxNewShop.Size = new System.Drawing.Size(197, 22);
            this.textBoxNewShop.TabIndex = 15;
            this.textBoxNewShop.Text = "New shop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1484, 569);
            this.Controls.Add(this.textBoxNewShop);
            this.Controls.Add(this.comboBoxShopSelect);
            this.Controls.Add(this.radioButtonNewShop);
            this.Controls.Add(this.radioButtonShopSelect);
            this.Controls.Add(this.buttonGetResults);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.listViewSimilar);
            this.Controls.Add(this.listViewProducts);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.comboBoxCamDeviceSelect);
            this.Controls.Add(this.buttonStopCam);
            this.Controls.Add(this.buttonTakePhoto);
            this.Controls.Add(this.buttonStartCam);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque comparer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseForm);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonStartCam;
        private System.Windows.Forms.Button buttonTakePhoto;
        private System.Windows.Forms.Button buttonStopCam;
        private System.Windows.Forms.ComboBox comboBoxCamDeviceSelect;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewProducts;
        private System.Windows.Forms.ListView listViewSimilar;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonGetResults;
        private System.Windows.Forms.RadioButton radioButtonShopSelect;
        private System.Windows.Forms.RadioButton radioButtonNewShop;
        private System.Windows.Forms.ComboBox comboBoxShopSelect;
        private System.Windows.Forms.TextBox textBoxNewShop;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

