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

namespace cms_evo_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.cars_list);

            var cars = new List<CarModel>
            {
                new CarModel("Ford Fusion"),
                new CarModel("Ford C-MAX"),
                new CarModel("Audo A6")
            };

            var carsList = FindViewById<ListView>(Resource.Id.carsList);

            carsList.Adapter = new CarsListAdapter(this, cars);

        }
    }
}