using AmanePOSHelpers;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms;

public class LoginForm : Form
{
    // to fix make sure that the cashiers dont need an email to log in, just a username and password or pin

    private Panel AnavBar = null!;
    private Panel AcardPanel = null!;
    private Label AlblTitle = null!;

    // password mode
    private Panel ApanelPassword = null!;
    private Label AlblEmail = null!;
    private TextBox AtxtEmail = null!;
    private Label AlblPassword = null!;
    private TextBox AtxtPassword = null!;
    private Label AlblForgot = null!;
    private Button AbtnLogin = null!;
    private Button AbtnPinSwitch = null!;

    // pin mode
    private Panel ApanelPin = null!;
    private Label AlblPinInstr = null!;
    private Label AlblPinDisplay = null!;
    private TableLayoutPanel ApinPad = null!;
    private Button AbtnPasswordSwitch = null!;
    private Panel NavPanel;
    private Button dashboardBtn;
    private Button settingsBtn;
    private Button transactionsBtn;
    private Button orderBtn;
    private Button inventoryBtn;
    private string ApinBuffer = "";



    // constructor to set up the form and build UI
    public class MainShellForm : Form
    {
        public MainShellForm()
        {
            Text = "Amane POS";
            Size = new Size(1280, 800);
            BackColor = AmaneStyling.PageBg;
            StartPosition = FormStartPosition.CenterScreen;

            var lbl = new Label
            {
                Text = "logged in — shell coming soon",
                AutoSize = true,
                Location = new Point(50, 50),
                Font = AmaneStyling.FontTitle,
            };
            Controls.Add(lbl);
        }
    }
    public LoginForm()
    {
        Text = "Amane — Staff Portal";
        Size = new Size(1280, 800);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = AmaneStyling.PageBg;
        Font = AmaneStyling.FontBody;

        BuildNavBar();
        BuildCard();
        BuildPasswordPanel();
        BuildPinPanel();
        ShowPasswordMode();


        Resize += (_, _) => CentreCard();
    }

    // building navigation bar with logo

    private void BuildNavBar()
    {
        AnavBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = AmaneStyling.NavHeight,
            BackColor = AmaneStyling.NavBar,
            Padding = new Padding(20, 0, 20, 0)
        };

