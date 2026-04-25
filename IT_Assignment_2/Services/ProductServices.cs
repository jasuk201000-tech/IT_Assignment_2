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
        public static List<Product> GetCategories() =>
            CsvHelper.LoadProducts()
                .GroupBy(p => p.ProductCategory)
                .Select(g => g.First())
                .ToList();

        // get low stock products

        public static List<Product> GetLowStockProducts() =>
            CsvHelper.LoadProducts()
                .Where(p => p.HasLowStock)
                .ToList();

        //add product method

        public static List<Product> AddProduct(Product newProduct)
        {
            var products = CsvHelper.LoadProducts();
            products.Add(newProduct);
            CsvHelper.SaveProducts(products);
            return products;
        }

        // update product method

        public static List<Product> UpdateProduct(Product updatedProduct)
        {
            var products = CsvHelper.LoadProducts();
            var index = products.FindIndex(p => p.ProductId == updatedProduct.ProductId);
            if (index != -1)
            {
                products[index] = updatedProduct;
                CsvHelper.SaveProducts(products);
            }
            return products;
        }

        // delete product method

        public static List<Product> DeleteProduct(Guid productId)
        {
            var products = CsvHelper.LoadProducts();
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                CsvHelper.SaveProducts(products);
            }
            return products;
        }

        // add variant method

        public static List<ProductVariant> AddVariant(Guid productId, ProductVariant newVariant)
        {
            var products = CsvHelper.LoadProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.Variants.Add(newVariant);
                CsvHelper.SaveProducts(products);
                return product.Variants;
            }
            return new List<ProductVariant>();
        }

        // update variant method

        public static List<ProductVariant> UpdateVariant(Guid productId, ProductVariant updatedVariant)
        {
            var products = CsvHelper.LoadProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var index = product.Variants.FindIndex(v => v.VariantId == updatedVariant.VariantId);
                if (index != -1)
                {
                    product.Variants[index] = updatedVariant;
                    CsvHelper.SaveProducts(products);
                    return product.Variants;
                }
            }
            return new List<ProductVariant>();
        }

        // delete variant method

        public static List<ProductVariant> DeleteVariant(Guid productId, Guid variantId)
        {
            var products = CsvHelper.LoadProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var variantToRemove = product.Variants.FirstOrDefault(v => v.VariantId == variantId);
                if (variantToRemove != null)
                {
                    product.Variants.Remove(variantToRemove);
                    CsvHelper.SaveProducts(products);
                    return product.Variants;
                }
            }
            return new List<ProductVariant>();
        }

        // deduct stock method

        public static void DeductStock(Guid variantId, int quantity)
        {
            var products = CsvHelper.LoadProducts();
            foreach (var product in products)
            {
                var variant = product.Variants.FirstOrDefault(v => v.VariantId == variantId);
                if (variant != null)
                {
                    variant.StockQty = Math.Max(0, variant.StockQty - quantity);
                    CsvHelper.SaveProducts(products);
                    return;
                }
            }
        }

        // restock variant method

        public static void RestockVariant(Guid variantId, int quantity)
        {
            var products = CsvHelper.LoadProducts();
            foreach (var product in products)
            {
                var variant = product.Variants.FirstOrDefault(v => v.VariantId == variantId);
                if (variant != null)
                {
                    variant.StockQty += quantity;
                    CsvHelper.SaveProducts(products);
                    return;
                }
            }
        }
    }
}
