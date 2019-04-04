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
using Cms.Settings;

namespace CmsDroid.Activities.CarDetails.GetCarDetailsClient
{
    static class GetCarDetailsClientFactory
    {
        public static IGetCarDetailsClient Get()
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