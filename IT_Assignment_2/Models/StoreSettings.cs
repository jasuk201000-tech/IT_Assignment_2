using System;

namespace IT_Assignment_2.Models
{
    public class StoreSettings
    {
        // store info
        public string StoreName { get; set; } = "Amane";
        public string? StoreAddress { get; set; }
        public string? StorePhone { get; set; }
        public string? StoreEmail { get; set; }
        public string? StoreHandle { get; set; }
        public string? LogoPath { get; set; }

        // tax settings
        public decimal TaxRate { get; set; } = 0.10m;

        // receipt settings
        public string ReturnPolicy { get; set; } = string.Empty;
        public bool ReceiptShowLogo { get; set; } = true;
        public bool ReceiptShowAddress { get; set; } = true;
        public bool ReceiptShowPhone { get; set; } = true;
        public bool ReceiptShowSocials { get; set; } = true;
        public bool ReceiptShowPolicy { get; set; } = true;
    }

    public class DiscountCode
    {
        // discount information
        public Guid DiscountId { get; set; }
        public string Code { get; set; } = string.Empty;

        // discount details
        public decimal DiscountAmount { get; set; }
        public bool IsPercentage { get; set; } = true;

        // validity
        public DateTime? ExpiryDate { get; set; }    // null means never expires

        // computed property
        public bool IsActive => ExpiryDate == null || DateTime.Now < ExpiryDate;
    }
}