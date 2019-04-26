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
using CmsDroid;

namespace CmsDroid.Activities.CarsList.GetCarsClient
{
    static class GetCarsClientFactory
    {
        public static IGetCarsClient Client
        {
            get
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
}