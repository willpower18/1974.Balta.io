using BaltaStore.Domain.StoreContext.CustomerComands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerComand();
            command.FirstName = "Wiliam";
            command.LastName = "Paulino";
            command.Document = "90669111074";
            command.Email = "will@email.com";
            command.Phone = "1799999999";

            Assert.AreEqual(true, command.Valid());
        }

    }
}
