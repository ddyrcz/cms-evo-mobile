﻿using System;
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

namespace Cms.Http
{
    class GetCarDetailsClient
    {
        public DetailsViewCarModel GetCarDetails(Guid carId)
        {
            using (var http = new HttpClient())
            {
                var response = http.GetAsync($"http://10.0.2.2:5000/api/cars/{carId}").Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var carDetailsRepsonse = JsonConvert.DeserializeObject<GetCarDetailsResponse>(json);

                return carDetailsRepsonse.Car;
            }
        }

        public class GetCarDetailsResponse
        {
            public DetailsViewCarModel Car { get; set; }
        }
    }
}