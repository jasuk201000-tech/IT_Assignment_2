using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;

namespace IT_Assignment_2.Services;

public static class StaffService
{
    // password hashing via SHA256 with email as salt
    private static string HashPassword(string password, string email)
    {
        if (string.IsNullOrEmpty(password)) return string.Empty;

        using var sha = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password + email.ToLower());
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    private static bool VerifyPassword(string typed, string email, string stored)
    {
        return HashPassword(typed, email) == stored;
    }

    // Pin validation via conditionals
    public static bool IsValidPin(string pin)
    {
        // must be exactly 4 characters
        if (pin.Length != 4) return false;

        // must be all digits
        if (!pin.All(char.IsDigit)) return false;

        return true;
    }

    private static bool VerifyPin(string typed, string stored)
    {
        return typed == stored;
    }

    // password validation via conditionals 

    // simplified — 8 chars minimum, at least one number
    public static bool IsPasswordStrong(string password)
    {
        if (password.Length < 8) return false;
        if (!password.Any(char.IsDigit)) return false;
        return true;
    }

    // ── Lookups ───────────────────────────────────────────────────────────────

    public static List<Staff> GetAll() =>
        CsvHelper.LoadStaff();

    public static List<Staff> GetActive() =>
        CsvHelper.LoadStaff()
            .Where(s => s.IsActive)
            .ToList();

    public static Staff? GetById(Guid staffId) =>
        CsvHelper.LoadStaff()
            .FirstOrDefault(s => s.StaffId == staffId);

    // ── Authentication ────────────────────────────────────────────────────────

    public static Staff? AuthenticatePassword(string email, string password)
    {
        // find active staff member by email
        var staff = CsvHelper.LoadStaff()
            .FirstOrDefault(s =>
                s.Email.Equals(email.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && s.IsActive);

        if (staff == null) return null;

        // verify password against stored hash
        if (!VerifyPassword(password, staff.Email, staff.PasswordHash))
            return null;

        return staff;
    }

    public static Staff? AuthenticatePin(string email, string pin)
    {
        // find active staff member with a PIN set
        var staff = CsvHelper.LoadStaff()
            .FirstOrDefault(s =>
                s.Email.Equals(email.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && s.IsActive
                && s.PINHash != null);

        if (staff == null) return null;

        // plain comparison — PIN is stored as plain text
        if (!VerifyPin(pin, staff.PINHash!))
            return null;

        return staff;
    }

    // validation method to prevent duplicate emails during creation

    public static bool IsEmailTaken(string email) =>
        CsvHelper.LoadStaff()
            .Any(s => s.Email.Equals(email.Trim(),
                StringComparison.OrdinalIgnoreCase));

    // creating new staff members

    public static bool CreateStaff(Staff staff, string password, string? pin)
    {
        // validate before saving anything
        if (IsEmailTaken(staff.Email)) return false;
        if (!IsPasswordStrong(password)) return false;
        if (pin != null && !IsValidPin(pin)) return false;

        // generate ID and hash password
        staff.StaffId = Guid.NewGuid();
        staff.PasswordHash = HashPassword(password, staff.Email);
        staff.PINHash = pin == null ? null : Hashpin(pin); // hash the PIN if provided
        staff.CreatedAt = DateTime.Now;
        staff.IsActive = true;

        // saving to CSV
        var allStaff = CsvHelper.LoadStaff();
        allStaff.Add(staff);
        CsvHelper.SaveStaff(allStaff);
        return true;
    }

    // updating existing staff members

    // settting status of staff members

    public static void SetActiveStatus(Guid staffId, bool isActive)
    {
        var allStaff = CsvHelper.LoadStaff();
        var target = allStaff.FirstOrDefault(s => s.StaffId == staffId);
        if (target != null) target.IsActive = isActive;
        CsvHelper.SaveStaff(allStaff);
    }

    // updating the role of staff members
    public static void UpdateRole(Guid staffId, UserRole newRole)
    {
        var allStaff = CsvHelper.LoadStaff();
        var target = allStaff.FirstOrDefault(s => s.StaffId == staffId);
        if (target != null) target.Role = newRole;
        CsvHelper.SaveStaff(allStaff);
    }

    public static void UpdatePassword(Guid staffId, string newPassword)
    {
        if (!IsPasswordStrong(newPassword)) return;

        var allStaff = CsvHelper.LoadStaff();
        var target = allStaff.FirstOrDefault(s => s.StaffId == staffId);
        if (target != null)
            target.PasswordHash = HashPassword(newPassword, target.Email);
        CsvHelper.SaveStaff(allStaff);
    }

    public static void UpdatePin(Guid staffId, string? newPin)
    {
        if (newPin != null && !IsValidPin(newPin)) return;

        var allStaff = CsvHelper.LoadStaff();
        var target = allStaff.FirstOrDefault(s => s.StaffId == staffId);
        if (target != null) target.PINHash = newPin == null ? null : Hashpin(newPin);
        CsvHelper.SaveStaff(allStaff);
    }

    // test data seed, creating an admin if not already present
    public static void SeedTestOwner()
    {
        if (IsEmailTaken("owner@amane.com")) return;

        CreateStaff(new Staff
        {
            FirstName = "Store",
            LastName = "Owner",
            Email = "owner@amane.com",
            Role = UserRole.Admin
        },
        password: "Amane2025",
        pin: "1234");
    }

    private static string Hashpin(string pin)
    {
        if (string.IsNullOrEmpty(pin)) return string.Empty;

        using var sha = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(pin);
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}