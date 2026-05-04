namespace IT_Assignment_2.Forms
{
    partial class InventoryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            productlbl1 = new Label();
            priceLbl1 = new Label();
            stockLbl1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(stockLbl1);
            panel1.Controls.Add(priceLbl1);
            panel1.Controls.Add(productlbl1);
            panel1.Location = new Point(112, 219);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 178);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Location = new Point(396, 219);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 178);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(224, 224, 224);
            panel3.Location = new Point(679, 219);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 178);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(224, 224, 224);
            panel4.Location = new Point(112, 484);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 178);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(224, 224, 224);
            panel5.Location = new Point(396, 484);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 178);
            panel5.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(224, 224, 224);
            panel6.Location = new Point(679, 484);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 178);
            panel6.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Cambria", 10F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(384, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 23);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "enter category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 13F);
            label1.Location = new Point(112, 77);
            label1.Name = "label1";
            label1.Size = new Size(182, 21);
            label1.TabIndex = 7;
            label1.Text = "please type in product";
            // 
            // productlbl1
            // 
            productlbl1.AutoSize = true;
            productlbl1.Font = new Font("Cambria", 10F);
            productlbl1.Location = new Point(35, 23);
            productlbl1.Name = "productlbl1";
            productlbl1.Size = new Size(126, 16);
            productlbl1.TabIndex = 0;
            productlbl1.Text = "midnight lace dress";
            // 
            // priceLbl1
            // 
            priceLbl1.AutoSize = true;
            priceLbl1.Font = new Font("Cambria", 15F);
            priceLbl1.ForeColor = Color.RosyBrown;
            priceLbl1.Location = new Point(64, 57);
            priceLbl1.Name = "priceLbl1";
            priceLbl1.Size = new Size(68, 23);
            priceLbl1.TabIndex = 1;
            priceLbl1.Text = "$85.49";
            // 
            // stockLbl1
            // 
            stockLbl1.AutoSize = true;
            stockLbl1.Font = new Font("Cambria", 10F);
            stockLbl1.Location = new Point(53, 97);
            stockLbl1.Name = "stockLbl1";
            stockLbl1.Size = new Size(95, 16);
            stockLbl1.TabIndex = 2;
            stockLbl1.Text = "12 left in stock";
            // 
            // InventoryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "InventoryControl";
            Size = new Size(1347, 778);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label productlbl1;
        private ComboBox comboBox1;
        private Label label1;
        private Label stockLbl1;
        private Label priceLbl1;
    }
}
