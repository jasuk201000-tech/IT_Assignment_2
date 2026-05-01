namespace IT_Assignment_2.Forms
{
    partial class BuildOrderControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Panel orderPnl;
            Panel mainPnl;
            panel7 = new Panel();
            removeBtn = new Button();
            ordersumTxt = new TextBox();
            panel6 = new Panel();
            comboBox3 = new ComboBox();
            stock4 = new TextBox();
            price4 = new TextBox();
            item4 = new TextBox();
            panel5 = new Panel();
            comboBox4 = new ComboBox();
            stock5 = new TextBox();
            price6 = new TextBox();
            item5 = new TextBox();
            panel4 = new Panel();
            comboBox5 = new ComboBox();
            textBox1 = new TextBox();
            price7 = new TextBox();
            item6 = new TextBox();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            stock3 = new TextBox();
            price3 = new TextBox();
            item3 = new TextBox();
            panel2 = new Panel();
            sizeCombo = new ComboBox();
            stock2 = new TextBox();
            price2 = new TextBox();
            item2 = new TextBox();
            panel1 = new Panel();
            comboBox2 = new ComboBox();
            stock1 = new TextBox();
            price1 = new TextBox();
            item1 = new TextBox();
            categoryComboBox = new ComboBox();
            searchboxTxt = new TextBox();
            searchTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            discountTxt = new TextBox();
            applydiscountBtn = new Button();
            chargeBtn = new Button();
            orderPnl = new Panel();
            mainPnl = new Panel();

            orderPnl.SuspendLayout();
            panel7.SuspendLayout();
            mainPnl.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();

            // orderPnl
            orderPnl.BackColor = System.Drawing.SystemColors.ControlLight;
            orderPnl.Controls.Add(chargeBtn);
            orderPnl.Controls.Add(applydiscountBtn);
            orderPnl.Controls.Add(discountTxt);
            orderPnl.Controls.Add(textBox2);
            orderPnl.Controls.Add(label4);
            orderPnl.Controls.Add(label3);
            orderPnl.Controls.Add(label2);
            orderPnl.Controls.Add(label1);
            orderPnl.Controls.Add(panel7);
            orderPnl.Controls.Add(ordersumTxt);
            orderPnl.Location = new System.Drawing.Point(648, 0);
            orderPnl.Name = "orderPnl";
            orderPnl.Size = new System.Drawing.Size(415, 556);
            orderPnl.TabIndex = 0;

            // panel7
            panel7.BackColor = System.Drawing.Color.White;
            panel7.Controls.Add(removeBtn);
            panel7.Location = new System.Drawing.Point(59, 67);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(317, 166);
            panel7.TabIndex = 2;

            // removeBtn
            removeBtn.BackColor = System.Drawing.Color.White;
            removeBtn.Font = new System.Drawing.Font("Segoe UI", 15F);
            removeBtn.Location = new System.Drawing.Point(271, 29);
            removeBtn.Name = "removeBtn";
            removeBtn.Size = new System.Drawing.Size(29, 34);
            removeBtn.TabIndex = 0;
            removeBtn.Text = "ⓧ";
            removeBtn.UseVisualStyleBackColor = false;

            // ordersumTxt
            ordersumTxt.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            ordersumTxt.BorderStyle = BorderStyle.None;
            ordersumTxt.Font = new System.Drawing.Font("Cambria", 12F);
            ordersumTxt.Location = new System.Drawing.Point(19, 23);
            ordersumTxt.Name = "ordersumTxt";
            ordersumTxt.Size = new System.Drawing.Size(136, 19);
            ordersumTxt.TabIndex = 1;
            ordersumTxt.Text = "order summary";

            // mainPnl
            mainPnl.BackColor = System.Drawing.Color.Ivory;
            mainPnl.Controls.Add(panel6);
            mainPnl.Controls.Add(panel5);
            mainPnl.Controls.Add(panel4);
            mainPnl.Controls.Add(panel3);
            mainPnl.Controls.Add(panel2);
            mainPnl.Controls.Add(panel1);
            mainPnl.Controls.Add(categoryComboBox);
            mainPnl.Controls.Add(searchboxTxt);
            mainPnl.Controls.Add(searchTxt);
            mainPnl.Location = new System.Drawing.Point(3, 3);
            mainPnl.Name = "mainPnl";
            mainPnl.Size = new System.Drawing.Size(648, 556);
            mainPnl.TabIndex = 1;

            // panel1
            panel1.BackColor = System.Drawing.Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(stock1);
            panel1.Controls.Add(price1);
            panel1.Controls.Add(item1);
            panel1.Location = new System.Drawing.Point(20, 115);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(164, 115);
            panel1.TabIndex = 3;

            comboBox2.Font = new System.Drawing.Font("Cambria", 8F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(25, 76);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(100, 20);
            comboBox2.TabIndex = 6;
            comboBox2.Text = "choose size";

            stock1.BorderStyle = BorderStyle.None;
            stock1.Font = new System.Drawing.Font("Cambria", 8F);
            stock1.Location = new System.Drawing.Point(25, 57);
            stock1.Name = "stock1";
            stock1.Size = new System.Drawing.Size(100, 13);
            stock1.TabIndex = 2;
            stock1.Text = "18 in stock";
            stock1.TextAlign = HorizontalAlignment.Center;

            price1.BorderStyle = BorderStyle.None;
            price1.Font = new System.Drawing.Font("Cambria", 12F);
            price1.ForeColor = System.Drawing.Color.LightPink;
            price1.Location = new System.Drawing.Point(25, 32);
            price1.Name = "price1";
            price1.Size = new System.Drawing.Size(100, 19);
            price1.TabIndex = 1;
            price1.Text = "$30.99";
            price1.TextAlign = HorizontalAlignment.Center;

            item1.BorderStyle = BorderStyle.None;
            item1.Font = new System.Drawing.Font("Cambria", 8F);
            item1.Location = new System.Drawing.Point(25, 13);
            item1.Name = "item1";
            item1.Size = new System.Drawing.Size(100, 13);
            item1.TabIndex = 0;
            item1.Text = "hazel wrap top";
            item1.TextAlign = HorizontalAlignment.Center;

            // panel2
            panel2.BackColor = System.Drawing.Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(sizeCombo);
            panel2.Controls.Add(stock2);
            panel2.Controls.Add(price2);
            panel2.Controls.Add(item2);
            panel2.Location = new System.Drawing.Point(246, 115);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(164, 115);
            panel2.TabIndex = 4;

            sizeCombo.Font = new System.Drawing.Font("Cambria", 8F);
            sizeCombo.FormattingEnabled = true;
            sizeCombo.Location = new System.Drawing.Point(32, 76);
            sizeCombo.Name = "sizeCombo";
            sizeCombo.Size = new System.Drawing.Size(100, 20);
            sizeCombo.TabIndex = 4;
            sizeCombo.Text = "choose size";

            stock2.BorderStyle = BorderStyle.None;
            stock2.Font = new System.Drawing.Font("Cambria", 8F);
            stock2.Location = new System.Drawing.Point(32, 57);
            stock2.Name = "stock2";
            stock2.Size = new System.Drawing.Size(100, 13);
            stock2.TabIndex = 3;
            stock2.Text = "9 in stock";
            stock2.TextAlign = HorizontalAlignment.Center;

            price2.BorderStyle = BorderStyle.None;
            price2.Font = new System.Drawing.Font("Cambria", 12F);
            price2.ForeColor = System.Drawing.Color.LightPink;
            price2.Location = new System.Drawing.Point(32, 32);
            price2.Name = "price2";
            price2.Size = new System.Drawing.Size(100, 19);
            price2.TabIndex = 2;
            price2.Text = "$45.00";
            price2.TextAlign = HorizontalAlignment.Center;

            item2.BorderStyle = BorderStyle.None;
            item2.Font = new System.Drawing.Font("Cambria", 8F);
            item2.Location = new System.Drawing.Point(32, 13);
            item2.Name = "item2";
            item2.Size = new System.Drawing.Size(100, 13);
            item2.TabIndex = 1;
            item2.Text = "tiered noir mini skirt";
            item2.TextAlign = HorizontalAlignment.Center;

            // panel3
            panel3.BackColor = System.Drawing.Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(stock3);
            panel3.Controls.Add(price3);
            panel3.Controls.Add(item3);
            panel3.Location = new System.Drawing.Point(464, 115);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(164, 115);
            panel3.TabIndex = 5;

            comboBox1.Font = new System.Drawing.Font("Cambria", 8F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(32, 76);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(100, 20);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "choose size";

            stock3.BorderStyle = BorderStyle.None;
            stock3.Font = new System.Drawing.Font("Cambria", 8F);
            stock3.Location = new System.Drawing.Point(32, 57);
            stock3.Name = "stock3";
            stock3.Size = new System.Drawing.Size(100, 13);
            stock3.TabIndex = 4;
            stock3.Text = "25 in stock";
            stock3.TextAlign = HorizontalAlignment.Center;

            price3.BorderStyle = BorderStyle.None;
            price3.Font = new System.Drawing.Font("Cambria", 12F);
            price3.ForeColor = System.Drawing.Color.LightPink;
            price3.Location = new System.Drawing.Point(32, 32);
            price3.Name = "price3";
            price3.Size = new System.Drawing.Size(100, 19);
            price3.TabIndex = 3;
            price3.Text = "$15.99";
            price3.TextAlign = HorizontalAlignment.Center;

            item3.BorderStyle = BorderStyle.None;
            item3.Font = new System.Drawing.Font("Cambria", 8F);
            item3.Location = new System.Drawing.Point(9, 13);
            item3.Name = "item3";
            item3.Size = new System.Drawing.Size(150, 13);
            item3.TabIndex = 2;
            item3.Text = "dollhouse ribbon headband";
            item3.TextAlign = HorizontalAlignment.Center;

            // panel4
            panel4.BackColor = System.Drawing.Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(comboBox5);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(price7);
            panel4.Controls.Add(item6);
            panel4.Location = new System.Drawing.Point(464, 270);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(164, 118);
            panel4.TabIndex = 6;

            comboBox5.Font = new System.Drawing.Font("Cambria", 8F);
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new System.Drawing.Point(32, 76);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(100, 20);
            comboBox5.TabIndex = 9;
            comboBox5.Text = "choose size";

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Cambria", 8F);
            textBox1.Location = new System.Drawing.Point(32, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(100, 13);
            textBox1.TabIndex = 7;
            textBox1.Text = "10 in stock";
            textBox1.TextAlign = HorizontalAlignment.Center;

            price7.BorderStyle = BorderStyle.None;
            price7.Font = new System.Drawing.Font("Cambria", 12F);
            price7.ForeColor = System.Drawing.Color.LightPink;
            price7.Location = new System.Drawing.Point(32, 32);
            price7.Name = "price7";
            price7.Size = new System.Drawing.Size(100, 19);
            price7.TabIndex = 6;
            price7.Text = "$85.49";
            price7.TextAlign = HorizontalAlignment.Center;

            item6.BorderStyle = BorderStyle.None;
            item6.Font = new System.Drawing.Font("Cambria", 8F);
            item6.Location = new System.Drawing.Point(9, 13);
            item6.Name = "item6";
            item6.Size = new System.Drawing.Size(150, 13);
            item6.TabIndex = 5;
            item6.Text = "midnight lace dress";
            item6.TextAlign = HorizontalAlignment.Center;

            // panel5
            panel5.BackColor = System.Drawing.Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(comboBox4);
            panel5.Controls.Add(stock5);
            panel5.Controls.Add(price6);
            panel5.Controls.Add(item5);
            panel5.Location = new System.Drawing.Point(246, 270);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(164, 118);
            panel5.TabIndex = 7;

            comboBox4.Font = new System.Drawing.Font("Cambria", 8F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(32, 76);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(100, 20);
            comboBox4.TabIndex = 8;
            comboBox4.Text = "choose size";

            stock5.BorderStyle = BorderStyle.None;
            stock5.Font = new System.Drawing.Font("Cambria", 8F);
            stock5.Location = new System.Drawing.Point(32, 57);
            stock5.Name = "stock5";
            stock5.Size = new System.Drawing.Size(100, 13);
            stock5.TabIndex = 6;
            stock5.Text = "out of stock";
            stock5.TextAlign = HorizontalAlignment.Center;

            price6.BorderStyle = BorderStyle.None;
            price6.Font = new System.Drawing.Font("Cambria", 12F);
            price6.ForeColor = System.Drawing.Color.LightPink;
            price6.Location = new System.Drawing.Point(32, 32);
            price6.Name = "price6";
            price6.Size = new System.Drawing.Size(100, 19);
            price6.TabIndex = 5;
            price6.Text = "$12.50";
            price6.TextAlign = HorizontalAlignment.Center;

            item5.BorderStyle = BorderStyle.None;
            item5.Font = new System.Drawing.Font("Cambria", 8F);
            item5.Location = new System.Drawing.Point(9, 13);
            item5.Name = "item5";
            item5.Size = new System.Drawing.Size(150, 13);
            item5.TabIndex = 4;
            item5.Text = "obsidian heart ring";
            item5.TextAlign = HorizontalAlignment.Center;

            // panel6
            panel6.BackColor = System.Drawing.Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(comboBox3);
            panel6.Controls.Add(stock4);
            panel6.Controls.Add(price4);
            panel6.Controls.Add(item4);
            panel6.Location = new System.Drawing.Point(20, 270);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(164, 118);
            panel6.TabIndex = 8;

            comboBox3.Font = new System.Drawing.Font("Cambria", 8F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(25, 76);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(100, 20);
            comboBox3.TabIndex = 7;
            comboBox3.Text = "choose size";

            stock4.BorderStyle = BorderStyle.None;
            stock4.Font = new System.Drawing.Font("Cambria", 8F);
            stock4.Location = new System.Drawing.Point(25, 57);
            stock4.Name = "stock4";
            stock4.Size = new System.Drawing.Size(100, 13);
            stock4.TabIndex = 5;
            stock4.Text = "low in stock";
            stock4.TextAlign = HorizontalAlignment.Center;

            price4.BorderStyle = BorderStyle.None;
            price4.Font = new System.Drawing.Font("Cambria", 12F);
            price4.ForeColor = System.Drawing.Color.LightPink;
            price4.Location = new System.Drawing.Point(25, 32);
            price4.Name = "price4";
            price4.Size = new System.Drawing.Size(100, 19);
            price4.TabIndex = 4;
            price4.Text = "$64.99";
            price4.TextAlign = HorizontalAlignment.Center;

            item4.BorderStyle = BorderStyle.None;
            item4.Font = new System.Drawing.Font("Cambria", 8F);
            item4.Location = new System.Drawing.Point(3, 13);
            item4.Name = "item4";
            item4.Size = new System.Drawing.Size(150, 13);
            item4.TabIndex = 3;
            item4.Text = "angel eyes pyjama set";
            item4.TextAlign = HorizontalAlignment.Center;

            // search and heading
            categoryComboBox.AllowDrop = true;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new System.Drawing.Point(219, 64);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new System.Drawing.Size(121, 23);
            categoryComboBox.TabIndex = 2;
            categoryComboBox.Text = "categories";
            categoryComboBox.SelectedIndexChanged += categoryComboBox_SelectedIndexChanged;

            searchboxTxt.AcceptsReturn = true;
            searchboxTxt.BorderStyle = BorderStyle.FixedSingle;
            searchboxTxt.Font = new System.Drawing.Font("Cambria", 10F);
            searchboxTxt.Location = new System.Drawing.Point(20, 64);
            searchboxTxt.Margin = new Padding(0);
            searchboxTxt.Name = "searchboxTxt";
            searchboxTxt.Size = new System.Drawing.Size(136, 23);
            searchboxTxt.TabIndex = 1;
            searchboxTxt.Text = "search products";
            searchboxTxt.TextChanged += searchboxTxt_TextChanged;

            searchTxt.BackColor = System.Drawing.Color.Ivory;
            searchTxt.BorderStyle = BorderStyle.None;
            searchTxt.Font = new System.Drawing.Font("Cambria", 12F);
            searchTxt.Location = new System.Drawing.Point(20, 20);
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new System.Drawing.Size(136, 19);
            searchTxt.TabIndex = 0;
            searchTxt.Text = "select products";

            // totals labels
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Cambria", 10F);
            label1.Location = new System.Drawing.Point(59, 251);
            label1.Name = "label1";
            label1.TabIndex = 3;
            label1.Text = "subtotal";

            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Cambria", 10F);
            label2.Location = new System.Drawing.Point(59, 284);
            label2.Name = "label2";
            label2.TabIndex = 4;
            label2.Text = "discount amount";

            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Cambria", 10F);
            label3.Location = new System.Drawing.Point(59, 309);
            label3.Name = "label3";
            label3.TabIndex = 5;
            label3.Text = "tax";

            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Cambria", 15F);
            label4.Location = new System.Drawing.Point(59, 331);
            label4.Name = "label4";
            label4.TabIndex = 6;
            label4.Text = "TOTAL";

            textBox2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new System.Drawing.Font("Cambria", 9F);
            textBox2.Location = new System.Drawing.Point(59, 376);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(100, 15);
            textBox2.TabIndex = 7;
            textBox2.Text = "discount code";

            discountTxt.Location = new System.Drawing.Point(59, 406);
            discountTxt.Name = "discountTxt";
            discountTxt.Size = new System.Drawing.Size(118, 23);
            discountTxt.TabIndex = 8;
            discountTxt.Text = "AMANE10";

            applydiscountBtn.Font = new System.Drawing.Font("Cambria", 9F);
            applydiscountBtn.Location = new System.Drawing.Point(226, 406);
            applydiscountBtn.Name = "applydiscountBtn";
            applydiscountBtn.Size = new System.Drawing.Size(75, 23);
            applydiscountBtn.TabIndex = 9;
            applydiscountBtn.Text = "apply";
            applydiscountBtn.UseVisualStyleBackColor = true;

            chargeBtn.BackColor = System.Drawing.Color.RosyBrown;
            chargeBtn.Font = new System.Drawing.Font("Cambria", 10F);
            chargeBtn.Location = new System.Drawing.Point(59, 449);
            chargeBtn.Name = "chargeBtn";
            chargeBtn.Size = new System.Drawing.Size(242, 41);
            chargeBtn.TabIndex = 10;
            chargeBtn.Text = "Charge";
            chargeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chargeBtn.UseVisualStyleBackColor = false;

            // BuildOrderControl
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPnl);
            Controls.Add(orderPnl);
            Name = "BuildOrderControl";
            Size = new System.Drawing.Size(1061, 523);

            orderPnl.ResumeLayout(false);
            orderPnl.PerformLayout();
            panel7.ResumeLayout(false);
            mainPnl.ResumeLayout(false);
            mainPnl.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        // field declarations
        private TextBox ordersumTxt;
        private Panel panel7;
        private Button removeBtn;
        private TextBox searchTxt;
        private TextBox searchboxTxt;
        private ComboBox categoryComboBox;
        private Panel panel1;
        private ComboBox comboBox2;
        private TextBox stock1;
        private TextBox price1;
        private TextBox item1;
        private Panel panel2;
        private ComboBox sizeCombo;
        private TextBox stock2;
        private TextBox price2;
        private TextBox item2;
        private Panel panel3;
        private ComboBox comboBox1;
        private TextBox stock3;
        private TextBox price3;
        private TextBox item3;
        private Panel panel4;
        private ComboBox comboBox5;
        private TextBox textBox1;
        private TextBox price7;
        private TextBox item6;
        private Panel panel5;
        private ComboBox comboBox4;
        private TextBox stock5;
        private TextBox price6;
        private TextBox item5;
        private Panel panel6;
        private ComboBox comboBox3;
        private TextBox stock4;
        private TextBox price4;
        private TextBox item4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Button chargeBtn;
        private Button applydiscountBtn;
        private TextBox discountTxt;
    }
}
