using AmanePOSHelpers;
using IT_Assignment_2.Data;
using IT_Assignment_2.Models;
using IT_Assignment_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT_Assignment_2.Forms
{
    public class LoginForm : Form
    {

        // form set up

        //controls
        private Panel _navBar = null!;
        private Label _lblLogo = null!;
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
        private Label _lblOr = null!;
        private Button _btnPinSwitch = null!;
        private Label _lblNewStaff = null!;

        // pin mode
        private Panel _panelPin = null!;
        private Label _lblPinInstr = null!;
        private Label _lblPinDisplay = null!;
        private TableLayoutPanel _pinPad = null!;
        private Button _btnPasswordSwitch = null!;
        private string _pinBuffer = "";

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
        }

        private void BuildNavBar()
        {
            _navBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = AmaneStyling.NavHeight,
                BackColor = AmaneStyling.NavBar,
                Padding = new Padding(20, 0, 20, 0)
            };

            // BuildLogoControl handles image vs text fallback automatically
            var logo = AmaneStyling.BuildLogoControl();
            _navBar.Controls.Add(logo);

            Controls.Add(_navBar);
        }

        public void BuildCard()
        {
            _cardPanel = new Panel
            {
                Size = new Size(400, 450),
                BackColor = AmaneStyling.CardBg,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point((ClientSize.Width - 400) / 2, (ClientSize.Height - 450) / 2)
            };
            _lblTitle = new Label
            {
                Text = "Staff Login",
                Font = AmaneStyling.FontBody,
                ForeColor = AmaneStyling.TextOnNav,
                AutoSize = true,
                Location = new Point(30, 30)
            };
            _cardPanel.Controls.Add(_lblTitle);
            Controls.Add(_cardPanel);
        }

        public void BuildPasswordPanel()
        {
            _panelPassword = new Panel
            {
                Size = new Size(340, 300),
                Location = new Point(30, 80)
            };
            _lblEmail = new Label
            {
                Text = "Email",
                Font = AmaneStyling.FontBody,
                ForeColor = AmaneStyling.TextDark,
                AutoSize = true,
                Location = new Point(0, 0)
            };
            _txtEmail = new TextBox
            {
                Size = new Size(300, 30),
                Location = new Point(0, 30)
            };
            _lblPassword = new Label
            {
                Text = "Password",
                Font = AmaneStyling.FontBody,
                ForeColor = AmaneStyling.TextDark,
                AutoSize = true,
                Location = new Point(0, 80)
            };
            _txtPassword = new TextBox
            {
                Size = new Size(300, 30),
                Location = new Point(0, 110),
                UseSystemPasswordChar = true
            };
            _lblForgot = new Label
            {
                Text = "Forgot password?",
                Font = AmaneStyling.FontBody,
                ForeColor = AmaneStyling.TextOnURL,
                AutoSize = true,
                Location = new Point(0, 150),
                Cursor = Cursors.Hand
            };
            _btnLogin = new Button
            {
                Text = "Login",
                Size = new Size(300, 40),
                Location = new Point(0, 190),
                BackColor = AmaneStyling.ButtonPrimary,
                ForeColor = AmaneStyling.ButtonText,
                FlatStyle = FlatStyle.Flat
            };
            _btnLogin.FlatAppearance.BorderSize = 0;
            // event handlers would be added here
            _panelPassword.Controls.AddRange(new Control[]
            {
                _lblEmail, _txtEmail, _lblPassword, _txtPassword, _lblForgot, _btnLogin
            });
            _cardPanel.Controls.Add(_panelPassword);
        }

        public void BuildPinPanel()
        {
            _panelPin = new Panel
            {
                Size = new Size(340, 300),
                Location = new Point(30, 80),
                Visible = false
            };
            _lblPinInstr = new Label
            {
                Text = "Enter your 4-digit PIN",
                Font = AmaneStyling.FontBody,
                ForeColor = AmaneStyling.TextDark,
                AutoSize = true,
                Location = new Point(0, 0)
            };
            _lblPinDisplay = new Label
            {
                Text = "",
                Font = new Font(AmaneStyling.FontBody.FontFamily, 18f, FontStyle.Bold),
                ForeColor = AmaneStyling.TextDark,
                AutoSize = true,
                Location = new Point(0, 40)
            };
            _pinPad = new TableLayoutPanel
            {
                Size = new Size(300, 200),
                Location = new Point(0, 80),
                ColumnCount = 3,
                RowCount = 4
            };
            for (int i = 1; i <= 9; i++)
            {
                var btn = CreatePinButton(i.ToString());
                _pinPad.Controls.Add(btn);
            }
            var btnZero = CreatePinButton("0");
            _pinPad.Controls.Add(btnZero, 1, 3);
            _btnPasswordSwitch = new Button
            {
                Text = "Use Password",
                Size = new Size(300, 40),
                Location = new Point(0, 290),
                BackColor = AmaneStyling.ButtonSecondary,
                ForeColor = AmaneStyling.ButtonText,
                FlatStyle = FlatStyle.Flat
            };
            _btnPasswordSwitch.FlatAppearance.BorderSize = 0;
            // event handler would be added here
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
                BackColor = AmaneStyling.ButtonPrimary,
                ForeColor = AmaneStyling.ButtonText,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            // event handler would be added here
            return btn;
        }
    }
}
