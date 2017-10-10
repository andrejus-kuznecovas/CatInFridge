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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(567, 11);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(478, 378);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonStartCam
            // 
            this.buttonStartCam.Location = new System.Drawing.Point(567, 418);
            this.buttonStartCam.Margin = new System.Windows.Forms.Padding(12);
            this.buttonStartCam.Name = "buttonStartCam";
            this.buttonStartCam.Size = new System.Drawing.Size(92, 35);
            this.buttonStartCam.TabIndex = 2;
            this.buttonStartCam.Text = "Start";
            this.buttonStartCam.UseVisualStyleBackColor = true;
            this.buttonStartCam.Click += new System.EventHandler(this.buttonStartCam_Click);
            // 
            // buttonTakePhoto
            // 
            this.buttonTakePhoto.Location = new System.Drawing.Point(760, 418);
            this.buttonTakePhoto.Margin = new System.Windows.Forms.Padding(12);
            this.buttonTakePhoto.Name = "buttonTakePhoto";
            this.buttonTakePhoto.Size = new System.Drawing.Size(91, 35);
            this.buttonTakePhoto.TabIndex = 3;
            this.buttonTakePhoto.Text = "Take a photo";
            this.buttonTakePhoto.UseVisualStyleBackColor = true;
            this.buttonTakePhoto.Click += new System.EventHandler(this.buttonTakePhoto_Click);
            // 
            // buttonStopCam
            // 
            this.buttonStopCam.Location = new System.Drawing.Point(957, 418);
            this.buttonStopCam.Margin = new System.Windows.Forms.Padding(12);
            this.buttonStopCam.Name = "buttonStopCam";
            this.buttonStopCam.Size = new System.Drawing.Size(88, 35);
            this.buttonStopCam.TabIndex = 4;
            this.buttonStopCam.Text = "Stop";
            this.buttonStopCam.UseVisualStyleBackColor = true;
            this.buttonStopCam.Click += new System.EventHandler(this.buttonStopCam_Click);
            // 
            // comboBoxCamDeviceSelect
            // 
            this.comboBoxCamDeviceSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCamDeviceSelect.FormattingEnabled = true;
            this.comboBoxCamDeviceSelect.Location = new System.Drawing.Point(567, 393);
            this.comboBoxCamDeviceSelect.Margin = new System.Windows.Forms.Padding(12);
            this.comboBoxCamDeviceSelect.Name = "comboBoxCamDeviceSelect";
            this.comboBoxCamDeviceSelect.Size = new System.Drawing.Size(479, 21);
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
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
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
            this.listViewProducts.Location = new System.Drawing.Point(12, 51);
            this.listViewProducts.MultiSelect = false;
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(233, 399);
            this.listViewProducts.TabIndex = 7;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.Details;
            this.listViewProducts.SelectedIndexChanged += new System.EventHandler(this.listViewProducts_SelectedIndexChanged);
            // 
            // listViewSimilar
            // 
            this.listViewSimilar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewSimilar.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSimilar.Location = new System.Drawing.Point(319, 51);
            this.listViewSimilar.MultiSelect = false;
            this.listViewSimilar.Name = "listViewSimilar";
            this.listViewSimilar.Size = new System.Drawing.Size(233, 399);
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
            this.buttonEdit.Location = new System.Drawing.Point(102, 11);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(71, 23);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(192, 11);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(71, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonGetResults
            // 
            this.buttonGetResults.Location = new System.Drawing.Point(319, 11);
            this.buttonGetResults.Name = "buttonGetResults";
            this.buttonGetResults.Size = new System.Drawing.Size(71, 23);
            this.buttonGetResults.TabIndex = 11;
            this.buttonGetResults.Text = "Get results";
            this.buttonGetResults.UseVisualStyleBackColor = true;
            this.buttonGetResults.Visible = false;
            this.buttonGetResults.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1113, 462);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque comparer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseForm);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

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
    }
}

