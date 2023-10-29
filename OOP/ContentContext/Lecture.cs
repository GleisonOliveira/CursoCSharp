using POO.ContentContext.Enums;

namespace OOP.ContentContext
{
    public class Lecture : ContentBase
    {
        public int Order { get; set; }
        public string Title { get; set; } = null!;
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}