using System;

namespace CmsDroid.Activities.CarDetails.UpdateCarClient
{
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