using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizletWidget.Utils
{
    class HttpUtility
    {
        public static Dictionary<string, string> ParseQueryString(string query)
        {
            return Regex.Matches(query, "([^?=&]+)(=([^&]*))?").Cast<Match>().ToDictionary(x => x.Groups[1].Value, x => x.Groups[3].Value);
        }
    }
}
