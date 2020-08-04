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

namespace CmsDroid.Activities.CarsList.GetCarsClient
{
    static class MemoryData
    {
        static public List<CarDto> Cars = new List<CarDto>
            {
                new CarDto(new Guid("65777ad6-87b7-4491-b827-42b4a819dcaa"),
                    "Renault",
                    "SLU GT44",
                    true),
                new CarDto(new Guid("60eed1e7-508f-4538-abd5-f63472be557e"),
                    "Ford C-MAX",
                    "SLU 52BF",
                    true),
                new CarDto(new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"),
                    "Ford Fusion",
                    "SLU 44AS",
                    false),
                new CarDto(new Guid("967641bf-9c2d-4f76-9e3b-a5f1ff9ede32"),
                    "Audi A6",
                    "SLU GG3Z",
                    false),
                new CarDto(new Guid("373f2bd6-7064-4af4-af54-ffc5731fb00b"),
                    "Renault",
                    "SLU P2SS",
                    false),
                new CarDto(new Guid("f904fb36-b102-483d-8fc0-b06efa15c6bc"),
                    "Renault",
                    "SLU VF56",
                    false),
                new CarDto(new Guid("6680752f-af8f-464e-9e8e-414041513616"),
                    "Renault",
                    "SLU BOI4",
                    false),
                new CarDto(new Guid("c90bc465-07a9-48b3-b108-a0024e4d9cf9"),
                    "Renault",
                    "SLU 0IC3",
                    false),
                new CarDto(new Guid("a19bbb3f-62b4-46e5-a389-4d8a3845600a"),
                    "Iveco",
                    "SLU 8UUH",
                    false),
                new CarDto(new Guid("3ad6b64e-8331-448e-a7a5-9fc9a3341836"),
                    "Renault Kangoo",
                    "SLU DW21",
                    false),
            };
    }
}