using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Assignment_2.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<ProductVariant> Variants { get; set; } = new();
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int TotalStock => Variants.Sum(v => v.StockQty);
        public decimal MinPrice => Variants.Count > 0
                                        ? Variants.Min(v => v.Price)
                                        : 0m;
        public bool HasLowStock => Variants.Any(v => v.IsLowStock);
        public bool HasOutOfStock => Variants.Any(v => v.IsOutOfStock);
    }



    public class ProductVariant
    {
        public Guid VariantId { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; } = string.Empty;
        public string? Colour { get; set; }
        public string? Sku { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public int LowStockThreshold { get; set; } = 3;

        public bool IsLowStock => StockQty <= LowStockThreshold;
        public bool IsOutOfStock => StockQty == 0;

        

    }
}
