using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.Queries;

namespace DanielStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
    }
}
