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

namespace CmsDroid.Activities.CarsList.GetCarsClient
{
    class RemoteClient : IGetCarsClient 
    {
        public  List<CarDto> GetCars()
        {
            using (var http = new HttpClient())
            {
                var response =  http.GetAsync($"{StaticAppSettings.ServiceAddress}/api/cars").Result;

                var json =  response.Content.ReadAsStringAsync().Result;

                var carsRepsonse = JsonConvert.DeserializeObject<GetCarsResponse>(json);

                return carsRepsonse.Cars;
            }
        }

        class GetCarsResponse
        {
            public List<CarDto> Cars { get; set; }
        }
    }
}