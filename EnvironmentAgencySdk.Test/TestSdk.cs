using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gradient.EnvironmentAgencySdk.Test
{
    [TestClass]
    public class TestSdk
    {
        [TestMethod]
        public async Task TestGetStations()
        {
            var ea = new Sdk();
            var stations = await ea.GetStations();
            Assert.IsNotNull(stations);
            Assert.IsTrue(stations.Count > 1);
        }

        [DataTestMethod]
        [DataRow("")]
        public async Task TestGetStationsByLabelMissing(string label)
        {
            var ea = new Sdk();
            var stations = await ea.GetStations(label: label);
            Assert.IsNotNull(stations);
            Assert.IsTrue(stations.Count > 1);
        }

        [DataTestMethod]
        [DataRow("xxxxxx", 0)]
        [DataRow("CALNE PRINCE CHARLES DRIVE", 1)]
        public async Task TestGetStationsByLabel(string label, int expected)
        {
            var ea = new Sdk();
            var stations = await ea.GetStations(label: label);
            Assert.IsNotNull(stations);
            Assert.AreEqual(expected, stations.Count);
            if (expected > 0)
                Assert.AreEqual(label, stations[0].Label);
        }

        [DataTestMethod]
        [DataRow("xxxx", 0)]
        [DataRow("0", 1)]
        [DataRow("1029TH", 1)]
        public async Task TestGetStationsByStationReference(string stationReference, int expected)
        {
            var ea = new Sdk();
            var stations = await ea.GetStations(stationReference: stationReference);
            Assert.IsNotNull(stations);
            Assert.AreEqual(expected, stations.Count);
            if (expected>0)
                Assert.AreEqual(stationReference, stations[0].StationReference);
        }

        [DataTestMethod]
        [DataRow("0")]
        [DataRow("52203")]
        public async Task TestGetStation_Ok(string stationReference)
        {
            var ea = new Sdk();
            var station = await ea.GetStation(stationReference);
            Assert.IsNotNull(station);
            Assert.AreEqual(stationReference, station.StationReference);
        }

        [DataTestMethod]
        [DataRow("xxx")]
        [DataRow("-99")]
        public async Task TestGetStation_Fail (string stationReference)
        {
            var ea = new Sdk();
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => ea.GetStation(stationReference));
        }

    }
}