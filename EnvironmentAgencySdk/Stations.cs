using System.Collections.Generic;

namespace Gradient.EnvironmentAgencySdk
{
    public class Stations : StationBase
    {
        public List<Measure> Measures { get; set; } = new List<Measure>();
    }
}
