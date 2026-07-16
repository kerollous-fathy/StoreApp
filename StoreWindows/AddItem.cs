using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreWindows
{
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var item = new Item();
            item.Id =Convert.ToInt32(txtId.Text);
            item.Name = txtName.Text;
            item.Price = Convert.ToDecimal(txtId.Text);
            item.Quantity = Convert.ToInt32(txtId.Text);
            await MainClass.itemBL.Add(item);
        }
    }
}
