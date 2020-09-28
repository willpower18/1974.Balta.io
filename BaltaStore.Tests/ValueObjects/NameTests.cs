using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Paulino");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenNameIsValid()
        {
            var name = new Name("Wiliam", "Paulino");
            Assert.AreEqual(true, name.IsValid);
            Assert.AreEqual(0, name.Notifications.Count);
        }
    }
}
