using AmanePOSHelpers;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Windows.Forms;


namespace IT_Assignment_2.Forms
{
    public partial class Form1 : Form
    {
        
        private Panel NavPanel = null!;

        public Form1()
        {
            InitializeComponent();

            
            NavPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = AmaneStyling.NavBar
            };

           
            this.Controls.Add(NavPanel);
        }

        
    }
}
