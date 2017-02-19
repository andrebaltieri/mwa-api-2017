﻿using System;
using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Services;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso!");
                return null;
            }

            // Passo 2. Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            // Passo 3. Adicionar Notificações
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(user.Notifications);

            // Passo 4. Inserir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            // Passo 5. Enviar E-mail de boas vindas
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name)
                );

            // Passo 6. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
