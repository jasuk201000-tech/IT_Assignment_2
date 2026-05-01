using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            logoBtn = new Button();
            settingsBtn = new Button();
            reportsBtn = new Button();
            orderBtn = new Button();
            button2 = new Button();
            button1 = new Button();
            pnlContent = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(220, 180, 180);
            panel1.Controls.Add(logoBtn);
            panel1.Controls.Add(settingsBtn);
            panel1.Controls.Add(reportsBtn);
            panel1.Controls.Add(orderBtn);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 69);
            panel1.TabIndex = 0;
            // 
            // logoBtn
            // 
            logoBtn.Location = new Point(22, 27);
            logoBtn.Name = "logoBtn";
            logoBtn.Size = new Size(86, 23);
            logoBtn.TabIndex = 5;
            logoBtn.Text = "𝖆𝖒𝖆𝖓𝖊";
            logoBtn.UseVisualStyleBackColor = true;
            logoBtn.Click += logoBtn_Click;
            // 
            // settingsBtn
            // 
            settingsBtn.Font = new Font("Cambria", 10F);
            settingsBtn.Location = new Point(1182, 27);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(104, 23);
            settingsBtn.TabIndex = 4;
            settingsBtn.Text = "settings";
            settingsBtn.UseVisualStyleBackColor = true;
            // 
            // reportsBtn
            // 
            reportsBtn.Font = new Font("Cambria", 10F);
            reportsBtn.Location = new Point(1046, 27);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(104, 23);
            reportsBtn.TabIndex = 3;
            reportsBtn.Text = "reports";
            reportsBtn.UseVisualStyleBackColor = true;
            // 
            // orderBtn
            // 
            orderBtn.Font = new Font("Cambria", 10F);
            orderBtn.Location = new Point(902, 27);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(104, 23);
            orderBtn.TabIndex = 2;
            orderBtn.Text = "orders";
            orderBtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Cambria", 10F);
            button2.Location = new Point(754, 27);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 1;
            button2.Text = "inventory";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Cambria", 10F);
            button1.Location = new Point(612, 27);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 0;
            button1.Text = "dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Location = new Point(2, 76);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1350, 460);
            pnlContent.TabIndex = 1;
            // 
            // Form1
            // 
            ClientSize = new Size(1351, 533);
            Controls.Add(pnlContent);
            Controls.Add(panel1);
            Name = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Button settingsBtn;
        private Button reportsBtn;
        private Button orderBtn;
        private Button logoBtn;

        private void logoBtn_Click(object sender, EventArgs e)
        {
            logoBtn.Enabled = false;
        }

        private Panel pnlContent;
    }
}
