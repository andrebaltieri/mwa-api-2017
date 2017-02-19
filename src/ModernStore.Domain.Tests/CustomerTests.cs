using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private CustomerBuilder builder;

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            builder = new CustomerBuilder();

            var customer = builder
                .WithName("", "Baltieri")
                .Build();
            builder.Build();

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            builder = new CustomerBuilder();

            var customer = builder
                .WithName("André","")
                .Build();
            builder.Build();

            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            builder = new CustomerBuilder();

            var customer = builder
                .WithEmail("a")
                .Build();
            builder.Build();

            Assert.IsFalse(customer.IsValid());
        }


    }

    internal class CustomerBuilder
    {
        private Name _aName;
        private Email _anEmail;
        private Document _aDocument;
        private User _anUser;


        public CustomerBuilder()
        {
            _aName = new Name("André", "Baltieri");
            _anEmail = new Email("andrebaltieri");
            _aDocument = new Document("46224227608");
            _anUser = new User("andrebaltieri", "123456", "123456");
        }


        public Customer Build() => new Customer(_aName, _anEmail, _aDocument, _anUser);


        public CustomerBuilder WithName(string first, string last)
        {
            _aName = new Name(first, last);
            return this;
        }

        public CustomerBuilder WithEmail(string email)
        {
            _anEmail = new Email(email);
            return this;
        }

        public CustomerBuilder WithDocument(string documenti)
        {
            _aDocument = new Document(documenti);
            return this;
        }

        public CustomerBuilder WithUser(string username, string password, string confirmPassword)
        {
            _anUser = new User(username, password, confirmPassword);
            return this;
        }


    }
}
