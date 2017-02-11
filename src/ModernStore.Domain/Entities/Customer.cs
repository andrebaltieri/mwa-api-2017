using System;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            BirthDate = null;
            Email = email;
            Document = document;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            AddNotifications(name.Notifications);

            Name = name;
            BirthDate = birthDate;
        }
    }
}
