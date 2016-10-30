namespace EC_Components_DataBase
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lab_components = new System.Windows.Forms.Label();
            this.txt_projectName = new System.Windows.Forms.TextBox();
            this.lab_projectName = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.lab_search = new System.Windows.Forms.Label();
            this.btn_Add1 = new System.Windows.Forms.Button();
            this.btn_CreateProject = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txt_Builds = new System.Windows.Forms.TextBox();
            this.lab_Builds = new System.Windows.Forms.Label();
            this.btn_deduct = new System.Windows.Forms.Button();
            this.txt_Deduct = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(154, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // lab_components
            // 
            this.lab_components.AutoSize = true;
            this.lab_components.Location = new System.Drawing.Point(12, 79);
            this.lab_components.Name = "lab_components";
            this.lab_components.Size = new System.Drawing.Size(66, 13);
            this.lab_components.TabIndex = 2;
            this.lab_components.Text = "Components";
            // 
            // txt_projectName
            // 
            this.txt_projectName.Location = new System.Drawing.Point(228, 35);
            this.txt_projectName.Name = "txt_projectName";
            this.txt_projectName.Size = new System.Drawing.Size(100, 20);
            this.txt_projectName.TabIndex = 3;
            // 
            // lab_projectName
            // 
            this.lab_projectName.AutoSize = true;
            this.lab_projectName.Location = new System.Drawing.Point(151, 42);
            this.lab_projectName.Name = "lab_projectName";
            this.lab_projectName.Size = new System.Drawing.Size(71, 13);
            this.lab_projectName.TabIndex = 4;
            this.lab_projectName.Text = "Project Name";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(818, 35);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(127, 20);
            this.txt_Search.TabIndex = 5;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // lab_search
            // 
            this.lab_search.AutoSize = true;
            this.lab_search.Location = new System.Drawing.Point(771, 42);
            this.lab_search.Name = "lab_search";
            this.lab_search.Size = new System.Drawing.Size(41, 13);
            this.lab_search.TabIndex = 6;
            this.lab_search.Text = "Search";
            // 
            // btn_Add1
            // 
            this.btn_Add1.Location = new System.Drawing.Point(115, 486);
            this.btn_Add1.Name = "btn_Add1";
            this.btn_Add1.Size = new System.Drawing.Size(33, 23);
            this.btn_Add1.TabIndex = 7;
            this.btn_Add1.Text = "+1";
            this.btn_Add1.UseVisualStyleBackColor = true;
            this.btn_Add1.Click += new System.EventHandler(this.btn_Add1_Click);
            // 
            // btn_CreateProject
            // 
            this.btn_CreateProject.Location = new System.Drawing.Point(850, 515);
            this.btn_CreateProject.Name = "btn_CreateProject";
            this.btn_CreateProject.Size = new System.Drawing.Size(95, 23);
            this.btn_CreateProject.TabIndex = 8;
            this.btn_CreateProject.Text = "Create Project";
            this.btn_CreateProject.UseVisualStyleBackColor = true;
            this.btn_CreateProject.Click += new System.EventHandler(this.btn_CreateProject_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(154, 515);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 9;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_Builds
            // 
            this.txt_Builds.Location = new System.Drawing.Point(78, 489);
            this.txt_Builds.Name = "txt_Builds";
            this.txt_Builds.Size = new System.Drawing.Size(31, 20);
            this.txt_Builds.TabIndex = 10;
            this.txt_Builds.Text = "0";
            // 
            // lab_Builds
            // 
            this.lab_Builds.AutoSize = true;
            this.lab_Builds.Location = new System.Drawing.Point(43, 496);
            this.lab_Builds.Name = "lab_Builds";
            this.lab_Builds.Size = new System.Drawing.Size(35, 13);
            this.lab_Builds.TabIndex = 11;
            this.lab_Builds.Text = "Builds";
            // 
            // btn_deduct
            // 
            this.btn_deduct.Location = new System.Drawing.Point(252, 514);
            this.btn_deduct.Name = "btn_deduct";
            this.btn_deduct.Size = new System.Drawing.Size(75, 23);
            this.btn_deduct.TabIndex = 12;
            this.btn_deduct.Text = "Deduct";
            this.btn_deduct.UseVisualStyleBackColor = true;
            this.btn_deduct.Click += new System.EventHandler(this.btn_deduct_Click);
            // 
            // txt_Deduct
            // 
            this.txt_Deduct.Location = new System.Drawing.Point(334, 516);
            this.txt_Deduct.Name = "txt_Deduct";
            this.txt_Deduct.Size = new System.Drawing.Size(39, 20);
            this.txt_Deduct.TabIndex = 13;
            this.txt_Deduct.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(961, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Text = "Project";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRowsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 26);
            // 
            // editRowsToolStripMenuItem
            // 
            this.editRowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.editRowsToolStripMenuItem.Name = "editRowsToolStripMenuItem";
            this.editRowsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.editRowsToolStripMenuItem.Text = "Edit Rows";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 538);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txt_Deduct);
            this.Controls.Add(this.btn_deduct);
            this.Controls.Add(this.lab_Builds);
            this.Controls.Add(this.txt_Builds);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_CreateProject);
            this.Controls.Add(this.btn_Add1);
            this.Controls.Add(this.lab_search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.lab_projectName);
            this.Controls.Add(this.txt_projectName);
            this.Controls.Add(this.lab_components);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Click += new System.EventHandler(this.Form3_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lab_components;
        private System.Windows.Forms.TextBox txt_projectName;
        private System.Windows.Forms.Label lab_projectName;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label lab_search;
        private System.Windows.Forms.Button btn_Add1;
        private System.Windows.Forms.Button btn_CreateProject;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txt_Builds;
        private System.Windows.Forms.Label lab_Builds;
        private System.Windows.Forms.Button btn_deduct;
        private System.Windows.Forms.TextBox txt_Deduct;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
    }
}