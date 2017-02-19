using System;
using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.CommandHandlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<UpdateCustomerCommand>,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(UpdateCustomerCommand command)
        {
            // Recuperar o cliente
            var customer = _customerRepository.Get(command.Id);

            // Caso o cliente não existe
            if (customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado");
                return;
            }

            // Atualizar a entidade
            var name = new Name(command.FirstName, command.LastName);
            customer.Update(name, command.BirthDate);

            // Adiciona as notificações
            AddNotifications(customer.Notifications);
            
            // Persistir no banco
            if (customer.IsValid())
                _customerRepository.Update(customer);
        }

        public void Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso!");
                return;
            }

            // Passo 2. Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var customer = new Customer()
            // Passo 3. Inserir no banco
            // Passo 4. Enviar E-mail de boas vindas
        }
    }
}
