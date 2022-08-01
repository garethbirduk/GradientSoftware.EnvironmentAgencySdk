using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gradient.EnvironmentAgencySdk
{
    public class EnvironmentAgencyList<T>
        where T : IEnvironmentAgencyItem
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        public Meta Meta { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }

}
