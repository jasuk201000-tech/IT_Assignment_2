using System;
using System.Collections.Generic;

namespace IT_Assignment_2.Models
{
    public enum OrderStatus
    {
        Pending = 1,
        Completed = 2,
        Refunded = 3,
        Voided = 4
    }

    public enum PaymentMethod
    {
        Cash = 1,
        Card = 2,
        Mixed = 3
    }

    public class Order
    {
        //identifying factors
        public int OrderId { get; set; }
        public int StaffId { get; set; }
        public string? CustomerName { get; set; }    // optional — walk-ins have no name

        //status and payment details
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public PaymentMethod PaymentMethod { get; set; }

        //financial details
        public decimal DiscountAmount { get; set; }
        public string? DiscountCode { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Change { get; set; }

        
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        public List<OrderItem> Items { get; set; } = new();

        //computed financial properties
        public decimal Subtotal => Items.Sum(i => i.LineTotal);
        public decimal Total => Subtotal - DiscountAmount + TaxAmount;
    }

    public class OrderItem
    {
        // identifying factors
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int VariantId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string? Colour { get; set; }

        // financial aspects
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        //computed properties
        public decimal LineTotal => Quantity * UnitPrice;
    }
}