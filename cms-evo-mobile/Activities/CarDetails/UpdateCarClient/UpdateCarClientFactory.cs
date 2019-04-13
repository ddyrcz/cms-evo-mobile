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

namespace CmsDroid.Activities.CarDetails.UpdateCarClient
{
    static class UpdateCarClientFactory
    {
        public static IUpdateCarClient Get()
        {
            if (StaticAppSettings.UseMockData)
            {
                return new MemoryClient();
            }
            else
            {
                return new RemoteClient();
            }
        }
    }
}