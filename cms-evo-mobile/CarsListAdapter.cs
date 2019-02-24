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
using static Cms.Data.ListViewDataStore;

namespace Cms
{
   

    class CarsListAdapter : RecyclerView.Adapter
    {
        private readonly List<ListViewCarModel> _cars;

        public event EventHandler<Guid> CarClicked;

        public CarsListAdapter(List<ListViewCarModel> cars)
            : base()
        {
            _cars = cars;
        }

        public override int ItemCount => _cars.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var carViewHolder = holder as CarViewHolder;

            var car = _cars[position];

            carViewHolder.Name.Text = car.Name;
            carViewHolder.RegistrationNumber.Text = car.RegistrationNumber;
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