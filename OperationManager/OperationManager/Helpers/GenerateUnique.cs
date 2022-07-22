using OperationManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationManager.Helpers
{
    public static class GenerateUnique
    {
        public static int DeviceId(List<Device> devices)
        {
            if (devices.Count == 0)
            {
                return 1;
            }
            return devices.Select(x => x.DeviceID).ToList().Max() + 1;
        }
        public static int OperationId(List<Operation> operations)
        {
            if (operations.Count == 0)
            {
                return 1;
            }
            return operations.Select(x => x.OperationID).ToList().Max() + 1;
        }
    }
}
