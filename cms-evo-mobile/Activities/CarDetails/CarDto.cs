using System;

namespace CmsDroid.Activities.CarDetails
{
    class CarDto
    {
        public CarDto(Guid id,
            string name,
            string registrationNumber,
            DateTime? termTechnicalResearch,
            DateTime? ocExpiry,
            DateTime? ocInstallmentDate,
            DateTime? acExpiry,
            DateTime? liftUdtExpiry,
            DateTime? tachoLegalizationExpiry)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            OcInstallmentDate = ocInstallmentDate;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid Id { get; }
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