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
using Utils;
using static Cms.Data.ListViewDataStore;

namespace Cms
{
    [Activity(Label = "CarDetailsActivity")]
    public class CarDetailsActivity : Activity
    {
        TextView _registrationNumberOcExpiry;
        TextView _registrationNumberAcExpiry;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.car_details);

            var carId = Intent.GetExtra<Guid>("SelectedCarId");

            var car = Data.DetailsViewDataStore.Details[carId];

            var nameTextView = FindViewById<EditText>(Resource.Id.details_car_name);
            nameTextView.Text = car.Name;

            var registrationNumberTextView = FindViewById<EditText>(Resource.Id.details_car_registration_number);
            registrationNumberTextView.Text = car.RegistrationNumber;


            _registrationNumberOcExpiry = FindViewById<EditText>(Resource.Id.details_car_oc_expiry);
            _registrationNumberOcExpiry.Text = car.OcExpiry.ToString("dd.MM.yyyy");
            _registrationNumberOcExpiry.Click += RegistrationNumberOcExpiry_Click;


            _registrationNumberAcExpiry = FindViewById<TextView>(Resource.Id.details_car_ac_expiry);
            _registrationNumberAcExpiry.Text = car.OcExpiry.ToString("dd.MM.yyyy");
            _registrationNumberAcExpiry.Click += RegistrationNumberAcExpiry_Click;
        }

        private void RegistrationNumberAcExpiry_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _registrationNumberAcExpiry.Text = time.ToString("dd.MM.yyyy");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void RegistrationNumberOcExpiry_Click(object sender, EventArgs e)
        {            
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _registrationNumberOcExpiry.Text = time.ToString("dd.MM.yyyy");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}