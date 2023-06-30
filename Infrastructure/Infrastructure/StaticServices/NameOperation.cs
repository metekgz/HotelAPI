using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name) =>
            name
            .Replace("/", "")
            .Replace("!", "")
            .Replace("'", "")
            .Replace("+", "")
            .Replace("%", "")
            .Replace("&", "")
            .Replace("/", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("=", "")
            .Replace("?", "")
            .Replace("_", "")
            .Replace("ğ", "")
            .Replace("ü", "")
            .Replace("ş", "")
            .Replace("i", "")
            .Replace(";", "")
            .Replace(",", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "")
            .Replace("ö", "")
            .Replace("ç", "")
            .Replace(".", "");
    }
}
