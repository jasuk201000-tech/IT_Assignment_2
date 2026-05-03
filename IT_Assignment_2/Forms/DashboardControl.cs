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


            // revenue panel
            decimal revenue = SafeGet(() => OrderService.GetTodaysRevenue(), 0m);
            AddKpiValue(panel1, $"${revenue:N2}");

            // orders panel
            int orders = SafeGet(() => OrderService.GetTodaysOrderCount(), 0);
            AddKpiValue(panel2, orders.ToString());

           

            // low stock panel
            int lowStockItems = SafeGet(
                 int lowStock = SafeGet(
                () => ProductServices.GetLowStockProducts()
                          .SelectMany(p => p.Variants)
                          .Count(v => v.IsLowStock),
                  AddKpiValue(panel3, lowStock.ToString(),
                lowStock > 0 ? Color.FromArgb(220, 180, 100) // Warning amber
                             : Color.FromArgb(130, 180, 140)); // Success green

            // returns tile — count of refunded orders today
            int returns = SafeGet(
                () => OrderService.GetTodaysOrders()
                          .Count(o => o.Status == OrderStatus.Refunded),
                0);
            AddKpiValue(panel4, returns.ToString());

             private void AddKpiValue(Panel tile, string value,
            Color? colour = null)
        {
            var lbl = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20f, FontStyle.Regular),
                ForeColor = colour ?? Color.FromArgb(70, 50, 50),
                BackColor = Color.Transparent,
                AutoSize = true,
                // position below the existing title label
                Location = new Point(10, 38)
            };
            tile.Controls.Add(lbl);
        }


        private void SetUpButtons()
        {
            // Implementation for setting up buttons
            neworderBtn.Click += (_, _) => NavigationRequested?.Invoke("orders");
            inventorymanageBtn.Click += (_, _) => NavigationRequested?.Invoke("inventory");
            reportsviewBtn.Click += (_, _) => NavigationRequested?.Invoke("reports");

            // hide reports button for cashiers
            reportsviewBtn.Visible = SessionManager.IsManager;
        }

        private void LoadLowStockAlerts()
        {
            // Implementation for loading low stock alerts
            lowstockalertPnl.Controls.Clear();

            List<Product> lowProducts = SafeGet(
                () => ProductServices.GetLowStockProducts(),
                new List<Product>());

            if (lowProducts.Count == 0)
            {
                // empty state — show a friendly message
                lowstockalertPnl.Controls.Add(new Label
                {
                    Text = "all products are well stocked ✓",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = Color.FromArgb(130, 180, 140),
                    AutoSize = true,
                    Margin = new Padding(8)
                });
                return;
            }
            foreach (var product in lowProducts)
            {
                foreach (var variant in product.Variants.Where(v => v.IsLowStock))
                {
                    lowstockalertPnl.Controls.Add(
                        BuildLowStockRow(product.ProductName, variant));
                }
            }
             private Panel BuildLowStockRow(string productName, ProductVariant variant)
        {
            // colour the count — red if zero, amber if low
            Color countColour = variant.StockQty == 0
                ? Color.FromArgb(210, 100, 100)   // Danger red
                : Color.FromArgb(220, 180, 100);  // Warning amber

            var row = new Panel
            {
                Size = new Size(lowstockalertPnl.Width - 8, 32),
                BackColor = Color.FromArgb(250, 243, 240), // CardBg
                Margin = new Padding(4, 2, 4, 2)
            };

            // product name
            row.Controls.Add(new Label
            {
                Text = productName,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(70, 50, 50),
                AutoSize = true,
                Location = new Point(8, 8)
            });

            // size
            row.Controls.Add(new Label
            {
                Text = $"Size {variant.Size}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(140, 110, 110),
                AutoSize = true,
                Location = new Point(200, 8)
            });

            // stock count
            string countText = variant.StockQty == 0 ? "out of stock" : $"{variant.StockQty} left";
            row.Controls.Add(new Label
            {
                Text = countText,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = countColour,
                AutoSize = true,
                Location = new Point(320, 8)
            });

            return row;
        }

        // safe Get method to handle potential exceptions from service calls, returning a fallback value if an error occurs
        public static T SafeGet<T>(Func<T> fn, T fallback)
        {
            try { return fn(); }
            catch { return fallback; }
        }
    }
}
