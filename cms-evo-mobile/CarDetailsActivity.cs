﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cms.Http;
using Cms.Utils;
using Refractored.Fab;
using Utils;
using static Cms.Data.ListViewDataStore;

namespace Cms
{
    [Activity(Label = "CarDetailsActivity")]
    public class CarDetailsActivity : Activity
    {
        const string DateFormat = "dd.MM.yyyy";

        bool _isDataInitialized = false;
        TextView _technicalTermResearch;
        TextView _registrationNumberOcExpiry;
        TextView _registrationNumberAcExpiry;
        TextView _liftUdtExpiry;
        TextView _tachoLegalizationExpiry;
        FloatingActionButton _fabButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.car_details);

            var carId = Intent.GetExtra<Guid>("SelectedCarId");

            var client = new GetCarDetailsClient();
            var car = client.GetCarDetails(carId);

            _fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab_button);
            _fabButton.Visibility = ViewStates.Gone;

            var nameTextView = FindViewById<EditText>(Resource.Id.details_car_name);
            nameTextView.TextChanged += (obj, args) => DataChanged();
            nameTextView.Text = car.Name;

            var registrationNumberTextView = FindViewById<EditText>(Resource.Id.details_car_registration_number);
            registrationNumberTextView.TextChanged += (obj, args) => DataChanged();
            registrationNumberTextView.Text = car.RegistrationNumber;

            _technicalTermResearch = FindViewById<EditText>(Resource.Id.details_car_term_technical_research);
            _technicalTermResearch.Text = car.TermTechnicalResearch.ToString(DateFormat);
            _technicalTermResearch.TextChanged += (obj, args) => DataChanged();
            _technicalTermResearch.Click += TechnicalTermResearch_Click;

            _registrationNumberOcExpiry = FindViewById<EditText>(Resource.Id.details_car_oc_expiry);
            _registrationNumberOcExpiry.Text = car.OcExpiry.ToString(DateFormat);
            _registrationNumberOcExpiry.TextChanged += (obj, args) => DataChanged();
            _registrationNumberOcExpiry.Click += RegistrationNumberOcExpiry_Click;

            _registrationNumberAcExpiry = FindViewById<EditText>(Resource.Id.details_car_ac_expiry);
            _registrationNumberAcExpiry.Text = car.AcExpiry?.ToString(DateFormat);
            _registrationNumberAcExpiry.TextChanged += (obj, args) => DataChanged();
            _registrationNumberAcExpiry.Click += RegistrationNumberAcExpiry_Click;

            _liftUdtExpiry = FindViewById<EditText>(Resource.Id.details_car_lift_udt_expiry);
            _liftUdtExpiry.Text = car.LiftUdtExpiry?.ToString(DateFormat);
            _liftUdtExpiry.TextChanged += (obj, args) => DataChanged();
            _liftUdtExpiry.Click += LiftUdtExpiry_Click;

            _tachoLegalizationExpiry = FindViewById<EditText>(Resource.Id.details_car_tacho_legalization_expiry);
            _tachoLegalizationExpiry.Text = car.TachoLegalizationExpiry?.ToString(DateFormat);
            _tachoLegalizationExpiry.TextChanged += (obj, args) => DataChanged();
            _tachoLegalizationExpiry.Click += TachoLegalizationExpiry_Click;

            _isDataInitialized = true;
            
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

        private void DataChanged()
        {
            if (_isDataInitialized)
            {
                _fabButton.Visibility = ViewStates.Visible;
            }
        }
    }

    public class DetailsViewCarModel
    {
        public DetailsViewCarModel(Guid id,
            string name,
            string registrationNumber,
            DateTime termTechnicalResearch,
            DateTime ocExpiry,
            DateTime? acExpiry,
            DateTime? liftUdtExpiry,
            DateTime? tachoLegalizationExpiry)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }
        public DateTime TermTechnicalResearch { get; }
        public DateTime OcExpiry { get; }
        public DateTime? AcExpiry { get; }
        public DateTime? LiftUdtExpiry { get; }
        public DateTime? TachoLegalizationExpiry { get; }
    }
}