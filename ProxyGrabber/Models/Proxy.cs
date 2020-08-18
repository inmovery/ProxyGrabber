using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyGrabber.Models {
    public class Proxy {

        public string Ip { get; set; }

        public string Port { get; set; }

        public ProxyType Type { get; set; } 

        public Proxy() {}

        public Proxy(string ip_address, string port, ProxyType type) {
            this.Ip = ip_address;
            this.Port = port;
            this.Type = type;
        }

    }
}
