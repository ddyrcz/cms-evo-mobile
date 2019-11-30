
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
using CmsDroid.Services;
using CmsDroid.Utils;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Refractored.Fab;

namespace CmsDroid.Activities.CarsList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class CarsListActivity : Activity
    {
        RecyclerView _recyclerView;
        CarsListAdapter _carsAdapter;
        List<CarsListViewModel> _cars;

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

            var startNotificationServiceFabButton = FindViewById<FloatingActionButton>(Resource.Id.start_notification_service);
            startNotificationServiceFabButton.AttachToRecyclerView(_recyclerView);
            startNotificationServiceFabButton.Click += StartNotificationServiceFabButton_Click;


            CreateNotificationChannel();

        }

        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "location_notification";
        internal static readonly string COUNT_KEY = "count";

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channelName = "Channel name";
            var channelDescription = "Channel description";
            var channel = new NotificationChannel(CHANNEL_ID, channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private void StartNotificationServiceFabButton_Click(object sender, EventArgs e)
        {
            //var toast = Toast.MakeText(this, "Starting notification service...",  ToastLength.Short);
            //toast.Show();

            //this.StartForegroundServiceCompat<DemoService>();

            // Set up an intent so that tapping the notifications returns to this app:
            Intent intent = new Intent(this, typeof(CarsListActivity));

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);



            // Build the notification:
            var builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetContentIntent(pendingIntent)          
                .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                          .SetContentTitle("Button Clicked") // Set the title
                          .SetSmallIcon(Resource.Drawable.notification_icon_background) // This is the icon to display
                          .SetContentText($"Message text."); // the message to display.

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());

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