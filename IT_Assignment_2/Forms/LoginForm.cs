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
    }
}
