using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;

namespace IT_Assignment_2.Services
{
    public static class StaffServices
    {
        // password hashing - moved inside the class to avoid CS0116
        private static string HashPassword(string password)
        {
            if (password == null) return string.Empty;
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // get all staff members method
        public static List<Staff> GetAllStaff()
        {
            return CsvHelper.LoadStaff();
        }

        // adding new staff member method
        public static void AddStaff(Staff newStaff)
        {
            var staffList = GetAllStaff() ?? new List<Staff>();
            staffList.Add(newStaff);
            CsvHelper.SaveStaff(staffList);
        }

        // get a list of active staff members method
        public static List<Staff> GetActive()
        {
            var staffList = GetAllStaff();
            return staffList?.Where(s => s.IsActive).ToList() ?? new List<Staff>();
        }

        // get a staff member by their ID method
        public static Staff? GetById(Guid staffId)
        {
            return CsvHelper.LoadStaff()
                .FirstOrDefault(s => s.StaffId == staffId);
        }

        // authentication method for staff login
        public static Staff? Authenticate(string email, string password)
        {
            var staffList = GetAllStaff();
            if (staffList == null || !staffList.Any())
            {
                return null;
            }

            var hashedPassword = HashPassword(password ?? string.Empty);

            return staffList.FirstOrDefault(s =>
                !string.IsNullOrEmpty(s.Email)
                && s.Email.Equals(email ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                && string.Equals(s.PasswordHash ?? string.Empty, hashedPassword, StringComparison.Ordinal));
        }

        
    }
}
