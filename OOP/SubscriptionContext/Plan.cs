using OOP.NotificationContext;
using OOP.SharedContext;

namespace OOP.SubscriptionContext
{
    internal class Plan : Base
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Plan(string title, decimal price)
        {
            if (string.IsNullOrEmpty(title))
                AddNotification(new Notification("title", "The title can`t be empty or null"));

            Title = title;
            Price = price;
        }
    }
}