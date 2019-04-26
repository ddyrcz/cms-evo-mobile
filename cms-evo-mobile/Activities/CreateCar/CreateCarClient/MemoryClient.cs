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
    class MemoryClient : ICreateCarClient
    {
        public Task Create(CreateCarRequest request)
        {
            return Task.CompletedTask;
        }
    }
}