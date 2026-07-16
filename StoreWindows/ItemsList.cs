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
    public partial class ItemsList : Form
    {
        public ItemsList()
        {
            InitializeComponent();
        }

        private async void ItemsList_LoadAsync(object sender, EventArgs e)
        {
            dgvItems.DataSource = await MainClass.itemBL.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addItem = new AddItem();
            addItem.Show();
        }
    }
}
