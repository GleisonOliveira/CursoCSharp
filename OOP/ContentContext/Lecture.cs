using OOP.SharedContext;
using POO.ContentContext.Enums;

namespace OOP.ContentContext
{
    public class Lecture : Base
    {
        public int Order { get; set; } = 1;
        public string Title { get; set; }
        public int DurationInMinutes { get; set; } = 1;
        public EContentLevel Level { get; set; } = EContentLevel.Beginner;

        public Lecture(string title)
        {
            Title = title;
        }

        public Lecture(string title, EContentLevel level, int order, int durationInMinutes)
        {
            Title = title;
            Level = level;
            Order = order;
            DurationInMinutes = durationInMinutes;
        }
    }
}