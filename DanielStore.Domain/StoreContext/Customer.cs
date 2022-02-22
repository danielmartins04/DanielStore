using System;

namespace DanielStore.Domain.StoreContext
{
    public class Customer
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
    }
}