using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using TestingAPI2;
using System.Collections;
using TestingAPI2.Entities;

namespace TestingWindowsForms
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private ArrayList products;

        public Form1()
        {
            InitializeComponent();
        }        
        
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
            }
            
        }
        
        private void buttonStartCam_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBoxCamDeviceSelect.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(OpenCamFrame);
            cam.Start();
        }

        private void OpenCamFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox.Image = bit;
        }

        private void buttonStopCam_Click(object sender, EventArgs e)
        {
            if (cam != null)
            {
                  if (cam.IsRunning)
                  {
                       cam.Stop();
                  }
            }
        }
        
        private void buttonTakePhoto_Click(object sender, EventArgs e)
        {
            if (cam != null)
            {
                saveFileDialog.InitialDirectory = @"C:\";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(saveFileDialog.FileName);
                    //textBoxOcrResult.Text = Program.ImageToText(openFileDialog.FileName);
                }
            }
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            if (cam != null)
            {
                cam.Stop();
            }
            Application.Exit();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                products = Ocr.GetPrices(openFileDialog.FileName);
                RefreshProductListView();
            }
        }

        private void RefreshProductListView()
        {
            listViewProducts.Items.Clear();
            ListViewItem item;
            foreach (Product entry
                in products)
            {
                item = listViewProducts.Items.Add(entry.name);
                item.SubItems.Add(entry.price);
                listViewProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            if (listViewProducts.Items.Count != 0)
                buttonGetResults.Visible = true;
            else buttonGetResults.Visible = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewProducts.SelectedItems[0];
            using (EditDialogBox db = new EditDialogBox(item.Text, item.SubItems[1].Text))
            {
                if (db.ShowDialog() == DialogResult.OK)
                {
                    products.RemoveAt(listViewProducts.Items.IndexOf(item));
                    products.Add(new Product(db.ReturnValue1.name, db.ReturnValue1.price));
                }
            }
            RefreshProductListView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            products.Remove(listViewProducts.SelectedItems[0].Text);
            RefreshProductListView();
        }

        private void listViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!buttonEdit.Visible)
            {
                buttonEdit.Visible = true;
                buttonDelete.Visible = true;
            }
            else if(listViewProducts.SelectedItems.Count == 0)
            {
                buttonEdit.Visible = false;
                buttonDelete.Visible = false;
            }
        }

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            Repository.WriteToXmlFile(products);
        }
    }
}
