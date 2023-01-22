namespace BlazorAtelierCremazieServer.Models
{

    public class Rootobject
    {
        public Datas media { get; set; }
        public string id { get; set; }
    }

    public class Datas
    {
        public Media[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Media
    {
        public Media()
        {

        }

        public string id { get; set; }
        public string media_type { get; set; }
        public string media_url { get; set; }
        public Owner owner { get; set; }
        public DateTime timestamp { get; set; }
        public int like_count { get; set; }
        public string permalink { get; set; }
        public string caption { get; set; }
        public string thumbnail_url { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
    }

}
