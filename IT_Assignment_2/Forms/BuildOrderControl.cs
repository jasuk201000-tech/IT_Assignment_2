using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IT_Assignment_2.Data;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;

namespace IT_Assignment_2.Forms
{
    
    public partial class BuildOrderControl : UserControl
    {
        // managing the order state
        private readonly List<OrderItem> _items = new();
        private decimal _discountAmount = 0m;
        private string? _discountCode = null;
        private List<Product> _allProducts = new();
        private List<(Panel Card, TextBox Name, TextBox Price,
            TextBox Stock, ComboBox Size, Product? Product)> _slots = new();

        // building the order creation interface with product selection, order summary, and checkout functionality
        public BuildOrderControl()
        {
            InitializeComponent();
            WireUpSlots();
            WireUpButtons();
            LoadCategories();
            LoadProducts();
            RecalculateTotals();
        }

        private void WireUpSlots()
        {
            _slots = new List<(Panel, TextBox, TextBox, TextBox, ComboBox, Product?)>
            {
                (panel1, item1, price1, stock1,  comboBox2, null),
                (panel2, item2, price2, stock2,  sizeCombo, null),
                (panel3, item3, price3, stock3,  comboBox1, null),
                (panel4, item6, price7, textBox1,comboBox5, null),
                (panel5, item5, price6, stock5,  comboBox4, null),
                (panel6, item4, price4, stock4,  comboBox3, null),
            };

            for (int i = 0; i < _slots.Count; i++)
            {
                int idx = i;
                var (card, name, price, stock, size, _) = _slots[idx];
                card.Click += (_, _) => CardClicked(idx);
                name.Click += (_, _) => CardClicked(idx);
                price.Click += (_, _) => CardClicked(idx);
                stock.Click += (_, _) => CardClicked(idx);
            }
        }

        private void WireUpButtons()
        {
            // search and filter triggers
            chargeBtn.Click += BtnCharge_Click;
            applydiscountBtn.Click += BtnApplyDiscount_Click;
            removeBtn.Visible = false;
        }

        private void LoadCategories()
        {
            // load categories into the filter dropdown
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Add("categories");
            foreach (var c in ProductServices.GetCategories())
                categoryComboBox.Items.Add(c);
            categoryComboBox.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            // load products based on search and category filters, and populate the product slots
            string? search = searchboxTxt.Text == "search products"
                || string.IsNullOrWhiteSpace(searchboxTxt.Text)
                ? null : searchboxTxt.Text.Trim();

            string? category = categoryComboBox.SelectedIndex > 0
                ? categoryComboBox.SelectedItem?.ToString() : null;

            _allProducts = ProductServices.Search(category, search);

            //adding products to the slots
            for (int i = 0; i < _slots.Count; i++)
            {
                var (card, name, price, stock, size, _) = _slots[i];

                // stock conditions and display logic
                if (i < _allProducts.Count)
                {
                    var p = _allProducts[i];
                    name.Text = p.ProductName;
                    price.Text = $"${p.MinPrice:N2}";

                    if (p.TotalStock == 0)
                    {
                        stock.Text = "out of stock"; stock.ForeColor = Color.Gray;
                        price.ForeColor = Color.LightGray;
                        card.BackColor = Color.FromArgb(240, 240, 240); size.Enabled = false;
                    }
                    else if (p.HasLowStock)
                    {
                        stock.Text = "low in stock"; stock.ForeColor = Color.FromArgb(180, 120, 30);
                        price.ForeColor = Color.LightPink;
                        card.BackColor = Color.White; size.Enabled = true;
                    }
                    else
                    {
                        stock.Text = $"{p.TotalStock} in stock"; stock.ForeColor = Color.Gray;
                        price.ForeColor = Color.LightPink;
                        card.BackColor = Color.White; size.Enabled = true;
                    }

                    size.Items.Clear();
                    size.Items.Add("choose size");
                    foreach (var v in p.Variants.Where(v => !v.IsOutOfStock))
                        size.Items.Add(v.Size);
                    size.SelectedIndex = 0;

                    _slots[i] = (card, name, price, stock, size, p);
                    card.Visible = true;
                }
                else
                {
                    card.Visible = false;
                    _slots[i] = (card, name, price, stock, size, null);
                }
            }
        }

