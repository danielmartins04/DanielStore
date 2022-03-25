using System;
using DanielStore.Shared;

namespace DanielStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(){}

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = Name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}