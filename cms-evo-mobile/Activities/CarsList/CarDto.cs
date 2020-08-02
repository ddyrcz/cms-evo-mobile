using System;

namespace CmsDroid.Activities.CarsList
{
    public class CarDto
    {
        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public bool IsReviewRequired { get; }

        public CarDto(Guid id,
            string name,
            string registrationNumber,
            bool isReviewRequired)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            IsReviewRequired = isReviewRequired;
        }
    }
}