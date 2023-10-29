using System.Diagnostics.CodeAnalysis;
using OOP.ContentContext;
using OOP.NotificationContext;

namespace POO.ContentContext
{
    public class CareerItem : ContentBase
    {
        public CareerItem(int ordem, string title, string description, Course course)
        {
            if (string.IsNullOrEmpty(title))
                AddNotification(new Notification(nameof(title), "The title can`t be empty or null"));

            if (string.IsNullOrEmpty(description))
                AddNotification(new Notification(nameof(description), "The description can`t be empty or null"));

            Ordem = ordem;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Ordem { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}