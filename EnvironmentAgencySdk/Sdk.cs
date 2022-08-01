using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gradient.EnvironmentAgencySdk
{

    public class Sdk
    {
        public const string BaseUrl = "http://environment.data.gov.uk/";

        public string FloodMonitoring = "flood-monitoring/id/";
        public Sdk()
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public HttpClient HttpClient { get; private set; }

        public async Task<List<Stations>> GetStations(
            string label = "",
            string stationReference = "",
            string RLOIid = "",
            string search = "",
            double x = 0.0,
            double y = 0.0,
            int distance = 0
            )
        {
            var url = $"{FloodMonitoring}/stations";
            var parameters = new List<string>();
            if (!string.IsNullOrWhiteSpace(label)) parameters.Add($"label={label}");
            if (!string.IsNullOrWhiteSpace(stationReference)) parameters.Add($"stationReference={stationReference}");
            if (!string.IsNullOrWhiteSpace(RLOIid)) parameters.Add($"RLOIid={RLOIid}");
            if (!string.IsNullOrWhiteSpace(label)) parameters.Add($"search={search}");

            if (x > 0 && y > 0 & distance > 0)
            {
                parameters.Add($"x={x}");
                parameters.Add($"x={y}");
                parameters.Add($"x={distance}");
            }

            url = $"{url}?{string.Join("&", parameters)}";
            var json = await Get(url);
            return JsonHelpers.CreateFromJsonString<EnvironmentAgencyList<Stations>>(json).Items;
        }

        private async Task<string> Get(string fullUrl)
        {
            var response = await HttpClient.GetAsync(fullUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<Station> GetStation(string stationReference)
        {
            var url = $"{FloodMonitoring}/stations/{stationReference}";
            var json = await Get(url);
            return JsonHelpers.CreateFromJsonString<EnvironmentAgencyItem<Station>>(json).Item;
        }
    }

    public class EaResponse<T>
    {
        public string Context { get; set; } = "";

        public Meta Meta { get; set; } = new Meta();
        public List<T> Items { get; set; } = new List<T>();
    }
}