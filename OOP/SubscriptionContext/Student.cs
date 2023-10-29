using OOP.SharedContext;

namespace OOP.SubscriptionContext
{
    public class Student : Base
    {
        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Subscription> Subscriptions { get; set; }
        public bool IsPremium => Subscriptions.Any(x => x.IsActive);
        
        public Student(User user, string name, string email, List<Subscription>? subscriptions)
        {
            User = user;
            Email = email;
            Name = name;

            if (subscriptions == null)
            {
                Subscriptions = new List<Subscription>();

                return;
            }

            Subscriptions = subscriptions;
        }
    }
}