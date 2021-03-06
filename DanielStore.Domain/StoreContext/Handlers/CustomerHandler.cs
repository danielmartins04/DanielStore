using System;
using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.Repositories;
using DanielStore.Domain.StoreContext.Services;
using DanielStore.Domain.StoreContext.ValueObjects;
using DanielStore.Shared;
using DanielStore.Shared.Commands;
using FluentValidator;

namespace DanielStore.Domain.Handlers
{
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar CPF existente
            if (_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "O Documento já existe.");

            // Verificar email existente
            if (_customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "O Email já existe.");

            // Criar os VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            // Persistir o cliente
            _customerRepository.Save(customer);

            // Enviar um email de boas vindas
            _emailService.Send(email.Address, "daniel@dev.io", "Bem vindo", "Seja bem vindo ao Daniel Store.");

            // Retornar o resultado para a tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}