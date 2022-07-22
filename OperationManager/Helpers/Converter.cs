using System.IO;
using System.Threading.Tasks;

namespace OperationManager.Helpers
{
    public static class Converter
    {
        public static async Task<byte[]> ToByteArrayAsync(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                await input.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
