using System.Collections.Generic;
using System.Linq;
using P1.Data.Models;
using P1.Domain;

#nullable enable

namespace P1.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly P1Context _context;

        public OrderRepository(P1Context context)
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
        public IEnumerable<Order> GetAll()
        {
            // query from DB
            var entities = _context.Orders.ToList();

            // map to domain model
            return entities.Select(e => new Order()
            {
                Id = e.Id,
                OrderDate = e.OrderDate,
                TotalPrice = e.TotalPrice,
                Customer = e.Customer,
                Location = e.Location
            });
        }

        public Order? Get(int? id)
        {
            // query from DB
            var entity = _context.Orders;

            // map to domain model
            var e = entity.First(e => e.Id == id);
            if (e == null)
                return null;
            else
                return new Order()
                {
                    Id = e.Id,
                    OrderDate = e.OrderDate,
                    TotalPrice = e.TotalPrice,
                    Customer = e.Customer,
                    Location = e.Location
                };
        }

        public void Create(Order order)
        {
            // map to EF model
            var entity = new OrderEntity
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
                Location = order.Location,
                CustomerNavigation = _context.Customers.First(a => a.Id == order.Customer),
                LocationNavigation = _context.Locations.First(a => a.Id == order.Location)
            };

            _context.Orders.Add(entity);

            // write changes to DB
            _context.SaveChanges();

        }

        // only support changing stock
        public void Update(Order order)
        {
            // query the DB
            var entity = _context.Orders.First(l => l.Id == order.Id);

            entity.OrderDate = order.OrderDate;
            entity.TotalPrice = order.TotalPrice;
            entity.Customer = order.Customer;
            entity.Location = order.Location;
            entity.CustomerNavigation = _context.Customers.First(a => a.Id == order.Customer);
            entity.LocationNavigation = _context.Locations.First(a => a.Id == order.Location);

            // write changes to DB
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // query the DB
            var entity = _context.Orders.First(x => x.Id == id);

            _context.Remove(entity);

            // write changes to DB
            _context.SaveChanges();
        }
    }
}