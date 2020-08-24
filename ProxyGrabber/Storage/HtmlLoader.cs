using System.Net.Http;
using System.Threading.Tasks;
using ProxyGrabber.Models.Interfaces;

namespace ProxyGrabber.Storage {
    public class HtmlLoader {
        
        readonly HttpClient client;
        readonly string url;
        
        public HtmlLoader(IParserSettings settings) {
            client = new HttpClient();
            url = settings.BaseUrl;
        }
        
        public async Task<string> GetSourceByPageIdAsync(int id) {
            var currentUrl = url;
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
        
    }
}