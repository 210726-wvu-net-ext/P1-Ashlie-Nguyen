using System.Collections.Generic;

#nullable enable

namespace P1.Domain
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();

        Location? Get(int? id);

        void Create(Location location);

        void Update(Location location);

        void Delete(int id);
    }
}