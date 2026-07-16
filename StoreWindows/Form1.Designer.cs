namespace StoreWindows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            itemsToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem = new ToolStripMenuItem();
            addEditToolStripMenuItem = new ToolStripMenuItem();
            customerToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem1 = new ToolStripMenuItem();
            addEditToolStripMenuItem1 = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem2 = new ToolStripMenuItem();
            addEditToolStripMenuItem2 = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            totalSalesToolStripMenuItem = new ToolStripMenuItem();
            salesByCustomersToolStripMenuItem = new ToolStripMenuItem();
            salesByItemsToolStripMenuItem = new ToolStripMenuItem();
            topCustomersToolStripMenuItem = new ToolStripMenuItem();
            topItemsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { itemsToolStripMenuItem, customerToolStripMenuItem, ordersToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // itemsToolStripMenuItem
            // 
            itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem, addEditToolStripMenuItem });
            itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            itemsToolStripMenuItem.Size = new Size(59, 24);
            itemsToolStripMenuItem.Text = "Items";
            // 
            // listToolStripMenuItem
            // 
            listToolStripMenuItem.Name = "listToolStripMenuItem";
            listToolStripMenuItem.Size = new Size(224, 26);
            listToolStripMenuItem.Text = "List";
            listToolStripMenuItem.Click += listToolStripMenuItem_Click;
            // 
            // addEditToolStripMenuItem
            // 
            addEditToolStripMenuItem.Name = "addEditToolStripMenuItem";
            addEditToolStripMenuItem.Size = new Size(224, 26);
            addEditToolStripMenuItem.Text = "Add - Edit";
            addEditToolStripMenuItem.Click += addEditToolStripMenuItem_Click;
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem1, addEditToolStripMenuItem1 });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(86, 24);
            customerToolStripMenuItem.Text = "Customer";
            // 
            // listToolStripMenuItem1
            // 
            listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            listToolStripMenuItem1.Size = new Size(156, 26);
            listToolStripMenuItem1.Text = "List";
            // 
            // addEditToolStripMenuItem1
            // 
            addEditToolStripMenuItem1.Name = "addEditToolStripMenuItem1";
            addEditToolStripMenuItem1.Size = new Size(156, 26);
            addEditToolStripMenuItem1.Text = "Add -Edit";
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem2, addEditToolStripMenuItem2 });
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(67, 24);
            ordersToolStripMenuItem.Text = "Orders";
            // 
            // listToolStripMenuItem2
            // 
            listToolStripMenuItem2.Name = "listToolStripMenuItem2";
            listToolStripMenuItem2.Size = new Size(160, 26);
            listToolStripMenuItem2.Text = "List";
            // 
            // addEditToolStripMenuItem2
            // 
            addEditToolStripMenuItem2.Name = "addEditToolStripMenuItem2";
            addEditToolStripMenuItem2.Size = new Size(160, 26);
            addEditToolStripMenuItem2.Text = "Add - Edit";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { totalSalesToolStripMenuItem, salesByCustomersToolStripMenuItem, salesByItemsToolStripMenuItem, topCustomersToolStripMenuItem, topItemsToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // totalSalesToolStripMenuItem
            // 
            totalSalesToolStripMenuItem.Name = "totalSalesToolStripMenuItem";
            totalSalesToolStripMenuItem.Size = new Size(219, 26);
            totalSalesToolStripMenuItem.Text = "Total Sales";
            // 
            // salesByCustomersToolStripMenuItem
            // 
            salesByCustomersToolStripMenuItem.Name = "salesByCustomersToolStripMenuItem";
            salesByCustomersToolStripMenuItem.Size = new Size(219, 26);
            salesByCustomersToolStripMenuItem.Text = "Sales by Customers";
            // 
            // salesByItemsToolStripMenuItem
            // 
            salesByItemsToolStripMenuItem.Name = "salesByItemsToolStripMenuItem";
            salesByItemsToolStripMenuItem.Size = new Size(219, 26);
            salesByItemsToolStripMenuItem.Text = "Sales by Items";
            // 
            // topCustomersToolStripMenuItem
            // 
            topCustomersToolStripMenuItem.Name = "topCustomersToolStripMenuItem";
            topCustomersToolStripMenuItem.Size = new Size(219, 26);
            topCustomersToolStripMenuItem.Text = "Top Customers";
            // 
            // topItemsToolStripMenuItem
            // 
            topItemsToolStripMenuItem.Name = "topItemsToolStripMenuItem";
            topItemsToolStripMenuItem.Size = new Size(219, 26);
            topItemsToolStripMenuItem.Text = "Top Items";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem itemsToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem addEditToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem1;
        private ToolStripMenuItem addEditToolStripMenuItem1;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem2;
        private ToolStripMenuItem addEditToolStripMenuItem2;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem totalSalesToolStripMenuItem;
        private ToolStripMenuItem salesByCustomersToolStripMenuItem;
        private ToolStripMenuItem salesByItemsToolStripMenuItem;
        private ToolStripMenuItem topCustomersToolStripMenuItem;
        private ToolStripMenuItem topItemsToolStripMenuItem;
    }
}
