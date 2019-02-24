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
using Cms.Utils;
using static Cms.Data.ListViewDataStore;

namespace Cms
{
    [Activity(Label = "CarDetailsActivity")]
    public class CarDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.car_details);

            var car = Intent.GetExtra<ListViewCarModel>("selectedCar");

            var makeTextView = FindViewById<TextView>(Resource.Id.details_car_make);

            //makeTextView.Text = car.Make;
        }
    }
}