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

        public Country Country { get; set; }

        public Anonymity Anonymity { get; set; }

        public int Speed { get; set; }

        public Proxy(string ip_address, string port, ProxyType type, Country country, Anonymity anonymity, int speed) {
            this.Ip = ip_address;
            this.Port = port;
            this.Type = type;
            this.Country = country;
            this.Anonymity = anonymity;
            this.Speed = speed;
        }

        public Proxy() { }

    }
}
