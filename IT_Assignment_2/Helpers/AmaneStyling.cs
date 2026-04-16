using System.Drawing;
using System.Reflection;

namespace AmanePOSHelpers;

public static class AmaneStyling
{
    // defining a cohesive colour pallete for the application

    // main components
    public static readonly Color NavBar = ColorTranslator.FromHtml("#DCB4B4");
    public static readonly Color CardPanel = ColorTranslator.FromHtml("#9E8585");
    public static readonly Color PageBg = ColorTranslator.FromHtml("#F5EEE8");
    public static readonly Color Accent = ColorTranslator.FromHtml("#C69898");
    public static readonly Color Divider = ColorTranslator.FromHtml("#D2B9B9");

    // text colouring
    public static readonly Color TextDark = ColorTranslator.FromHtml("#463232");
    public static readonly Color TextMuted = ColorTranslator.FromHtml("#8C6E6E");
    public static readonly Color TextOnNav = ColorTranslator.FromHtml("#3C2828");

   // interactive components
    public static readonly Color InputBg = ColorTranslator.FromHtml("#FFFFFF");
    public static readonly Color InputBorder = ColorTranslator.FromHtml("#C8AAAA");
    public static readonly Color ButtonPrimary = ColorTranslator.FromHtml("#C69898");
    public static readonly Color ButtonText = ColorTranslator.FromHtml("#FFFFFF");
    public static readonly Color CardBg = ColorTranslator.FromHtml("#FAF3F0");

    // status indicators
    public static readonly Color Success = ColorTranslator.FromHtml("#82B48C");
    public static readonly Color Warning = ColorTranslator.FromHtml("#DCB464");
    public static readonly Color Danger = ColorTranslator.FromHtml("#D26464");

    // font settings
    public const int NavHeight = 56;
    public const int ButtonHeight = 40;

    public static readonly Font FontBody = new Font("Segoe UI", 9f, FontStyle.Regular);
    public static readonly Font FontButton = new Font("Segoe UI", 10f, FontStyle.Regular);

   // resource management for the logo image
    private const string LogoResourceName =
        "AmaneRetailPOS.Resources.Images.amane_logo.png";

  
    private static Image? _logoCache;

    // conditional loading of the logo image with error handling and caching
    public static Image? LogoImage
    {
        get
        {
           
            if (_logoCache != null)
                return _logoCache;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                
                var stream = assembly.GetManifestResourceStream(LogoResourceName);

                if (stream != null)
                    _logoCache = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logo failed to load: {ex.Message}");
                
            }

            return _logoCache;
        }
    }

    // creating a seperate method for the backup logo
    public static Control BackupLogoStyling()
    {
        var container = new Panel
        {
            Size = new Size(140, NavHeight),   
            Location = new Point(16, 0),
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand
        };

        var label = new Label
        {
            Text = "a m a n e",
            Font = new Font("Segoe UI", 13f, FontStyle.Regular),
            ForeColor = TextOnNav,
            AutoSize = true,
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand
        };

 
        label.Location = new Point(0, (container.Height - label.PreferredHeight) / 2);

        container.Controls.Add(label);

        return container;   
    }

  // positioning for logo
    public static Control BuildLogoControl()
    {
        if (LogoImage != null)
        {
            return new PictureBox
            {
                Image = LogoImage,
                Size = new Size(140, NavHeight - 16),
                Location = new Point(20, 8),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
        }

        return BackupLogoStyling();
    }
}