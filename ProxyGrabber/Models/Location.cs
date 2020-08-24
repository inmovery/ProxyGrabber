using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGrabber.Models {
    public class Location {

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Timezone { get; set; }

        public string Provider { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Bitmap Icon { get; set; }

        public Location() { }

        public Location(string country) {
            this.Country = country;
        }

    }
}
