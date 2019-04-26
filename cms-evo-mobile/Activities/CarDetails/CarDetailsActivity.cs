using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CmsDroid.Activities.CarDetails.GetCarDetailsClient;
using CmsDroid.Activities.CarDetails.UpdateCarClient;
using CmsDroid.Utils;
using Refractored.Fab;

namespace CmsDroid.Activities.CarDetails
{
    [Activity(Label = "CarDetailsActivity")]
    public class CarDetailsActivity : Activity
    {
        const string DateFormat = "dd.MM.yyyy";

        bool _isDataInitialized = false;
        EditText _name;
        EditText _registrationNumber;
        TextView _technicalTermResearch;
        TextView _ocExpiry;
        TextView _acExpiry;
        TextView _liftUdtExpiry;
        TextView _tachoLegalizationExpiry;
        FloatingActionButton _updateCarButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.car_details);

            var carId = Intent.GetExtra<Guid>("SelectedCarId");

            var getCarDetailsClient = GetCarDetailsClientFactory.Get();
            var car = getCarDetailsClient.GetDetails(carId);

            _updateCarButton = FindViewById<FloatingActionButton>(Resource.Id.save_fab_button);
            _updateCarButton.Visibility = ViewStates.Gone;
            _updateCarButton.Click += OnUpdateCarClicked;

            _name = FindViewById<EditText>(Resource.Id.details_car_name);
            _name.TextChanged += (obj, args) => OnDataChanged();
            _name.Text = car.Name;

            _registrationNumber = FindViewById<EditText>(Resource.Id.details_car_registration_number);
            _registrationNumber.TextChanged += (obj, args) => OnDataChanged();
            _registrationNumber.Text = car.RegistrationNumber;

            _technicalTermResearch = FindViewById<EditText>(Resource.Id.details_car_term_technical_research);
            _technicalTermResearch.Text = car.TermTechnicalResearch?.ToString(DateFormat);
            _technicalTermResearch.TextChanged += (obj, args) => OnDataChanged();
            _technicalTermResearch.Click += TechnicalTermResearch_Click;

            _ocExpiry = FindViewById<EditText>(Resource.Id.details_car_oc_expiry);
            _ocExpiry.Text = car.OcExpiry?.ToString(DateFormat);
            _ocExpiry.TextChanged += (obj, args) => OnDataChanged();
            _ocExpiry.Click += RegistrationNumberOcExpiry_Click;

            _acExpiry = FindViewById<EditText>(Resource.Id.details_car_ac_expiry);
            _acExpiry.Text = car.AcExpiry?.ToString(DateFormat);
            _acExpiry.TextChanged += (obj, args) => OnDataChanged();
            _acExpiry.Click += RegistrationNumberAcExpiry_Click;

            _liftUdtExpiry = FindViewById<EditText>(Resource.Id.details_car_lift_udt_expiry);
            _liftUdtExpiry.Text = car.LiftUdtExpiry?.ToString(DateFormat);
            _liftUdtExpiry.TextChanged += (obj, args) => OnDataChanged();
            _liftUdtExpiry.Click += LiftUdtExpiry_Click;

            _tachoLegalizationExpiry = FindViewById<EditText>(Resource.Id.details_car_tacho_legalization_expiry);
            _tachoLegalizationExpiry.Text = car.TachoLegalizationExpiry?.ToString(DateFormat);
            _tachoLegalizationExpiry.TextChanged += (obj, args) => OnDataChanged();
            _tachoLegalizationExpiry.Click += TachoLegalizationExpiry_Click;

            _isDataInitialized = true;            
        }

        private async void OnUpdateCarClicked(object sender, EventArgs e)
        {
            var updateCarClient = UpdateCarClientFactory.Get();

            var request = new UpdateCarRequest(Intent.GetExtra<Guid>("SelectedCarId"),
                _name.Text,
                _registrationNumber.Text,
                DateParser.ParseDate(_technicalTermResearch.Text, DateFormat),
                DateParser.ParseDate(_ocExpiry.Text, DateFormat),
                DateParser.ParseDate(_acExpiry.Text, DateFormat),
                DateParser.ParseDate(_liftUdtExpiry.Text, DateFormat),
                DateParser.ParseDate(_tachoLegalizationExpiry.Text, DateFormat));

            await updateCarClient.Update(request);

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
                _acExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void RegistrationNumberOcExpiry_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _ocExpiry.Text = time.ToString(DateFormat);
            });
            datePickerFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void OnDataChanged()
        {
            if (_isDataInitialized)
            {
                ShowUpdateButton();
            }
        }

        private void ShowUpdateButton()
        {
            _updateCarButton.Visibility = ViewStates.Visible;
        }
    }
}