using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IT_Assignment_2.Models;
using System.Reflection;

namespace IT_Assignment_2.Data;

public static class CsvHelper
{
    // links to CSV files in the Data/CSV folder. Each file corresponds to one data model.
    private static string DataFolder =>
        Path.Combine(Application.StartupPath, "Data", "CSV");

    private static string FilePath(string fileName) =>
        Path.Combine(DataFolder, fileName);

    // csv parsing and file handling methods
    private static string[] ParseLine(string line)
    {
        var fields = new List<string>();
        bool inQuote = false;
        var current = new System.Text.StringBuilder();

        foreach (char c in line)
        {
            if (c == '"')
            {
                inQuote = !inQuote;
            }
            else if (c == ',' && !inQuote)
            {
                fields.Add(current.ToString().Trim());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }

        fields.Add(current.ToString().Trim());
        return fields.ToArray();
    }

    // ensures that all csv files exist with headers
    private static List<string[]> ReadRows(string fileName)
    {
        string path = FilePath(fileName);
        if (!File.Exists(path)) return new List<string[]>();

        return File.ReadAllLines(path)
            .Skip(1)                          // skip header row
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(ParseLine)
            .ToList();
    }

   // creates new row in the csv files for data input
    private static void AppendRow(string fileName, string row)
    {
        string path = FilePath(fileName);
        File.AppendAllLines(path, new[] { row });
    }

    // rewrites the entire csv file with a new header and set of rows (used for updates)
    private static void RewriteFile(string fileName, string header, IEnumerable<string> rows)
    {
        string path = FilePath(fileName);
        var lines = new List<string> { header };
        lines.AddRange(rows);
        File.WriteAllLines(path, lines);
    }

    // null helpers

    private static string? NullableString(string val) =>
        string.IsNullOrEmpty(val) ? null : val;

    private static DateTime? NullableDate(string val) =>
        string.IsNullOrEmpty(val) ? null : DateTime.Parse(val);

    private static Guid? NullableGuid(string val) =>
        string.IsNullOrEmpty(val) ? null : Guid.Parse(val);

    // staff csv format:

    public static List<Staff> LoadStaff()
    {
        var list = new List<Staff>();

        foreach (var col in ReadRows("Staff.csv"))
        {
            list.Add(new Staff
            {
                StaffId = Guid.Parse(col[0]),
                FirstName = col[1],
                LastName = col[2],
                Email = col[3],
                PasswordHash = col[4],
                PINHash = NullableString(col[5]),
                Role = (UserRole)int.Parse(col[6]),
                IsActive = bool.Parse(col[7]),
                CreatedAt = DateTime.Parse(col[8]),
                LastLogin = NullableDate(col[9])
            });
        }

        return list;
    }
    // saving staff method
    public static void SaveStaff(List<Staff> allStaff)
    {
        const string header =
            "StaffId,FirstName,LastName,Email,PasswordHash,PinHash," +
            "Role,IsActive,CreatedAt,LastLogin";

        var rows = allStaff.Select(s => string.Join(",",
            s.StaffId,
            s.FirstName,
            s.LastName,
            s.Email,
            s.PasswordHash,
            s.PINHash ?? "",
            (int)s.Role,
            s.IsActive,
            s.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            s.LastLogin?.ToString("yyyy-MM-dd HH:mm:ss") ?? ""
        ));

        RewriteFile("Staff.csv", header, rows);
    }

    // customer csv format:

    public static List<Customer> LoadCustomers()
    {
        var list = new List<Customer>();

        foreach (var col in ReadRows("Customers.csv"))
        {
            list.Add(new Customer
            {
                CustomerId = Guid.Parse(col[0]),
                FirstName = col[1],
                LastName = col[2],
                Email = col[3],
                LoyaltyPoints = int.Parse(col[4]),
                CreatedAt = DateTime.Parse(col[5])
            });
        }

        return list;
    }

    // saving customers method
    public static void SaveCustomers(List<Customer> allCustomers)
    {
        const string header =
            "CustomerId,FirstName,LastName,Email,LoyaltyPoints,CreatedAt";

        var rows = allCustomers.Select(c => string.Join(",",
            c.CustomerId,
            c.FirstName,
            c.LastName,
            c.Email,
            c.LoyaltyPoints,
            c.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        )) ;

        RewriteFile("Customers.csv", header, rows);
    }

    // products csv format:

    public static List<Product> LoadProducts()
    {
        var list = new List<Product>();

        foreach (var col in ReadRows("Products.csv"))
        {
            list.Add(new Product
            {
                ProductId = Guid.Parse(col[0]),
                ProductName = col[1],
                ProductCategory = col[2],
                ProductDescription = NullableString(col[3]),
                ProductImageUrl = NullableString(col[4]),
                IsActive = bool.Parse(col[5]),
                CreatedAt = DateTime.Parse(col[6]),
                UpdatedAt = DateTime.Parse(col[7])
            });
        }

        // load variants and attach to their parent product
        var variants = LoadProductVariants();
        foreach (var product in list)
        {
            product.Variants = variants
                .Where(v => v.ProductId == product.ProductId)
                .ToList();
        }

        return list;
    }

    public static void SaveProducts(List<Product> allProducts)
    {
        const string header =
            "ProductId,ProductName,ProductCategory,ProductDescription," +
            "ProductImageUrl,IsActive,CreatedAt,UpdatedAt";

        var rows = allProducts.Select(p => string.Join(",",
            p.ProductId,
            p.ProductName,
            p.ProductCategory,
            $"\"{p.ProductDescription ?? ""}\"",   // quotes handle commas in descriptions
            p.ProductImageUrl ?? "",
            p.IsActive,
            p.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            p.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        ));

        RewriteFile("Products.csv", header, rows);
    }

    // product variants csv format:

    public static List<ProductVariant> LoadProductVariants()
    {
        var list = new List<ProductVariant>();

        foreach (var col in ReadRows("ProductVariants.csv"))
        {
            list.Add(new ProductVariant
            {
                VariantId = Guid.Parse(col[0]),
                ProductId = Guid.Parse(col[1]),
                ProductName = col[2],
                Size = col[3],
                Colour = NullableString(col[4]),
                Sku = NullableString(col[5]),
                Price = decimal.Parse(col[6]),
                StockQty = int.Parse(col[7]),
                LowStockThreshold = int.Parse(col[8])
            });
        }

        return list;
    }

    // saving product variants method
    public static void SaveProductVariants(List<ProductVariant> allVariants)
    {
        const string header =
            "VariantId,ProductId,ProductName,Size,Colour,Sku," +
            "Price,StockQty,LowStockThreshold";

        var rows = allVariants.Select(v => string.Join(",",
            v.VariantId,
            v.ProductId,
            v.ProductName,
            v.Size,
            v.Colour ?? "",
            v.Sku ?? "",
            v.Price,
            v.StockQty,
            v.LowStockThreshold
        ));

        RewriteFile("ProductVariants.csv", header, rows);
    }

    // updates variant stock quantity
    public static void UpdateVariantStock(Guid variantId, int newQty)
    {
        var variants = LoadProductVariants();
        var target = variants.FirstOrDefault(v => v.VariantId == variantId);
        if (target != null) target.StockQty = newQty;
        SaveProductVariants(variants);
    }

   
    ///  order csv format:
    

    public static List<Order> LoadOrders()
    {
        var list = new List<Order>();

        foreach (var col in ReadRows("Orders.csv"))
        {
            // building order
            var order = new Order
            {
                OrderId = Guid.Parse(col[0]),
                StaffId = Guid.Parse(col[1]),
                CustomerId = !string.IsNullOrEmpty(col[2]) ? Guid.Parse(col[2]) : Guid.Empty,
                Status = (OrderStatus)int.Parse(col[3]),
                PaymentMethod = (PaymentMethod)int.Parse(col[4]),
                DiscountAmount = decimal.Parse(col[5]),
                DiscountCode = NullableString(col[6]),
                TaxAmount = decimal.Parse(col[7]),
                
                AmountTendered = decimal.Parse(col[9]),
                Change = decimal.Parse(col[10]),
                Notes = NullableString(col[11]),
                CreatedAt = DateTime.Parse(col[12])
            };

            
            if (decimal.TryParse(col[8], out decimal parsedTotal))
            {
                var prop = typeof(Order).GetProperty("Total", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var setMethod = prop?.GetSetMethod(true);
                if (setMethod != null)
                {
                    
                    setMethod.Invoke(order, new object[] { parsedTotal });
                }
                
            }

            list.Add(order);
        }

        // attach order items to their parent order
        var items = LoadOrderItems();
        foreach (var order in list)
        {
            order.Items = items
                .Where(i => i.OrderId == order.OrderId)
                .ToList();
        }

        return list;
    }

    public static void SaveOrder(Order order)
    {
        // append order header row
        string orderRow = string.Join(",",
            order.OrderId,
            order.StaffId,
            order.CustomerId != Guid.Empty ? order.CustomerId.ToString() : "",
            (int)order.Status,
            (int)order.PaymentMethod,
            order.DiscountAmount,
            order.DiscountCode ?? "",
            order.TaxAmount,
            order.Total,
            order.AmountTendered,
            order.Change,
            order.Notes ?? "",
            order.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        );

        AppendRow("Orders.csv", orderRow);

        // append each order item
        foreach (var item in order.Items)
            SaveOrderItem(item);
    }

    // order items csv format:

    public static List<OrderItem> LoadOrderItems()
    {
        var list = new List<OrderItem>();

        foreach (var col in ReadRows("OrderItems.csv"))
        {
            list.Add(new OrderItem
            {
                OrderItemId = Guid.Parse(col[0]),
                OrderId = Guid.Parse(col[1]),
                VariantId = Guid.Parse(col[2]),
                ProductName = col[3],
                Size = col[4],
                Colour = NullableString(col[5]),
                Quantity = int.Parse(col[6]),
                UnitPrice = decimal.Parse(col[7])
            });
        }

        return list;
    }

    public static void SaveOrderItem(OrderItem item)
    {
        string row = string.Join(",",
            item.OrderItemId,
            item.OrderId,
            item.VariantId,
            item.ProductName,
            item.Size,
            item.Colour ?? "",
            item.Quantity,
            item.UnitPrice
        );

        AppendRow("OrderItems.csv", row);
    }

    // discount codes csv format:

    public static List<DiscountCode> LoadDiscountCodes()
    {
        var list = new List<DiscountCode>();

        foreach (var col in ReadRows("DiscountCodes.csv"))
        {
            list.Add(new DiscountCode
            {
                DiscountId = Guid.Parse(col[0]),
                Code = col[1],
                DiscountAmount = decimal.Parse(col[2]),
                IsPercentage = bool.Parse(col[3]),
                ExpiryDate = NullableDate(col[4])
            });
        }

        return list;
    }

    // finds active discount code by code string (case-insensitive)
    public static DiscountCode? FindDiscountCode(string code)
    {
        return LoadDiscountCodes()
            .FirstOrDefault(d =>
                d.Code.Equals(code, StringComparison.OrdinalIgnoreCase)
                && d.IsActive);
    }

    // store settings

    public static Dictionary<string, string> LoadSettings()
    {
        var dict = new Dictionary<string, string>();

        foreach (var col in ReadRows("StoreSettings.csv"))
        {
            if (col.Length >= 2)
                dict[col[0]] = col[1];
        }

        return dict;
    }

    public static string GetSetting(string key, string defaultValue = "")
    {
        var settings = LoadSettings();
        return settings.TryGetValue(key, out string? val) ? val : defaultValue;
    }

    public static void SetSetting(string key, string value)
    {
        var settings = LoadSettings();
        settings[key] = value;

        const string header = "SettingKey,SettingValue";
        var rows = settings.Select(kv => $"{kv.Key},{kv.Value}");
        RewriteFile("StoreSettings.csv", header, rows);
    }

    public static decimal GetTaxRate() =>
        decimal.TryParse(GetSetting("TaxRate", "0.10"), out decimal rate)
            ? rate : 0.10m;
}