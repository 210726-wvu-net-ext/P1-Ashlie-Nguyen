using System.Collections.Generic;
using System.Linq;
using P1.Data.Models;
using P1.Domain;

#nullable enable

namespace P1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly P1Context _context;

        public ProductRepository(P1Context context)
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
        public IEnumerable<Product> GetAll()
        {
            // query from DB
            var entities = _context.Products.ToList();

            // map to domain model
            return entities.Select(e => new Product(e.Id, e.Name, e.Category, e.ReleaseDate, e.Price));
        }

        public Product? Get(int? id)
        {
            // query from DB
            var entity = _context.Products;

            // map to domain model
            var e = entity.First(e => e.Id == id);
            if (e == null)
                return null;
            else
                return new Product(e.Id, e.Name, e.Category, e.ReleaseDate, e.Price);
        }

        public void Create(Product product)
        {
            // map to EF model
            var entity = new ProductEntity { Id = product.Id, Name = product.Name, Category = product.Category, ReleaseDate = product.ReleaseDate, Price = product.Price };

            _context.Products.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }

        // only support changing stock
        public void Update(Product product)
        {
            // query the DB
            var entity = _context.Products.First(l => l.Id == product.Id);

            entity.Name = product.Name;
            entity.Category = product.Category;
            entity.ReleaseDate = product.ReleaseDate;
            entity.Price = product.Price;

            // write changes to DB
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // query the DB
            var entity = _context.Products.First(x => x.Id == id);

            _context.Remove(entity);

            // write changes to DB
            _context.SaveChanges();
        }
    }
}