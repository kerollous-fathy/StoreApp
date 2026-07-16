namespace StoreWindows
{
    partial class ItemsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvItems = new DataGridView();
            panel1 = new Panel();
            btnAdd = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.Location = new Point(0, 0);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.Size = new Size(800, 450);
            dgvItems.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 55);
            panel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(22, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 42);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(797, 392);
            panel2.TabIndex = 2;
            // 
            // ItemsList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvItems);
            Name = "ItemsList";
            Text = "ItemsList";
            Load += ItemsList_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvItems;
        private Panel panel1;
        private Panel panel2;
        private Button btnAdd;
    }
}