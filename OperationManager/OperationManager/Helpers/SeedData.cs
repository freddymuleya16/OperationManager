using Newtonsoft.Json;
using OperationManager.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OperationManager.Helpers
{
    public static class SeedData
    {
        public static async Task SeedJsonAsync()
        {
            var operationList = new List<Operation>()
            {
                new Operation()
                {
                    OperationID =1,
                    OrderInWhichToPerform =1,
                    Name = "Mobisel",
                    Device = new Device{
                        DeviceID = 1,
                        Name = "DSLR",
                        DeviceType = DeviceType.Camera,
                    }

                },
                new Operation()
                {
                    OperationID =2,
                    OrderInWhichToPerform =2,
                    Name = "Mobisel",
                    Device = new Device{
                        DeviceID = 2,
                        Name = "DSLR",
                        DeviceType = DeviceType.Camera,
                    }

                },
                new Operation()
                {
                    OperationID =3,
                    OrderInWhichToPerform =3,
                    Name = "Mobisel",
                    Device = new Device{
                        DeviceID = 3,
                        Name = "DSLR",
                        DeviceType = DeviceType.Camera,
                    }

                },
            };
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            using (StreamWriter r = new StreamWriter(startupPath + "\\Data\\operations.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(operationList));
            }
        }
    }
}
