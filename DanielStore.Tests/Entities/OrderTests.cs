using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.Enums;
using DanielStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanielStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Daniel", "Martins");
            var document = new Document("06507398330");
            var email = new Email("freitasdaniel39@gmail.com");
            _customer = new Customer(name, document, email, "99265-3398");
            _order = new Order(_customer);

            _mouse = new Product("mouse", "razor", "img01.png", 100M, 10);
            _keyboard = new Product("keyboard", "razor", "img02.png", 100M, 10);
            _monitor = new Product("monitor", "lg", "img02.png", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        // Caso de uso: Deve retornar dois quando forem adicionados dois itens válidos
        [TestMethod]
        public void ShouldReturnTwoAddedTwoValidItems()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_keyboard, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchaseFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        // Ao confirmar o pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldReturnTwoShippingWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 5); // 1 
            _order.AddItem(_mouse, 5); // 2
            _order.AddItem(_mouse, 5); // 3
            _order.AddItem(_mouse, 5); // 4
            _order.AddItem(_mouse, 5); // 5
            _order.AddItem(_mouse, 5); // 6
            _order.AddItem(_mouse, 5); // 7
            _order.AddItem(_mouse, 5); // 8
            _order.AddItem(_mouse, 5); // 9
            _order.AddItem(_mouse, 5); // 10
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 5); // 1 
            _order.AddItem(_mouse, 5); // 2
            _order.AddItem(_mouse, 5); // 3
            _order.AddItem(_mouse, 5); // 4
            _order.AddItem(_mouse, 5); // 5
            _order.AddItem(_mouse, 5); // 6
            _order.AddItem(_mouse, 5); // 7
            _order.AddItem(_mouse, 5); // 8
            _order.AddItem(_mouse, 5); // 9
            _order.AddItem(_mouse, 5); // 10
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}
