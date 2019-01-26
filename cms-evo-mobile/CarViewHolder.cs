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

namespace Cms
{
    class CarViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView RegistrationNumber { get; private set; }

        public CarViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.carListItemName);
            RegistrationNumber = itemView.FindViewById<TextView>(Resource.Id.carListItemRegistrationNumber);
        }
    }
}