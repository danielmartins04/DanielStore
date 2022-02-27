using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanielStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Daniel", "Martins");
            var document = new Document("12345678911");
            var email = new Email("daniel@gmail.com");

            var c = new Customer(name, document, email, "12345678911");
            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 1);
            var teclado = new Product("Teclado", "Teclado", "image.png", 69.90M, 2);
            var impressora = new Product("Impressora", "Impressora", "image.png", 400.90M, 1);

            var order = new Order(c);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 3));
            order.AddItem(new OrderItem(impressora, 2));

            // Pedido realizado
            order.Place();

            // Simulação do pagamento
            order.Pay();

            // Simulação do envio
            order.Ship();

            // Simulação do cancelamento
            order.Cancel();
        }
    }
}
