using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using TestingAPI2;

namespace TestingWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo VideoCaptureDevice in webcam)
            {
                comboBoxCamDeviceSelect.Items.Add(VideoCaptureDevice.Name);
            }
            if (webcam.Count > 0)
            {
                comboBoxCamDeviceSelect.SelectedIndex = 0;
            }
            else
            {
                buttonStartCam.Dispose();
                buttonTakePhoto.Dispose();
                buttonStopCam.Dispose();
                comboBoxCamDeviceSelect.Dispose();
                pictureBox.Dispose();
                //System.Windows.Forms.MessageBox.Show("Sorry there are no cameras available on your device");
                //System.Windows.Forms.Application.Exit();
            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBoxCamDeviceSelect.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox.Image = bit;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cam != null)
            {
                  if (cam.IsRunning)
                  {
                       cam.Stop();
                  }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (cam != null)
            {
                saveFileDialog.InitialDirectory = @"C:\";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(saveFileDialog.FileName);
                    Program obj = new Program();
                    textBoxOcrResult.Text = obj.ImageToText(openFileDialog.FileName);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null)
            {
                cam.Stop();
            }
            System.Windows.Forms.Application.Exit();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program obj = new Program();
                textBoxOcrResult.Text = obj.ImageToText(openFileDialog.FileName);
            }
        }
    }
}
