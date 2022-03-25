using DanielStore.Domain.Handlers;
using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanielStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Daniel";
            command.LastName = "Martins";
            command.Document = "84438437059";
            command.Email = "daniel@dev.io";
            command.Phone = "992636655";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }
    }
}