namespace IT_Assignment_2.Forms
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));

            image1 = new PictureBox();
            image2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            returnsLbl = new Label();
            panel3 = new Panel();
            lowstockLbl = new Label();
            panel2 = new Panel();
            orderLbl = new Label();
            panel1 = new Panel();
            revenueLbl = new Label();
            lowstockalertPnl = new FlowLayoutPanel();
            lowstockLbl2 = new Label();
            label3 = new Label();
            panel5 = new Panel();
            neworderBtn = new Button();
            inventorymanageBtn = new Button();
            reportsviewBtn = new Button();

            ((System.ComponentModel.ISupportInitialize)image1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)image2).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();

            // ── image1 — unchanged ────────────────────────────────────────────
            image1.Image = (Image)resources.GetObject("image1.Image");
            image1.Location = new Point(-61, -156);
            image1.Name = "image1";
            image1.Size = new Size(737, 421);
            image1.TabIndex = 2;
            image1.TabStop = false;

            // ── image2 — unchanged ────────────────────────────────────────────
            image2.Image = (Image)resources.GetObject("image2.Image");
            image2.Location = new Point(610, -156);
            image2.Name = "image2";
            image2.Size = new Size(737, 421);
            image2.TabIndex = 3;
            image2.TabStop = false;

            // ── label1  "welcome *insert name*" ──────────────────────────────
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
            label1.ForeColor = Color.FromArgb(70, 50, 50);       // TextDark
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(392, 96);
            label1.Name = "label1";
            label1.Size = new Size(212, 23);
            label1.TabIndex = 4;
            label1.Text = "welcome *insert name*";

            // ── label2  date ──────────────────────────────────────────────────
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(140, 110, 110);    // TextMuted
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(450, 128);
            label2.Name = "label2";
            label2.Size = new Size(95, 16);
            label2.TabIndex = 5;
            label2.Text = "May 3rd, 2026";

            // ── panel4  returns KPI tile ──────────────────────────────────────
            panel4.BackColor = Color.FromArgb(250, 243, 240);  // CardBg
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(returnsLbl);
            panel4.Location = new Point(821, 177);
            panel4.Name = "panel4";
            panel4.Size = new Size(164, 88);
            panel4.TabIndex = 13;

            returnsLbl.AutoSize = true;
            returnsLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            returnsLbl.ForeColor = Color.FromArgb(140, 110, 110); // TextMuted
            returnsLbl.BackColor = Color.Transparent;
            returnsLbl.Location = new Point(58, 13);
            returnsLbl.Name = "returnsLbl";
            returnsLbl.Size = new Size(53, 16);
            returnsLbl.TabIndex = 7;
            returnsLbl.Text = "returns";

            // ── panel3  low stock alerts KPI tile ─────────────────────────────
            panel3.BackColor = Color.FromArgb(250, 243, 240);  // CardBg
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lowstockLbl);
            panel3.Location = new Point(572, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(165, 88);
            panel3.TabIndex = 11;

            lowstockLbl.AutoSize = true;
            lowstockLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lowstockLbl.ForeColor = Color.FromArgb(140, 110, 110); // TextMuted
            lowstockLbl.BackColor = Color.Transparent;
            lowstockLbl.Location = new Point(26, 13);
            lowstockLbl.Name = "lowstockLbl";
            lowstockLbl.Size = new Size(101, 16);
            lowstockLbl.TabIndex = 7;
            lowstockLbl.Text = "low stock alerts";

            // ── panel2  orders today KPI tile ─────────────────────────────────
            panel2.BackColor = Color.FromArgb(250, 243, 240);  // CardBg
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(orderLbl);
            panel2.Location = new Point(268, 177);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 88);
            panel2.TabIndex = 12;

            orderLbl.AutoSize = true;
            orderLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            orderLbl.ForeColor = Color.FromArgb(140, 110, 110);  // TextMuted
            orderLbl.BackColor = Color.Transparent;
            orderLbl.Location = new Point(38, 13);
            orderLbl.Name = "orderLbl";
            orderLbl.Size = new Size(84, 16);
            orderLbl.TabIndex = 7;
            orderLbl.Text = "orders today";

            // ── panel1  revenue KPI tile ──────────────────────────────────────
            panel1.BackColor = Color.FromArgb(250, 243, 240);  // CardBg
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(revenueLbl);
            panel1.Location = new Point(39, 177);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 88);
            panel1.TabIndex = 10;

            revenueLbl.AutoSize = true;
            revenueLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            revenueLbl.ForeColor = Color.FromArgb(140, 110, 110); // TextMuted
            revenueLbl.BackColor = Color.Transparent;
            revenueLbl.Location = new Point(27, 13);
            revenueLbl.Name = "revenueLbl";
            revenueLbl.Size = new Size(103, 16);
            revenueLbl.TabIndex = 7;
            revenueLbl.Text = "today's revenue";

            // ── lowstockalertPnl  scrollable low stock list ───────────────────
            lowstockalertPnl.BackColor = Color.FromArgb(235, 220, 215); // SidebarBg
            lowstockalertPnl.Location = new Point(13, 308);
            lowstockalertPnl.Name = "lowstockalertPnl";
            lowstockalertPnl.Size = new Size(484, 257);
            lowstockalertPnl.TabIndex = 14;

            // ── lowstockLbl2  section heading ─────────────────────────────────
            lowstockLbl2.AutoSize = true;
            lowstockLbl2.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lowstockLbl2.ForeColor = Color.FromArgb(140, 110, 110); // TextMuted
            lowstockLbl2.BackColor = Color.Transparent;
            lowstockLbl2.Location = new Point(13, 280);
            lowstockLbl2.Name = "lowstockLbl2";
            lowstockLbl2.Size = new Size(101, 16);
            lowstockLbl2.TabIndex = 15;
            lowstockLbl2.Text = "low stock alerts";

            // ── label3  quick actions heading ─────────────────────────────────
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label3.ForeColor = Color.FromArgb(140, 110, 110);    // TextMuted
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(558, 280);
            label3.Name = "label3";
            label3.Size = new Size(86, 16);
            label3.TabIndex = 16;
            label3.Text = "quick actions";

            // ── panel5  quick actions container ──────────────────────────────
            panel5.BackColor = Color.FromArgb(235, 220, 215);    // SidebarBg
            panel5.Controls.Add(reportsviewBtn);
            panel5.Controls.Add(inventorymanageBtn);
            panel5.Controls.Add(neworderBtn);
            panel5.Location = new Point(558, 308);
            panel5.Name = "panel5";
            panel5.Size = new Size(392, 257);
            panel5.TabIndex = 17;

            // ── neworderBtn ───────────────────────────────────────────────────
            neworderBtn.BackColor = Color.FromArgb(198, 152, 152); // ButtonPrimary
            neworderBtn.ForeColor = Color.White;                   // ButtonText
            neworderBtn.FlatStyle = FlatStyle.Flat;
            neworderBtn.FlatAppearance.BorderSize = 0;
            neworderBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            neworderBtn.ImageAlign = ContentAlignment.MiddleLeft;
            neworderBtn.Location = new Point(28, 28);
            neworderBtn.Name = "neworderBtn";
            neworderBtn.Size = new Size(256, 34);
            neworderBtn.TabIndex = 0;
            neworderBtn.Text = "new order";
            neworderBtn.UseVisualStyleBackColor = false;
            neworderBtn.Cursor = Cursors.Hand;

            // ── inventorymanageBtn ────────────────────────────────────────────
            inventorymanageBtn.BackColor = Color.FromArgb(240, 210, 210); // AccentLight
            inventorymanageBtn.ForeColor = Color.FromArgb(70, 50, 50);   // TextDark
            inventorymanageBtn.FlatStyle = FlatStyle.Flat;
            inventorymanageBtn.FlatAppearance.BorderSize = 0;
            inventorymanageBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            inventorymanageBtn.ImageAlign = ContentAlignment.MiddleLeft;
            inventorymanageBtn.Location = new Point(28, 76);
            inventorymanageBtn.Name = "inventorymanageBtn";
            inventorymanageBtn.Size = new Size(256, 34);
            inventorymanageBtn.TabIndex = 1;
            inventorymanageBtn.Text = "manage inventory";
            inventorymanageBtn.UseVisualStyleBackColor = false;
            inventorymanageBtn.Cursor = Cursors.Hand;

            // ── reportsviewBtn ────────────────────────────────────────────────
            reportsviewBtn.BackColor = Color.FromArgb(240, 210, 210);   // AccentLight
            reportsviewBtn.ForeColor = Color.FromArgb(70, 50, 50);      // TextDark
            reportsviewBtn.FlatStyle = FlatStyle.Flat;
            reportsviewBtn.FlatAppearance.BorderSize = 0;
            reportsviewBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            reportsviewBtn.ImageAlign = ContentAlignment.MiddleLeft;
            reportsviewBtn.Location = new Point(28, 124);
            reportsviewBtn.Name = "reportsviewBtn";
            reportsviewBtn.Size = new Size(256, 34);
            reportsviewBtn.TabIndex = 2;
            reportsviewBtn.Text = "view reports";
            reportsviewBtn.UseVisualStyleBackColor = false;
            reportsviewBtn.Cursor = Cursors.Hand;

            // ── DashboardControl ──────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 238, 232); // PageBg — warm cream
            Controls.Add(panel5);
            Controls.Add(label3);
            Controls.Add(lowstockLbl2);
            Controls.Add(lowstockalertPnl);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(image2);
            Controls.Add(image1);
            Name = "DashboardControl";
            Size = new Size(1019, 582);

            ((System.ComponentModel.ISupportInitialize)image1).EndInit();
            ((System.ComponentModel.ISupportInitialize)image2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLbl;
        private PictureBox image1;
        private PictureBox image2;
        private Label label1;
        private Label label2;
        private Panel panel4;
        private Label returnsLbl;
        private Panel panel3;
        private Label lowstockLbl;
        private Panel panel2;
        private Label orderLbl;
        private Panel panel1;
        private Label revenueLbl;
        private FlowLayoutPanel lowstockalertPnl;
        private Label lowstockLbl2;
        private Label label3;
        private Panel panel5;
        private Button reportsviewBtn;
        private Button inventorymanageBtn;
        private Button neworderBtn;
    }
}