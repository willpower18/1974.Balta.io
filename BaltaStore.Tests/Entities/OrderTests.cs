using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        public OrderTests()
        {
            var name = new Name("Wiliam ", "Paulino");
            var document = new Document("43699044807");
            var email = new Email("willjcpower@gmail.com");
            _customer = new Customer(name, document, email, "17992279401");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard Gamer", "Keyboard Gamer", "Keyboard.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "Cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);
        }
        //Consigo Criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        //Ao criar o pedido o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //Ao adicionar novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenPurchasedFiveItems()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        //Ao confirmar pedido, deve retornar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao Pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //Dados mais de 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCarnceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_keyboard, 1);
            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Cenceled, x.Status);
            }
        }
    }
}