namespace AmaneRetailPOS.Constants;

public static class SizeOptions
{
    private static readonly Dictionary<string, List<string>> _sizesByCategory = new()
    {
        { "Clothing", new() { "XS", "S", "M", "L", "XL" } },
        { "Shoes", new() { "6", "7", "8", "9", "10" } },
        { "Accessories", new() { "One Size" } }
    };

    public static List<string> GetSizesForCategory(string category)
    {
        return _sizesByCategory.TryGetValue(category, out var sizes)
            ? sizes
            : new List<string>();
    }

    public static bool IsValidSize(string category, string size)
    {
        return GetSizesForCategory(category).Contains(size);
    }
}
