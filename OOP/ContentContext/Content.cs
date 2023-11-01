using OOP.NotificationContext;
using OOP.SharedContext;

namespace OOP.ContentContext
{
    internal abstract class Content : Base
    {
        public Content(string title, string url)
        {
            if (string.IsNullOrEmpty(title))
                AddNotification(new Notification("title", "The title can`t be empty or null"));

            if (string.IsNullOrEmpty(url))
                AddNotification(new Notification("url", "The url can`t be empty or null"));

            Title = title;
            Url = url;
        }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}