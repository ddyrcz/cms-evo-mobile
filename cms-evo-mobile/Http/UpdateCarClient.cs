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

namespace CmsDroid.Http
{
    class UpdateCarClient
    {
        public void Update(UpdateCarRequest request)
        {
            using (var http = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                http.PutAsync("http://10.0.2.2:5000/api/cars", stringContent).Wait();
            }
        }
    }

    class UpdateCarRequest
    {
        public UpdateCarRequest(Guid carId,
            string name, 
            string registrationNumber, 
            DateTime termTechnicalResearch, 
            DateTime ocExpiry, 
            DateTime? acExpiry,
            DateTime? liftUdtExpiry,
            DateTime? tachoLegalizationExpiry)
        {
            CarId = carId;
            Name = name;
            RegistrationNumber = registrationNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid CarId { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public DateTime TermTechnicalResearch { get; }
        public DateTime OcExpiry { get; }
        public DateTime? AcExpiry { get; }
        public DateTime? LiftUdtExpiry { get; }
        public DateTime? TachoLegalizationExpiry { get; }
    }
}