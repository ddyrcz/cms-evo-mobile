
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
using CmsDroid.Activities.CarDetails;
using CmsDroid.Activities.CarsList.DeleteCarClient;
using CmsDroid.Activities.CarsList.GetCarsClient;
using CmsDroid.Utils;
using Refractored.Fab;

namespace CmsDroid.Activities.CarsList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        RecyclerView _recyclerView;
        CarsListAdapter _carsAdapter;
        List<CarDto> _cars;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.cars_list);

            GetCars();

            _carsAdapter = new CarsListAdapter(_cars);
            _carsAdapter.CarClicked += CarClicked;
            _carsAdapter.CarLongClicked += CarLongClicked;

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.carsListRecyclerView);

            _recyclerView.SetAdapter(_carsAdapter);

            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var fab = FindViewById<FloatingActionButton>(Resource.Id.add_car_button);
            fab.AttachToRecyclerView(_recyclerView);
            fab.Click += AddCarClicked;

            FirebaseNotificationsInitializer.InitializeFirebaseNotifications(this);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            var completedRequest = (Request)requestCode;

            if (resultCode == Result.Ok)
            {
                HandleRequestCompletion(completedRequest);
            }
        }

        private void HandleRequestCompletion(Request completedRequest)
        {
            switch (completedRequest)
            {
                case Request.UpdateCarRequest:
                    RefreshCarsList();
                    break;
                case Request.CreateCarRequest:
                    RefreshCarsList();
                    break;
                default:
                    break;
            }
        }

        private void GetCars()
        {
            var cars = GetCarsClientFactory.Client.GetCars();

            _cars = cars;
        }

        private void RefreshCarsList()
        {
            GetCars();

            _carsAdapter?.UpdateItems(_cars);
            _carsAdapter?.NotifyDataSetChanged();
        }

        private void AddCarClicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateCarActivity));
            StartActivityForResult(intent, (int)Request.CreateCarRequest);
        }

        private void CarClicked(object sender, Guid carId)
        {
            var intent = new Intent(this, typeof(CarDetailsActivity));
            intent.PutExtra("SelectedCarId", carId);
            StartActivityForResult(intent, (int)Request.UpdateCarRequest);
        }

        private void CarLongClicked(object sender, Guid pressedCarId)
        {
            var builder = new AlertDialog.Builder(this);

            builder.SetMessage("Czy napewno usunąć pojazd?");
            builder.SetPositiveButton("Tak", (s, args) =>
            {
                DeleteCar(pressedCarId);
            });
            builder.SetNegativeButton("Nie", (s, args) => { });

            builder.Create().Show();
        }

        private async void DeleteCar(Guid carId)
        {
            await DeleteCarClientFactory.Client.Delete(carId);
            RefreshCarsList();
        }
    }

    enum Request
    {
        UpdateCarRequest,
        CreateCarRequest
    }
}