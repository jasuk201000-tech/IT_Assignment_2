using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace IT_Assignment_2.Models
{
    public enum UserRole
    {
        // enumerating roles, to efficently create role-based access control in the application
        Cashier = 1,
        Manager = 2,
        Admin = 3
    }
    public class Staff
    {
        // getting and setting all properties for staff
       public int StaffId { get; set; } 
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set;} = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set;} = string.Empty;
        public string? PINHash { get; set; } 
        public string PasswordHash { get; set;} = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAdmin => Role == UserRole.Admin;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLogin { get; set; } 
    }
}
