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
using Newtonsoft.Json;

namespace CmsDroid.Activities.CreateCar.CreateCarClient
{
    class RemoteClient : ICreateCarClient
    {
        public async Task Create(CreateCarRequest request)
        {
            using (var http = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                await http.PostAsync($"{StaticAppSettings.ServiceAddress}/api/cars", stringContent);
            }
        }
    }
}