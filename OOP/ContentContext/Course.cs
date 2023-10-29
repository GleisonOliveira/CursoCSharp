using POO.ContentContext.Enums;

namespace OOP.ContentContext
{
    public class Course : Content
    {
        public string Tag { get; set; } = string.Empty;
        public IList<Module> Modules { get; set; }
        public int DurationInMinutes { get; set; } = 1;
        public EContentLevel Level { get; set; } = EContentLevel.Beginner;

        public Course(string title, string url, IList<Module> modules) : base(title, url)
        {
            Modules = modules;
            DurationInMinutes = modules.Sum(module => module.DurationInMinutes);
        }
    }
}