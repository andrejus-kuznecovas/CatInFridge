using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*CLIENT EXAMPLE*/
/*while adding service reference go to advanced and select System.Collections.Generic.List*/
namespace Client
{
    public partial class ProductsStats : Form
    {
        public ProductsStats()
        {
            InitializeComponent();
        }

        private void GetProductsBtn_Click(object sender, EventArgs e)
        {
            if (openedPictureTxt.TextLength == 0)
            {
                //TODO: Open error windows "Picture has not been selected"
            }

            BLService.BLServiceClient client = new BLService.BLServiceClient(); //may need to specify binding here: ... = new BLService.BLServiceClient(basiHttpBinding_IBLService);

            Bitmap img = new Bitmap(openedPictureTxt.Text);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, img.RawFormat);
            byte[] result = stream.ToArray();

            List<BLService.Product> productsList = client.GetPrices(result);

            itemListView1.View = View.Details;
            itemListView1.GridLines = true;

            itemListView1.Columns.Add("ProductName", 230);
            itemListView1.Columns.Add("Price", 80);

            itemListView1.Items.Clear();
            ListViewItem item;

            foreach (var entry
                in productsList)
            {
                item = itemListView1.Items.Add(entry.Name);
                item.SubItems.Add(entry.Price);
                itemListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void OpenPictureBtn_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openedPictureTxt.Text = ofd.FileName;
            }
        }

        private void OpenedPicturesTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductsStats_Load(object sender, EventArgs e)
        {

        }
    }
}
