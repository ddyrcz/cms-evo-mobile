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

namespace CmsDroid.Activities.CarsList
{
    class CarViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView RegistrationNumber { get; private set; }
        public CardView CardView { get; private set; }

        public CarViewHolder(View itemView,
            Action<int> clickListener,
            Action<int> longClickListener) : base(itemView)
        {   
            Name = itemView.FindViewById<TextView>(Resource.Id.carListItemName);
            RegistrationNumber = itemView.FindViewById<TextView>(Resource.Id.carListItemRegistrationNumber);
            CardView = itemView.FindViewById<CardView>(Resource.Id.car_list_item_card_view);

            itemView.Click += (sender, e) => clickListener(LayoutPosition);
            itemView.LongClick += (sender, e) => longClickListener(LayoutPosition);
        }
    }
}