using POO.ContentContext;

namespace OOP.ContentContext
{
    public class Career : Content
    {
        public int TotalCourses => Items.Count;
        public IList<CareerItem> Items { get; set; }

        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }
    }
}