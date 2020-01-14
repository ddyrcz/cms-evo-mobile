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
        public static bool UseMockData = false;
        public static string ServiceAddress = "http://77.55.194.166:5000";
    }
}