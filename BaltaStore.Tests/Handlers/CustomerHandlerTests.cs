using BaltaStore.Domain.StoreContext.CustomerComands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerComand();
            command.FirstName = "Wiliam";
            command.LastName = "Paulino";
            command.Document = "90669111074";
            command.Email = "will@email.com";
            command.Phone = "1799999999";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }

    }
}