using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Common.Utilities
{
    public static class PersianConvertorDate
    {
        public static string ToShamsi(this string value)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(Convert.ToDateTime(value)) + "/" + pc.GetMonth(Convert.ToDateTime(value)).ToString("00") + "/" +
                   pc.GetDayOfMonth(Convert.ToDateTime(value)).ToString("00");
        }
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear((value)) + "/" + pc.GetMonth((value)).ToString("00") + "/" +
                   pc.GetDayOfMonth((value)).ToString("00");
        }
    }
}