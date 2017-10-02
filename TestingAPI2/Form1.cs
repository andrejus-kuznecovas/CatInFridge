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
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            if (webcam.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Sorry there are no cameras available on your device");
                System.Windows.Forms.Application.Exit();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
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
                saveFileDialog1.InitialDirectory = @"D:\Visual Studio Projects\Testing Visual Studio\TestingWinForms\Pictures";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
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
    }
}
