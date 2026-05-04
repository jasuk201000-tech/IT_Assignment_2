using AmanePOSHelpers;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms
{
    public partial class DashboardControl : UserControl
    {
        
        private Customer? _customer;
        private int lowStock;

        
        public event Action<string>? NavigationRequested;

        // default constructor for manager view
        public DashboardControl()
        {
            InitializeComponent();
            UsernameGreeting();
            SetUpKPITiles();
            SetUpButtons();
            LoadLowStockAlerts();
        }

        
        public DashboardControl(Customer customer) : this()
        {
            _customer = customer;
            UsernameGreeting();
        }

        // adding value to the top label
        public void UsernameGreeting()
        {
            int hour = DateTime.Now.Hour;
            string period = hour < 12 ? "Morning" : hour < 18 ? "Afternoon" : "Evening";
            string name = SessionManager.CurrentUser?.FirstName ?? "there";

            label1.Text = $"Good {period}, {name}";
            label2.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        // key performance indicator tiles — revenue, orders today, low stock count, returns
        private void SetUpKPITiles()
        {
            // revenue
            decimal revenue = SafeGet(() => OrderService.GetTodaysRevenue(), 0m);
            AddKpiValue(panel1, $"${revenue:N2}");

            // orders today
            int orders = SafeGet(() => OrderService.GetTodaysOrderCount(), 0);
            AddKpiValue(panel2, orders.ToString());

            // low stock count
            int lowStockCount = SafeGet(
                () => ProductServices.GetLowStockProducts()
                          .SelectMany(p => p.Variants)
                          .Count(v => v.IsLowStock),
                0);
            AddKpiValue(panel3, lowStockCount.ToString(),
                lowStockCount > 0
                    ? AmanePOSHelpers.AmaneStyling.Warning
                    : AmanePOSHelpers.AmaneStyling.Success);

            // returns — refunded orders today
            int returns = SafeGet(
                () => OrderService.GetTodaysOrders()
                          .Count(o => o.Status == OrderStatus.Refunded),
                0);
            AddKpiValue(panel4, returns.ToString());
        }

        // adds the large value label to a KPI tile below its title label
        private void AddKpiValue(Panel tile, string value, Color? colour = null)
        {
            var lbl = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20f, FontStyle.Regular),
                ForeColor = colour ?? Color.FromArgb(70, 50, 50),
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(10, 38)
            };
            tile.Controls.Add(lbl);
        }

        // quick navigation buttons
        private void SetUpButtons()
        {
            
            neworderBtn.Click += (_, _) => NavigationRequested?.Invoke("orders");
            inventorymanageBtn.Click += (_, _) => NavigationRequested?.Invoke("inventory");
            reportsviewBtn.Click += (_, _) => NavigationRequested?.Invoke("reports");

            // cashiers do not see the reports button
            reportsviewBtn.Visible = SessionManager.IsManager;
        }

        // low stock alerts
        private void LoadLowStockAlerts()
        {
            lowstockalertPnl.Controls.Clear();

            List<Product> lowProducts = SafeGet(
                () => ProductServices.GetLowStockProducts(),
                new List<Product>());

            if (lowProducts.Count == 0)
            {
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
                foreach (var variant in product.Variants.Where(v => v.IsLowStock))
                    lowstockalertPnl.Controls.Add(
                        BuildLowStockRow(product.ProductName, variant));
        }

        // builds one row for a low stock variant
        private Panel BuildLowStockRow(string productName, ProductVariant variant)
        {
            Color countColour = variant.StockQty == 0
                ? AmaneStyling.Danger
                : AmaneStyling.Warning;

            var row = new Panel
            {
                Size = new Size(lowstockalertPnl.Width - 8, 32),
                BackColor = Color.FromArgb(250, 243, 240),
                Margin = new Padding(4, 2, 4, 2)
            };

            row.Controls.Add(new Label
            {
                Text = productName,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(70, 50, 50),
                AutoSize = true,
                Location = new Point(8, 8)
            });

            row.Controls.Add(new Label
            {
                Text = $"Size {variant.Size}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(140, 110, 110),
                AutoSize = true,
                Location = new Point(200, 8)
            });

            string countText = variant.StockQty == 0
                ? "out of stock"
                : $"{variant.StockQty} left";

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

        // try catch
        private static T SafeGet<T>(Func<T> fn, T fallback)
        {
            try { return fn(); }
            catch { return fallback; }
        }
    }
}