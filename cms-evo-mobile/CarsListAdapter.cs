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
    class CarModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string RegistrationNumber { get; }

        public CarModel(Guid id, string name, string registrationNumber)
        {
            Id = id;
            Name = name;
            RegistrationNumber = registrationNumber;
        }
    }

    class CarsListAdapter : RecyclerView.Adapter
    {
        private readonly List<CarModel> _cars;

        public CarsListAdapter(List<CarModel> cars)
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
            var carViewHolder = new CarViewHolder(itemView);
            return carViewHolder;
        }
    }
}