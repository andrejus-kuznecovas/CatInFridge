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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.textBoxOcrResult = new System.Windows.Forms.TextBox();
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
            this.buttonStartCam.Click += new System.EventHandler(this.button1_Click);
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
            this.buttonTakePhoto.Click += new System.EventHandler(this.button2_Click);
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
            this.buttonStopCam.Click += new System.EventHandler(this.button3_Click);
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
            // textBoxOcrResult
            // 
            this.textBoxOcrResult.Location = new System.Drawing.Point(12, 53);
            this.textBoxOcrResult.Margin = new System.Windows.Forms.Padding(12);
            this.textBoxOcrResult.Multiline = true;
            this.textBoxOcrResult.Name = "textBoxOcrResult";
            this.textBoxOcrResult.Size = new System.Drawing.Size(237, 397);
            this.textBoxOcrResult.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1113, 462);
            this.Controls.Add(this.textBoxOcrResult);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.comboBoxCamDeviceSelect);
            this.Controls.Add(this.buttonStopCam);
            this.Controls.Add(this.buttonTakePhoto);
            this.Controls.Add(this.buttonStartCam);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque comparer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.TextBox textBoxOcrResult;
    }
}

