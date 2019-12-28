using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CmsDroid
{
    static class StaticAppSettings
    {
        public static bool UseMockData = true;
        public static string ServiceAddress = "http://77.55.208.42:5000";
    }
}