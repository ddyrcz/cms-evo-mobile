using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace CmsDroid.Utils
{
    static class FirebaseNotificationsInitializer
    {

        public static void InitializeFirebaseNotifications(Activity context)
        {
            if (IsPlayServicesAvailable(context))
            {
                CreateNotificationChannel(context);
                FirebaseMessaging.Instance.SubscribeToTopic("main");
            }
        }

        private static bool IsPlayServicesAvailable(Activity context)
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);
            return resultCode == ConnectionResult.Success;
        }

        private static void CreateNotificationChannel(Activity context)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel("cms_notification_channel_id",
                                                  "Main",
                                                  NotificationImportance.Default);

            var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}