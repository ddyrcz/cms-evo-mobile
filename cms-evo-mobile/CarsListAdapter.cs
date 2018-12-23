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

    class CarsListAdapter : BaseAdapter<CarModel>
    {
        private readonly Activity _context;
        private readonly List<CarModel> _cars;

        public CarsListAdapter(Activity context, List<CarModel> cars)
            : base()
        {
            _context = context;
            _cars = cars;
        }

        public override CarModel this[int position] => _cars[position];

        public override int Count => _cars.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _cars[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = _context.LayoutInflater.Inflate(Resource.Layout.car_list_item, null);
            view.FindViewById<TextView>(Resource.Id.list_item_car_name).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.list_item_car_registration_number).Text = item.RegistrationNumber;
            return view;
        }
    }
}