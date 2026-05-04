using AmanePOSHelpers;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using System;
using System.Windows.Forms;
using IT_Assignment_2.Services;
namespace IT_Assignment_2.Forms;

public partial class MainShellForm : Form
{
    // main controls
    private Panel navBar = null!;
    private Panel contentArea = null!;
    private Button btnDashboard = null!;
    private Button btnInventory = null!;
    private Button btnOrders = null!;
    private Button btnReports = null!;
    private Button btnSettings = null!;
    private Label _lblUser = null!;

    // initializing components (moved from constructor to avoid duplicate constructor error)
    private void InitializeComponents()
    {
        Text = "Amane POS";
        Size = new Size(1280, 800);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = AmaneStyling.PageBg;
        Font = AmaneStyling.FontBody;

        BuildNavBar();
        BuildContentArea();
        ApplyRoleVisibility();

        // load dashboard as the first screen
        NavigateTo("dashboard");
    }

    // navigation bar construction
    private void BuildNavBar()
    {
        navBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = AmaneStyling.NavHeight,
            BackColor = AmaneStyling.NavBar
        };

        // logo — clicking takes you home
        var logo = AmaneStyling.BuildLogoControl();
        logo.Click += (_, _) => NavigateTo("dashboard");
        navBar.Controls.Add(logo);

        // nav buttons
        btnDashboard = MakeNavButton("dashboard", 200);
        btnInventory = MakeNavButton("inventory", 320);
        btnOrders = MakeNavButton("orders", 430);
        btnReports = MakeNavButton("reports", 540);
        btnSettings = MakeNavButton("settings", 650);

       
        btnDashboard.Click += (_, _) => NavigateTo("dashboard");
        btnInventory.Click += (_, _) => NavigateTo("inventory");
        btnOrders.Click += (_, _) => NavigateTo("orders");
        btnReports.Click += (_, _) => NavigateTo("reports");
        btnSettings.Click += (_, _) => NavigateTo("settings");

        
        _lblUser = new Label
        {
            Text = SessionManager.CurrentUser?.FullName ?? "",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextOnNav,
            AutoSize = true,
            Location = new Point(1150,
                (AmaneStyling.NavHeight - 15) / 2)
        };

        navBar.Controls.AddRange(new Control[]
        {
            btnDashboard, btnInventory, btnOrders,
            btnReports, btnSettings, _lblUser
        });

        Controls.Add(navBar);
    }

    private Button MakeNavButton(string label, int x)
    {
        return new Button
        {
            Text = label,
            Font = AmaneStyling.FontNavItem,
            ForeColor = AmaneStyling.TextOnNav,
            BackColor = AmaneStyling.NavBar,
            FlatStyle = FlatStyle.Flat,
            Size = new Size(100, AmaneStyling.NavHeight),
            Location = new Point(x, 0),
            Cursor = Cursors.Hand,
            FlatAppearance = { BorderSize = 0 }
        };
    }

    
    private void BuildContentArea()
    {
        contentArea = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = AmaneStyling.PageBg
        };
        Controls.Add(contentArea);
    }

    
    private void ApplyRoleVisibility()
    {
        // cashiers only see dashboard, inventory, orders
         btnReports.Visible = SessionManager.IsManager;
         btnSettings.Visible = SessionManager.IsAdmin;
    }

    
    public void NavigateTo(string section)
    {
        contentArea.Controls.Clear();

        UserControl next = section switch
        {
            "dashboard" => new DashboardControl(),
            "inventory" => new InventoryControl(),
            "orders" => new BuildOrderControl(),
            "reports" => new ReportsControl(),
            "settings" => new SettingsControl(),
            _ => new DashboardControl()
        };

        next.Dock = DockStyle.Fill;
        contentArea.Controls.Add(next);
    }
}