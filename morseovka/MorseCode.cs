using System.Text;
using System.Text.RegularExpressions;

namespace morseovka;

public class MorseCode
{
    private static Dictionary<string, string> translate_table = new()
    {
        {"A", ".-" }, { "B", "-..." }, { "C", "-.-." }, { "D", "-.." }, { "E", "." },
        { "F", "..-." }, { "G", "--." }, { "H", "...." }, { "I", ".." }, { "J", ".---" },
        { "K", "-.-" }, { "L", ".-.." }, { "M", "--" }, { "N", "-." }, { "O", "---" },
        { "P", ".--." }, { "Q", "--.-" }, { "R", ".-." }, { "S", "..." }, { "T", "-" },
        { "U", "..-" }, { "V", "...-" }, { "W", ".--" }, { "X", "-..-" }, { "Y", "-.--" },
        { "Z", "--.." },
        { "0", "-----" }, { "1", ".----" }, { "2", "..---" }, { "3", "...--" },
        { "4", "....-" }, { "5", "....." }, { "6", "-...." }, { "7", "--..." },
        { "8", "---.." }, { "9", "----." },
        { ".", ".-.-.-" }, { ",", "--..--" }, { " ", "" }
    };

    public static string Encode(string input)
    {
        string clean_input = input.Normalize(NormalizationForm.FormD);
        clean_input = clean_input.ToUpper();
        StringBuilder encoded_builder = new();
        foreach (var letter in clean_input)
        {
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(letter) !=
                System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                encoded_builder.Append(translate_table.FirstOrDefault(x => x.Key == letter.ToString()).Value);
                encoded_builder.Append("/");
            }
        }

        encoded_builder.Remove(encoded_builder.Length-1, 1);
        return encoded_builder.ToString();
    }
    
    public static string Decode(string input)
    {
        string[] decoded_string = input.Split("/");
        StringBuilder encoded_builder = new();
        foreach (var letter in decoded_string)
        {
            encoded_builder.Append(translate_table.FirstOrDefault(x => x.Value == letter).Key);
        }
        return encoded_builder.ToString();
    }
}