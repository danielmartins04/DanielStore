using System.Data;
using System.Linq;
using DanielStore.Domain.StoreContext.Entities;
using DanielStore.Domain.StoreContext.Queries;
using DanielStore.Domain.StoreContext.Repositories;
using DanielStore.Infra.StoreContext.DataContexts;
using Dapper;

namespace DanielStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DanielDataContext _context;

        public CustomerRepository(DanielDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstaName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                  Id = address.Id,
                  CustomerId = customer.Id,
                  Number = address.Number,
                  Complement = address.District,
                  City = address.City,
                  State = address.State,
                  Country = address.Country,
                  ZipCode = address.ZipCode,
                  Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}