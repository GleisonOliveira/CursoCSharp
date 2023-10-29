using OOP.SharedContext;

namespace OOP.ContentContext
{
    public class Module : Base
    {
        public int Order { get; set; } = 1;
        public string Title { get; set; } = null!;
        public IList<Lecture> Lectures { get; set; }

        public int DurationInMinutes => Lectures.Sum(lecture => lecture.DurationInMinutes);

        public Module(string title)
        {
            Title = title;
            Lectures = new List<Lecture>();
        }

        public Module(string title, IList<Lecture> lectures, int order = 1)
        {
            Title = title;
            Order = order;
            Lectures = lectures;
        }
    }
}