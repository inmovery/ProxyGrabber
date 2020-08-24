using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using ProxyGrabber.Models;

namespace ProxyGrabber.Storage {
    public class ResponseHelper {

        readonly string CheckUrl = "http://ip-api.com/json/";
        
        public Location GetProxyLocation(string ip, string port) {
            Location location = new Location();
            var ping = new Ping();
            var reply = ping.Send(ip); //SendAsync();
            if (reply.Status == IPStatus.Success) {
                JObject jObject = JObject.Parse(new WebClient().DownloadString(CheckUrl + ip));
                location.Country = (string) jObject["country"];
                location.Region = (string) jObject["regionName"];
                location.City = (string) jObject["city"];
                location.CountryCode = (string) jObject["countryCode"];
                // Additional data
                location.Timezone = (string) jObject["timezone"];
                location.Latitude = (double) jObject["lat"];
                location.Longitude = (double) jObject["isp"];
                
                // TODO: write result to a file related for working proxies
                
            }

            return location;
        }
    }
}