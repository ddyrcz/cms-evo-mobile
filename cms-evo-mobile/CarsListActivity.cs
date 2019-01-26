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
using Cms.Utils;

namespace Cms
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        RecyclerView _recyclerView;
        RecyclerView.LayoutManager _layoutManager;
        CarsListAdapter _carsAdapter;
        List<CarModel> _cars;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.cars_list);

            _cars = new List<CarModel>
            {
                new CarModel(Guid.NewGuid(), "Ford Fusion", "SLU 44AS"),
                new CarModel(Guid.NewGuid(), "Ford C-MAX", "SLU 52BF"),
                new CarModel(Guid.NewGuid(), "Audo A6", "SLU GG3Z"),
                new CarModel(Guid.NewGuid(), "Renault", "SLU GT44"),
                new CarModel(Guid.NewGuid(), "Renault", "SLU P2SS"),
                new CarModel(Guid.NewGuid(), "Renault", "SLU VF56"),
                new CarModel(Guid.NewGuid(), "Renault", "SLU BOI4"),
                new CarModel(Guid.NewGuid(), "Renault", "SLU 0IC3"),
                new CarModel(Guid.NewGuid(), "Iveco", "SLU 8UUH"),
                new CarModel(Guid.NewGuid(), "Renault Kangoo", "SLU DW21"),
            };

            _carsAdapter = new CarsListAdapter(_cars);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.carsListRecyclerView);

            _recyclerView.SetAdapter(_carsAdapter);

            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

        }

        private void CarsList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var openDetailsIntent = new Intent(this, typeof(CarDetailsActivity));

            var selectedCar = _cars[e.Position];

            openDetailsIntent.PutExtra("selectedCar", selectedCar);

            StartActivity(openDetailsIntent);
        }
    }
}