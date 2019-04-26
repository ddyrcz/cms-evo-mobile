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
using CmsDroid.Activities.CreateCar.CreateCarClient;
using CmsDroid.Utils;
using Refractored.Fab;

namespace CmsDroid.Activities
{
    [Activity(Label = "CreateCarActivity")]
    public class CreateCarActivity : Activity
    {
        const string DateFormat = "dd.MM.yyyy";

        EditText _name;
        EditText _registrationNumber;
        TextView _technicalTermResearch;
        TextView _registrationNumberOcExpiry;
        TextView _registrationNumberAcExpiry;
        TextView _liftUdtExpiry;
        TextView _tachoLegalizationExpiry;
        FloatingActionButton _createCarButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.car_details);

            _createCarButton = FindViewById<FloatingActionButton>(Resource.Id.save_fab_button);
            _createCarButton.Click += OnCreateCarClicked;

            _name = FindViewById<EditText>(Resource.Id.details_car_name);

            _registrationNumber = FindViewById<EditText>(Resource.Id.details_car_registration_number);

            _technicalTermResearch = FindViewById<EditText>(Resource.Id.details_car_term_technical_research);            
            _technicalTermResearch.Click += TechnicalTermResearch_Click;

            _registrationNumberOcExpiry = FindViewById<EditText>(Resource.Id.details_car_oc_expiry);            
            _registrationNumberOcExpiry.Click += RegistrationNumberOcExpiry_Click;

            _registrationNumberAcExpiry = FindViewById<EditText>(Resource.Id.details_car_ac_expiry);            
            _registrationNumberAcExpiry.Click += RegistrationNumberAcExpiry_Click;

            _liftUdtExpiry = FindViewById<EditText>(Resource.Id.details_car_lift_udt_expiry);            
            _liftUdtExpiry.Click += LiftUdtExpiry_Click;

            _tachoLegalizationExpiry = FindViewById<EditText>(Resource.Id.details_car_tacho_legalization_expiry);            
            _tachoLegalizationExpiry.Click += TachoLegalizationExpiry_Click;
        }

        private async void OnCreateCarClicked(object sender, EventArgs e)
        {
            var createCarRequest = new CreateCarRequest(
                Guid.NewGuid(),
               _name.Text,
               _registrationNumber.Text,
               DateParser.ParseDate(_technicalTermResearch.Text, DateFormat),
               DateParser.ParseDate(_registrationNumberOcExpiry.Text, DateFormat),
               DateParser.ParseDate(_registrationNumberAcExpiry.Text, DateFormat),
               DateParser.ParseDate(_liftUdtExpiry.Text, DateFormat),
               DateParser.ParseDate(_tachoLegalizationExpiry.Text, DateFormat));

            await CreateCarClientFactory.Client.Create(createCarRequest);

            SetResult(Result.Ok);
            Finish();
        }

        private void TachoLegalizationExpiry_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _tachoLegalizationExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void LiftUdtExpiry_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _liftUdtExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void TechnicalTermResearch_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _technicalTermResearch.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void RegistrationNumberAcExpiry_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _registrationNumberAcExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void RegistrationNumberOcExpiry_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _registrationNumberOcExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}