using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.Repositories;

namespace DanielStore.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}