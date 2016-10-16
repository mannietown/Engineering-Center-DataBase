namespace EC_Components_DataBase
{
    partial class Form2
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
            this.txt_PN = new System.Windows.Forms.TextBox();
            this.txt_MN = new System.Windows.Forms.TextBox();
            this.txt_CT = new System.Windows.Forms.TextBox();
            this.txt_P = new System.Windows.Forms.TextBox();
            this.txt_V = new System.Windows.Forms.TextBox();
            this.txt_UP = new System.Windows.Forms.TextBox();
            this.txt_S = new System.Windows.Forms.TextBox();
            this.txt_NACP1 = new System.Windows.Forms.TextBox();
            this.txt_NACP2 = new System.Windows.Forms.TextBox();
            this.txt_NACP3 = new System.Windows.Forms.TextBox();
            this.lab_PN = new System.Windows.Forms.Label();
            this.lab_MN = new System.Windows.Forms.Label();
            this.lab_CT = new System.Windows.Forms.Label();
            this.lab_P = new System.Windows.Forms.Label();
            this.lab_V = new System.Windows.Forms.Label();
            this.lab_UP = new System.Windows.Forms.Label();
            this.lab_S = new System.Windows.Forms.Label();
            this.lab_NACP1 = new System.Windows.Forms.Label();
            this.lab_NACP2 = new System.Windows.Forms.Label();
            this.lab_NACP3 = new System.Windows.Forms.Label();
            this.btn_AddComponent = new System.Windows.Forms.Button();
            this.cb_CT = new System.Windows.Forms.ComboBox();
            this.cb_V = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_PN
            // 
            this.txt_PN.Location = new System.Drawing.Point(137, 39);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Size = new System.Drawing.Size(100, 20);
            this.txt_PN.TabIndex = 0;
            // 
            // txt_MN
            // 
            this.txt_MN.Location = new System.Drawing.Point(137, 80);
            this.txt_MN.Name = "txt_MN";
            this.txt_MN.Size = new System.Drawing.Size(100, 20);
            this.txt_MN.TabIndex = 1;
            // 
            // txt_CT
            // 
            this.txt_CT.Location = new System.Drawing.Point(137, 127);
            this.txt_CT.Name = "txt_CT";
            this.txt_CT.Size = new System.Drawing.Size(100, 20);
            this.txt_CT.TabIndex = 2;
            this.txt_CT.TextChanged += new System.EventHandler(this.txt_CT_TextChanged);
            // 
            // txt_P
            // 
            this.txt_P.Location = new System.Drawing.Point(137, 167);
            this.txt_P.Name = "txt_P";
            this.txt_P.Size = new System.Drawing.Size(100, 20);
            this.txt_P.TabIndex = 3;
            // 
            // txt_V
            // 
            this.txt_V.Location = new System.Drawing.Point(137, 205);
            this.txt_V.Name = "txt_V";
            this.txt_V.Size = new System.Drawing.Size(100, 20);
            this.txt_V.TabIndex = 4;
            // 
            // txt_UP
            // 
            this.txt_UP.Location = new System.Drawing.Point(137, 245);
            this.txt_UP.Name = "txt_UP";
            this.txt_UP.Size = new System.Drawing.Size(100, 20);
            this.txt_UP.TabIndex = 5;
            // 
            // txt_S
            // 
            this.txt_S.Location = new System.Drawing.Point(137, 287);
            this.txt_S.Name = "txt_S";
            this.txt_S.Size = new System.Drawing.Size(100, 20);
            this.txt_S.TabIndex = 6;
            // 
            // txt_NACP1
            // 
            this.txt_NACP1.Location = new System.Drawing.Point(511, 39);
            this.txt_NACP1.Name = "txt_NACP1";
            this.txt_NACP1.Size = new System.Drawing.Size(100, 20);
            this.txt_NACP1.TabIndex = 7;
            // 
            // txt_NACP2
            // 
            this.txt_NACP2.Location = new System.Drawing.Point(511, 80);
            this.txt_NACP2.Name = "txt_NACP2";
            this.txt_NACP2.Size = new System.Drawing.Size(100, 20);
            this.txt_NACP2.TabIndex = 8;
            // 
            // txt_NACP3
            // 
            this.txt_NACP3.Location = new System.Drawing.Point(511, 118);
            this.txt_NACP3.Name = "txt_NACP3";
            this.txt_NACP3.Size = new System.Drawing.Size(100, 20);
            this.txt_NACP3.TabIndex = 9;
            // 
            // lab_PN
            // 
            this.lab_PN.AutoSize = true;
            this.lab_PN.Location = new System.Drawing.Point(12, 46);
            this.lab_PN.Name = "lab_PN";
            this.lab_PN.Size = new System.Drawing.Size(66, 13);
            this.lab_PN.TabIndex = 10;
            this.lab_PN.Text = "Part Number";
            // 
            // lab_MN
            // 
            this.lab_MN.AutoSize = true;
            this.lab_MN.Location = new System.Drawing.Point(12, 87);
            this.lab_MN.Name = "lab_MN";
            this.lab_MN.Size = new System.Drawing.Size(110, 13);
            this.lab_MN.TabIndex = 11;
            this.lab_MN.Text = "Manufacturer Number";
            // 
            // lab_CT
            // 
            this.lab_CT.AutoSize = true;
            this.lab_CT.Location = new System.Drawing.Point(12, 134);
            this.lab_CT.Name = "lab_CT";
            this.lab_CT.Size = new System.Drawing.Size(88, 13);
            this.lab_CT.TabIndex = 12;
            this.lab_CT.Text = "Component Type";
            // 
            // lab_P
            // 
            this.lab_P.AutoSize = true;
            this.lab_P.Location = new System.Drawing.Point(12, 174);
            this.lab_P.Name = "lab_P";
            this.lab_P.Size = new System.Drawing.Size(50, 13);
            this.lab_P.TabIndex = 13;
            this.lab_P.Text = "Package";
            // 
            // lab_V
            // 
            this.lab_V.AutoSize = true;
            this.lab_V.Location = new System.Drawing.Point(12, 212);
            this.lab_V.Name = "lab_V";
            this.lab_V.Size = new System.Drawing.Size(34, 13);
            this.lab_V.TabIndex = 14;
            this.lab_V.Text = "Value";
            // 
            // lab_UP
            // 
            this.lab_UP.AutoSize = true;
            this.lab_UP.Location = new System.Drawing.Point(12, 252);
            this.lab_UP.Name = "lab_UP";
            this.lab_UP.Size = new System.Drawing.Size(53, 13);
            this.lab_UP.TabIndex = 15;
            this.lab_UP.Text = "Unit Price";
            // 
            // lab_S
            // 
            this.lab_S.AutoSize = true;
            this.lab_S.Location = new System.Drawing.Point(12, 294);
            this.lab_S.Name = "lab_S";
            this.lab_S.Size = new System.Drawing.Size(35, 13);
            this.lab_S.TabIndex = 16;
            this.lab_S.Text = "Stock";
            // 
            // lab_NACP1
            // 
            this.lab_NACP1.AutoSize = true;
            this.lab_NACP1.Location = new System.Drawing.Point(440, 42);
            this.lab_NACP1.Name = "lab_NACP1";
            this.lab_NACP1.Size = new System.Drawing.Size(35, 13);
            this.lab_NACP1.TabIndex = 17;
            this.lab_NACP1.Text = "label1";
            // 
            // lab_NACP2
            // 
            this.lab_NACP2.AutoSize = true;
            this.lab_NACP2.Location = new System.Drawing.Point(440, 87);
            this.lab_NACP2.Name = "lab_NACP2";
            this.lab_NACP2.Size = new System.Drawing.Size(35, 13);
            this.lab_NACP2.TabIndex = 18;
            this.lab_NACP2.Text = "label1";
            // 
            // lab_NACP3
            // 
            this.lab_NACP3.AutoSize = true;
            this.lab_NACP3.Location = new System.Drawing.Point(440, 125);
            this.lab_NACP3.Name = "lab_NACP3";
            this.lab_NACP3.Size = new System.Drawing.Size(35, 13);
            this.lab_NACP3.TabIndex = 19;
            this.lab_NACP3.Text = "label1";
            // 
            // btn_AddComponent
            // 
            this.btn_AddComponent.Location = new System.Drawing.Point(511, 294);
            this.btn_AddComponent.Name = "btn_AddComponent";
            this.btn_AddComponent.Size = new System.Drawing.Size(100, 23);
            this.btn_AddComponent.TabIndex = 20;
            this.btn_AddComponent.Text = "Add Component";
            this.btn_AddComponent.UseVisualStyleBackColor = true;
            this.btn_AddComponent.Click += new System.EventHandler(this.btn_AddComponent_Click);
            // 
            // cb_CT
            // 
            this.cb_CT.FormattingEnabled = true;
            this.cb_CT.Location = new System.Drawing.Point(275, 127);
            this.cb_CT.Name = "cb_CT";
            this.cb_CT.Size = new System.Drawing.Size(121, 21);
            this.cb_CT.TabIndex = 21;
            this.cb_CT.TextChanged += new System.EventHandler(this.cb_CT_TextChanged);
            // 
            // cb_V
            // 
            this.cb_V.FormattingEnabled = true;
            this.cb_V.Location = new System.Drawing.Point(275, 203);
            this.cb_V.Name = "cb_V";
            this.cb_V.Size = new System.Drawing.Size(121, 21);
            this.cb_V.TabIndex = 22;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 325);
            this.Controls.Add(this.cb_V);
            this.Controls.Add(this.cb_CT);
            this.Controls.Add(this.btn_AddComponent);
            this.Controls.Add(this.lab_NACP3);
            this.Controls.Add(this.lab_NACP2);
            this.Controls.Add(this.lab_NACP1);
            this.Controls.Add(this.lab_S);
            this.Controls.Add(this.lab_UP);
            this.Controls.Add(this.lab_V);
            this.Controls.Add(this.lab_P);
            this.Controls.Add(this.lab_CT);
            this.Controls.Add(this.lab_MN);
            this.Controls.Add(this.lab_PN);
            this.Controls.Add(this.txt_NACP3);
            this.Controls.Add(this.txt_NACP2);
            this.Controls.Add(this.txt_NACP1);
            this.Controls.Add(this.txt_S);
            this.Controls.Add(this.txt_UP);
            this.Controls.Add(this.txt_V);
            this.Controls.Add(this.txt_P);
            this.Controls.Add(this.txt_CT);
            this.Controls.Add(this.txt_MN);
            this.Controls.Add(this.txt_PN);
            this.Name = "Form2";
            this.Text = "Add New Component";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PN;
        private System.Windows.Forms.TextBox txt_MN;
        private System.Windows.Forms.TextBox txt_CT;
        private System.Windows.Forms.TextBox txt_P;
        private System.Windows.Forms.TextBox txt_V;
        private System.Windows.Forms.TextBox txt_UP;
        private System.Windows.Forms.TextBox txt_S;
        private System.Windows.Forms.TextBox txt_NACP1;
        private System.Windows.Forms.TextBox txt_NACP2;
        private System.Windows.Forms.TextBox txt_NACP3;
        private System.Windows.Forms.Label lab_PN;
        private System.Windows.Forms.Label lab_MN;
        private System.Windows.Forms.Label lab_CT;
        private System.Windows.Forms.Label lab_P;
        private System.Windows.Forms.Label lab_V;
        private System.Windows.Forms.Label lab_UP;
        private System.Windows.Forms.Label lab_S;
        private System.Windows.Forms.Label lab_NACP1;
        private System.Windows.Forms.Label lab_NACP2;
        private System.Windows.Forms.Label lab_NACP3;
        private System.Windows.Forms.Button btn_AddComponent;
        private System.Windows.Forms.ComboBox cb_CT;
        private System.Windows.Forms.ComboBox cb_V;
    }
}