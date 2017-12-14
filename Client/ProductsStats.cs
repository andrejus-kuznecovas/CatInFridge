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
        //list for loaded products
        List<BLService.Product> productsList = new List<BLService.Product>();
        OpenFileDialog ofd = new OpenFileDialog();
        BLService.Stats statistics = new BLService.Stats();

        public ProductsStats()
        {
            InitializeComponent();
        }

        private void ProductsStats_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ProductsStats_Load_1(object sender, EventArgs e)
        {

        }

        private void OpenPicBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               picLocationBox.Text = ofd.FileName;
            }
        }
    
        private void picLocationBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void getProdsBtn_Click(object sender, EventArgs e)
        {
        
            BLService.BLServiceClient client = new BLService.BLServiceClient(); //may need to specify binding here: ... = new BLService.BLServiceClient(basiHttpBinding_IBLService);

            Bitmap img = new Bitmap(picLocationBox.Text);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, img.RawFormat);
            byte[] result = stream.ToArray();

            DateTime date = new DateTime(2017, 06, 06, 12, 12, 12);
            //List<BLService.Product> productsList = client.GetPrices(result);
            productsList.Add(new BLService.Product() {  Name = "desra",
                                                        Price = 1.45,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "MEAT"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() {Name = "Iki" } });

            productsList.Add(new BLService.Product() {  Name = "jogurtas",
                                                        Price = 2.19,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "DAIRY"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" } });

            productsList.Add(new BLService.Product() {  Name = "desrele",
                                                        Price = 3.1,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "MEAT"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" } });

            productsList.Add(new BLService.Product()
                                                    {
                                                        Name = "desrele",
                                                        Price = 4.1,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "MEAT"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" }
                                                    });

            productsList.Add(new BLService.Product() {  Name = "obuoliu sultys",
                                                        Price = 4.99,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "DRINKS"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" } });

            productsList.Add(new BLService.Product() {  Name = "rukytas kumpis",
                                                        Price = 2.69,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "MEAT"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" } });

            productsList.Add(new BLService.Product() {  Name = "varskes surelis",
                                                        Price = 0.99,
                                                        Category = (BLService.Cat)Enum.Parse(typeof(BLService.Cat), "DAIRY"),
                                                        Date = date,
                                                        ProductShop = new BLService.Shop() { Name = "Iki" } });

            productsView.View = View.Details;
            productsView.GridLines = true;

            productsView.Columns.Add("ProductName", 230);
            productsView.Columns.Add("Price", 80);
            productsView.Columns.Add("Category", 120);
            productsView.Columns.Add("Shop", 230);
            productsView.Columns.Add("Date", 80);

            productsView.Items.Clear();
            ListViewItem item;

            foreach (var entry
                in productsList)
            {
                item = productsView.Items.Add(entry.Name);
                item.SubItems.Add(Convert.ToString(entry.Price));
                item.SubItems.Add(entry.Category.ToString());
                item.SubItems.Add(entry.ProductShop.Name);
                item.SubItems.Add(Convert.ToString(entry.Date));
                productsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void GetStatsBtn_Click(object sender, EventArgs e)
        {
            BLService.BLServiceClient client = new BLService.BLServiceClient();
            if (productsList == null)
            {
                MessageBox.Show("Please select a product list first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (client.GetStats(productsList) == null) throw new ArgumentNullException();
            statistics = client.GetStats(productsList);
            
            /* For spendings by category view */
            spendingsByCategoryView.View = View.Details;
            spendingsByCategoryView.GridLines = true;

            spendingsByCategoryView.Columns.Add("Category", 120);
            spendingsByCategoryView.Columns.Add("Amount", 80);

            spendingsByCategoryView.Items.Clear();
            ListViewItem item;

            foreach (var entry in statistics.spendingsByCategory)
            {
                item = spendingsByCategoryView.Items.Add(entry.Key);
                item.SubItems.Add(Convert.ToString(entry.Value));
                spendingsByCategoryView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            //-------------------------------------------------------------------

            /*For spendings by shop view */
            spendingsByShopView.View = View.Details;
            spendingsByShopView.GridLines = true;

            spendingsByShopView.Columns.Add("Shop", 120);
            spendingsByShopView.Columns.Add("Amount", 80);

            spendingsByShopView.Items.Clear();
            ListViewItem itemShopView;

            foreach (var entry in statistics.spendingsByShop)
            {
                itemShopView = spendingsByShopView.Items.Add(entry.Key);
                itemShopView.SubItems.Add(Convert.ToString(entry.Value));
                spendingsByShopView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            //--------------------------------------------------------------------------------------

            /*For average spendings by category view */
            avgSpendingsByCategoryView.View = View.Details;
            avgSpendingsByCategoryView.GridLines = true;

            avgSpendingsByCategoryView.Columns.Add("Category", 120);
            avgSpendingsByCategoryView.Columns.Add("Average", 80);

            avgSpendingsByCategoryView.Items.Clear();
            ListViewItem avgCatView;

            foreach (var entry in statistics.averageByCategory)
            {
                avgCatView = avgSpendingsByCategoryView.Items.Add(entry.Key);
                avgCatView.SubItems.Add(Convert.ToString(entry.Value));
                avgSpendingsByCategoryView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------

            /*For average spendings by shop view */
            avgSpendingsByShopView.View = View.Details;
            avgSpendingsByShopView.GridLines = true;

            avgSpendingsByShopView.Columns.Add("Shop", 120);
            avgSpendingsByShopView.Columns.Add("Average", 80);

            avgSpendingsByShopView.Items.Clear();
            ListViewItem avgShopView;

            foreach (var entry in statistics.averageByShop)
            {
                avgShopView = avgSpendingsByShopView.Items.Add(entry.Key);
                avgShopView.SubItems.Add(Convert.ToString(entry.Value));
                avgSpendingsByShopView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        
        
           /*For cheapest products by category view */
            cheapestByCategoryView.View = View.Details;
            cheapestByCategoryView.GridLines = true;

            cheapestByCategoryView.Columns.Add("Category", 120);
            cheapestByCategoryView.Columns.Add("Name", 80);
            cheapestByCategoryView.Columns.Add("Price", 80);

            cheapestByCategoryView.Items.Clear();
            ListViewItem cheapestCategoryView;

            statistics.cheapestByCategory["MEAT"] = new BLService.Product() { Name = "test", Price = 1};
            foreach (var entry in statistics.cheapestByCategory)
            {
                cheapestCategoryView = mostPopularByCategoryView.Items.Add(entry.Key);
                cheapestCategoryView.SubItems.Add(Convert.ToString(entry.Value.Name));
                cheapestCategoryView.SubItems.Add(Convert.ToString(entry.Value.Price));
                mostPopularByCategoryView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            //--------------------------------------------------------------------------------------


            /*For cheapest products by shop view */
            cheapestByShopView.View = View.Details;
            cheapestByShopView.GridLines = true;

            cheapestByShopView.Columns.Add("Shop", 120);
            cheapestByShopView.Columns.Add("Name", 80);
            cheapestByShopView.Columns.Add("Price", 80);

            cheapestByShopView.Items.Clear();
            ListViewItem cheapestShopView;

            foreach (var entry in statistics.cheapestByShop)
            {
                cheapestShopView = mostPopularByShopView.Items.Add(entry.Key);
                cheapestShopView.SubItems.Add(Convert.ToString(entry.Value.Name));
                cheapestShopView.SubItems.Add(Convert.ToString(entry.Value.Price));
                mostPopularByShopView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------

            /*For most popular products by category view */
            mostPopularByCategoryView.View = View.Details;
            mostPopularByCategoryView.GridLines = true;

            mostPopularByCategoryView.Columns.Add("Category", 120);
            mostPopularByCategoryView.Columns.Add("Name", 80);

            mostPopularByCategoryView.Items.Clear();
            ListViewItem popCategoryView;

            /*
            foreach (var entry in statistics.mostPopularByCategory)
            {
                popCategoryView = mostPopularByCategoryView.Items.Add(entry.Key);
                popCategoryView.SubItems.Add(Convert.ToString(entry.Value));
                mostPopularByCategoryView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }*/
            //--------------------------------------------------------------------------------------

            /*For most popular products by shop view */
            mostPopularByShopView.View = View.Details;
            mostPopularByShopView.GridLines = true;

            mostPopularByShopView.Columns.Add("Shop", 120);
            mostPopularByShopView.Columns.Add("Name", 80);

            mostPopularByShopView.Items.Clear();
            ListViewItem popShopView;
            /*
           foreach (var entry in statistics.mostPopularByShop)
           {
               popShopView = mostPopularByShopView.Items.Add(entry.Key);
               popShopView.SubItems.Add(Convert.ToString(entry.Value));
               mostPopularByShopView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
           }*/
            //--------------------------------------------------------------------------------------


            client.Close();
        }

        private void productsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void spendingsByCategoryView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
