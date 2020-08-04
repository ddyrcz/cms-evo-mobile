using System.Collections.Generic;

namespace CmsDroid.Activities.CarsList.GetCarsClient
{
    internal class MemoryClient : IGetCarsClient
    {
        public List<CarDto> GetCars()
        {
            return MemoryData.Cars;
        }
    }
}