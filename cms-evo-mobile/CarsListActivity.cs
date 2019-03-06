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

            _cars = ListViewDataStore.Cars;

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
            Toast.MakeText(this, "Create car clicked!", ToastLength.Short).Show();
        }

        private void CarClicked(object sender, Guid carId)
        {
            var intent = new Intent(this, typeof(CarDetailsActivity));
            intent.PutExtra("SelectedCarId", carId);
            StartActivity(intent);
        }
    }
}