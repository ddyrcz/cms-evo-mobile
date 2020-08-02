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

namespace CmsDroid.Activities.CarDetails.UpdateCarClient
{
    static class UpdateCarClientFactory
    {
        public static IUpdateCarClient Get()
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

    interface IUpdateCarClient
    {
        Task Update(UpdateCarRequest request);
    }

    class UpdateCarRequest
    {
        public UpdateCarRequest(Guid carId,
           string name,
           string registrationNumber,
           DateTime? termTechnicalResearch,
           DateTime? ocExpiry,
           DateTime? ocInstallmentDate,
           DateTime? acExpiry,
           DateTime? liftUdtExpiry,
           DateTime? tachoLegalizationExpiry)
        {
            CarId = carId;
            Name = name;
            RegistrationNumber = registrationNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            OcInstallmentDate = ocInstallmentDate;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid CarId { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public DateTime? TermTechnicalResearch { get; }
        public DateTime? OcExpiry { get; }
        public DateTime? OcInstallmentDate { get; }
        public DateTime? AcExpiry { get; }
        public DateTime? LiftUdtExpiry { get; }
        public DateTime? TachoLegalizationExpiry { get; }
    }
}