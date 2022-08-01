using Newtonsoft.Json;
using System.IO;

namespace Gradient.EnvironmentAgencySdk
{
    public static class JsonHelpers
    {
        public static T CreateFromJsonString<T>(this string json)
        {
            T data;
            using (MemoryStream stream = new(System.Text.Encoding.Default.GetBytes(json)))
            {
                data = JsonConvert.DeserializeObject<T>(json);
            }
            return data;
        }
    }
}