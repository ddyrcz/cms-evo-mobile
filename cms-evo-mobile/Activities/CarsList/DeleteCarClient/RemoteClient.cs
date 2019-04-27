using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    class RemoteClient : IDeleteCarClient
    {
        public async Task Delete(Guid id)
        {
            using (var http = new HttpClient())
            {
                await http.DeleteAsync($"{StaticAppSettings.ServiceAddress}/api/cars/{id}");
            }
        }
    }
}