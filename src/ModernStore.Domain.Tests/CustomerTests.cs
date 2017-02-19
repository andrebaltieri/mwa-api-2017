using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("hsilvest", "123");
        private readonly Name name = new Name("Henrique", "Silvestre");
        private readonly Email email = new Email("henrique@gmail.com");
        public readonly Document document = new Document("76745148544");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            Name invalidName = new Name("", "Silvestre");
            var customer = new Customer(invalidName, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            Name invalidName = new Name("Henrique", "");
            var customer = new Customer(invalidName, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            Email invalidEmail = new Email("a");
            var customer = new Customer(name, invalidEmail, document, user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}