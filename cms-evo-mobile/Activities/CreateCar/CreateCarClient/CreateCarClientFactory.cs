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

namespace CmsDroid.Activities.CreateCar.CreateCarClient
{
    static class CreateCarClientFactory
    {
        public static ICreateCarClient Client
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

    interface ICreateCarClient
    {
        Task Create(CreateCarRequest request);
    }

    class CreateCarRequest
    {
        public CreateCarRequest(Guid id,
           string name,
           string registrationNumber,
           DateTime termTechnicalResearch,
           DateTime ocExpiry,
           DateTime? acExpiry,
           DateTime? liftUdtExpiry,
           DateTime? tachoLegalizationExpiry)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public DateTime TermTechnicalResearch { get; }
        public DateTime OcExpiry { get; }
        public DateTime? AcExpiry { get; }
        public DateTime? LiftUdtExpiry { get; }
        public DateTime? TachoLegalizationExpiry { get; }
    }
}