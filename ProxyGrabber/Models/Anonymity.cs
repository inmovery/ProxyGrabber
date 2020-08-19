using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGrabber.Models {
    public class Anonymity {

        public string State { get; set; }

        public Anonymity(string state) {
            this.State = state;
        }

        public Anonymity() { }

    }
}
