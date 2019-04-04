using System;

namespace CmsDroid.Activities.CarsList
{
    public class CarsListViewModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public bool ApproachingExpiration { get; }

        public CarsListViewModel(Guid id,
            string name,
            string registrationNumber,
            bool approachingExpiration)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            ApproachingExpiration = approachingExpiration;
        }
    }
}