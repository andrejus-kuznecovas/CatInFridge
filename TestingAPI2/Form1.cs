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
        private ArrayList newProducts;
        private ArrayList otherProducts;
        private ArrayList shopList;

        public Form1()
        {
            InitializeComponent();
        }        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            otherProducts = new ArrayList();
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in webcam)
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

            RefreshShopList();

            if (comboBoxShopSelect.Items.Count == 0)
            {
                comboBoxShopSelect.Enabled = false;
                radioButtonNewShop.Enabled = false;
                radioButtonShopSelect.Enabled = false;
                textBoxNewShop.ReadOnly = false;
                radioButtonNewShop.Checked = true;
                radioButtonShopSelect.Checked = false;
            }
            else comboBoxShopSelect.SelectedIndex = 0;
        }

        private void RefreshShopList()
        {
            shopList = Repository.ReadShopsFromXmlFile();

            foreach (Shop shop in shopList)
                comboBoxShopSelect.Items.Add(shop.name);
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
                newProducts = Ocr.GetPrices(openFileDialog.FileName);
                if (newProducts == null)
                {
                    MessageBox.Show("Nepavyko nuskaityti jokios prekes.\nBandykite dar karta!");
                    buttonOpenFile_Click(sender, e);
                }
                RefreshNewProductListView();

                otherProducts.Clear();
                listViewSimilar.Items.Clear();
            }
        }

        private void RefreshNewProductListView()
        {
            listViewProducts.Items.Clear();
            ListViewItem item;
            foreach (Tuple<string, string> entry
                in newProducts)
            {
                item = listViewProducts.Items.Add(entry.Item1);
                item.SubItems.Add(entry.Item2);
                listViewProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            if (listViewProducts.Items.Count != 0)
                buttonGetResults.Visible = true;
            else buttonGetResults.Visible = false;

            buttonEdit.Visible = false;
            buttonDelete.Visible = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewProducts.SelectedItems[0];
            using (EditDialogBox db = new EditDialogBox(item.Text, item.SubItems[1].Text))
            {
                if (db.ShowDialog() == DialogResult.OK)
                {
                    newProducts.RemoveAt(listViewProducts.Items.IndexOf(item));
                    newProducts.Add(db.ReturnValue1);
                }
            }
            RefreshNewProductListView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            newProducts.RemoveAt(listViewProducts.SelectedIndices[0]);
            RefreshNewProductListView();
        }

        private void listViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(listViewProducts.SelectedItems.Count == 0 || otherProducts.Count != 0)
            {
                buttonEdit.Visible = false;
                buttonDelete.Visible = false;
            }
            else if (!buttonEdit.Visible)
            {
                buttonEdit.Visible = true;
                buttonDelete.Visible = true;
            }
            if (otherProducts.Count != 0)
                RefreshSimilarProductList();
        }

        private void RefreshSimilarProductList()
        {
            listViewSimilar.Items.Clear();
            ListViewItem item;
            foreach (Product product
                in otherProducts)
            {
                item = listViewSimilar.Items.Add(product.name);
                item.SubItems.Add(product.shop.name);
                item.SubItems.Add(product.price);
                listViewSimilar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            

            Shop newShop;

            if(radioButtonNewShop.Checked)
            {
                newShop = new Shop(textBoxNewShop.Text);
                Repository.WriteShopToXmlFile(newShop);
            }
            else
                newShop = (Shop) shopList[comboBoxShopSelect.SelectedIndex];

            otherProducts = Repository.ReadProductsFromXmlFile();

            Repository.WriteProductsToXmlFile(newProducts, newShop);
        }

        private void radioButtonNewShop_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewShop.ReadOnly = !radioButtonNewShop.Checked;
        }

        private void radioButtonShopSelect_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxShopSelect.Enabled = radioButtonShopSelect.Checked;
        }
    }
}
