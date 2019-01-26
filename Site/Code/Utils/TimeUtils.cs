using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Code.Utils
{
    public static class TimeUtils
    {
        public static int TimeToUt(string t)
        {
            var sp = t.Split(':');
            return int.Parse(sp[0]) * 3600 + int.Parse(sp[1]) * 60;
        }

        public static string TimeFromUt(int t)
        {
            var h = (int)Math.Floor((double)t / (60 * 60));
            var m = (t - h * 60 * 60) / 60;
            return $"{(h < 10 ? "0" : "")}{h}:{(m < 10 ? "0" : "")}{m}";
        }
    }
}