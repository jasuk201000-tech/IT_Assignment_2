using System.Collections.Generic;
using System.Linq;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;

namespace IT_Assignment_2.Services
{
    public static class StaffServices
    {
        // get all staff members method
        public static List<Staff> GetAllStaff()
        {
            return CsvHelper.LoadStaff();
        }

        // adding new staff member method
        public static void AddStaff(Staff newStaff)
        {
            var staffList = GetAllStaff();
            staffList.Add(newStaff);
            CsvHelper.SaveStaff(staffList);
        }

        // get a list of active staff members method
        public static List<Staff> GetActive()
        {
            var staffList = GetAllStaff();
            return staffList.Where(s => s.IsActive).ToList();
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

            if (staffList == null)
            {
                return null;
            }
            if (!staffList.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return staffList.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
            && s.PasswordHash == password);
            }
            else
            {
                return null;
            }
        }
    }
}
