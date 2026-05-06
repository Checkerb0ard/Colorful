using System.Text;
using UnityEngine;

namespace Colorful.Utilities;

internal static class RichTextUtilities
{
    internal static string Rainbowify(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        StringBuilder builder = new StringBuilder(text.Length * 24);

        int colorIndex = 0;
        int coloredCharacterCount = 0;

        foreach (char c in text)
        {
            if (!char.IsWhiteSpace(c))
                coloredCharacterCount++;
        }

        if (coloredCharacterCount == 0)
            return text;

        foreach (char c in text)
        {
            if (char.IsWhiteSpace(c))
            {
                builder.Append(c);
                continue;
            }

            float hue = (float)colorIndex / coloredCharacterCount;
            Color color = Color.HSVToRGB(hue, 1f, 1f);

            builder.Append("<color=#");
            builder.Append(ToHtmlStringRGB(color));
            builder.Append(">");
            builder.Append(c);
            builder.Append("</color>");

            colorIndex++;
        }

        return builder.ToString();
    }
    
    private static string ToHtmlStringRGB(Color color)
    {
        byte r = FloatToByte(color.r);
        byte g = FloatToByte(color.g);
        byte b = FloatToByte(color.b);

        return $"{r:X2}{g:X2}{b:X2}";
    }

    private static byte FloatToByte(float value)
    {
        value = Mathf.Clamp01(value);
        return (byte)Mathf.RoundToInt(value * 255f);
    }
}