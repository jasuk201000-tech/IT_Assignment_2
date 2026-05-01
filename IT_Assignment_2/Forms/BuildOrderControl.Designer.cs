using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        // nothing is saved to the database before its submitted, so a list is used as a temporary storage for the order items until submission
        private readonly List<OrderItem> _items = new();
        private decimal _discountAmount = 0m;
        private string? _discountCode = null;

        // product data
        private List<Product> _products = new();
        private List<(Panel Card, TextBox Name, TextBox Price,
         TextBox Stock, ComboBox Size, Product? Product)> _slots = new(); // generalising UI elements for easier management and reusability
    }
}