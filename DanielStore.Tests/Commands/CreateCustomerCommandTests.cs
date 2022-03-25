using DanielStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanielStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Daniel";
            command.LastName = "Martins";
            command.Document = "06507398330";
            command.Email = "daniel@dev.com";
            command.Phone = "992658945";

            Assert.AreEqual(true, command.Valid());
        }
    }
}