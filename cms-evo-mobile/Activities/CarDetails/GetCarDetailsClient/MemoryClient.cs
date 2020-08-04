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

namespace CmsDroid.Activities.CarDetails.GetCarDetailsClient
{
    class MemoryClient : IGetCarDetailsClient
    {
        public CarDto GetDetails(Guid carId)
        {
            return MemoryData.Details[carId];
        }
    }

    static class MemoryData
    {
        public static Dictionary<Guid, CarDto> Details =
            new Dictionary<Guid, CarDto>()
            {
                {
                        new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"),
                        new CarDto(
                            new Guid("b429bd7c-8c84-4a13-bec6-309eb41aee28"),
                            "Ford Fusion",
                            "SLU 44AS",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("60eed1e7-508f-4538-abd5-f63472be557e"),
                        new CarDto(
                            new Guid("60eed1e7-508f-4538-abd5-f63472be557e"),
                            "Ford C-MAX",
                            "SLU 52BF",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("967641bf-9c2d-4f76-9e3b-a5f1ff9ede32"),
                        new CarDto(
                            new Guid("967641bf-9c2d-4f76-9e3b-a5f1ff9ede32"),
                           "Audi A6",
                           "SLU GG3Z",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("65777ad6-87b7-4491-b827-42b4a819dcaa"),
                        new CarDto(
                            new Guid("65777ad6-87b7-4491-b827-42b4a819dcaa"),
                           "Renault",
                           "SLU GT44",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 03, 05),
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("373f2bd6-7064-4af4-af54-ffc5731fb00b"),
                        new CarDto(
                            new Guid("373f2bd6-7064-4af4-af54-ffc5731fb00b"),
                           "Renault",
                           "SLU P2SS",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 11, 07),
                            new DateTime(2019, 04, 21),
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("f904fb36-b102-483d-8fc0-b06efa15c6bc"),
                        new CarDto(
                            new Guid("f904fb36-b102-483d-8fc0-b06efa15c6bc"),
                            "Renault",
                            "SLU VF56",
                            new DateTime(2019, 06, 05),
                            new DateTime(2020, 02, 25),
                            new DateTime(2019, 11, 01),
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("6680752f-af8f-464e-9e8e-414041513616"),
                        new CarDto(
                            new Guid("6680752f-af8f-464e-9e8e-414041513616"),
                            "Renault",
                            "SLU BOI4",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("c90bc465-07a9-48b3-b108-a0024e4d9cf9"),
                        new CarDto(
                            new Guid("c90bc465-07a9-48b3-b108-a0024e4d9cf9"),
                            "Renault",
                            "SLU 0IC3",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                        new Guid("a19bbb3f-62b4-46e5-a389-4d8a3845600a"),
                        new CarDto(
                            new Guid("a19bbb3f-62b4-46e5-a389-4d8a3845600a"),
                            "Iveco",
                            "SLU 8UUH",
                            new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
                {
                    new Guid("3ad6b64e-8331-448e-a7a5-9fc9a3341836"),
                    new CarDto(
                        new Guid("3ad6b64e-8331-448e-a7a5-9fc9a3341836"),
                        "Renault Kangoo",
                        "SLU DW21",
                        new DateTime(2019, 06, 05),
                            new DateTime(2019, 10, 05),
                            null,
                            new DateTime(2019, 04, 22),
                            new DateTime(2019, 10, 05),
                            new DateTime(2019, 04, 22))
                },
            };
    }
}