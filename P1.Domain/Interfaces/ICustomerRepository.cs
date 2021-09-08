using System.Collections.Generic;

#nullable enable

namespace P1.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer? Get(int? id);

        void Create(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }
}