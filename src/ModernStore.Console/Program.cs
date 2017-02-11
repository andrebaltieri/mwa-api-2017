using System;
using System.Collections.Generic;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items = new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand
                    {
                        Product =  Guid.NewGuid(),
                        Quantity = 3
                    }
                }
            };

            GenerateOrder(
                new FakeCustomerRepository(),
                new FakeProductRepository(),
                new FakeOrderRepository(),
                command);
            Console.ReadKey();
        }

        public static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {
            var handler = new OrderCommandHandler(
                customerRepository,
                productRepository,
                orderRepository);
            handler.Handle(command);            

            if (handler.IsValid())
                Console.WriteLine("Pedido cadastrado com sucesso!");
        }
    }

    public class FakeProductRepository : IProductRepository
    {
        public Product Get(Guid id)
        {
            return new Product("Mouse", 299, "", 50);
        }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            return null;
        }

        public Customer GetByUserId(Guid id)
        {
            return new Customer(
                new Name("André", "Baltieri"),
                new Email("andrebaltieri@hotmail.com"),
                new Document("72546524135"),
                new User("andrebaltieri", "andrebaltieri")
            );
        }

        public void Update(Customer customer)
        {
            
        }
    }

    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {

        }
    }
}