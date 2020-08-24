namespace ProxyGrabber.Models {
    public class Proxy {

        public string Ip { get; set; }

        public string Port { get; set; }

        public ProxyType Type { get; set; } 

        public Location Location { get; set; }

        public Anonymity Anonymity { get; set; }

        public int Speed { get; set; }

        public Proxy(string ipAddress, string port, ProxyType type, Location location, Anonymity anonymity, int speed) {
            this.Ip = ipAddress;
            this.Port = port;
            this.Type = type;
            this.Location = location;
            this.Anonymity = anonymity;
            this.Speed = speed;
        }

        public Proxy() { }

    }
}
