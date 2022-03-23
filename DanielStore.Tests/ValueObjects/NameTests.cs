using DanielStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanielStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name validName;
        private Name invalidName;

        public NameTests()
        {
            validName = new Name("", "Martins");
            invalidName = new Name("Daniel", "Martins");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            Assert.AreEqual(false, validName.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsValid()
        {
            Assert.AreEqual(true, invalidName.IsValid);
        }
    }
}
