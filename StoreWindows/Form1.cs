namespace StoreWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ItemListForm = new ItemsList();
            ItemListForm.Show();
        }

        private void addEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addItem = new AddItem();
            addItem.Show();
        }
    }
}
