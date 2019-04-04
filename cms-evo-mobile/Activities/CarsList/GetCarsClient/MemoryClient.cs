using System.Collections.Generic;

namespace CmsDroid.Activities.CarsList.GetCarsClient
{
    internal class MemoryClient : IGetCarsClient
    {
        public List<CarsListViewModel> GetCars()
        {
            return MemoryData.Cars;
        }
    }
}