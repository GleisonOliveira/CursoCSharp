using OOP.SharedContext;

namespace OOP.ContentContext
{
    internal class Module : Base
    {
        public int Order { get; set; } = 1;
        public string Title { get; set; } = null!;
        public IEnumerable<Lecture> Lectures { get; set; }

        public int DurationInMinutes => Lectures.Sum(lecture => lecture.DurationInMinutes);

        public Module(string title)
        {
            Title = title;
            Lectures = new List<Lecture>();
        }

        public Module(string title, IEnumerable<Lecture> lectures, int order = 1)
        {
            Title = title;
            Order = order;
            Lectures = lectures;
        }
    }
}