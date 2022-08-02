﻿using Newtonsoft.Json;

namespace Gradient.EnvironmentAgencySdk
{
    public class Measurement : IEnvironmentAgencyItem
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        public string DatumType { get; set; }
        public string Label { get; set; }
        public LatestReading LatestReading { get; set; }
        public string Notation { get; set; }
        public string Parameter { get; set; }
        public string ParameterName { get; set; }
        public int Period { get; set; }
        public string Qualifier { get; set; }
        public string Station { get; set; }
        public string StationReference { get; set; }
        public string Unit { get; set; }
        public string UnitName { get; set; }
        public string ValueType { get; set; }
    }



}
