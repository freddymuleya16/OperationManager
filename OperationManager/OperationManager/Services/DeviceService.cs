using Newtonsoft.Json;
using OperationManager.Helpers;
using OperationManager.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OperationManager.Services
{
    public class DeviceService
    {
        private readonly string _dataDir;

        public DeviceService(string dataDir)
        {
            _dataDir = dataDir;
        }

        public async Task<Device> GetDevicesByIdAsync(int deviceId)
        {
            return (await GetDevicesAsync()).FirstOrDefault(x => x.DeviceID == deviceId);
        }
        public async Task<List<Device>> GetDevicesAsync()
        {
            List<Device> items;
            using (StreamReader r = new StreamReader(_dataDir + "device.json"))
            {
                string json = await r.ReadToEndAsync();
                items = JsonConvert.DeserializeObject<List<Device>>(json);
            }
            return items;
        }
        public async Task<bool> DeleteDevicesByIdAsync(int deviceId)
        {
            var deviceList = await GetDevicesAsync();
            deviceList.Remove(deviceList.FirstOrDefault(x => x.DeviceID == deviceId));
            using (StreamWriter r = new StreamWriter(_dataDir + "device.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(deviceList));
            }
            return true;
        }
        public async Task<Device> SaveDevicesByIdAsync(Device device)
        {
            var deviceList = await GetDevicesAsync();
            if (deviceList is null)
            {
                deviceList = new List<Device>();
            }
            device.DeviceID = GenerateUnique.DeviceId(deviceList);
            deviceList.Add(device);
            using (StreamWriter r = new StreamWriter(_dataDir + "device.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(deviceList));
            }
            return device;
        }
        public async Task<Device> UpdateDevicesAsync(Device device)
        {
            var deviceList = await GetDevicesAsync();
            deviceList.Remove(deviceList.FirstOrDefault(x => x.DeviceID == device.DeviceID));
            deviceList.Add(device);
            using (StreamWriter r = new StreamWriter(_dataDir + "device.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(deviceList));
            }
            return device;
        }
    }
}
