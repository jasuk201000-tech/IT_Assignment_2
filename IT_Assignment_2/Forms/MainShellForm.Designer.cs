using AmanePOSHelpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms
{
    partial class MainShellForm : Form
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

        private void InitializeComponent()
        {
            InitializeComponent(flowLayoutPanel1, GetLogoBtn1());
        }

        private Button GetLogoBtn1()
        {
            return logoBtn;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(FlowLayoutPanel flowLayoutPanel11, Button logoBtn1)
        {
            NavPanel = new Panel();
            settingsBtn = new Button();
            transactionsBtn = new Button();
            ordersBtn = new Button();
            inventoryBtn = new Button();
            dashboardBtn = new Button();
            logoBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = AmaneStyling.NavBar;
            NavPanel.Controls.Add(logoBtn);
            NavPanel.Controls.Add(settingsBtn);
            NavPanel.Controls.Add(transactionsBtn);
            NavPanel.Controls.Add(ordersBtn);
            NavPanel.Controls.Add(inventoryBtn);
            NavPanel.Controls.Add(dashboardBtn);
            NavPanel.Location = new Point(0, -3);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(1349, 48);
            NavPanel.TabIndex = 0;
            // 
            // settingsBtn
            // 
            settingsBtn.BackColor = AmaneStyling.NavBar;
            settingsBtn.Font = new Font("Cambria", 8.25F);
            settingsBtn.Location = new Point(1161, 15);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(94, 23);
            settingsBtn.TabIndex = 4;
            settingsBtn.Text = "settings";
            settingsBtn.UseVisualStyleBackColor = false;
            // 
            // transactionsBtn
            // 
            transactionsBtn.BackColor = AmaneStyling.NavBar;
            transactionsBtn.Font = new Font("Cambria", 8.25F);
            transactionsBtn.Location = new Point(1035, 15);
            transactionsBtn.Name = "transactionsBtn";
            transactionsBtn.Size = new Size(94, 23);
            transactionsBtn.TabIndex = 3;
            transactionsBtn.Text = "transactions";
            transactionsBtn.UseVisualStyleBackColor = false;
            // 
            // ordersBtn
            // 
            ordersBtn.BackColor = Color.FromArgb(220, 180, 180);
            ordersBtn.Font = new Font("Cambria", 8.25F);
            ordersBtn.Location = new Point(913, 15);
            ordersBtn.Name = "ordersBtn";
            ordersBtn.Size = new Size(94, 23);
            ordersBtn.TabIndex = 2;
            ordersBtn.Text = "orders";
            ordersBtn.UseVisualStyleBackColor = false;
            // 
            // inventoryBtn
            // 
            inventoryBtn.BackColor = AmaneStyling.NavBar;
            inventoryBtn.Font = new Font("Cambria", 8.25F);
            inventoryBtn.Location = new Point(789, 15);
            inventoryBtn.Name = "inventoryBtn";
            inventoryBtn.Size = new Size(94, 23);
            inventoryBtn.TabIndex = 1;
            inventoryBtn.Text = "inventory";
            inventoryBtn.UseVisualStyleBackColor = false;
            // 
            // dashboardBtn
            // 

            dashboardBtn.BackColor = AmaneStyling.NavBar;
            dashboardBtn.Font = new Font("Cambria", 8.25F);
            dashboardBtn.Location = new Point(661, 15);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Size = new Size(94, 23);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "dashboard";
            dashboardBtn.UseVisualStyleBackColor = false;
            // 
            // logoBtn
            // 
            logoBtn.BackColor = AmaneStyling.NavBar;
            logoBtn.Location = new Point(22, 15);
            logoBtn.Name = "logoBtn";
            logoBtn.Size = new Size(97, 23);
            logoBtn1.TabIndex = 6;
            logoBtn.Text = "𝖆𝖒𝖆𝖓𝖊\n";
            logoBtn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(2, 48);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel11.Size = new Size(1347, 592);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 634);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(NavPanel);
            Name = "Form1";
            Text = "Form1";
            NavPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel NavPanel;
        private Button transactionsBtn;
        private Button ordersBtn;
        private Button inventoryBtn;
        private Button dashboardBtn;
        private Button settingsBtn;
        private Button logoBtn;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}