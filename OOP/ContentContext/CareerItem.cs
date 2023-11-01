using OOP.NotificationContext;
using OOP.SharedContext;

namespace OOP.ContentContext
{
    internal class CareerItem : Base
    {
        public CareerItem(string title, Course course, string? description = null, int ordem = 1)
        {
            if (string.IsNullOrEmpty(title))
                AddNotification(new Notification(nameof(title), "The title can`t be empty or null"));

            Ordem = ordem;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Ordem { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Course Course { get; set; }
    }
}