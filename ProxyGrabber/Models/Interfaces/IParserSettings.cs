namespace ProxyGrabber.Models.Interfaces {
    public interface IParserSettings {
        string BaseUrl { get; set; }
        
        string Prefix { get; set; }

        int FirstPage { get; set; }

        int LastPage { get; set; }
    }
}