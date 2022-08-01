using Newtonsoft.Json;

namespace Gradient.EnvironmentAgencySdk
{
    public class EnvironmentAgencyItem<T>
        where T : IEnvironmentAgencyItem
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        public Meta Meta { get; set; }
        [JsonProperty("items")]
        public T Item { get; set; }
    }

}
