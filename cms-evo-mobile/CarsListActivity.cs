using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using cms_evo_mobile.Utils;

namespace cms_evo_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        private List<CarModel> _cars;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.cars_list);

            _cars = new List<CarModel>
            {
                new CarModel(Guid.NewGuid(), "Ford Fusion"),
                new CarModel(Guid.NewGuid(), "Ford C-MAX"),
                new CarModel(Guid.NewGuid(), "Audo A6")
            };

            var carsList = FindViewById<ListView>(Resource.Id.carsList);

            carsList.Adapter = new CarsListAdapter(this, _cars);

            carsList.ItemClick += CarsList_ItemClick;

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