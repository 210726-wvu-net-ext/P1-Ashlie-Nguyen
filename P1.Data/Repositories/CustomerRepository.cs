using System.Collections.Generic;
using System.Linq;
using P1.Data.Models;
using P1.Domain;

#nullable enable

namespace P1.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly P1Context _context;

        public CustomerRepository(P1Context context)
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
        public IEnumerable<Customer> GetAll()
        {
            // query from DB
            var entities = _context.Customers;

            // map to domain model
            return entities.Select(e => new Customer()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Phone = e.Phone,
                RegistrationDate = e.RegistrationDate
            });
        }

        public Customer? Get(int? id)
        {
            // query from DB
            var entity = _context.Customers;

            // map to domain model
            var e = entity.First(e => e.Id == id);
            if (e == null)
                return null;
            else
                return new Customer()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                    RegistrationDate = e.RegistrationDate
                };
        }

        public void Create(Customer customer)
        {
            // map to EF model
            var entity = new CustomerEntity { 
                Id = customer.Id, 
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                RegistrationDate = customer.RegistrationDate
            };

            _context.Customers.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }

        // only support changing stock
        public void Update(Customer customer)
        {
            // query the DB
            var entity = _context.Customers.First(l => l.Id == customer.Id);

            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Phone = customer.Phone;
            entity.RegistrationDate = customer.RegistrationDate;

            // write changes to DB
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // query the DB
            var entity = _context.Customers.First(x => x.Id == id);

            _context.Remove(entity);

            // write changes to DB
            _context.SaveChanges();
        }
    }
}