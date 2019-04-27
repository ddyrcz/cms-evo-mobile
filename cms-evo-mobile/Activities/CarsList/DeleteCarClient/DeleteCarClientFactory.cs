using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CmsDroid.Activities.CarsList.DeleteCarClient
{
    static class DeleteCarClientFactory
    {
        public static IDeleteCarClient Client
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

    interface IDeleteCarClient
    {
        Task Delete(Guid id);
    }
}