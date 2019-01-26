using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Code.Utils
{
    public static class Dictionary
    {
        public static Dictionary<string, string> GetDictionary(object o)
        {
            return o.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(o)?.ToString());
        }
    }
}