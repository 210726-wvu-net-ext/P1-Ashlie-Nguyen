using System.Collections.Generic;

#nullable enable

namespace P1.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? Get(int? id);

        void Create(Product product);

        void Update(Product product);

        void Delete(int id);
    }
}