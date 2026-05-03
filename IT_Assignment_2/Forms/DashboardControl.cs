using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms
{
    public partial class DashboardControl : UserControl
    {
        // Instance field to hold the current customer; set via the overloaded constructor.
        private Customer _customer;

        // Parameterless constructor kept for designer compatibility.
        public DashboardControl()
        {
            InitializeComponent();
            // Do not call UsernameGreeting here because no Customer instance is available.
            UsernameGreeting(); // This will set a generic greeting until the overloaded constructor is used.
            SetUpKPITiles();
            SetUpButtons();
            LoadLowStockAlerts();
        }

        // Overloaded constructor: callers should use this to provide the current customer.
        public DashboardControl(Customer customer) : this()
        {
            _customer = customer;
            UsernameGreeting();
        }

        private void UsernameGreeting()
        {
            int hour = DateTime.Now.Hour;
            string TimeOfDay = hour < 12 ? "Morning" : hour < 18 ? "Afternoon" : "Evening";
            string name = SessionManager.CurrentUser?.FirstName ?? "there";
            label1.Text = $"Good {TimeOfDay}, {name}";

            label2.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void SetUpKPITiles()
        {
            // Implementation for setting up KPI tiles
        }

        private void SetUpButtons()
        {
            // Implementation for setting up buttons
        }

        private void LoadLowStockAlerts()
        {
            // Implementation for loading low stock alerts
        }
    }
    
}
