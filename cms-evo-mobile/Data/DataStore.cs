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

namespace Cms.Data
{
    static class ListViewDataStore
    {
        public class ListViewCarModel
        {
            public Guid Id { get; }
            public string Name { get; }
            public string RegistrationNumber { get; }

            public ListViewCarModel(Guid id, string name, string registrationNumber)
            {
                Id = id;
                Name = name;
                RegistrationNumber = registrationNumber;
            }
        }

        static public List<ListViewCarModel> Cars = new List<ListViewCarModel>
            {
                new ListViewCarModel(new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"), "Ford Fusion", "SLU 44AS"),
                new ListViewCarModel(Guid.NewGuid(), "Ford C-MAX", "SLU 52BF"),
                new ListViewCarModel(Guid.NewGuid(), "Audi A6", "SLU GG3Z"),
                new ListViewCarModel(Guid.NewGuid(), "Renault", "SLU GT44"),
                new ListViewCarModel(Guid.NewGuid(), "Renault", "SLU P2SS"),
                new ListViewCarModel(Guid.NewGuid(), "Renault", "SLU VF56"),
                new ListViewCarModel(Guid.NewGuid(), "Renault", "SLU BOI4"),
                new ListViewCarModel(Guid.NewGuid(), "Renault", "SLU 0IC3"),
                new ListViewCarModel(Guid.NewGuid(), "Iveco", "SLU 8UUH"),
                new ListViewCarModel(Guid.NewGuid(), "Renault Kangoo", "SLU DW21"),
            };
    }

    static class DetailsViewDataStore
    {
        public class DetailsViewCarModel
        {
            public DetailsViewCarModel(Guid id,
                string name,
                string registrationNumber,
                DateTime ocExpiry,
                DateTime acExpiry)
            {
                Id = id;
                Name = name;
                RegistrationNumber = registrationNumber;
                OcExpiry = ocExpiry;
                AcExpiry = acExpiry;
            }

            public Guid Id { get; }
            public string Name { get; }
            public string RegistrationNumber { get; }
            public DateTime OcExpiry { get; }
            public DateTime AcExpiry { get; }


        }

        public static Dictionary<Guid, DetailsViewCarModel> Details =
            new Dictionary<Guid, DetailsViewCarModel>()
            {
                { new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"),
                new DetailsViewCarModel(new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"),
                    "Ford Fusion", "SLU 44AS", new DateTime(2018, 10, 05), new DateTime(2018, 04, 22))}
            };
    }

}