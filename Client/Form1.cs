using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*CLIENT EXAMPLE*/
/*while adding service reference go to advanced and select System.Collections.Generic.List*/
namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getProductsBtn_Click(object sender, EventArgs e)
        {
            BLService.BLServiceClient client = new BLService.BLServiceClient(); //may need to specify binding here: ... = new BLService.BLServiceClient(basiHttpBinding_IBLService);
            List<BLService.Product> productsList = client.GetPrices(@"D:\cekis.jpg");

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
    }
}
