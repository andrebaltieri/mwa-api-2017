using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User _user = new User("andrebaltieri", "andrebaltieri", "andrebaltieri");
        private readonly Name _name = new Name("André", "Baltieri");
        private readonly Email _email = new Email("andrebaltieri@gmail.com");
        private readonly Document _document = new Document("35747822179");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var name = new Name("", "Baltieri");
            var customer = new Customer(name, _email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var name = new Name("André", "");
            var customer = new Customer(name, _email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var email = new Email("andre");
            var customer = new Customer(_name, email, _document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidDocumentShouldReturnANotification()
        {
            var document = new Document("35747822178");
            var customer = new Customer(_name, _email, document, _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidConfirmPasswordShouldReturnANotification()
        {
            var user = new User("andrebaltieri", "andrebaltieri", "andrebaltiere");
            var customer = new Customer(_name, _email, _document, user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
