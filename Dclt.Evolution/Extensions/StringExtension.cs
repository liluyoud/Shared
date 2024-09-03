using static System.Net.Mime.MediaTypeNames;

namespace Dclt.Evolution.Extensions;

public static class StringExtension
{
    public static string ToRemoteJid(this string number)
    {
        // if Jid is well formated return this
        if (number.IndexOf("whatsapp") >= 0) return number;

        number = number.ToOnlyNumbers();

        if (number.Length == 11) // 88 9 8888888 - remove 9 on number
            number = number.Substring(0, 2) + number.Substring(3, 8);
        
        if (number.Length == 13) // 88 88 9 8888888 - remove 9 on number
            number = number.Substring(0, 4) + number.Substring(5, 8);

        // add BR code to phone number
        if (number.Length <= 11)
            number = "55" + number;

        // add WhatsApp Jid to number
        number += "@s.whatsapp.net";
        return number;
    }

    public static string ToOnlyNumbers(this string number)
    {
        var strArray = number.ToCharArray();
        var strNumber = "";
        foreach (var caracter in strArray)
        {
            if (char.IsDigit(caracter))
                strNumber += caracter;
        }
        return strNumber;
    }
}
