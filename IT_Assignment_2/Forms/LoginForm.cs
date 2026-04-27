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

    private Panel _navBar = null!;
    private Panel _cardPanel = null!;
    private Label _lblTitle = null!;

    // password mode
    private Panel _panelPassword = null!;
    private Label _lblEmail = null!;
    private TextBox _txtEmail = null!;
    private Label _lblPassword = null!;
    private TextBox _txtPassword = null!;
    private Label _lblForgot = null!;
    private Button _btnLogin = null!;
    private Button _btnPinSwitch = null!;

    // pin mode
    private Panel _panelPin = null!;
    private Label _lblPinInstr = null!;
    private Label _lblPinDisplay = null!;
    private TableLayoutPanel _pinPad = null!;
    private Button _btnPasswordSwitch = null!;
    private string _pinBuffer = "";



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
        _navBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = AmaneStyling.NavHeight,
            BackColor = AmaneStyling.NavBar,
            Padding = new Padding(20, 0, 20, 0)
        };

        var logo = AmaneStyling.BuildLogoControl();
        _navBar.Controls.Add(logo);
        Controls.Add(_navBar);
    }

    // card container for login elements, centered in the form

    private void BuildCard()
    {
        _cardPanel = new Panel
        {
            Size = new Size(400, 480),
            BackColor = AmaneStyling.CardBg,
            BorderStyle = BorderStyle.FixedSingle
        };

        _lblTitle = new Label
        {
            Text = "amane staff portal",
            Font = AmaneStyling.FontTitle,
            ForeColor = AmaneStyling.TextDark,
            AutoSize = true,
            Location = new Point(30, 24)
        };

        _cardPanel.Controls.Add(_lblTitle);
        Controls.Add(_cardPanel);
        CentreCard();
    }

    private void CentreCard()
    {
        _cardPanel.Location = new Point(
            (ClientSize.Width - _cardPanel.Width) / 2,
            (ClientSize.Height - _cardPanel.Height) / 2
        );
    }

    // password panel with email and password fields, and switch to PIN mode

    private void BuildPasswordPanel()
    {
        _panelPassword = new Panel
        {
            Size = new Size(340, 360),
            Location = new Point(30, 70)
        };

        _lblEmail = new Label
        {
            Text = "please enter email/username",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 0)
        };

        _txtEmail = new TextBox
        {
            Size = new Size(340, 30),
            Location = new Point(0, 20)
        };
        AmaneStyling.StyleTextBox(_txtEmail);

        _lblPassword = new Label
        {
            Text = "please enter password",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 65)
        };

        _txtPassword = new TextBox
        {
            Size = new Size(340, 30),
            Location = new Point(0, 85),
            UseSystemPasswordChar = true
        };
        AmaneStyling.StyleTextBox(_txtPassword);

        _lblForgot = new Label
        {
            Text = "forgotten password?",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.Accent,
            AutoSize = true,
            Location = new Point(0, 125),
            Cursor = Cursors.Hand
        };

        _btnLogin = new Button
        {
            Text = "log in",
            Size = new Size(340, AmaneStyling.ButtonHeight),
            Location = new Point(0, 160)
        };
        AmaneStyling.StyleButton(_btnLogin);
        _btnLogin.Click += BtnLogin_Click;

        _btnPinSwitch = new Button
        {
            Text = "PIN Log in",
            Size = new Size(160, AmaneStyling.ButtonHeight),
            Location = new Point(180, 160)
        };
        AmaneStyling.StyleButton(_btnPinSwitch, primary: false);
        _btnPinSwitch.Click += (_, _) => ShowPinMode();

        _panelPassword.Controls.AddRange(new Control[]
        {
            _lblEmail, _txtEmail,
            _lblPassword, _txtPassword,
            _lblForgot, _btnLogin, _btnPinSwitch
        });

        _cardPanel.Controls.Add(_panelPassword);
    }

    // PIN panel

    private void BuildPinPanel()
    {
        _panelPin = new Panel
        {
            Size = new Size(340, 360),
            Location = new Point(30, 70),
            Visible = false
        };

        _lblPinInstr = new Label
        {
            Text = "enter your 4-digit PIN",
            Font = AmaneStyling.FontLabel,
            ForeColor = AmaneStyling.TextMuted,
            AutoSize = true,
            Location = new Point(0, 0)
        };

        _lblPinDisplay = new Label
        {
            Text = "",
            Font = new Font(AmaneStyling.FontBody.FontFamily, 20f),
            ForeColor = AmaneStyling.TextDark,
            AutoSize = true,
            Location = new Point(0, 30)
        };

        _pinPad = new TableLayoutPanel
        {
            Size = new Size(300, 210),
            Location = new Point(0, 70),
            ColumnCount = 3,
            RowCount = 4
        };

        // set equal column and row sizes
        for (int i = 0; i < 3; i++)
            _pinPad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
        for (int i = 0; i < 4; i++)
            _pinPad.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));

        // digits 1-9
        for (int i = 1; i <= 9; i++)
            _pinPad.Controls.Add(CreatePinButton(i.ToString()));

        // bottom row — empty, 0, backspace
        _pinPad.Controls.Add(new Label(), 0, 3);
        _pinPad.Controls.Add(CreatePinButton("0"), 1, 3);
        _pinPad.Controls.Add(CreatePinButton("⌫"), 2, 3);

        _btnPasswordSwitch = new Button
        {
            Text = "use password instead",
            Size = new Size(300, AmaneStyling.ButtonHeight),
            Location = new Point(0, 295)
        };
        AmaneStyling.StyleButton(_btnPasswordSwitch, primary: false);
        _btnPasswordSwitch.Click += (_, _) => ShowPasswordMode();

        _panelPin.Controls.AddRange(new Control[]
        {
            _lblPinInstr, _lblPinDisplay, _pinPad, _btnPasswordSwitch
        });

        _cardPanel.Controls.Add(_panelPin);
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
        _panelPassword.Visible = true;
        _panelPin.Visible = false;
        _pinBuffer = "";
        _lblPinDisplay.Text = "";
    }

    private void ShowPinMode()
    {
        _panelPassword.Visible = false;
        _panelPin.Visible = true;
    }

    // authentication logic for password login

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_txtEmail.Text) ||
            string.IsNullOrWhiteSpace(_txtPassword.Text))
        {
            ShowError("Please enter your email and password.");
            return;
        }

        var staff = StaffService.AuthenticatePassword(
            _txtEmail.Text.Trim(),
            _txtPassword.Text);

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
            if (_pinBuffer.Length > 0)
                _pinBuffer = _pinBuffer[..^1];
        }
        else
        {
            if (_pinBuffer.Length >= 4) return;
            _pinBuffer += key;
        }

        // show dots for each digit entered
        _lblPinDisplay.Text = new string('●', _pinBuffer.Length);

        // auto submit when 4 digits entered
        if (_pinBuffer.Length == 4)
            SubmitPin();
    }

    private void SubmitPin()
    {
        // PIN login requires email to identify the staff member
        if (string.IsNullOrWhiteSpace(_txtEmail.Text))
        {
            ShowError("Please enter your email first.");
            _pinBuffer = "";
            _lblPinDisplay.Text = "";
            return;
        }

        var staff = StaffService.AuthenticatePin(
            _txtEmail.Text.Trim(),
            _pinBuffer);

        if (staff == null)
        {
            ShowError("Incorrect PIN.");
            _pinBuffer = "";
            _lblPinDisplay.Text = "";
            return;
        }

        SessionManager.Login(staff);
        OpenShell();
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

    private void MainShellForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        // log out when shell is closed
        SessionManager.Logout();
        Show();
    }


}