        private void CardClicked(int idx)
        {
            var (_, _, _, _, size, product) = _slots[idx];
            if (product == null) return;

            if (product.TotalStock == 0)
            {
                MessageBox.Show("This product is out of stock.", "Amane",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (size.SelectedIndex <= 0)
            {
                MessageBox.Show("Please choose a size first.", "Amane",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            var variant = product.Variants
                .FirstOrDefault(v => v.Size == size.SelectedItem!.ToString());

            if (variant == null || variant.IsOutOfStock)
            {
                MessageBox.Show("This size is out of stock.", "Amane",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            var existing = _items.FirstOrDefault(i => i.VariantId == variant.VariantId);
            if (existing != null)
                existing.Quantity++;
            else
                _items.Add(new OrderItem
                {
                    OrderItemId = Guid.NewGuid(),
                    VariantId = variant.VariantId,
                    ProductName = product.ProductName,
                    Size = variant.Size,
                    Colour = variant.Colour,
                    Quantity = 1,
                    UnitPrice = variant.Price
                });

            RefreshOrderList();
            RecalculateTotals();
        }

        private void RefreshOrderList()
        {
            foreach (var row in panel7.Controls.OfType<Panel>().ToList())
                panel7.Controls.Remove(row);

            if (_items.Count == 0) return;

            int y = 8;
            foreach (var item in _items)
            {
                var row = new Panel
                {
                    Size = new Size(panel7.Width - 16, 32),
                    Location = new Point(8, y),
                    BackColor = Color.White
                };
                row.Controls.Add(new Label
                {
                    Text = $"{item.ProductName}  ·  {item.Size}  x{item.Quantity}",
                    Font = new Font("Cambria", 8f),
                    ForeColor = Color.FromArgb(60, 50, 50),
                    AutoSize = true,
                    Location = new Point(4, 8)
                });
                row.Controls.Add(new Label
                {
                    Text = $"${item.LineTotal:N2}",
                    Font = new Font("Cambria", 8f),
                    ForeColor = Color.FromArgb(60, 50, 50),
                    AutoSize = true,
                    Location = new Point(230, 8)
                });

                var btnX = new Button
                {
                    Text = "ⓧ",
                    Size = new Size(28, 28),
                    Location = new Point(row.Width - 34, 2),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 10f),
                    Cursor = Cursors.Hand
                };
                btnX.FlatAppearance.BorderSize = 0;
                var captured = item;
                btnX.Click += (_, _) =>
                {
                    _items.Remove(captured);
                    RefreshOrderList();
                    RecalculateTotals();
                };
                row.Controls.Add(btnX);
                panel7.Controls.Add(row);
                y += 34;
            }
        }

        private void RecalculateTotals()
        {
            decimal subtotal = _items.Sum(i => i.LineTotal);
            decimal tax = (subtotal - _discountAmount) * SettingsService.GetTaxRate();
            decimal total = subtotal - _discountAmount + tax;

            label1.Text = $"subtotal             ${subtotal:N2}";
            label2.Text = $"discount amount  -${_discountAmount:N2}";
            label3.Text = $"tax                      ${tax:N2}";
            label4.Text = $"TOTAL   ${total:N2}";

            chargeBtn.Text = $"Charge  ${total:N2}";
            chargeBtn.Enabled = _items.Count > 0;
            chargeBtn.BackColor = _items.Count > 0
                ? Color.RosyBrown : Color.FromArgb(200, 185, 185);
        }
        // loading products when search text or category filter changes
        private void searchboxTxt_TextChanged(object sender, EventArgs e) => LoadProducts();
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadProducts();

        // discount button event
        private void BtnApplyDiscount_Click(object? sender, EventArgs e)
        {
            string code = discountTxt.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                _discountAmount = 0m; _discountCode = null;
                RecalculateTotals(); return;
            }
            // validate discount code and calculate discount amount
            var discount = OrderService.GetDiscountCode(code);
            if (discount == null)
            {
                MessageBox.Show("Invalid or expired discount code.", "Amane",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // calculate discount based on the current order subtotal and the discount type
            decimal sub = _items.Sum(i => i.LineTotal);
            _discountCode = discount.Code;
            _discountAmount = discount.IsPercentage
                ? Math.Round(sub * (discount.DiscountAmount / 100), 2)
                : discount.DiscountAmount;

            RecalculateTotals();
            MessageBox.Show($"Discount applied: {discount.Code}  (-${_discountAmount:N2})",
                "Amane", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // button event handler for finalizing the order, with validation, order creation, and user feedback
        private void BtnCharge_Click(object? sender, EventArgs e)
        {
            if (_items.Count == 0) return;

            decimal subtotal = _items.Sum(i => i.LineTotal);
            decimal tax = (subtotal - _discountAmount) * SettingsService.GetTaxRate();
            decimal total = subtotal - _discountAmount + tax;

            var order = new Order
            {
                StaffId = SessionManager.CurrentUser!.StaffId,
                Items = new List<OrderItem>(_items),
                DiscountAmount = _discountAmount,
                DiscountCode = _discountCode,
                TaxAmount = tax,
                AmountTendered = total,
                Change = 0m,
                PaymentMethod = PaymentMethod.Card,
                Status = OrderStatus.Completed
            };

            if (!OrderService.PlaceOrder(order))
            {
                MessageBox.Show("Order failed — one or more items may be out of stock.",
                    "Amane", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            _items.Clear(); _discountAmount = 0m; _discountCode = null; discountTxt.Text = "";
            RefreshOrderList(); RecalculateTotals(); LoadProducts();

            MessageBox.Show($"Order complete!\nTotal: ${total:N2}",
                "Amane — Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
