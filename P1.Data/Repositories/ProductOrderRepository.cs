using System.Collections.Generic;
using System.Linq;
using P1.Data.Models;
using P1.Domain;

#nullable enable

namespace P1.Data
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly P1Context _context;

        public ProductOrderRepository(P1Context context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        // this method's job is to somehow get a collection of locations
        // not location entities. therefore it has to convert from location entities
        // it gets from the dbcontext. (mapping)

        /// <summary>
        /// Get all locations, without order history
        /// </summary>
        /// <returns>The locations</returns>
        /// <remarks>
        /// this method's job is to somehow get a collection of locations
        /// not location entities. therefore it has to convert from location entities
        /// it gets from the dbcontext. (mapping)
        /// </remarks>
        public IEnumerable<ProductOrder> GetAll()
        {
            // query from DB
            var entities = _context.ProductOrders.ToList();

            // map to domain model
            return entities.Select(e => new ProductOrder(e.Id, e.Number, e.Product, e.Order));
        }

        public ProductOrder? Get(int? id)
        {
            // query from DB
            var entity = _context.ProductOrders;

            // map to domain model
            var e = entity.First(e => e.Id == id);
            if (e == null)
                return null;
            else
                return new ProductOrder(e.Id, e.Number, e.Product, e.Order);
        }

        public void Create(ProductOrder po)
        {
            // map to EF model
            var entity = new ProductOrderEntity { Id = po.Id, Number = po.Number, Product = po.Product, Order = po.Order };

            _context.ProductOrders.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }

        // only support changing stock
        public void Update(ProductOrder po)
        {
            // query the DB
            var entity = _context.ProductOrders.First(l => l.Id == po.Id);

            entity.Number = po.Number;
            entity.Product = po.Product;
            entity.Order = po.Order;

            // write changes to DB
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // query the DB
            var entity = _context.ProductOrders.First(x => x.Id == id);

            _context.Remove(entity);

            // write changes to DB
            _context.SaveChanges();
        }
    }
}