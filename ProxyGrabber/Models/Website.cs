using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGrabber.Models {
    public class Website {

        public string Url { get; set; }

        public Website(string url) {
            this.Url = url;
        }

        public override string ToString() {
            return Url;
        }

    }
}
