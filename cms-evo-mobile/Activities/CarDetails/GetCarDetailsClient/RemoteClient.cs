using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace CmsDroid.Activities.CarDetails.GetCarDetailsClient
{
    class RemoteClient : IGetCarDetailsClient
    {
        public CarDto GetDetails(Guid carId)
        {
            using (var http = new HttpClient())
            {
                var response = http.GetAsync($"{StaticAppSettings.ServiceAddress}/api/cars/{carId}").Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var carDetailsRepsonse = JsonConvert.DeserializeObject<GetCarDetailsResponse>(json);

                return carDetailsRepsonse.Car;
            }
        }

        public class GetCarDetailsResponse
        {
            public CarDto Car { get; set; }
        }
    }
}