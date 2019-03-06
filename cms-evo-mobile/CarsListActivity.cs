using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cms.Data;
using Cms.Utils;
using Refractored.Fab;
using static Cms.Data.ListViewDataStore;

namespace Cms
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        RecyclerView _recyclerView;        
        CarsListAdapter _carsAdapter;
        List<ListViewCarModel> _cars;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.cars_list);


            var service = new Http.GetCarsClient();
            var cars = service.GetCars();

            _cars = cars;

            _carsAdapter = new CarsListAdapter(_cars);
            _carsAdapter.CarClicked += CarClicked;

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.carsListRecyclerView);

            _recyclerView.SetAdapter(_carsAdapter);

            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var fab = FindViewById<FloatingActionButton>(Resource.Id.add_car_button);
            fab.AttachToRecyclerView(_recyclerView);
            fab.Click += AddCarClicked;

        }

        private void AddCarClicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateCarActivity));           
            StartActivity(intent);
        }

        private void CarClicked(object sender, Guid carId)
        {
            var intent = new Intent(this, typeof(CarDetailsActivity));
            intent.PutExtra("SelectedCarId", carId);
            StartActivity(intent);
        }
    }

    public class ListViewCarModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public bool ApproachingExpiration { get; }

        public ListViewCarModel(Guid id,
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