        var logo = AmaneStyling.BuildLogoControl();
        AnavBar.Controls.Add(logo);
        Controls.Add(AnavBar);
    }

    // card container for login elements, centered in the form

    private void BuildCard()
    {
        AcardPanel = new Panel
        {
            Size = new Size(400, 480),
            BackColor = AmaneStyling.CardBg,
            BorderStyle = BorderStyle.FixedSingle
        };

        AlblTitle = new Label
        {
            Text = "amane staff portal",
            Font = AmaneStyling.FontTitle,
            ForeColor = AmaneStyling.TextDark,
            AutoSize = true,
            Location = new Point(30, 24)
        };

        AcardPanel.Controls.Add(AlblTitle);
        Controls.Add(AcardPanel);
        CentreCard();
    }

    private void CentreCard()
    {
        AcardPanel.Location = new Point(
            (ClientSize.Width - AcardPanel.Width) / 2,
            (ClientSize.Height - AcardPanel.Height) / 2
        );
    }

    // password panel with email and password fields, and switch to PIN mode

    private void BuildPasswordPanel()
    {
        ApanelPassword = new Panel
        {
            Size = new Size(340, 360),
            Location = new Point(30, 70)
        };

        AlblEmail = new Label
        {
            Text = "please enter email/username",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 0)
        };

        AtxtEmail = new TextBox
        {
            Size = new Size(340, 30),
            Location = new Point(0, 20)
        };
        AmaneStyling.StyleTextBox(AtxtEmail);

        AlblPassword = new Label
        {
            Text = "please enter password",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 65)
        };

        AtxtPassword = new TextBox
        {
            Size = new Size(340, 30),
            Location = new Point(0, 85),
            UseSystemPasswordChar = true
        };
        AmaneStyling.StyleTextBox(AtxtPassword);

        AlblForgot = new Label
        {
            Text = "forgotten password?",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.Accent,
            AutoSize = true,
            Location = new Point(0, 125),
            Cursor = Cursors.Hand
        };

        AbtnLogin = new Button
        {
            Text = "log in",
            Size = new Size(340, AmaneStyling.ButtonHeight),
            Location = new Point(0, 160)
        };
        AmaneStyling.StyleButton(AbtnLogin);
        AbtnLogin.Click += BtnLogin_Click;

        AbtnPinSwitch = new Button
        {
            Text = "PIN Log in",
            Size = new Size(160, AmaneStyling.ButtonHeight),
            Location = new Point(240, 160)
        };
        AmaneStyling.StyleButton(AbtnPinSwitch, primary: false);
        AbtnPinSwitch.Click += (_, _) => ShowPinMode();

        ApanelPassword.Controls.AddRange(new Control[]
        {
            AlblEmail, AtxtEmail,
            AlblPassword, AtxtPassword,
            AlblForgot, AbtnLogin, AbtnPinSwitch
        });

        AcardPanel.Controls.Add(ApanelPassword);
    }

    // PIN panel

    private void BuildPinPanel()
    {
        ApanelPin = new Panel
        {
            Size = new Size(340, 360),
            Location = new Point(30, 70),
            Visible = false
        };

        AlblPinInstr = new Label
        {
            Text = "enter your 4-digit PIN",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 0)
        };

        AlblPinDisplay = new Label
        {
            Text = "",
            Font = new Font(AmaneStyling.FontBody.FontFamily, 20f),
            ForeColor = AmaneStyling.TextDark,
            AutoSize = true,
            Location = new Point(0, 30)
        };

        ApinPad = new TableLayoutPanel
        {
            Size = new Size(300, 210),
            Location = new Point(0, 70),
            ColumnCount = 3,
            RowCount = 4
        };

        for (int i = 0; i < 3; i++)
            ApinPad.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33f));
        for (int i = 0; i < 4; i++)
            ApinPad.RowStyles.Add(
                new RowStyle(SizeType.Percent, 25f));

        for (int i = 1; i <= 9; i++)
            ApinPad.Controls.Add(CreatePinButton(i.ToString()));
        ApinPad.Controls.Add(new Label(), 0, 3);
        ApinPad.Controls.Add(CreatePinButton("0"), 1, 3);
        ApinPad.Controls.Add(CreatePinButton("⌫"), 2, 3);

        AbtnPasswordSwitch = new Button
        {
            Text = "use password instead",
            Size = new Size(300, AmaneStyling.ButtonHeight),
            Location = new Point(0, 295)
        };
        AmaneStyling.StyleButton(AbtnPasswordSwitch, primary: false);
        AbtnPasswordSwitch.Click += (_, _) => ShowPasswordMode();

        ApanelPin.Controls.AddRange(new Control[]
        {
        AlblPinInstr, AlblPinDisplay, ApinPad, AbtnPasswordSwitch, ApinPad, ApinPad,
        });

        AcardPanel.Controls.Add(ApanelPin);
    }

    private Button CreatePinButton(string text)
    {
        var btn = new Button
        {
            Text = text,
            Dock = DockStyle.Fill,
            BackColor = AmaneStyling.TextOnAccent,
            ForeColor = AmaneStyling.TextDark,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(2)
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.Click += (_, _) => PinKeyPressed(text);
        return btn;
    }

    // mode switching logic

    private void ShowPasswordMode()
    {
        ApanelPassword.Visible = true;
        ApanelPin.Visible = false;
        ApinBuffer = "";
        AlblPinDisplay.Text = "";
    }

    private void ShowPinMode()
    {
        ApanelPassword.Visible = false;
        ApanelPin.Visible = true;
    }

    // authentication logic for password login

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(AtxtEmail.Text) ||
            string.IsNullOrWhiteSpace(AtxtPassword.Text))
        {
            ShowError("Please enter your email and password.");
            return;
        }

        var staff = StaffService.AuthenticatePassword(
            AtxtEmail.Text.Trim(),
            AtxtPassword.Text);

        if (staff == null)
        {
            ShowError("Incorrect email or password.");
            return;
        }

        SessionManager.Login(staff);
        OpenShell();
    }

    // PIN logic

    private void PinKeyPressed(string key)
    {
        if (key == "⌫")
        {
            if (ApinBuffer.Length > 0)
                ApinBuffer = ApinBuffer[..^1];
        }
        else
        {
            if (ApinBuffer.Length >= 4) return;
            ApinBuffer += key;
        }

        // show dots for each digit entered
        AlblPinDisplay.Text = new string('●', ApinBuffer.Length);

        // auto submit when 4 digits entered
        if (ApinBuffer.Length == 4)
            SubmitPin();
    }


    // utility method to show error messages in a consistent way

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Amane",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    private void OpenShell()
    {
        var shell = new MainShellForm();
        shell.Show();
        Hide();
    }

    // submit PIN for authentication, similar to password login but using the PIN buffer instead
    private void SubmitPin()
    {
        var staff = StaffService.AuthenticatePin(ApinBuffer);

        if (staff == null)
        {
            ShowError("Incorrect PIN.");
            ApinBuffer = "";
            AlblPinDisplay.Text = "";
            return;
        }

        SessionManager.Login(staff);
        OpenShell();
    }

    private void InitializeComponent()
    {
        NavPanel = new Panel();
        dashboardBtn = new Button();
        inventoryBtn = new Button();
        orderBtn = new Button();
        transactionsBtn = new Button();
        settingsBtn = new Button();
        NavPanel.SuspendLayout();
        SuspendLayout();
        // 
        // NavPanel
        // 
        NavPanel.BackColor = Color.FromArgb(220, 180, 180);
        NavPanel.Controls.Add(settingsBtn);
        NavPanel.Controls.Add(transactionsBtn);
        NavPanel.Controls.Add(orderBtn);
        NavPanel.Controls.Add(inventoryBtn);
        NavPanel.Controls.Add(dashboardBtn);
        NavPanel.Location = new Point(0, 1);
        NavPanel.Name = "NavPanel";
        NavPanel.Size = new Size(951, 44);
        NavPanel.TabIndex = 0;
        // 
        // dashboardBtn
        // 
        dashboardBtn.BackColor = Color.FromArgb(220, 180, 180);
        dashboardBtn.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        dashboardBtn.Location = new Point(410, 11);
        dashboardBtn.Name = "dashboardBtn";
        dashboardBtn.Size = new Size(75, 23);
        dashboardBtn.TabIndex = 0;
        dashboardBtn.Text = "dashboard";
        dashboardBtn.UseVisualStyleBackColor = false;
        // 
        // inventoryBtn
        // 
        inventoryBtn.BackColor = Color.FromArgb(220, 180, 180);
        inventoryBtn.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        inventoryBtn.Location = new Point(511, 11);
        inventoryBtn.Name = "inventoryBtn";
        inventoryBtn.Size = new Size(75, 23);
        inventoryBtn.TabIndex = 1;
        inventoryBtn.Text = "inventory";
        inventoryBtn.UseVisualStyleBackColor = false;
        // 
        // orderBtn
        // 
        orderBtn.BackColor = Color.FromArgb(220, 180, 180);
        orderBtn.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        orderBtn.Location = new Point(609, 11);
        orderBtn.Name = "orderBtn";
        orderBtn.Size = new Size(75, 23);
        orderBtn.TabIndex = 2;
        orderBtn.Text = "orders";
        orderBtn.UseVisualStyleBackColor = false;
        // 
        // transactionsBtn
        // 
        transactionsBtn.BackColor = Color.FromArgb(220, 180, 180);
        transactionsBtn.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        transactionsBtn.Location = new Point(709, 11);
        transactionsBtn.Name = "transactionsBtn";
        transactionsBtn.Size = new Size(75, 23);
        transactionsBtn.TabIndex = 3;
        transactionsBtn.Text = "transactions";
        transactionsBtn.UseVisualStyleBackColor = false;
        // 
        // settingsBtn
        // 
        settingsBtn.BackColor = Color.FromArgb(220, 180, 180);
        settingsBtn.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        settingsBtn.Location = new Point(811, 11);
        settingsBtn.Name = "settingsBtn";
        settingsBtn.Size = new Size(75, 23);
        settingsBtn.TabIndex = 4;
        settingsBtn.Text = "settings";
        settingsBtn.UseVisualStyleBackColor = false;
        // 
        // LoginForm
        // 
        ClientSize = new Size(950, 670);
        Controls.Add(NavPanel);
        Name = "LoginForm";
        NavPanel.ResumeLayout(false);
        ResumeLayout(false);

    }

    private void MainShellForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        // log out when shell is closed
        SessionManager.Logout();
        Show();
    }


}

