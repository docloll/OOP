using System;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.ApplicationServices.Ports.Gateways.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolOlympiads.ApplicationServices.Repositories
{
    public class DbOlympiadRepository : IReadOnlyOlympiadRepository,
                                     IOlympiadRepository
    {
        private readonly IOlympiadDatabaseGateway _databaseGateway;

        public DbOlympiadRepository(IOlympiadDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Olympiad> GetOlympiad(long id)
            => await _databaseGateway.GetOlympiad(id);

        public async Task<IEnumerable<Olympiad>> GetAllOlympiads()
            => await _databaseGateway.GetAllOlympiads();

        public async Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria)
            => await _databaseGateway.QueryOlympiads(criteria.Filter);

        public async Task AddOlympiad(Olympiad olympiad)
            => await _databaseGateway.AddOlympiad(olympiad);

        public async Task RemoveOlympiad(Olympiad olympiad)
            => await _databaseGateway.RemoveOlympiad(olympiad);

        public async Task UpdateOlympiad(Olympiad olympiad)
            => await _databaseGateway.UpdateOlympiad(olympiad);
    }
}
