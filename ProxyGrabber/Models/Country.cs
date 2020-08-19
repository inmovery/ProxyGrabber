using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGrabber.Models {
    public class Country {

        public string Name { get; set; }

        public Bitmap Icon { get; set; }

        public Country(string name, Bitmap icon) {
            this.Name = name;
            this.Icon = icon;
        }

        public Country() { }

    }
}
