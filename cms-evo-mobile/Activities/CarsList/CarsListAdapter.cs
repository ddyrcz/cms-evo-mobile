using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CmsDroid.Activities.CarsList;

namespace CmsDroid.Activities.CarsList
{
    class CarsListAdapter : RecyclerView.Adapter
    {
        private List<CarsListViewModel> _cars;

        public event EventHandler<Guid> CarClicked;

        public CarsListAdapter(List<CarsListViewModel> cars)
            : base()
        {
            _cars = cars;
        }

        public override int ItemCount => _cars.Count;

        public void UpdateItems(List<CarsListViewModel> cars)
        {
            _cars = cars;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var carViewHolder = holder as CarViewHolder;

            var car = _cars[position];

            carViewHolder.Name.Text = car.Name;
            carViewHolder.RegistrationNumber.Text = car.RegistrationNumber;

            if (car.ApproachingExpiration)
            {
                SetWarningColorsToCarItem(carViewHolder);
            }
            else
            {
                SetDefaultColorsToCarItem(carViewHolder);
            }
        }

        private static void SetDefaultColorsToCarItem(CarViewHolder carViewHolder)
        {
            carViewHolder.CardView.SetCardBackgroundColor(Color.White);
            carViewHolder.Name.SetTextColor(Color.ParseColor("#777777"));
            carViewHolder.RegistrationNumber.SetTextColor(Color.ParseColor("#777777"));
        }

        private static void SetWarningColorsToCarItem(CarViewHolder carViewHolder)
        {
            carViewHolder.CardView.SetCardBackgroundColor(Color.ParseColor("#f98989"));
            carViewHolder.Name.SetTextColor(Color.White);
            carViewHolder.RegistrationNumber.SetTextColor(Color.White);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.car_list_item, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            var carViewHolder = new CarViewHolder(itemView, CarListItemClicked);
            return carViewHolder;
        }

        public void CarListItemClicked(int position)
        {
            var carClicked = _cars[position];

            CarClicked?.Invoke(this, carClicked.Id);
        }
    }
}