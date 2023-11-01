using OOP.NotificationContext;
using OOP.SharedContext;

namespace OOP.SubscriptionContext
{
    internal class User : Base
    {
        public User(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                AddNotification(new Notification(nameof(username), "The username can`t be empty or null"));

            if (string.IsNullOrEmpty(password))
                AddNotification(new Notification(nameof(password), "The password can`t be empty or null"));

            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}