using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal static class Helper
    {
        //https://stackoverflow.com/questions/5417070/c-sharp-version-of-sql-like
        public static bool Like(this string toSearch, string toFind)
        {
            return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
        }

        public static string GetCurrentSolutionPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "..", "..");
        }

        public static bool MoveFile(string src)
        {
            try
            {
                if (File.Exists(src) == false) return false;
                string nameFile = src.Split('\\').Last();
                string dest = Path.Combine(GetCurrentSolutionPath(), "Assets", "Documents", nameFile);
                File.Copy(src, dest);
                if (File.Exists(dest) == false) return false;
                return true;
            }catch (Exception ex)
            {
                var x = ex.Message;
                return false;
            }
        }
    }
}
