using System;
using System.Web.Services;

/// <summary>
/// Text Reversal Service provides various text manipulation operations
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Allow this Web Service to be called from script
[System.Web.Script.Services.ScriptService]
public class TextReversal : System.Web.Services.WebService
{
    [WebMethod(Description = "Completely reverses input")]
    public string ReverseText(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    [WebMethod(Description = "Keeps order of words and reverses each word individually")]
    public string ReverseWords(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
        return string.Join(" ", words);
    }

    [WebMethod(Description = "Reverses order of words while keeping each word in its initial spelling")]
    public string ReverseWordOrder(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string[] words = input.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    [WebMethod(Description = "Reverses paragraph order")]
    public string ReverseParagraphs(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string[] paragraphs = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        Array.Reverse(paragraphs);
        return string.Join(Environment.NewLine, paragraphs);
    }

    [WebMethod(Description = "Reverses input and appends it to the original input")]
    public string CreatePalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        return input + reversed;
    }
}