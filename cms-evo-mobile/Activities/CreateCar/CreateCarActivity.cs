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
        TextView _ocExpiry;
        TextView _ocInstallmentDate;
        TextView _acExpiry;
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
            _technicalTermResearch.Click += 
                (sender, args) => OnSelectDateClicked(_technicalTermResearch);

            _ocExpiry = FindViewById<EditText>(Resource.Id.details_car_oc_expiry);
            _ocExpiry.Click += 
                (sender, args) => OnSelectDateClicked(_ocExpiry);

            _ocInstallmentDate = FindViewById<EditText>(Resource.Id.details_car_oc_installment_date);
            _ocInstallmentDate.Click +=
                (sender, args) => OnSelectDateClicked(_ocInstallmentDate);

            _acExpiry = FindViewById<EditText>(Resource.Id.details_car_ac_expiry);
            _acExpiry.Click += 
                (sender, args) => OnSelectDateClicked(_acExpiry);

            _liftUdtExpiry = FindViewById<EditText>(Resource.Id.details_car_lift_udt_expiry);
            _liftUdtExpiry.Click += 
                (sender, args) => OnSelectDateClicked(_liftUdtExpiry);

            _tachoLegalizationExpiry = FindViewById<EditText>(Resource.Id.details_car_tacho_legalization_expiry);
            _tachoLegalizationExpiry.Click += 
                (sender, args) => OnSelectDateClicked(_tachoLegalizationExpiry);
        }

        private async void OnCreateCarClicked(object sender, EventArgs e)
        {
            var createCarRequest = new CreateCarRequest(
                Guid.NewGuid(),
               _name.Text,
               _registrationNumber.Text,
               DateParser.ParseDate(_technicalTermResearch.Text, DateFormat),
               DateParser.ParseDate(_ocExpiry.Text, DateFormat),
               DateParser.ParseDate(_ocInstallmentDate  .Text, DateFormat),
               DateParser.ParseDate(_acExpiry.Text, DateFormat),
               DateParser.ParseDate(_liftUdtExpiry.Text, DateFormat),
               DateParser.ParseDate(_tachoLegalizationExpiry.Text, DateFormat));

            await CreateCarClientFactory.Client.Create(createCarRequest);

            SetResult(Result.Ok);
            Finish();
        }
        
        private void OnSelectDateClicked(TextView clickedDateTextView)
        {
            var datePicker = new DatePickerFragment(
                DateParser.ParseDate(clickedDateTextView.Text, DateFormat));

            datePicker.Show(FragmentManager, DatePickerFragment.TAG);

            datePicker.OnDateSelected += (sender, selectedDate) =>
            {
                clickedDateTextView.Text = selectedDate.ToString(DateFormat);
            };            
        }
    }
}