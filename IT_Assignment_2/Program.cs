using IT_Assignment_2;
using IT_Assignment_2.Forms;
using IT_Assignment_2.Services;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // creates a real owner account with properly hashed password
        // only runs if owner@amane.com doesn't already exist
        StaffService.SeedTestOwner();

        Application.Run(new LoginForm());
    }
}