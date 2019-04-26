using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CmsDroid.Utils
{
    static class DateParser
    {
        public static DateTime? ParseDate(string date, string dateFormat)
        {
            return
                 string.IsNullOrEmpty(date) ?
                    null :
                    DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture) as DateTime?;
        }
    }
}