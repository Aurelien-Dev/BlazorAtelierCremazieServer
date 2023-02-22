namespace BlazorAtelierCremazieServer.Models
{
    public class InstaFeed
    {
        public InstaPost[] Data { get; set; }
    }

    public class InstaPost
    {
        public string id { get; set; }
        public string permalink { get; set; }
        public string caption { get; set; }
        public string thumbnail_url { get; set; }
        public string media_url { get; set; }
        public string media_type { get; set; }
    }
}