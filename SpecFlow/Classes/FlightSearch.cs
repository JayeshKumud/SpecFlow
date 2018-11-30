using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Classes
{
    public class FlightSearch
    {
        public string From { get; set; }
        public string To { get; set; }
        public int FromOffSet { get; set; }
        public int ToOffSet { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public string Class { get; set; }
    }
}
