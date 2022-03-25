using DanielStore.Domain.StoreContext.Services;

namespace DanielStore.Tests
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}