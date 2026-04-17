using AmanePOSModels;

namespace AmanePOSHelpers;

public static class SessionManager
{
    // implement the staff session management in a different file
    private static Staff? _currentUser;


    public static Staff? CurrentUser => _currentUser;
    public static bool IsLoggedIn => _currentUser != null;

    // works correctly because seniority matches the enum numbers
    // IsManager is true for both Manager and Admin roles
    public static bool IsAdmin => _currentUser?.Role == UserRole.Admin;
    public static bool IsManager => _currentUser?.Role >= UserRole.Manager;
    public static bool IsCashier => _currentUser?.Role == UserRole.Cashier;

    // this method is called by the LoginForm after the database confirms credentials

    // called by LoginForm after the database confirms credentials
    public static void Login(Staff user)
    {
        _currentUser = user;
    }

    // called by the logout button — wipes the session completely
    public static void Logout()
    {
        _currentUser = null;
    }
}