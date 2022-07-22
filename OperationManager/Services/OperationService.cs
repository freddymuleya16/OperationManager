using OperationManager.Helpers;
using OperationManager.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OperationManager.Services
{
    public class OperationService
    {
        private readonly string _dataDir;

        public OperationService(string dataDir)
        {
            _dataDir = dataDir;
        }

        public async Task<Operation> GetOperationsByIdAsync(int operationId)
        {
            return (await GetOperationsAsync()).FirstOrDefault(x => x.OperationID == operationId);
        }
        public async Task<List<Operation>> GetOperationsAsync()
        {
            List<Operation> items;
            using (StreamReader r = new StreamReader(_dataDir + "oparations.json"))
            {
                string json = await r.ReadToEndAsync();
                items = JsonConvert.DeserializeObject<List<Operation>>(json);
            }
            return items;
        }
        public async Task<bool> DeleteOperationsByIdAsync(int operationId)
        {
            var operationList = await GetOperationsAsync();
            operationList.Remove(operationList.FirstOrDefault(x => x.OperationID == operationId));
            using (StreamWriter r = new StreamWriter(_dataDir + "oparations.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(operationList));
            }
            return true;
        }
        public async Task<Operation> SaveOperationsByIdAsync(Operation operation)
        {
            var operationList = await GetOperationsAsync();
            if (operationList is null)
            {
                operationList = new List<Operation>();
            }
            operation.OperationID = GenerateUnique.OperationId(operationList);
            operationList.Add(operation);
            using (StreamWriter r = new StreamWriter(_dataDir + "oparations.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(operationList));
            }
            return operation;
        }
        public async Task<Operation> UpdateOperationsAsync(Operation operation)
        {
            var operationList = await GetOperationsAsync();
            operationList.Remove(operationList.FirstOrDefault(x => x.OperationID == operation.OperationID));
            operationList.Add(operation);
            using (StreamWriter r = new StreamWriter(_dataDir + "oparations.json"))
            {
                await r.WriteLineAsync(JsonConvert.SerializeObject(operationList));
            }
            return operation;
        }
    }
}
