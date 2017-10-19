using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingAPI2.Entities;

namespace TestingAPI2
{
    public partial class EditDialogBox : Form
    {
        public Tuple<string, string> ReturnValue1 { get; set; }

        public EditDialogBox(string name, string price)
        {
            InitializeComponent();
            textBoxName.Text = name;
            textBoxPrice.Text = price;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            double num;
            if (!textBoxName.Text.Equals(""))
                if (double.TryParse(textBoxPrice.Text, out num))
                    if (num > 0)
                        ReturnValue1 = new Tuple<string, string>(textBoxName.Text, textBoxPrice.Text);
        }

    }
}
