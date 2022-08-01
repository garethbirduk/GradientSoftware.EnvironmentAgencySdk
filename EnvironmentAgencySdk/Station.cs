using Newtonsoft.Json;

namespace Gradient.EnvironmentAgencySdk
{
    public class Station : StationBase
    {
        [JsonProperty("measures")]
        public Measure Measures { get; set; }
    }
}
