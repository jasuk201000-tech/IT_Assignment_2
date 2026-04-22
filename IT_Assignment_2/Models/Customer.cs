using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IT_Assignment_2.Models
{
    public class Customer
    {
        // implement an ID, first name and last name, email, loyalty points balance, and computed properties for full name and loyalty status

        public Guid CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; } = 0;

        public string CustomerName => $"{FirstName} {LastName}";

        public bool IsLoyalCustomer => LoyaltyPoints >= 100;

        public string LoyaltyStatus
        {
            get
            {
                if (LoyaltyPoints >= 1000)
                    return "Gold";
                else if (LoyaltyPoints >= 500)
                    return "Silver";
                else if (LoyaltyPoints >= 100)
                    return "Bronze";
                else
                    return "Standard";
            }
        }
    }
}
