using System.Collections.Generic;
using System.Linq;
using P1.Data.Models;
using P1.Domain;

#nullable enable

namespace P1.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly P1Context _context;

        public LocationRepository(P1Context context)
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
        public IEnumerable<Location> GetAll()
        {
            // query from DB
            var entities = _context.Locations.ToList();

            // map to domain model
            return entities.Select(e => new Location()
            {
                Id = e.Id,
                StoreName = e.StoreName,
                Phone = e.Phone,
                Hours = e.Hours,
                StreetAddress = e.StreetAddress,
                ZipCode = e.ZipCode,
                State = e.State,
                OpeningDate = e.OpeningDate
            });
        }

        public Location? Get(int? id)
        {
            // query from DB
            var entity = _context.Locations;

            // map to domain model
            var e = entity.First(e => e.Id == id);
            if (e == null)
                return null;
            else
                return new Location() {
                    Id = e.Id,
                    StoreName = e.StoreName,
                    Phone = e.Phone,
                    Hours = e.Hours,
                    StreetAddress = e.StreetAddress,
                    ZipCode = e.ZipCode,
                    State = e.State,
                    OpeningDate = e.OpeningDate
                };
            }

        public void Create(Location location)
        {
            // map to EF model
            var entity = new LocationEntity
            {
                Id = location.Id,
                StoreName = location.StoreName,
                Phone = location.Phone, 
                Hours = location.Hours, 
                StreetAddress = location.StreetAddress, 
                ZipCode = location.ZipCode, 
                State = location.State, 
                OpeningDate = location.OpeningDate 
            };

            _context.Locations.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }

        // only support changing stock
        public void Update(Location location)
        {
            // query the DB
            var entity = _context.Locations.First(l => l.Id == location.Id);

            entity.StoreName = location.StoreName;
            entity.Phone = location.Phone;
            entity.Hours = location.Hours;
            entity.StreetAddress = location.StreetAddress;
            entity.ZipCode = location.ZipCode;
            entity.State = location.State;
            entity.OpeningDate = location.OpeningDate;


            // write changes to DB
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // query the DB
            var entity = _context.Locations.First(x => x.Id == id);

            _context.Remove(entity);

            // write changes to DB
            _context.SaveChanges();
        }
    }
}