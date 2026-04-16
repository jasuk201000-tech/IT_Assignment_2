using System;
using System.Collections.Generic;
using System.Text;

namespace AmanePOSHelpers;

public static class SessionManager
{
    // enumeration for reusability and clarity in defining user roles across the application (increasing senority for arithemetic statements in methods)
    public enum UserRole
    {
        Admin = 1,
        Manager = 2,
        Cashier = 3
    }

   
    // simple session management for user authentication and role-based access control
    private static string? _currentUser;
    private static UserRole? _currentRole;

    // if user is logged in (improving security)
    public static bool IsLoggedIn => !string.IsNullOrEmpty(_currentUser);

    public static bool IsAdmin => CurrentRole == UserRole.Admin;

    public static bool IsCashier => CurrentRole == UserRole.Cashier;

    public static bool IsManager => CurrentRole == UserRole.Manager;
    public static string? CurrentUser => _currentUser;
    public static UserRole? CurrentRole => _currentRole;
    public static void Login(string username, UserRole role)
    {
        _currentUser = username;
        _currentRole = role;
    }
    public static void Logout()
    {
        _currentUser = null;
        _currentRole = null;
    }


}
