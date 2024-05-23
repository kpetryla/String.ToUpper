using System.Globalization;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace TurkishUpperCase;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTranslateClicked(object sender, EventArgs e)
    {
        string str1 = "indigo";
        string str2, str3;

        // str2 is an uppercase copy of str1, using English-United States culture.
        str2 = str1.ToUpper(new CultureInfo("en-US", false));

        // str3 is an uppercase copy of str1, using Turkish-Turkey culture.
        str3 = str1.ToUpper(new CultureInfo("tr-TR", false));

        // Compare the code points and compare the uppercase strings.
        Label1.Text = GetString(str1);
        Label2.Text = GetString(str2);
        Label3.Text = GetString(str3);
        
        Console.WriteLine("str2 is {0} to str3.",
            String.CompareOrdinal(str2, str3) == 0 ? "equal" : "not equal");
        
        string result = String.CompareOrdinal(str2, str3) == 0 ? "equal" : "not equal";

        Label4.Text = $"str2 is {result} to str3.";
    }

    private string GetString(string s)
    {
        StringBuilder sb = new StringBuilder(s);
        sb.Append(" ");

        foreach (ushort u in s)
        {
            int unicodeValue = Convert.ToInt32(u);
            // Format the integer as a hexadecimal string
            string hexValue = unicodeValue.ToString("x4");
            sb.Append(hexValue);
            sb.Append(" "); 
        }

        return sb.ToString();
    }
}