using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;
using IT_Assignment_2.Services;

namespace IT_Assignment_2.Services
{
    public static class OrderService
    {

        // get all orders method
        public static List<Order> GetAll() =>
                CsvHelper.LoadOrders();

        // get order by id method
        public static Order? GetById(Guid orderId) =>
            CsvHelper.LoadOrders()
                .FirstOrDefault(o => o.OrderId == orderId);


        // get order by staff method
        public static List<Order> GetByStaff(Guid staffId) =>
            CsvHelper.LoadOrders()
                .Where(o => o.StaffId == staffId)
                .ToList();

        // get order by customer method

        public static List<Order> GetByCustomer(Guid customerId) =>
            CsvHelper.LoadOrders()
                .Where(o => o.CustomerId == customerId)
                .ToList();

        // get order by date range method

        public static List<Order> GetByDateRange(DateTime startDate, DateTime endDate) =>
            CsvHelper.LoadOrders()
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .ToList();

        // get todays orders method

        public static List<Order> GetTodaysOrders() =>
            CsvHelper.LoadOrders()
                .Where(o => o.CreatedAt.Date == DateTime.Today)
                .ToList();

        // get todays revenue method

        public static decimal GetTodaysRevenue() =>
            CsvHelper.LoadOrders()
                .Where(o => o.CreatedAt.Date == DateTime.Today && o.Status == OrderStatus.Completed)
                .Sum(o => o.Total);

        // validate discount code

        public static bool ValidateDiscountCode(string code) =>
            CsvHelper.LoadDiscountCodes()
                .Any(d => d.Code.Equals(code.Trim(), StringComparison.OrdinalIgnoreCase) && d.IsActive);

        public static bool PlaceOrder(Order order)
        {
            // validate stock before touching any file
            foreach (var item in order.Items)
            {
                var variant = CsvHelper.LoadProductVariants()
                    .FirstOrDefault(v => v.VariantId == item.VariantId);

                if (variant == null || variant.StockQty < item.Quantity)
                    return false;
            }

            // all stock confirmed — now save and deduct
            order.OrderId = Guid.NewGuid();
            order.CreatedAt = DateTime.Now;
            order.Status = OrderStatus.Completed;

            foreach (var item in order.Items)
            {
                item.OrderItemId = Guid.NewGuid();
                item.OrderId = order.OrderId;
                ProductServices.DeductStock(item.VariantId, item.Quantity);
            }

            CsvHelper.SaveOrder(order);
            return true;
        }
    }
}
