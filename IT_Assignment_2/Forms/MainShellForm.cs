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
            inventoryBtn = new Button();
            dashboardBtn = new Button();
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
            panel1.Controls.Add(inventoryBtn);
            panel1.Controls.Add(dashboardBtn);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 69);
            panel1.TabIndex = 0;
            // 
            // logoBtn
            // 
            logoBtn.BackColor = Color.FromArgb(220, 180, 180);
            logoBtn.Location = new Point(22, 27);
            logoBtn.Name = "logoBtn";
            logoBtn.Size = new Size(86, 23);
            logoBtn.TabIndex = 5;
            logoBtn.Text = "𝖆𝖒𝖆𝖓𝖊";
            logoBtn.UseVisualStyleBackColor = false;
            logoBtn.Click += logoBtn_Click;
            // 
            // settingsBtn
            // 
            settingsBtn.BackColor = Color.FromArgb(220, 180, 180);
            settingsBtn.Font = new Font("Cambria", 10F);
            settingsBtn.Location = new Point(1182, 27);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(104, 23);
            settingsBtn.TabIndex = 4;
            settingsBtn.Text = "settings";
            settingsBtn.UseVisualStyleBackColor = false;
            // 
            // reportsBtn
            // 
            reportsBtn.BackColor = Color.FromArgb(220, 180, 180);
            reportsBtn.Font = new Font("Cambria", 10F);
            reportsBtn.Location = new Point(1046, 27);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(104, 23);
            reportsBtn.TabIndex = 3;
            reportsBtn.Text = "reports";
            reportsBtn.UseVisualStyleBackColor = false;
            // 
            // orderBtn
            // 
            orderBtn.BackColor = Color.FromArgb(220, 180, 180);
            orderBtn.Font = new Font("Cambria", 10F);
            orderBtn.Location = new Point(902, 27);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(104, 23);
            orderBtn.TabIndex = 2;
            orderBtn.Text = "orders";
            orderBtn.UseVisualStyleBackColor = false;
            orderBtn.Click += orderBtn_Click;
            // 
            // inventoryBtn
            // 
            inventoryBtn.BackColor = Color.FromArgb(220, 180, 180);
            inventoryBtn.Font = new Font("Cambria", 10F);
            inventoryBtn.Location = new Point(754, 27);
            inventoryBtn.Name = "inventoryBtn";
            inventoryBtn.Size = new Size(104, 23);
            inventoryBtn.TabIndex = 1;
            inventoryBtn.Text = "inventory";
            inventoryBtn.UseVisualStyleBackColor = false;
            // 
            // dashboardBtn
            // 
            dashboardBtn.BackColor = Color.FromArgb(220, 180, 180);
            dashboardBtn.Font = new Font("Cambria", 10F);
            dashboardBtn.Location = new Point(612, 27);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Size = new Size(104, 23);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "dashboard";
            dashboardBtn.UseVisualStyleBackColor = false;
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
        private Button inventoryBtn;
        private Button dashboardBtn;
        private Button settingsBtn;
        private Button reportsBtn;
        private Button orderBtn;
        private Button logoBtn;

        private void logoBtn_Click(object sender, EventArgs e)
        {
            logoBtn.Enabled = false;
        }

        private Panel pnlContent;

        private void ShowScreen(UserControl newScreen)
        {
            // Find existing controls and dispose them to free memory
            foreach (Control ctrl in pnlContent.Controls)
            {
                ctrl.Dispose();
            }

            pnlContent.Controls.Clear(); 
            newScreen.Dock = DockStyle.Fill; 
            pnlContent.Controls.Add(newScreen); 
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            ShowScreen(new BuildOrderControl());
        }
    }
}
