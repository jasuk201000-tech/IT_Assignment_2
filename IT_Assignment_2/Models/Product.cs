using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Assignment_2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;

        public string ProductCategory { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

    public class ProductVariant
    {
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; } = string.Empty;
        public string? Colour { get; set; }
        public string? Sku { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public int LowStockThreshold { get; set; } = 3;

        public bool IsLowStock => StockQty <= LowStockThreshold;
        public bool IsOutOfStock => StockQty == 0;

        public string ProductName { get; set; } = string.Empty;
    }
}
