namespace EC_Components_DataBase
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDataSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lab_comboBox = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.componentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.lab_search = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_ImageSize = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(208, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.updateRowToolStripMenuItem,
            this.goToSiteToolStripMenuItem,
            this.viewDataSheetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 114);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newColumnToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newColumnToolStripMenuItem
            // 
            this.newColumnToolStripMenuItem.Name = "newColumnToolStripMenuItem";
            this.newColumnToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.newColumnToolStripMenuItem.Text = "New Column";
            this.newColumnToolStripMenuItem.Click += new System.EventHandler(this.newColumnToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowToolStripMenuItem,
            this.columnToolStripMenuItem});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // rowToolStripMenuItem
            // 
            this.rowToolStripMenuItem.Name = "rowToolStripMenuItem";
            this.rowToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.rowToolStripMenuItem.Text = "Row";
            this.rowToolStripMenuItem.Click += new System.EventHandler(this.rowToolStripMenuItem_Click);
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.columnToolStripMenuItem.Text = "Column";
            // 
            // updateRowToolStripMenuItem
            // 
            this.updateRowToolStripMenuItem.Name = "updateRowToolStripMenuItem";
            this.updateRowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.updateRowToolStripMenuItem.Text = "Update Row";
            this.updateRowToolStripMenuItem.Click += new System.EventHandler(this.updateRowToolStripMenuItem_Click);
            // 
            // goToSiteToolStripMenuItem
            // 
            this.goToSiteToolStripMenuItem.Name = "goToSiteToolStripMenuItem";
            this.goToSiteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.goToSiteToolStripMenuItem.Text = "Go To Site";
            this.goToSiteToolStripMenuItem.Click += new System.EventHandler(this.goToSiteToolStripMenuItem_Click);
            // 
            // viewDataSheetToolStripMenuItem
            // 
            this.viewDataSheetToolStripMenuItem.Name = "viewDataSheetToolStripMenuItem";
            this.viewDataSheetToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewDataSheetToolStripMenuItem.Text = "View Data Sheet";
            this.viewDataSheetToolStripMenuItem.Click += new System.EventHandler(this.viewDataSheetToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // lab_comboBox
            // 
            this.lab_comboBox.AutoSize = true;
            this.lab_comboBox.Location = new System.Drawing.Point(12, 45);
            this.lab_comboBox.Name = "lab_comboBox";
            this.lab_comboBox.Size = new System.Drawing.Size(66, 13);
            this.lab_comboBox.TabIndex = 4;
            this.lab_comboBox.Text = "Components";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1003, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.projectToolStripMenuItem.Text = "Project";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentListToolStripMenuItem,
            this.projectsToolStripMenuItem1});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton2.Text = "Edit";
            // 
            // componentListToolStripMenuItem
            // 
            this.componentListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addComponentToolStripMenuItem,
            this.updateComponentToolStripMenuItem,
            this.removeComponentToolStripMenuItem});
            this.componentListToolStripMenuItem.Name = "componentListToolStripMenuItem";
            this.componentListToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.componentListToolStripMenuItem.Text = "Component List";
            // 
            // addComponentToolStripMenuItem
            // 
            this.addComponentToolStripMenuItem.Name = "addComponentToolStripMenuItem";
            this.addComponentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addComponentToolStripMenuItem.Text = "Add Component";
            this.addComponentToolStripMenuItem.Click += new System.EventHandler(this.addComponentToolStripMenuItem_Click);
            // 
            // updateComponentToolStripMenuItem
            // 
            this.updateComponentToolStripMenuItem.Name = "updateComponentToolStripMenuItem";
            this.updateComponentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.updateComponentToolStripMenuItem.Text = "Update Component";
            this.updateComponentToolStripMenuItem.Click += new System.EventHandler(this.updateComponentToolStripMenuItem_Click);
            // 
            // removeComponentToolStripMenuItem
            // 
            this.removeComponentToolStripMenuItem.Name = "removeComponentToolStripMenuItem";
            this.removeComponentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeComponentToolStripMenuItem.Text = "Remove Component";
            this.removeComponentToolStripMenuItem.Click += new System.EventHandler(this.removeComponentToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem1
            // 
            this.projectsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteProjectToolStripMenuItem});
            this.projectsToolStripMenuItem1.Name = "projectsToolStripMenuItem1";
            this.projectsToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.projectsToolStripMenuItem1.Text = "Projects";
            // 
            // deleteProjectToolStripMenuItem
            // 
            this.deleteProjectToolStripMenuItem.Name = "deleteProjectToolStripMenuItem";
            this.deleteProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteProjectToolStripMenuItem.Text = "Delete Project";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton3.Text = "View";
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projectsToolStripMenuItem.Text = "Projects";

            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(868, 31);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(131, 20);
            this.txt_Search.TabIndex = 6;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // lab_search
            // 
            this.lab_search.AutoSize = true;
            this.lab_search.Location = new System.Drawing.Point(821, 38);
            this.lab_search.Name = "lab_search";
            this.lab_search.Size = new System.Drawing.Size(41, 13);
            this.lab_search.TabIndex = 7;
            this.lab_search.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 282);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 181);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(208, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(345, 20);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // txt_ImageSize
            // 
            this.txt_ImageSize.Location = new System.Drawing.Point(12, 469);
            this.txt_ImageSize.Name = "txt_ImageSize";
            this.txt_ImageSize.Size = new System.Drawing.Size(178, 20);
            this.txt_ImageSize.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 521);
            this.Controls.Add(this.txt_ImageSize);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab_search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lab_comboBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lab_comboBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem componentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addComponentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newColumnToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label lab_search;
        private System.Windows.Forms.ToolStripMenuItem updateComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteProjectToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem goToSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDataSheetToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_ImageSize;
    }
}

