using System.Globalization;

namespace Dclt.Shared.Extensions;

public static class StringExtensions
{
    public static string ToUfDescription(this string uf)
    {
        switch (uf.ToUpper())
        {
            case "AC": return "Acre";
            case "AL": return "Alagoas";
            case "AP": return "Amapá";
            case "AM": return "Amazonas";
            case "BA": return "Bahia";
            case "CE": return "Ceará";
            case "DF": return "Distrito Federal";
            case "ES": return "Espírito Santo";
            case "GO": return "Goiás";
            case "MA": return "Maranhão";
            case "MT": return "Mato Grosso";
            case "MS": return "Mato Grosso do Sul";
            case "MG": return "Minas Gerais";
            case "PA": return "Pará";
            case "PB": return "Paraíba";
            case "PR": return "Paraná";
            case "PE": return "Pernambuco";
            case "PI": return "Piauí";
            case "RJ": return "Rio de Janeiro";
            case "RN": return "Rio Grande do Norte";
            case "RS": return "Rio Grande do Sul";
            case "RO": return "Rondônia";
            case "RR": return "Roraima";
            case "SC": return "Santa Catarina";
            case "SP": return "São Paulo";
            case "SE": return "Sergipe";
            case "TO": return "Tocantins";
            default: return "";
        }
    }

    public static string? CleanForNumber(this string? text)
    {
        if (text == null) return null;
        var strArray = text.ToCharArray();
        var strNumber = strArray[0] == '-' ? "-" : "";
        foreach (var caracter in strArray)
        {
            if (char.IsDigit(caracter))
                strNumber += caracter;
        }
        return strNumber;
    }

    public static string? ToCpf(this string? text)
    {
        if (text == null) return null;
        text = text.CleanForNumber();
        if (text!.Length < 11)
            text = text.PadLeft(11, '0');
        else if (text!.Length > 11)
            text = text.Substring(0, 11);
        return $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, 3)}-{text.Substring(9, 2)}";
    }

    public static string FirstName(this string name)
    {
        return name.Substring(0, name.IndexOf(' '));
    }

    public static string LastName(this string name)
    {
        return name.Substring(name.LastIndexOf(' ') + 1);
    }

    public static string ToShortName(this string name)
    {
        name = name.Trim();
        if (name.IndexOf(' ') <= 0) return name;
        return FirstName(name) + " " + LastName(name);
    }

    public static string ToFirstUppercase(this string text)
    {
        return char.ToUpper(text[0]) + text.Substring(1);
    }

    public static string? Capitalize(this string? text)
    {
        if (text == null) return null;
        text = text.Trim();
        if (text == null || text.Length == 0) return null;
        string[] excecoes = new string[] { "e", "de", "da", "das", "do", "dos", "para", "em", "no", "na", "nos", "nas", "o", "a", "os", "as", "ao", "aos", "à", "às" };
        string[] excecoesMaiusculas = new string[] { "ii", "iii", "iv", "vi", "vii", "viii", "ix", "xi", "xii", "xiii" };
        var palavras = new Queue<string>();
        int i = 0;
        foreach (var palavra in text.Split(' '))
        {
            if (!string.IsNullOrEmpty(palavra))
            {
                string final = palavra.ToLower();
                if (!excecoes.Contains(final))
                {
                    var letras = final.ToCharArray();
                    letras[0] = char.ToUpper(letras[0]);
                    final = new string(letras);
                }
                if (excecoesMaiusculas.Contains(palavra.ToLower()))
                {
                    final = palavra.ToUpper();
                }
                if (i == 0)
                {
                    var letras = final.ToCharArray();
                    letras[0] = char.ToUpper(letras[0]);
                    final = new string(letras);
                }
                palavras.Enqueue(final);
            }
            i++;
        }
        return string.Join(" ", palavras);
    }

    public static string Tagfy(this string texto)
    {
        return texto.ToLower();
    }

    public static string? CleanToDouble(this string? text, char decimalSeparator)
    {
        if (string.IsNullOrEmpty(text)) return null;
        text = text.Trim();
        var strArray = text.ToCharArray();
        var strNumber = strArray[0] == '-' ? "-" : "";
        foreach (var caracter in strArray)
        {
            if (char.IsDigit(caracter) || caracter == decimalSeparator)
                strNumber += caracter;
        }
        if (string.IsNullOrEmpty(strNumber))
            return null;
        var uiDecimalSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        if (decimalSeparator != uiDecimalSeparator[0])
            strNumber = strNumber.Replace(decimalSeparator, uiDecimalSeparator[0]);
        return strNumber;
    }

    public static double? ToDouble(this string? text, char decimalSeparator, bool NullAs0 = false)
    {
        var number = text.CleanToDouble(decimalSeparator);
        if (string.IsNullOrEmpty(number))
            return NullAs0 ? 0 : null;
        try
        {
            return Double.Parse(number);
        }
        catch
        {
            return null;
        }
    }

    public static string? GetNextStringValue(this string? text, string startText, int position)
    {
        if (string.IsNullOrEmpty(text)) return null;
        text = text.ToLower();
        startText = startText.ToLower();
        if (text.IndexOf(startText) < 0) return null;
        var pos = text.IndexOf(startText) + startText.Length;
        return text.Substring(pos, position);
    }

    public static string? GetNextStringValue(this string? text, string startText, string endText)
    {
        if (string.IsNullOrEmpty(text)) return null;
        text = text.ToLower();
        startText = startText.ToLower();
        endText = endText.ToLower();
        if (text.IndexOf(startText) < 0) return null;
        var startPos = text.IndexOf(startText) + startText.Length;
        var restText = text.Substring(startPos);
        var endPos = restText.IndexOf(endText);
        return restText.Substring(0, endPos);
    }
}
