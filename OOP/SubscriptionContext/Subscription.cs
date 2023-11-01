using OOP.SharedContext;

namespace OOP.SubscriptionContext
{
    internal class Subscription : Base
    {
        public Plan Plan { get; set; }
        public User User { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive => EndDate != null || EndDate >= DateTime.Now;
        public Subscription(Plan plan, User user)
        {
            Plan = plan;
            User = user;
        }
    }
}