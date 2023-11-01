namespace OOP.ContentContext
{
    internal class Career : Content
    {
        public int TotalCourses => Careers.Count;
        public IList<CareerItem> Careers { get; set; }

        public int DurationInMinutes => Careers.Sum(x => x.Course.DurationInMinutes);

        public Career(string title, string url, IList<CareerItem> careers) : base(title, url)
        {
            Careers = careers;
        }
    }
}