using System.Collections.Generic;

#nullable enable

namespace P1.Domain
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order? Get(int? id);

        void Create(Order order);

        void Update(Order order);

        void Delete(int id);
    }
}