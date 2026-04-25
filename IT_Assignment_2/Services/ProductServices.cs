using System;
using System.Collections.Generic;
using System.Text;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;

namespace IT_Assignment_2.Services
{
    public class ProductServices
    {
        // implement GetAll, GetById, Search (string? category, string? name), and GetVariantsByProductId, get categories get low stock

        // get all method
        public static List<Product> GetAll() =>
            CsvHelper.LoadProducts();

        // get by id method
        public static Product? GetById(Guid productId) =>
            CsvHelper.LoadProducts()
                .FirstOrDefault(p => p.ProductId == productId); 
        
        // search product via name and category
        public static List<Product> Search(string? category, string? name)
            {
            var products = CsvHelper.LoadProducts().AsEnumerable();
            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.ProductCategory.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(name))
                products = products.Where(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return products.ToList();
        }

        // get variants by product id
        public static List<ProductVariant> GetVariantsByProductId(Guid productId) =>
            CsvHelper.LoadProducts()
                .FirstOrDefault(p => p.ProductId == productId)?.Variants ?? new List<ProductVariant>();

        // get categories
        public static List<Product> GetCategories () =>
            CsvHelper.LoadProducts()
                .GroupBy(p => p.ProductCategory)
                .Select(g => g.First())
                .ToList();

        // get low stock products

        public static List<Product> GetLowStockProducts() =>
            CsvHelper.LoadProducts()
                .Where(p => p.HasLowStock)
                .ToList();
    }
}
