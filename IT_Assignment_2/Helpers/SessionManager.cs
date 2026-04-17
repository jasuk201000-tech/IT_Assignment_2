using IT_Assignment_2.Models;

namespace IT_Assignment_2.Helpers;

public static class SessionManager
{
    private static Staff? _currentUser;

    public static Staff? CurrentUser => _currentUser;
    public static bool IsLoggedIn => _currentUser is not null;
    public static bool IsAdmin => _currentUser?.Role == UserRole.Admin;
    public static bool IsManager => _currentUser?.Role >= UserRole.Manager;
    public static bool IsCashier => _currentUser?.Role == UserRole.Cashier;

    public static void Login(Staff user)
    {
        _currentUser = user;
    }

    public static void Logout()
    {
        _currentUser = null;
    }
}