using Newtonsoft.Json;

namespace Gradient.EnvironmentAgencySdk
{
    public class StationBase : IEnvironmentAgencyItem
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        public string RLOIid { get; set; }
        public string CatchmentName { get; set; }
        public string DateOpened { get; set; }
        public int Easting { get; set; }
        public string Label { get; set; }
        public double  Lat { get; set; }

        [JsonProperty("_long")]
        public double  Long { get; set; }
        public int Northing { get; set; }
        public string Notation { get; set; }
        public string RiverName { get; set; }
        public string StageScale { get; set; }
        public string StationReference { get; set; }
        public string Status { get; set; }
        public string Town { get; set; }
        public string WiskiID { get; set; }
        public double DatumOffset { get; set; }
        public string GridReference { get; set; }
        public string DownstageScale { get; set; }
    }
}
