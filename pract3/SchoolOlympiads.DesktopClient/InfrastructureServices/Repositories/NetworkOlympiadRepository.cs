using SchoolOlympiads.ApplicationServices.Ports.Cache;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolOlympiads.InfrastructureServices.Repositories
{
    public class NetworkOlympiadRepository : NetworkRepositoryBase, IReadOnlyOlympiadRepository
    {
        private readonly IDomainObjectsCache<Olympiad> _olympiadCache;

        public NetworkOlympiadRepository(string host, ushort port, bool useTls, IDomainObjectsCache<Olympiad> olympiadCache)
            : base(host, port, useTls)
            => _olympiadCache = olympiadCache;

        public async Task<Olympiad> GetOlympiad(long id)
            => CacheAndReturn(await ExecuteHttpRequest<Olympiad>($"Olympiads/{id}"));

        public async Task<IEnumerable<Olympiad>> GetAllOlympiads()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Olympiad>>($"Olympiads"), allObjects: true);

        public async Task<IEnumerable<Olympiad>> QueryOlympiads(ICriteria<Olympiad> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Olympiad>>($"Olympiads"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<Olympiad> CacheAndReturn(IEnumerable<Olympiad> olympiads, bool allObjects = false)
        {
            if (allObjects)
            {
                _olympiadCache.ClearCache();
            }
            _olympiadCache.UpdateObjects(olympiads, DateTime.Now.AddDays(1), allObjects);
            return olympiads;
        }

        private Olympiad CacheAndReturn(Olympiad olympiad)
        {
            _olympiadCache.UpdateObject(olympiad, DateTime.Now.AddDays(1));
            return olympiad;
        }
    }
}
