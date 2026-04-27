using System;
using System.Collections.Generic;
using IT_Assignment_2.Models;
using IT_Assignment_2.Data;

namespace IT_Assignment_2.Services;

public static class SettingsService
{
    // generic key value
    public static string Get(string key, string defaultValue = "") =>
        CsvHelper.GetSetting(key, defaultValue);

    // update one setting by key
    public static void Set(string key, string value) =>
        CsvHelper.SetSetting(key, value);

    // simple setting keys with typed return values

    public static decimal GetTaxRate() =>
        CsvHelper.GetTaxRate();

    public static string GetStoreName() =>
        CsvHelper.GetSetting("StoreName", "Amane");

    //get settings as a whole object for easier use in the app
    public static StoreSettings GetSettings()
    {
        var raw = CsvHelper.LoadSettings()
            ?? new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);

        // local helpers to keep the mapping clean
        string get(string key, string fallback = "") =>
            raw.TryGetValue(key, out var val)
            && val != null ? val : fallback;

        string? getNullable(string key)
        {
            var v = get(key, "");
            return string.IsNullOrWhiteSpace(v) ? null : v;
        }

        bool parseBool(string key) =>
            bool.TryParse(get(key, "false"), out var b) && b;

        decimal parseTax()
        {
            if (decimal.TryParse(get("TaxRate", ""), out var t))
                return t;
            return CsvHelper.GetTaxRate();
        }

        // returning store setting values with some defaults and parsing
        return new StoreSettings
        {
            StoreName = get("StoreName", "Amane"),
            StoreAddress = getNullable("StoreAddress"),
            StorePhone = getNullable("StorePhone"),
            StoreEmail = getNullable("StoreEmail"),
            StoreHandle = getNullable("StoreHandle"),
            LogoPath = getNullable("LogoPath"),
            TaxRate = parseTax(),
            ReturnPolicy = get("ReturnPolicy", ""),
            ReceiptShowLogo = parseBool("ReceiptShowLogo"),
            ReceiptShowAddress = parseBool("ReceiptShowAddress"),
            ReceiptShowPhone = parseBool("ReceiptShowPhone"),
            ReceiptShowSocials = parseBool("ReceiptShowSocials"),
            ReceiptShowPolicy = parseBool("ReceiptShowPolicy")
        };
    }

    // savng settings from a whole object, converting values to strings for storage

    public static void SaveSettings(StoreSettings s)
    {
        CsvHelper.SetSetting("StoreName", s.StoreName);
        CsvHelper.SetSetting("StoreAddress", s.StoreAddress ?? "");
        CsvHelper.SetSetting("StorePhone", s.StorePhone ?? "");
        CsvHelper.SetSetting("StoreEmail", s.StoreEmail ?? "");
        CsvHelper.SetSetting("StoreHandle", s.StoreHandle ?? "");
        CsvHelper.SetSetting("LogoPath", s.LogoPath ?? "");
        CsvHelper.SetSetting("TaxRate", s.TaxRate.ToString());
        CsvHelper.SetSetting("ReturnPolicy", s.ReturnPolicy);
        CsvHelper.SetSetting("ReceiptShowLogo", s.ReceiptShowLogo.ToString());
        CsvHelper.SetSetting("ReceiptShowAddress", s.ReceiptShowAddress.ToString()); 
        CsvHelper.SetSetting("ReceiptShowPhone", s.ReceiptShowPhone.ToString());
        CsvHelper.SetSetting("ReceiptShowSocials", s.ReceiptShowSocials.ToString());
        CsvHelper.SetSetting("ReceiptShowPolicy", s.ReceiptShowPolicy.ToString());
    }
}