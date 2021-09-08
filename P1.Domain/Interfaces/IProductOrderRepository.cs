using System.Collections.Generic;

#nullable enable

namespace P1.Domain
{
    public interface IProductOrderRepository
    {
        IEnumerable<ProductOrder> GetAll();

        ProductOrder? Get(int? id);

        void Create(ProductOrder po);

        void Update(ProductOrder po);

        void Delete(int id);
    }
}