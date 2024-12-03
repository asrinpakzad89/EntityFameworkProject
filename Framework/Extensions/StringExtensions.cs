namespace Framework.Extensions;

public static class StringExtensions
{
    public static string ToPersianString(this string? strInput)
    {
        if (string.IsNullOrWhiteSpace(strInput))
        {
            return "";
        }

        string[] arr = strInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string retVal = string.Join(" ", arr);

        string[] arr2 = new[] { ".", "+", "/", @"\", "%", ":", ";", ":", "،", "?", "؟", "«", "»", "(", ")", "[", "]", "{", "}", "!", "@", "#", "$", "^", "&", "*", "|", "؛" };
        foreach (string Str in arr2)
            retVal = retVal.Replace("ي", "ی").Replace("'", "&#146").Replace(Str, "").Replace(" ", "-");
        return retVal;
    }

    public static List<string> ToArray(this string? strInput)
    {
        if (string.IsNullOrWhiteSpace(strInput))
        {
            return new List<string>();
        }
        return strInput.Split('|', (char)StringSplitOptions.RemoveEmptyEntries)
            .Where(str => !string.IsNullOrEmpty(str))
            .ToList();
    }
}
