namespace OOP.ContentContext
{
    public class Module : ContentBase
    {
        public int Order { get; set; }
        public string Title { get; set; } = null!;
        public IList<Lecture> Lectures { get; set; }

        public Module()
        {
            Lectures = new List<Lecture>();
        }

    }
}