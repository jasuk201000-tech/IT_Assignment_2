using AmanePOSHelpers;
using IT_Assignment_2.Helpers;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Windows.Forms;

namespace IT_Assignment_2.Forms;

public class LoginForm : Form
{
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
    private string ApinBuffer = "";

    // constructor
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

    // navigation bar
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

    // main card, where all the log in details are nested
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

    // ── Password panel ────────────────────────────────────────────────────────
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
            Location = new Point(240, 160)  // sits to the right of log in
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

    // pin panel
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
            ApinPad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
        for (int i = 0; i < 4; i++)
            ApinPad.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));

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

        // FIX 2 — ApinPad was added three times, removed duplicates
        ApanelPin.Controls.AddRange(new Control[]
        {
            AlblPinInstr, AlblPinDisplay, ApinPad, AbtnPasswordSwitch
        });

        AcardPanel.Controls.Add(ApanelPin);
    }

    private Button CreatePinButton(string text)
    {
        var btn = new Button
        {
            Text = text,
            Dock = DockStyle.Fill,
            BackColor = AmaneStyling.AccentLight,  
            ForeColor = AmaneStyling.TextDark,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(2)
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.Click += (_, _) => PinKeyPressed(text);
        return btn;
    }

    // mode switching
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

    // password log in
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

    // pin login
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

        AlblPinDisplay.Text = new string('●', ApinBuffer.Length);

        if (ApinBuffer.Length == 4)
            SubmitPin();
    }

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

    // error messages
    private void ShowError(string message)
    {
        MessageBox.Show(message, "Amane",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    private void OpenShell()
    {
        var shell = new MainShellForm();
        shell.FormClosed += (_, _) =>
        {
            SessionManager.Logout();
            Show();
        };
        shell.Show();
        Hide();
    }
}