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
using Newtonsoft.Json;

namespace cms_evo_mobile.Utils
{
    public static class IntentExtension
    {
        public static Intent PutExtra<TExtra>(this Intent intent, string name, TExtra extra)
        {
            var json = JsonConvert.SerializeObject(extra);
            intent.PutExtra(name, json);
            return intent;
        }

        public static TExtra GetExtra<TExtra>(this Intent intent, string name)
        {
            var json = intent.GetStringExtra(name);
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(TExtra);
            }

            return JsonConvert.DeserializeObject<TExtra>(json);
        }
    }
}