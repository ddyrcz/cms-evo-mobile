using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.JobDispatcher;

namespace CmsDroid.Services
{
    [Service(Name = "com.xamarin.fjdtestapp.DemoJob")]
    [IntentFilter(new[] { FirebaseJobServiceIntent.Action })]
    public class DemoJob : JobService
    {
        static readonly string TAG = "X:DemoService";

        public override bool OnStartJob(IJobParameters jobParameters)
        {
            Task.Run(() =>
            {
                // Work is happening asynchronously (code omitted)

            });

            // Return true because of the asynchronous work
            return true;
        }

        public override bool OnStopJob(IJobParameters jobParameters)
        {
            // nothing to do.
            return false;
        }
    }
}