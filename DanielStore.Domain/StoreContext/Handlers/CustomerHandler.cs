using System;
using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DanielStore.Domain.StoreContext.Entities;
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
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar CPF existente

            // Verificar email existente

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

            // Persistir o cliente

            // Enviar um email de boas vindas

            // Retornar o resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}